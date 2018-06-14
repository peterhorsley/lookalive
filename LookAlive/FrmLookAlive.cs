using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;

namespace LookAlive
{
	public partial class FrmLookAlive : Form
	{
        private bool argumentsParsedOk = true;
		private bool firstUpdate = true;
		private bool notifyOnStateChange = true;
		private bool targetAlive = false;
		private bool pingCompleted = false;
		private string targetAddress = "";
		private string targetLabel = "";
        private int pingPeriodMs = 1000;
        private System.Drawing.SolidBrush colourBrush = null;
		private BackgroundWorker worker = null;
		private FrmPingResults frmPingResults = null;
		private string commandAppFileName = "";
		private string commandAppArgs = "";
		private bool commandHidden = false;
		private string aliveIconPath = "";
		private string deadIconPath = "";

		private Icon aliveIcon;
		private Icon deadIcon;

		/// <summary>
		/// Constructor for a new FrmLookAlive.
		/// </summary>
		/// <param name="args">An array of arguments passed to the program at startup.</param>
		public FrmLookAlive(string[] args)
		{
			InitializeComponent();

            argumentsParsedOk = ParseArgs(args);
			if (argumentsParsedOk)
			{
				if (!LoadIcon(ref aliveIcon, aliveIconPath, "LookAlive.Resources.Alive.ico") ||
					!LoadIcon(ref deadIcon, deadIconPath, "LookAlive.Resources.Dead.ico"))
				{
					argumentsParsedOk = false;
				}
			}

			if (!argumentsParsedOk)
			{
				ShowAboutBox();
			}

			monitorIcon.Icon = deadIcon;
			targetLabel = lblEnterName.Text;
			frmPingResults = new FrmPingResults();

			worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.WorkerSupportsCancellation = true;
			worker.DoWork += MonitorTargetAddress;
			worker.ProgressChanged += Monitor_ProgressChanged;
			worker.RunWorkerCompleted += Monitor_Completed;
		}

