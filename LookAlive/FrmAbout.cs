using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LookAlive
{
	public partial class FrmAbout : Form
	{
		public FrmAbout()
		{
			InitializeComponent();

			using (Stream helpStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LookAlive.Resources.help.rtf"))
			{
				helpText.LoadFile(helpStream, RichTextBoxStreamType.RichText);
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkLabel1.Tag.ToString());
		}
	}
}