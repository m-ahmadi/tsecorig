// Decompiled with JetBrains decompiler
// Type: TseClient.Program
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TseClient {
	internal static class Program {
		private const int ATTACH_PARENT_PROCESS = -1;

		[DllImport("kernel32.dll")]
		private static extern bool AttachConsole(int dwProcessId);

		[STAThread]
		private static void Main(string[] args) {
			Program.AttachConsole(-1);
			if (args.Length == 0) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run((Form)new MainForm());
			} else if (args[0].ToLower().Equals("fast"))
				new SilentExecuter().Execute();
			else
				Console.WriteLine("\nInvalid parameter");
		}
	}
}