		private bool LoadIcon(ref Icon icon, string iconFilePath, string iconResourcePath)
		{
			if (String.IsNullOrEmpty(iconFilePath))
			{
				using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(iconResourcePath))
				{
					icon = new Icon(imageStream);
				}
			}
			else
			{
				try
				{
					icon = new Icon(iconFilePath, new Size(16, 16));
				}
				catch (System.Exception ex)
				{
					MessageBox.Show(String.Format("Error parsing arguments:\n\nError loading icon from '{0}':\n\n{1}", iconFilePath, ex.Message), "Look Alive", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			if (colourBrush != null)
			{
				try
				{
					icon = AddColourId(icon, colourBrush);
				}
				catch (System.Exception)
				{
					MessageBox.Show(String.Format("Unable to add colour to icon '{0}'.\n\nPlease ensure this is a 16x16 icon (or contains a 16x16 icon).", iconFilePath), "Look Alive", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			return true;
		}

        private Icon AddColourId(Icon icon, Brush colour)
        {
            System.Drawing.Bitmap b = icon.ToBitmap();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
            g.FillRectangle(colour, new System.Drawing.Rectangle(12, 0, 4, 4));
            return FlimFlan.IconEncoder.Converter.BitmapToIcon(b);
        }

        /// <summary>
        /// See help.rtf for argument syntax.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool ParseOptionalArg(string arg)
        {
			if (arg.ToLowerInvariant().StartsWith("/upicon="))
			{
				aliveIconPath = arg.Substring(8);
				return true;
			}

			if (arg.ToLowerInvariant().StartsWith("/dnicon="))
			{
				deadIconPath = arg.Substring(8);
				return true;
			}

			if (arg == "/d")
			{
				SetNofityOnStateChange(false);
				return true;
			}

			if (arg.StartsWith("{"))
			{
				if (arg.EndsWith("}"))
				{
					string commandArg = arg.Substring(1, arg.Length - 2);
					if (commandArg.StartsWith("!"))
					{
						commandHidden = true;
						commandArg = commandArg.Substring(1);
					}

					int commandAppFileNameIndex = commandArg.IndexOf(",");
					if (commandAppFileNameIndex > 0)
					{
						commandAppFileName = commandArg.Substring(0, commandAppFileNameIndex);
						commandAppArgs = commandArg.Substring(commandAppFileNameIndex + 1);
					}
					else
					{
						commandAppFileName = commandArg;
					}
					return true;
				}
				else
				{
					MessageBox.Show("Error parsing arguments:\n\nMissing closing brace for command argument.", "Look Alive", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

            int period = 0;
            try
            {
                period = Convert.ToInt32(arg);
            }
            catch (Exception) { }

            if (period >= 1)
            {
                SetPeriod(period);
                return true;
            }

            Color colour = System.Drawing.Color.FromName(arg);
            if (colour.IsKnownColor)
            {
                SetColourId(colour);
                return true;
            }
            else
            {
				MessageBox.Show("Error parsing arguments:\n\nUnrecognised colour name '" + arg + "'.", "Look Alive", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
            }
        }

        private bool ParseArgs(string[] args)
        {
            if (args.Length > 0)
            {
                SetTarget(args[0]);

				for (int argNum = 1; argNum < args.Length; argNum++)
				{
					if (!ParseOptionalArg(args[argNum]))
					{
						return false;
					}
				}
            }

            return true;
        }

		private void EnableMonitoring(bool enable)
		{
			monitorIcon.Visible = enable;
			btnLookAlive.Enabled = txtTargetName.Enabled = txtPingPeriod.Enabled = enable;
			lblEnterName.Text = "Please wait...";
			txtTargetName.Text = targetAddress;
			txtPingPeriod.Text = Convert.ToString(pingPeriodMs / 1000);
			checkNotify.Checked = notifyOnStateChange;
			this.Visible = !monitorIcon.Visible;
			this.ShowInTaskbar = this.Visible;
			this.WindowState = monitorIcon.Visible ? FormWindowState.Minimized : FormWindowState.Normal;

			WaitForWorkerToStop();

			if (enable)
			{
				firstUpdate = true;
				monitorIcon.Text = String.Format("Look Alive - Monitoring '{0}'", targetAddress);

				// First argument is the background worker object itself.
				// This allows the calling function to notify the calling
				// thread of progress changes etc.
				//
				// Use the following code in the worker method:
				//
				//		object[] o = (object[])e.Argument;
				//		BackgroundWorkerEx worker = (BackgroundWorkerEx)o[0];

				object[] parms = { worker };
				worker.RunWorkerAsync(parms);
			}
			else
			{
				lblEnterName.Text = targetLabel;
				btnLookAlive.Enabled = txtTargetName.Enabled = txtPingPeriod.Enabled = true;
				txtTargetName.Focus();
			}
		}

		private void WaitForWorkerToStop()
		{
			while (worker.IsBusy)
			{
				if (!worker.CancellationPending)
				{
					worker.CancelAsync();
				}
				Application.DoEvents();
				Thread.Sleep(100);
			}
		}

		private void btnLookAlive_Click(object sender, EventArgs e)
		{
            int period = 0;
            try
            {
                period = Convert.ToInt32(txtPingPeriod.Text);
            }
            catch (Exception) {}

            if (period >= 1)
            {
                if (txtTargetName.Text.Length > 0)
                {
                    SetPeriod(period);
                    SetTarget(txtTargetName.Text);
					SetNofityOnStateChange(checkNotify.Checked);
                    EnableMonitoring(true);
                }
            }
            else
            {
                MessageBox.Show("Ping period must be a number greater than 0.", "Look Alive", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void SetNofityOnStateChange(bool notify)
		{
			notifyOnStateChange = notify;
		}

		private void SetTarget(string target)
		{
			targetAddress = target;
		}

        private void SetPeriod(int periodSec)
        {
            pingPeriodMs = periodSec * 1000;
        }

        private void SetColourId(Color colour)
        {
            colourBrush = new System.Drawing.SolidBrush(colour);
        }

		private void MonitorTargetAddress(object sender, DoWorkEventArgs e)
		{
			// first argument is the background worker object itself
			object[] o = (object[])e.Argument;
			BackgroundWorker worker = (BackgroundWorker)o[0];

			Ping ping = new Ping();
			ping.PingCompleted += new PingCompletedEventHandler(ping_PingCompleted);

			while (!worker.CancellationPending)
			{
				pingCompleted = false;
				try
				{
					ping.SendAsync(targetAddress, worker);
				}
				catch (Exception ex)
				{
					if (ex.InnerException != null)
					{
						worker.ReportProgress(0, new PingResult(ex.InnerException.Message));
					}
					else
					{
						worker.ReportProgress(0, new PingResult(ex.Message));
					}
				}

				bool pingCancelled = false;

				while (!pingCompleted)
				{
					if (worker.CancellationPending && !pingCancelled)
					{
						ping.SendAsyncCancel();
						pingCancelled = true;
					}

					Thread.Sleep(100);
				}

				for (int slice = 0; slice < pingPeriodMs / 100; slice++)
				{
					if (worker.CancellationPending)
					{
						break;
					}

					Thread.Sleep(100);
				}
            }
		}

		void ping_PingCompleted(object sender, PingCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				BackgroundWorker worker = (BackgroundWorker)e.UserState;

				if (e.Error != null)
				{
					if (e.Error.InnerException != null)
					{
						worker.ReportProgress(0, new PingResult(e.Error.InnerException.Message));
					}
					else
					{
						worker.ReportProgress(0, new PingResult(e.Error.Message));
					}
				}
				else
				{
					worker.ReportProgress(0, new PingResult((e.Reply.Status == IPStatus.Success), (int)e.Reply.RoundtripTime));
				}
			}

			pingCompleted = true;
		}

		private void Monitor_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
            PingResult result = (PingResult)e.UserState;

            if (String.IsNullOrEmpty(result.PingError))
            {
                if (result.IsAlive)
                {
                    frmPingResults.AddText(String.Format("[{0}] Replied in {1} ms.", targetAddress, result.ResponseTimeMs));
                }
                else
                {
                    frmPingResults.AddText(String.Format("[{0}] Request timed out.", targetAddress));
                }
            }
            else
            {
                frmPingResults.AddText(String.Format("[{0}] Error: {1}", targetAddress, result.PingError));
            }

			RunStateChangeCommand(result.IsAlive);
            UpdateMonitorIcon(result.IsAlive);
			
		}

		private void RunStateChangeCommand(bool targetNowAlive)
		{
			if (commandAppFileName.Length > 0)
			{
				if (this.targetAlive != targetNowAlive || firstUpdate)
				{
					ProcessStartInfo psi;

					string fileName = SubstituteFields(commandAppFileName, targetNowAlive);
					if (commandAppArgs.Length > 0)
					{
						string arguments = SubstituteFields(commandAppArgs, targetNowAlive);
						psi = new ProcessStartInfo(fileName, arguments);
					}
					else
					{
						psi = new ProcessStartInfo(fileName);
					}

					if (commandHidden)
					{
						psi.CreateNoWindow = true;
						psi.WindowStyle = ProcessWindowStyle.Hidden;
					}

					Process.Start(psi);
				}
			}
		}

		private string SubstituteFields(string sourceString, bool targetNowAlive)
		{
			return sourceString.Replace("{hostname_ip}", targetAddress)
				.Replace("{state}", targetNowAlive ? "online" : "offline")
				.Replace("{time}", DateTime.Now.ToString());
		}

		private void Monitor_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			// nothing to do here
		}

		private void UpdateMonitorIcon(bool targetNowAlive)
		{
			if (this.targetAlive != targetNowAlive || firstUpdate)
			{
				monitorIcon.Icon = targetNowAlive ? aliveIcon : deadIcon;
				if (!firstUpdate && notifyOnStateChange)
				{
					monitorIcon.ShowBalloonTip(10000, "Look Alive", String.Format("Host '{0}' is {1}.", this.targetAddress, targetNowAlive ? "online" : "offline"), ToolTipIcon.Info);
				}
				this.targetAlive = targetNowAlive;
				firstUpdate = false;
			}
		}

		private void FrmLookAlive_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnLookAlive.PerformClick();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			monitorIcon.Visible = false;
			frmPingResults.Exit();
			WaitForWorkerToStop();
			this.Close();
		}

		private void txtTargetName_TextChanged(object sender, EventArgs e)
		{
			btnLookAlive.Enabled = (txtTargetName.Text.Length > 0);
		}

		private void FrmLookAlive_Load(object sender, EventArgs e)
		{
            if (argumentsParsedOk && targetAddress.Length > 0)
			{
				EnableMonitoring(true);
			}

			Program.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
		}

		private void changeTargetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EnableMonitoring(false);
		}

		private void responseTimeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmPingResults.Show();
			frmPingResults.Activate();
		}

		private void monitorIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				responseTimeToolStripMenuItem.PerformClick();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
            ShowAboutBox();
        }

        private void ShowAboutBox()
        {
			using (FrmAbout frmAbout = new FrmAbout())
			{
				frmAbout.ShowDialog();
			}
		}

		private void FrmLookAlive_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (worker.IsBusy)
			{
				monitorIcon.Visible = false;
				worker.CancelAsync();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			ShowAboutBox();
		}
	}
}