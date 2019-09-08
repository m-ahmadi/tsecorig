// Decompiled with JetBrains decompiler
// Type: TseClient.Properties.Settings
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TseClient.Properties {
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase {
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

		public static Settings Default {
			get {
				return Settings.defaultInstance;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("Persian")]
		[UserScopedSetting]
		public string Language {
			get {
				return (string)this[nameof(Language)];
			}
			set {
				this[nameof(Language)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ExportDaysWithoutTrade {
			get {
				return (bool)this[nameof(ExportDaysWithoutTrade)];
			}
			set {
				this[nameof(ExportDaysWithoutTrade)] = (object)value;
			}
		}

		[DefaultSettingValue("True")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public bool ShowHeaders {
			get {
				return (bool)this[nameof(ShowHeaders)];
			}
			set {
				this[nameof(ShowHeaders)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string StorageLocation {
			get {
				return (string)this[nameof(StorageLocation)];
			}
			set {
				this[nameof(StorageLocation)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		[UserScopedSetting]
		public string FileName {
			get {
				return (string)this[nameof(FileName)];
			}
			set {
				this[nameof(FileName)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("csv")]
		public string FileExtension {
			get {
				return (string)this[nameof(FileExtension)];
			}
			set {
				this[nameof(FileExtension)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		[UserScopedSetting]
		public string Encoding {
			get {
				return (string)this[nameof(Encoding)];
			}
			set {
				this[nameof(Encoding)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue(",")]
		[UserScopedSetting]
		public char Delimeter {
			get {
				return (char)this[nameof(Delimeter)];
			}
			set {
				this[nameof(Delimeter)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("1380/01/01")]
		[UserScopedSetting]
		public string StartDate {
			get {
				return (string)this[nameof(StartDate)];
			}
			set {
				this[nameof(StartDate)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool UseProxy {
			get {
				return (bool)this[nameof(UseProxy)];
			}
			set {
				this[nameof(UseProxy)] = (object)value;
			}
		}

		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string IP {
			get {
				return (string)this[nameof(IP)];
			}
			set {
				this[nameof(IP)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string Port {
			get {
				return (string)this[nameof(Port)];
			}
			set {
				this[nameof(Port)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string UserName {
			get {
				return (string)this[nameof(UserName)];
			}
			set {
				this[nameof(UserName)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Password {
			get {
				return (string)this[nameof(Password)];
			}
			set {
				this[nameof(Password)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool AutomaticOpenFolder {
			get {
				return (bool)this[nameof(AutomaticOpenFolder)];
			}
			set {
				this[nameof(AutomaticOpenFolder)] = (object)value;
			}
		}

		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool RemoveOldFiles {
			get {
				return (bool)this[nameof(RemoveOldFiles)];
			}
			set {
				this[nameof(RemoveOldFiles)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		public bool ExcelOutput {
			get {
				return (bool)this[nameof(ExcelOutput)];
			}
			set {
				this[nameof(ExcelOutput)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DefaultSettingValue("0")]
		[DebuggerNonUserCode]
		public int LastInstrumentReceiveDate {
			get {
				return (int)this[nameof(LastInstrumentReceiveDate)];
			}
			set {
				this[nameof(LastInstrumentReceiveDate)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DefaultSettingValue("True")]
		[DebuggerNonUserCode]
		public bool EnableDecompression {
			get {
				return (bool)this[nameof(EnableDecompression)];
			}
			set {
				this[nameof(EnableDecompression)] = (object)value;
			}
		}

		[ApplicationScopedSetting]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		[DefaultSettingValue("http://service.tsetmc.com/WebService/TseClient.asmx")]
		[DebuggerNonUserCode]
		public string TseClient_ServerSerive_TseClient {
			get {
				return (string)this[nameof(TseClient_ServerSerive_TseClient)];
			}
		}

		[DefaultSettingValue("http://service.tsetmc.com/tsev2/data/TseClient2.aspx")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string TseClientServerUrl {
			get {
				return (string)this[nameof(TseClientServerUrl)];
			}
			set {
				this[nameof(TseClientServerUrl)] = (object)value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool UseWebService {
			get {
				return (bool)this[nameof(UseWebService)];
			}
			set {
				this[nameof(UseWebService)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool AdjustPrices {
			get {
				return (bool)this[nameof(AdjustPrices)];
			}
			set {
				this[nameof(AdjustPrices)] = (object)value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string AdjustedStorageLocation {
			get {
				return (string)this[nameof(AdjustedStorageLocation)];
			}
			set {
				this[nameof(AdjustedStorageLocation)] = (object)value;
			}
		}

		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool AdjustPricesOnShareIncrement {
			get {
				return (bool)this[nameof(AdjustPricesOnShareIncrement)];
			}
			set {
				this[nameof(AdjustPricesOnShareIncrement)] = (object)value;
			}
		}

		[DefaultSettingValue("0")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public int AdjustPricesCondition {
			get {
				return (int)this[nameof(AdjustPricesCondition)];
			}
			set {
				this[nameof(AdjustPricesCondition)] = (object)value;
			}
		}
	}
}
