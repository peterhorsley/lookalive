using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LookAlive
{
	public partial class FrmPingResults : Form
	{
		private bool programExiting = false;
		private readonly int maxResultLines = 100;

		private const int WM_QUERYENDSESSION = 0x0011;

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WM_QUERYENDSESSION)
			{
				programExiting = true;
			}

			// If this is WM_QUERYENDSESSION, the closing event should be
			// raised in the base WndProc.
			base.WndProc(ref m);
		}

		public FrmPingResults()
		{
			InitializeComponent();
		}

		public void Exit()
		{
			programExiting = true;
			Close();
		}

        public void AddText(string newText)
        {
			if (txtResults.Text.Length > 0)
			{
				txtResults.Text += Environment.NewLine;
			}

			string[] resultLines = txtResults.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
			if (resultLines.Length >= maxResultLines)
			{
				txtResults.Text = txtResults.Text.Substring(txtResults.Text.IndexOf(Environment.NewLine) + 2);
			}

            txtResults.Text += newText;
			txtResults.SelectionStart = txtResults.Text.Length;
			txtResults.ScrollToCaret();
		}

		private void FrmPingResults_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!programExiting)
			{
				e.Cancel = true;
				Hide();
			}
		}
	}
}