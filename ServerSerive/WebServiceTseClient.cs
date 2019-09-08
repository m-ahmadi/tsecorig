// Decompiled with JetBrains decompiler
// Type: TseClient.ServerSerive.WebServiceTseClient
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using TseClient.Properties;

namespace TseClient.ServerSerive {
	[WebServiceBinding(Name = "WebServiceTseClientSoap", Namespace = "http://tsetmc.com/")]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "4.0.30319.1")]
	[DebuggerStepThrough]
	public class WebServiceTseClient : SoapHttpClientProtocol {
		private SendOrPostCallback LastPossibleDevenOperationCompleted;
		private SendOrPostCallback InstrumentOperationCompleted;
		private SendOrPostCallback DecompressAndGetInsturmentClosingPriceOperationCompleted;
		private SendOrPostCallback LogErrorOperationCompleted;
		private SendOrPostCallback InstrumentAndShareOperationCompleted;
		private bool useDefaultCredentialsSetExplicitly;

		public WebServiceTseClient() {
			this.Url = Settings.Default.TseClient_ServerSerive_TseClient;
			if (this.IsLocalFileSystemWebService(this.Url)) {
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			} else
				this.useDefaultCredentialsSetExplicitly = true;
		}

		public new string Url {
			get {
				return base.Url;
			}
			set {
				if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
					base.UseDefaultCredentials = false;
				base.Url = value;
			}
		}

		public new bool UseDefaultCredentials {
			get {
				return base.UseDefaultCredentials;
			}
			set {
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		public event LastPossibleDevenCompletedEventHandler LastPossibleDevenCompleted;

		public event InstrumentCompletedEventHandler InstrumentCompleted;

		public event DecompressAndGetInsturmentClosingPriceCompletedEventHandler DecompressAndGetInsturmentClosingPriceCompleted;

		public event LogErrorCompletedEventHandler LogErrorCompleted;

		public event InstrumentAndShareCompletedEventHandler InstrumentAndShareCompleted;

		[SoapDocumentMethod("http://tsetmc.com/LastPossibleDeven", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tsetmc.com/", ResponseNamespace = "http://tsetmc.com/", Use = SoapBindingUse.Literal)]
		public string LastPossibleDeven() {
			return (string)this.Invoke(nameof(LastPossibleDeven), new object[0])[0];
		}

		public void LastPossibleDevenAsync() {
			this.LastPossibleDevenAsync((object)null);
		}

		public void LastPossibleDevenAsync(object userState) {
			if (this.LastPossibleDevenOperationCompleted == null)
				this.LastPossibleDevenOperationCompleted = new SendOrPostCallback(this.OnLastPossibleDevenOperationCompleted);
			this.InvokeAsync("LastPossibleDeven", new object[0], this.LastPossibleDevenOperationCompleted, userState);
		}

		private void OnLastPossibleDevenOperationCompleted(object arg) {
			if (this.LastPossibleDevenCompleted == null)
				return;
			InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs)arg;
			this.LastPossibleDevenCompleted((object)this, new LastPossibleDevenCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
		}

		[SoapDocumentMethod("http://tsetmc.com/Instrument", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tsetmc.com/", ResponseNamespace = "http://tsetmc.com/", Use = SoapBindingUse.Literal)]
		public string Instrument(int DEven) {
			return (string)this.Invoke(nameof(Instrument), new object[1]
			{
				(object) DEven
			})[0];
		}

		public void InstrumentAsync(int DEven) {
			this.InstrumentAsync(DEven, (object)null);
		}

		public void InstrumentAsync(int DEven, object userState) {
			if (this.InstrumentOperationCompleted == null)
				this.InstrumentOperationCompleted = new SendOrPostCallback(this.OnInstrumentOperationCompleted);
			this.InvokeAsync("Instrument", new object[1]
			{
				(object) DEven
			}, this.InstrumentOperationCompleted, userState);
		}

		private void OnInstrumentOperationCompleted(object arg) {
			if (this.InstrumentCompleted == null)
				return;
			InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs)arg;
			this.InstrumentCompleted((object)this, new InstrumentCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
		}

		[SoapDocumentMethod("http://tsetmc.com/DecompressAndGetInsturmentClosingPrice", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tsetmc.com/", ResponseNamespace = "http://tsetmc.com/", Use = SoapBindingUse.Literal)]
		public string DecompressAndGetInsturmentClosingPrice(string insCodes) {
			return (string)this.Invoke(nameof(DecompressAndGetInsturmentClosingPrice), new object[1]
			{
				(object) insCodes
			})[0];
		}

		public void DecompressAndGetInsturmentClosingPriceAsync(string insCodes) {
			this.DecompressAndGetInsturmentClosingPriceAsync(insCodes, (object)null);
		}

		public void DecompressAndGetInsturmentClosingPriceAsync(string insCodes, object userState) {
			if (this.DecompressAndGetInsturmentClosingPriceOperationCompleted == null)
				this.DecompressAndGetInsturmentClosingPriceOperationCompleted = new SendOrPostCallback(this.OnDecompressAndGetInsturmentClosingPriceOperationCompleted);
			this.InvokeAsync("DecompressAndGetInsturmentClosingPrice", new object[1]
			{
				(object) insCodes
			}, this.DecompressAndGetInsturmentClosingPriceOperationCompleted, userState);
		}

		private void OnDecompressAndGetInsturmentClosingPriceOperationCompleted(object arg) {
			if (this.DecompressAndGetInsturmentClosingPriceCompleted == null)
				return;
			InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs)arg;
			this.DecompressAndGetInsturmentClosingPriceCompleted((object)this, new DecompressAndGetInsturmentClosingPriceCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
		}

		[SoapDocumentMethod("http://tsetmc.com/LogError", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tsetmc.com/", ResponseNamespace = "http://tsetmc.com/", Use = SoapBindingUse.Literal)]
		public string LogError(string errorMessage) {
			return (string)this.Invoke(nameof(LogError), new object[1]
			{
				(object) errorMessage
			})[0];
		}

		public void LogErrorAsync(string errorMessage) {
			this.LogErrorAsync(errorMessage, (object)null);
		}

		public void LogErrorAsync(string errorMessage, object userState) {
			if (this.LogErrorOperationCompleted == null)
				this.LogErrorOperationCompleted = new SendOrPostCallback(this.OnLogErrorOperationCompleted);
			this.InvokeAsync("LogError", new object[1]
			{
				(object) errorMessage
			}, this.LogErrorOperationCompleted, userState);
		}

		private void OnLogErrorOperationCompleted(object arg) {
			if (this.LogErrorCompleted == null)
				return;
			InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs)arg;
			this.LogErrorCompleted((object)this, new LogErrorCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
		}

		[SoapDocumentMethod("http://tsetmc.com/InstrumentAndShare", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tsetmc.com/", ResponseNamespace = "http://tsetmc.com/", Use = SoapBindingUse.Literal)]
		public string InstrumentAndShare(int DEven, long LastID) {
			return (string)this.Invoke(nameof(InstrumentAndShare), new object[2]
			{
				(object) DEven,
				(object) LastID
			})[0];
		}

		public void InstrumentAndShareAsync(int DEven, long LastID) {
			this.InstrumentAndShareAsync(DEven, LastID, (object)null);
		}

		public void InstrumentAndShareAsync(int DEven, long LastID, object userState) {
			if (this.InstrumentAndShareOperationCompleted == null)
				this.InstrumentAndShareOperationCompleted = new SendOrPostCallback(this.OnInstrumentAndShareOperationCompleted);
			this.InvokeAsync("InstrumentAndShare", new object[2]
			{
				(object) DEven,
				(object) LastID
			}, this.InstrumentAndShareOperationCompleted, userState);
		}

		private void OnInstrumentAndShareOperationCompleted(object arg) {
			if (this.InstrumentAndShareCompleted == null)
				return;
			InvokeCompletedEventArgs completedEventArgs = (InvokeCompletedEventArgs)arg;
			this.InstrumentAndShareCompleted((object)this, new InstrumentAndShareCompletedEventArgs(completedEventArgs.Results, completedEventArgs.Error, completedEventArgs.Cancelled, completedEventArgs.UserState));
		}

		public new void CancelAsync(object userState) {
			base.CancelAsync(userState);
		}

		private bool IsLocalFileSystemWebService(string url) {
			if (url == null || url == string.Empty)
				return false;
			Uri uri = new Uri(url);
			return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
		}
	}
}
