using System;
using System.Windows.Forms;

namespace gstreamerplayer
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			
			// ---- WinForms Başlat ----
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}

