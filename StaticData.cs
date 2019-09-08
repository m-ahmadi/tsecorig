// Decompiled with JetBrains decompiler
// Type: TseClient.StaticData
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TseClient.Properties;

namespace TseClient {
	public class StaticData {
		public static string Language;
		public static List<ColumnInfo> ColumnsInfo;
		public static List<InstrumentInfo> Instruments;
		public static List<string> SelectedInstruments;
		public static string Version;
		public static List<TseShareInfo> TseShares;

		public static void FillStaticData() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			StaticData.Language = settings.Language;
			StaticData.ColumnsInfo = FileService.ColumnsInfo();
			StaticData.Instruments = FileService.Instruments();
			StaticData.TseShares = FileService.TseShares();
			StaticData.SelectedInstruments = FileService.SelectedInstruments();
			StaticData.Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
		}
	}
}
