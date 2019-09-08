// Decompiled with JetBrains decompiler
// Type: TseClient.ServerMethods
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.IO;
using System.Net;
using TseClient.Properties;
using TseClient.ServerSerive;

namespace TseClient {
	public class ServerMethods {
		public static string LogError(string section, Exception ex) {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			bool useWebService1 = settings.UseWebService;
			try {
				return ServerMethods.LogError(section, ex, useWebService1);
			} catch {
				bool useWebService2 = !useWebService1;
				settings.UseWebService = useWebService2;
				settings.Save();
				try {
					return ServerMethods.LogError(section, ex, useWebService2);
				} catch {
					return section.Equals("Instrument") ? " IP کامپیوتر شما :  نامشخص " : "\n\tثبت خطا در سرور ناموفق بود";
				}
			}
		}

		public static string LogError(string section, Exception ex, bool useWebService) {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (useWebService) {
					using (WebServiceTseClient serviceTseClient = new WebServiceTseClient())
						return serviceTseClient.LogError("[ " + section + " (" + StaticData.Version + ") (compression:" + settings.EnableDecompression.ToString() + ". UseWebService:" + settings.UseWebService.ToString() + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")");
				} else {
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(settings.TseClientServerUrl + "?t=LogError&a=[ " + section + " (" + StaticData.Version + ") (compression:" + settings.EnableDecompression.ToString() + "). UseWebService:" + settings.UseWebService.ToString() + " ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")");
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string end = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					response.Close();
					return " IP کامپیوتر شما : " + end;
				}
			} catch {
				throw;
			}
		}

		public static string Instrument(int lastDEven) {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			bool useWebService1 = settings.UseWebService;
			try {
				return ServerMethods.Instrument(lastDEven, useWebService1);
			} catch {
				bool useWebService2 = !useWebService1;
				settings.UseWebService = useWebService2;
				settings.Save();
				try {
					return ServerMethods.Instrument(lastDEven, useWebService2);
				} catch (Exception ex) {
					throw ex;
				}
			}
		}

		public static string Instrument(int lastDEven, bool useWebService) {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (useWebService) {
					using (WebServiceTseClient serviceTseClient = new WebServiceTseClient()) {
						serviceTseClient.EnableDecompression = settings.EnableDecompression;
						return serviceTseClient.Instrument(lastDEven);
					}
				} else {
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(settings.TseClientServerUrl + "?t=Instrument&a=" + (object)lastDEven);
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string end = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					response.Close();
					return end;
				}
			} catch {
				throw;
			}
		}

		public static string LastPossibleDeven() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			bool useWebService1 = settings.UseWebService;
			try {
				return ServerMethods.LastPossibleDeven(useWebService1);
			} catch {
				bool useWebService2 = !useWebService1;
				settings.UseWebService = useWebService2;
				settings.Save();
				try {
					return ServerMethods.LastPossibleDeven(useWebService2);
				} catch (Exception ex) {
					throw ex;
				}
			}
		}

		public static string LastPossibleDeven(bool useWebService) {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (useWebService) {
					using (WebServiceTseClient serviceTseClient = new WebServiceTseClient()) {
						serviceTseClient.EnableDecompression = settings.EnableDecompression;
						return serviceTseClient.LastPossibleDeven();
					}
				} else {
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(settings.TseClientServerUrl + "?t=LastPossibleDeven");
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string end = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					response.Close();
					return end;
				}
			} catch {
				throw;
			}
		}

		public static string GetInsturmentClosingPrice(string insCodes) {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			bool useWebService1 = settings.UseWebService;
			try {
				return ServerMethods.GetInsturmentClosingPrice(insCodes, useWebService1);
			} catch {
				bool useWebService2 = !useWebService1;
				settings.UseWebService = useWebService2;
				settings.Save();
				try {
					return ServerMethods.GetInsturmentClosingPrice(insCodes, useWebService2);
				} catch (Exception ex) {
					throw ex;
				}
			}
		}

		public static string GetInsturmentClosingPrice(string insCodes, bool useWebService) {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (useWebService) {
					using (WebServiceTseClient serviceTseClient = new WebServiceTseClient()) {
						serviceTseClient.EnableDecompression = settings.EnableDecompression;
						string insCodes1 = Utility.Compress(insCodes);
						return serviceTseClient.DecompressAndGetInsturmentClosingPrice(insCodes1);
					}
				} else {
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(settings.TseClientServerUrl + "?t=ClosingPrices&a=" + insCodes);
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string end = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					response.Close();
					return end;
				}
			} catch {
				throw;
			}
		}

		public static string InstrumentAndShare(int lastDEven, long lastId) {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			bool useWebService1 = settings.UseWebService;
			try {
				return ServerMethods.InstrumentAndShare(lastDEven, lastId, useWebService1);
			} catch {
				bool useWebService2 = !useWebService1;
				settings.UseWebService = useWebService2;
				settings.Save();
				try {
					return ServerMethods.InstrumentAndShare(lastDEven, lastId, useWebService2);
				} catch (Exception ex) {
					throw ex;
				}
			}
		}

		public static string InstrumentAndShare(int lastDEven, long lastId, bool useWebService) {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (useWebService) {
					using (WebServiceTseClient serviceTseClient = new WebServiceTseClient()) {
						serviceTseClient.EnableDecompression = settings.EnableDecompression;
						return serviceTseClient.InstrumentAndShare(lastDEven, lastId);
					}
				} else {
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(settings.TseClientServerUrl + "?t=InstrumentAndShare&a=" + (object)lastDEven + "&a2=" + (object)lastId);
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string end = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					response.Close();
					return end;
				}
			} catch {
				throw;
			}
		}
	}
}
