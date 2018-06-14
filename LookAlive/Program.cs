using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LookAlive
{
	static class Program
	{
		[DllImport("kernel32.dll")]
		internal static extern bool SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmLookAlive(args));
		}
	}
}