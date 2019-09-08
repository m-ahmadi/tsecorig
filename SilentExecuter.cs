// Decompiled with JetBrains decompiler
// Type: TseClient.SilentExecuter
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient {
	public class SilentExecuter {
		public void Execute() {
			UCStepInstruments ucStepInstruments = new UCStepInstruments();
			UCStepUpdate ucStepUpdate = new UCStepUpdate();
			StaticData.FillStaticData();
			if (!ucStepInstruments.UpdateInstruments())
				Console.WriteLine("Updating instruments info failed. Operation will continue with existing informations.");
			if (!ucStepUpdate.UpdateClosingPrices())
				Console.WriteLine("Updating prices info failed. Operation will continue with existing informations.");
			if (ucStepUpdate.GnerateFiles())
				return;
			Console.WriteLine("Generating files failed.");
		}

		private bool UpdateInstruments() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			if (Utility.ConvertDateTimeToGregorianInt(DateTime.Now) == settings.LastInstrumentReceiveDate)
				return true;
			try {
				int lastDEven = 0;
				foreach (InstrumentInfo instrument in StaticData.Instruments) {
					if (instrument.DEven > lastDEven)
						lastDEven = instrument.DEven;
				}
				long lastId = 0;
				foreach (TseShareInfo tseShare in StaticData.TseShares) {
					if (tseShare.Idn > lastId)
						lastId = tseShare.Idn;
				}
				Application.DoEvents();
				string str1 = ServerMethods.InstrumentAndShare(lastDEven, lastId);
				string str2 = str1.Split('@')[0];
				if (!string.IsNullOrEmpty(str2)) {
					if (str2.Equals("*")) {
						int num = (int)MessageBox.Show("بروز رسانی اطلاعات در حد فاصل ساعت هشت صبح تا یک بعد از ظهر روزهای شنبه تا چهارشنبه امکان پذیر نمی باشد. \nجهت مشاهده لیست فعلی نمادها روی دکمه مرحله بعد کلیک کنید.");
						return false;
					}
					string str3 = str2;
					char[] chArray = new char[1] { ';' };
					foreach (string str4 in str3.Split(chArray)) {
						string[] row = str4.Split(',');
						int index = StaticData.Instruments.FindIndex((Predicate<InstrumentInfo>)(p => p.InsCode == Convert.ToInt64(row[0])));
						if (index < 0) {
							StaticData.Instruments.Add(new InstrumentInfo() {
								InsCode = Convert.ToInt64(row[0].ToString()),
								InstrumentID = row[1].ToString(),
								LatinSymbol = row[2].ToString(),
								LatinName = row[3].ToString(),
								CompanyCode = row[4].ToString(),
								Symbol = row[5].ToString(),
								Name = row[6].ToString(),
								CIsin = row[7].ToString(),
								DEven = Convert.ToInt32(row[8].ToString()),
								Flow = Convert.ToByte(row[9].ToString()),
								LSoc30 = row[10].ToString(),
								CGdSVal = row[11].ToString(),
								CGrValCot = row[12].ToString(),
								YMarNSC = row[13].ToString(),
								CComVal = row[14].ToString(),
								CSecVal = row[15].ToString(),
								CSoSecVal = row[16].ToString(),
								YVal = row[17].ToString()
							});
						} else {
							StaticData.Instruments[index].InstrumentID = row[1].ToString();
							StaticData.Instruments[index].LatinSymbol = row[2].ToString();
							StaticData.Instruments[index].LatinName = row[3].ToString();
							StaticData.Instruments[index].CompanyCode = row[4].ToString();
							StaticData.Instruments[index].Symbol = row[5].ToString();
							StaticData.Instruments[index].Name = row[6].ToString();
							StaticData.Instruments[index].CIsin = row[7].ToString();
							StaticData.Instruments[index].DEven = Convert.ToInt32(row[8].ToString());
							StaticData.Instruments[index].Flow = Convert.ToByte(row[9].ToString());
							StaticData.Instruments[index].LSoc30 = row[10].ToString();
							StaticData.Instruments[index].CGdSVal = row[11].ToString();
							StaticData.Instruments[index].CGrValCot = row[12].ToString();
							StaticData.Instruments[index].YMarNSC = row[13].ToString();
							StaticData.Instruments[index].CComVal = row[14].ToString();
							StaticData.Instruments[index].CSecVal = row[15].ToString();
							StaticData.Instruments[index].CSoSecVal = row[16].ToString();
							StaticData.Instruments[index].YVal = row[17].ToString();
						}
					}
					FileService.WriteInstruments();
					settings.LastInstrumentReceiveDate = Utility.ConvertDateTimeToGregorianInt(DateTime.Now);
					settings.Save();
				}
				string str5 = str1.Split('@')[1];
				if (!string.IsNullOrEmpty(str5)) {
					string str3 = str5;
					char[] chArray = new char[1] { ';' };
					foreach (string str4 in str3.Split(chArray)) {
						string[] row = str4.Split(',');
						int index = StaticData.TseShares.FindIndex((Predicate<TseShareInfo>)(p => p.Idn == Convert.ToInt64(row[0])));
						if (index < 0) {
							StaticData.TseShares.Add(new TseShareInfo() {
								Idn = Convert.ToInt64(row[0].ToString()),
								InsCode = Convert.ToInt64(row[1].ToString()),
								DEven = Convert.ToInt32(row[2].ToString()),
								NumberOfShareNew = Convert.ToDecimal(row[3].ToString()),
								NumberOfShareOld = Convert.ToDecimal(row[4].ToString())
							});
						} else {
							StaticData.TseShares[index].InsCode = Convert.ToInt64(row[1].ToString());
							StaticData.TseShares[index].DEven = Convert.ToInt32(row[2].ToString());
							StaticData.TseShares[index].NumberOfShareNew = Convert.ToDecimal(row[3].ToString());
							StaticData.TseShares[index].NumberOfShareOld = Convert.ToDecimal(row[4].ToString());
						}
					}
					FileService.WriteTseShares();
				}
				return true;
			} catch (Exception ex) {
				if (ex.Message.Contains("The magic number in GZip header is not correct")) {
					if (settings.EnableDecompression) {
						settings.EnableDecompression = false;
						settings.Save();
						return false;
					}
				}
				try {
					if (FileService.LogErrorFile("[ Instrument (" + StaticData.Version + ") (compression:" + settings.EnableDecompression.ToString() + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1) {
						int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
					}
				} catch {
				}
				return false;
			}
		}

		private bool UpdateClosingPrices() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			try {
				string str1 = "";
				try {
					str1 = ServerMethods.LastPossibleDeven();
				} catch (Exception ex) {
					ServerMethods.LogError("lastPossibleDEvens", ex);
				}
				string[] strArray1 = str1.Split(';');
				int int32_1 = Convert.ToInt32(strArray1[0]);
				int int32_2 = Convert.ToInt32(strArray1[1]);
				long[][] numArray1 = new long[StaticData.SelectedInstruments.Count][];
				int index1 = 0;
				using (List<string>.Enumerator enumerator = StaticData.SelectedInstruments.GetEnumerator()) {
					while (enumerator.MoveNext()) {
						string item = enumerator.Current;
						int num = FileService.LastDeven(item);
						InstrumentInfo instrumentInfo = StaticData.Instruments.Find((Predicate<InstrumentInfo>)(p => p.InsCode == Convert.ToInt64(item)));
						if ((!(instrumentInfo.YMarNSC == "NO") || num != int32_1) && (!(instrumentInfo.YMarNSC == "ID") || num != int32_2)) {
							numArray1[index1] = new long[3];
							numArray1[index1][0] = Convert.ToInt64(item);
							numArray1[index1][1] = Convert.ToInt64(num);
							numArray1[index1][2] = instrumentInfo.YMarNSC == "NO" ? 0L : 1L;
							++index1;
						}
					}
				}
				int num1 = index1 % 20 != 0 ? index1 / 20 + 1 : index1 / 20;
				for (int index2 = 0; index2 < num1; ++index2) {
					int length = index2 < num1 - 1 ? 20 : index1 % 20;
					long[][] numArray2 = new long[length][];
					for (int index3 = 0; index3 < length; ++index3) {
						numArray2[index3] = new long[3];
						numArray2[index3][0] = numArray1[index2 * 20 + index3][0];
						numArray2[index3][1] = numArray1[index2 * 20 + index3][1];
						numArray2[index3][2] = numArray1[index2 * 20 + index3][2];
					}
					string str2 = "";
					foreach (long[] numArray3 in numArray2)
						str2 = str2 + (object)numArray3[0] + "," + (object)numArray3[1] + "," + (object)numArray3[2] + ";";
					string insturmentClosingPrice = ServerMethods.GetInsturmentClosingPrice(str2.Substring(0, str2.Length - 1));
					char[] chArray = new char[1] { '@' };
					foreach (string str3 in insturmentClosingPrice.Split(chArray)) {
						if (!string.IsNullOrEmpty(str3)) {
							List<ClosingPriceInfo> input = new List<ClosingPriceInfo>();
							string[] strArray2 = str3.Split(';');
							for (int index3 = 0; index3 < strArray2.Length; ++index3) {
								ClosingPriceInfo closingPriceInfo = new ClosingPriceInfo();
								try {
									string[] strArray3 = strArray2[index3].Split(',');
									closingPriceInfo.InsCode = Convert.ToInt64(strArray3[0].ToString());
									closingPriceInfo.DEven = Convert.ToInt32(strArray3[1].ToString());
									closingPriceInfo.PClosing = Convert.ToDecimal(strArray3[2].ToString());
									closingPriceInfo.PDrCotVal = Convert.ToDecimal(strArray3[3].ToString());
									closingPriceInfo.ZTotTran = Convert.ToDecimal(strArray3[4].ToString());
									closingPriceInfo.QTotTran5J = Convert.ToDecimal(strArray3[5].ToString());
									closingPriceInfo.QTotCap = Convert.ToDecimal(strArray3[6].ToString());
									closingPriceInfo.PriceMin = Convert.ToDecimal(strArray3[7].ToString());
									closingPriceInfo.PriceMax = Convert.ToDecimal(strArray3[8].ToString());
									closingPriceInfo.PriceYesterday = Convert.ToDecimal(strArray3[9].ToString());
									closingPriceInfo.PriceFirst = Convert.ToDecimal(strArray3[10].ToString());
									input.Add(closingPriceInfo);
								} catch (Exception ex) {
									ServerMethods.LogError("UpdateClosingPrices[Row:" + strArray2[index3] + "]", ex);
									throw ex;
								}
							}
							FileService.WriteClosingPrices(input);
						}
					}
				}
				return true;
			} catch (Exception ex) {
				if (ex.Message.Contains("The magic number in GZip header is not correct")) {
					if (settings.EnableDecompression) {
						settings.EnableDecompression = false;
						settings.Save();
						return false;
					}
				}
				try {
					if (FileService.LogErrorFile("[ UpdateClosingPrices (" + StaticData.Version + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1) {
						int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
					}
				} catch {
				}
				return false;
			}
		}

		private bool GnerateFiles() {
			try {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				if (string.IsNullOrEmpty(settings.StorageLocation) || !Directory.Exists(settings.StorageLocation))
					return false;
				int startDeven = 0;
				settings.StartDate.Replace("/", "").ToString();
				DateTime dateTime = Utility.ConvertJalaliStringToDateTime(settings.StartDate);
				startDeven = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
				int num1 = 0;
				using (List<string>.Enumerator enumerator = StaticData.SelectedInstruments.GetEnumerator()) {
					while (enumerator.MoveNext()) {
						string item = enumerator.Current;
						List<ClosingPriceInfo> cp = FileService.ClosingPrices(Convert.ToInt64(item));
						cp = cp.FindAll((Predicate<ClosingPriceInfo>)(p => p.DEven >= startDeven));
						if ((settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2) && cp.Count > 1) {
							List<ClosingPriceInfo> closingPriceInfoList = new List<ClosingPriceInfo>();
							Decimal num2 = new Decimal(1);
							closingPriceInfoList.Add(cp[cp.Count - 1]);
							double num3 = 0.0;
							if (settings.AdjustPricesCondition == 1) {
								for (int index = cp.Count - 2; index >= 0; --index) {
									if (cp[index].PClosing != cp[index + 1].PriceYesterday)
										++num3;
								}
							}
							if (settings.AdjustPricesCondition == 1 && num3 / (double)cp.Count < 0.08 || settings.AdjustPricesCondition == 2) {
								for (int i = cp.Count - 2; i >= 0; --i) {
									if (settings.AdjustPricesCondition == 1 && cp[i].PClosing != cp[i + 1].PriceYesterday || settings.AdjustPricesCondition == 2 && cp[i].PClosing != cp[i + 1].PriceYesterday && StaticData.TseShares.Exists((Predicate<TseShareInfo>)(p => {
										if (p.InsCode.ToString().Equals(item))
											return p.DEven == cp[i].DEven;
										return false;
									})))
										num2 = num2 * cp[i + 1].PriceYesterday / cp[i].PClosing;
									closingPriceInfoList.Add(new ClosingPriceInfo() {
										InsCode = cp[i].InsCode,
										DEven = cp[i].DEven,
										PClosing = Math.Round(num2 * cp[i].PClosing, 2),
										PDrCotVal = Math.Round(num2 * cp[i].PDrCotVal, 2),
										ZTotTran = cp[i].ZTotTran,
										QTotTran5J = cp[i].QTotTran5J,
										QTotCap = cp[i].QTotCap,
										PriceMin = Math.Round(num2 * cp[i].PriceMin),
										PriceMax = Math.Round(num2 * cp[i].PriceMax),
										PriceYesterday = Math.Round(num2 * cp[i].PriceYesterday),
										PriceFirst = Math.Round(num2 * cp[i].PriceFirst, 2)
									});
								}
								cp.Clear();
								for (int index = closingPriceInfoList.Count - 1; index >= 0; --index)
									cp.Add(closingPriceInfoList[index]);
							}
						}
						InstrumentInfo instrument = StaticData.Instruments.Find((Predicate<InstrumentInfo>)(p => p.InsCode.ToString().Equals(item)));
						if (!settings.ExcelOutput)
							FileService.WriteOutputFile(instrument, cp, !settings.RemoveOldFiles);
						else
							FileService.WriteOutputExcel(instrument, cp);
						++num1;
					}
				}
				return true;
			} catch (Exception ex) {
				ServerMethods.LogError("UpdateClosingPrices", ex);
				try {
					if (FileService.LogErrorFile("[ Generating Output Files (" + StaticData.Version + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1) {
						int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
					}
				} catch {
				}
				return false;
			}
		}
	}
}
