// Decompiled with JetBrains decompiler
// Type: TseClient.UCStepUpdate
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient {
	public class UCStepUpdate : UserControl {
		private bool isVisual = true;
		private IContainer components;
		protected RichTextBox rtbOperationLog;
		private Button btnStep3Next;
		private GroupBox groupBox3;
		private Button btnStep3Back;
		private Button btnStep3Reserve;
		private Button btnOpenFolder;
		private CheckBox chkRemoveOldFiles;
		private CheckBox chkAutomaticOpenFolder;
		private ProgressBar progressBar;
		private Label lblProgress;
		private Label label1;
		private Label label2;
		private ComboBox cbxAdjustPricesCondition;
		private MainForm owner;
		private bool readyToExit;

		protected override void Dispose(bool disposing) {
			if (disposing && this.components != null)
				this.components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			this.rtbOperationLog = new RichTextBox();
			this.btnStep3Next = new Button();
			this.groupBox3 = new GroupBox();
			this.btnStep3Back = new Button();
			this.btnStep3Reserve = new Button();
			this.btnOpenFolder = new Button();
			this.chkRemoveOldFiles = new CheckBox();
			this.chkAutomaticOpenFolder = new CheckBox();
			this.progressBar = new ProgressBar();
			this.lblProgress = new Label();
			this.label1 = new Label();
			this.label2 = new Label();
			this.cbxAdjustPricesCondition = new ComboBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			this.rtbOperationLog.BackColor = SystemColors.Control;
			this.rtbOperationLog.BorderStyle = BorderStyle.None;
			this.rtbOperationLog.Dock = DockStyle.Top;
			this.rtbOperationLog.Location = new Point(3, 17);
			this.rtbOperationLog.Name = "rtbOperationLog";
			this.rtbOperationLog.ReadOnly = true;
			this.rtbOperationLog.RightToLeft = RightToLeft.Yes;
			this.rtbOperationLog.Size = new Size(772, 278);
			this.rtbOperationLog.TabIndex = 1;
			this.rtbOperationLog.Text = "";
			this.btnStep3Next.Location = new Point(10, 352);
			this.btnStep3Next.Name = "btnStep3Next";
			this.btnStep3Next.Size = new Size(86, 26);
			this.btnStep3Next.TabIndex = 6;
			this.btnStep3Next.Text = "تولید خروجی";
			this.btnStep3Next.UseVisualStyleBackColor = true;
			this.btnStep3Next.Click += new EventHandler(this.btnStep3Next_Click_1);
			this.groupBox3.Controls.Add((Control)this.rtbOperationLog);
			this.groupBox3.Location = new Point(10, 45);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(778, 301);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "عملیات";
			this.btnStep3Back.Location = new Point(102, 352);
			this.btnStep3Back.Name = "btnStep3Back";
			this.btnStep3Back.Size = new Size(86, 26);
			this.btnStep3Back.TabIndex = 7;
			this.btnStep3Back.Text = "مرحله قبل";
			this.btnStep3Back.UseVisualStyleBackColor = true;
			this.btnStep3Back.Click += new EventHandler(this.btnStep3Back_Click);
			this.btnStep3Reserve.Location = new Point(286, 352);
			this.btnStep3Reserve.Name = "btnStep3Reserve";
			this.btnStep3Reserve.Size = new Size(86, 26);
			this.btnStep3Reserve.TabIndex = 8;
			this.btnStep3Reserve.Text = "تلاش مجدد";
			this.btnStep3Reserve.UseVisualStyleBackColor = true;
			this.btnStep3Reserve.Visible = false;
			this.btnStep3Reserve.Click += new EventHandler(this.btnStep3Reserve_Click);
			this.btnOpenFolder.Location = new Point(194, 352);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new Size(86, 26);
			this.btnOpenFolder.TabIndex = 9;
			this.btnOpenFolder.Text = "پوشه فایلها";
			this.btnOpenFolder.UseVisualStyleBackColor = true;
			this.btnOpenFolder.Visible = false;
			this.btnOpenFolder.Click += new EventHandler(this.btnOpenFolder_Click);
			this.chkRemoveOldFiles.AutoSize = true;
			this.chkRemoveOldFiles.Location = new Point(650, 352);
			this.chkRemoveOldFiles.Name = "chkRemoveOldFiles";
			this.chkRemoveOldFiles.Size = new Size(135, 17);
			this.chkRemoveOldFiles.TabIndex = 10;
			this.chkRemoveOldFiles.Text = "پاک کردن فایلهای موجود";
			this.chkRemoveOldFiles.UseVisualStyleBackColor = true;
			this.chkRemoveOldFiles.CheckedChanged += new EventHandler(this.chkRemoveOldFiles_CheckedChanged);
			this.chkAutomaticOpenFolder.AutoSize = true;
			this.chkAutomaticOpenFolder.Location = new Point(487, 352);
			this.chkAutomaticOpenFolder.Name = "chkAutomaticOpenFolder";
			this.chkAutomaticOpenFolder.Size = new Size(157, 17);
			this.chkAutomaticOpenFolder.TabIndex = 11;
			this.chkAutomaticOpenFolder.Text = "باز کردن اتوماتیک پوشه فایلها";
			this.chkAutomaticOpenFolder.UseVisualStyleBackColor = true;
			this.chkAutomaticOpenFolder.CheckedChanged += new EventHandler(this.chkAutomaticOpenFolder_CheckedChanged);
			this.progressBar.Location = new Point(13, 7);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new Size(745, 32);
			this.progressBar.TabIndex = 12;
			this.lblProgress.AutoSize = true;
			this.lblProgress.Location = new Point(762, 16);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new Size(24, 13);
			this.lblProgress.TabIndex = 13;
			this.lblProgress.Text = "0%";
			this.label1.AutoSize = true;
			this.label1.ForeColor = SystemColors.WindowFrame;
			this.label1.Location = new Point(9, 395);
			this.label1.Name = "label1";
			this.label1.Size = new Size(783, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "( فایلهای حاوی قیمت های تعدیل شده و تعدیل شده با افزایش سرمایه، در حالت لاتین به ترتیب با پسوندهای -a و -i و در حالت فارسی با پسوندهای -ت و-ا ذخیره می شوند)";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(703, 374);
			this.label2.Name = "label2";
			this.label2.Size = new Size(83, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "تعدیل قیمت ها :";
			this.cbxAdjustPricesCondition.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbxAdjustPricesCondition.FormattingEnabled = true;
			this.cbxAdjustPricesCondition.Items.AddRange(new object[3]
			{
				(object) "خیر",
				(object) "افزایش سرمایه + سود",
				(object) "افزایش سرمایه"
			});
			this.cbxAdjustPricesCondition.Location = new Point(487, 371);
			this.cbxAdjustPricesCondition.Name = "cbxAdjustPricesCondition";
			this.cbxAdjustPricesCondition.Size = new Size(210, 21);
			this.cbxAdjustPricesCondition.TabIndex = 18;
			this.cbxAdjustPricesCondition.SelectedIndexChanged += new EventHandler(this.cbxAdjustPricesCondition_SelectedIndexChanged);
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add((Control)this.cbxAdjustPricesCondition);
			this.Controls.Add((Control)this.label2);
			this.Controls.Add((Control)this.label1);
			this.Controls.Add((Control)this.lblProgress);
			this.Controls.Add((Control)this.progressBar);
			this.Controls.Add((Control)this.chkAutomaticOpenFolder);
			this.Controls.Add((Control)this.chkRemoveOldFiles);
			this.Controls.Add((Control)this.btnOpenFolder);
			this.Controls.Add((Control)this.btnStep3Reserve);
			this.Controls.Add((Control)this.btnStep3Back);
			this.Controls.Add((Control)this.btnStep3Next);
			this.Controls.Add((Control)this.groupBox3);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
			this.Name = nameof(UCStepUpdate);
			this.RightToLeft = RightToLeft.Yes;
			this.Size = new Size(800, 420);
			this.Load += new EventHandler(this.UCStepUpdate_Load);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		public UCStepUpdate(MainForm owner) {
			this.owner = owner;
			this.InitializeComponent();
		}

		public UCStepUpdate() {
			this.isVisual = false;
			this.InitializeComponent();
		}

		private void UCStepUpdate_Load(object sender, EventArgs e) {
			this.btnStep3Next.Enabled = false;
			this.btnStep3Next.Focus();
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			if (settings.AutomaticOpenFolder)
				this.chkAutomaticOpenFolder.Checked = true;
			this.cbxAdjustPricesCondition.SelectedIndex = settings.AdjustPricesCondition;
			if (settings.ExcelOutput) {
				this.chkRemoveOldFiles.Checked = true;
				this.chkRemoveOldFiles.Enabled = false;
			} else if (settings.RemoveOldFiles)
				this.chkRemoveOldFiles.Checked = true;
			if (!this.UpdateClosingPrices()) {
				this.btnStep3Reserve.Visible = true;
				this.btnStep3Next.Text = "ساخت فایلها با اطلاعات فعلی";
				this.btnStep3Next.Width = 200;
				this.btnStep3Back.Left += 114;
				this.btnStep3Reserve.Left += 114;
				this.btnOpenFolder.Left += 114;
				Application.DoEvents();
			}
			this.btnOpenFolder.Visible = true;
			this.btnStep3Next.Enabled = true;
		}

		private void btnStep3Back_Click(object sender, EventArgs e) {
			this.owner.TabSwitcher(Tabs.Settings);
		}

		private void btnStep3Reserve_Click(object sender, EventArgs e) {
			this.owner.TabSwitcher(Tabs.Update);
		}

		public bool UpdateClosingPrices() {
			Settings settings = new Settings();
			try {
				if (this.isVisual) {
					this.rtbOperationLog.AppendText("\n\tدریافت اطلاعات ... ");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
					this.progressBar.Value = 0;
					this.lblProgress.Text = "0%";
					Application.DoEvents();
				}
				string lastPossibleDeven = "";
				try {
					lastPossibleDeven = ServerMethods.LastPossibleDeven();
				} catch (Exception ex) {
					ServerMethods.LogError("lastPossibleDEvens", ex);
				}
				if (lastPossibleDeven.Equals("*")) {
					if (this.isVisual) {
						this.rtbOperationLog.AppendText("\n\tبروز رسانی اطلاعات در حد فاصل ساعت هشت صبح تا یک بعد از ظهر روزهای شنبه تا چهارشنبه امکان پذیر نمی باشد.");
						this.rtbOperationLog.AppendText("\n\tجهت ساخت فایلها با اطلاعات فعلی از دکمه تعبیه شده در پایین صفحه استفاده کنید.");
						this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
						this.rtbOperationLog.ScrollToCaret();
					}
					return false;
				}
				string[] strArray1 = lastPossibleDeven.Split(';');
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
					if (this.isVisual) {
						this.rtbOperationLog.AppendText("\n\tدریافت بخش " + (index2 + 1).ToString() + " از " + num1 + " اطلاعات ... ");
						this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
						this.rtbOperationLog.ScrollToCaret();
						Application.DoEvents();
						if (length == 0) {
							this.progressBar.Value = 100;
							this.lblProgress.Text = "100%";
							Application.DoEvents();
							continue;
						}
					}
					long[][] numArray2 = new long[length][];
					for (int index3 = 0; index3 < length; ++index3) {
						numArray2[index3] = new long[3];
						numArray2[index3][0] = numArray1[index2 * 20 + index3][0];
						numArray2[index3][1] = numArray1[index2 * 20 + index3][1];
						numArray2[index3][2] = numArray1[index2 * 20 + index3][2];
					}
					string insCodes = "";
					foreach (long[] numArray3 in numArray2)
						insCodes += numArray3[0] + "," + numArray3[1] + "," + numArray3[2] + ";";
					insCodes = insCodes.Substring(0, insCodes.Length - 1);
          string insturmentClosingPrice = ServerMethods.GetInsturmentClosingPrice(insCodes);
					if (insturmentClosingPrice.Equals("*")) {
						if (this.isVisual) {
							this.rtbOperationLog.AppendText("\n\tبروز رسانی اطلاعات در حد فاصل ساعت هشت صبح تا یک بعد از ظهر روزهای شنبه تا چهارشنبه امکان پذیر نمی باشد.");
							this.rtbOperationLog.AppendText("\n\tجهت ساخت فایلها با اطلاعات فعلی از دکمه تعبیه شده در پایین صفحه استفاده کنید.");
							this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
							this.rtbOperationLog.ScrollToCaret();
						}
						return false;
					}
					string str3 = insturmentClosingPrice;
					char[] chArray = new char[1] { '@' };
					foreach (string str4 in str3.Split(chArray)) {
						if (!string.IsNullOrEmpty(str4)) {
							List<ClosingPriceInfo> cpList = new List<ClosingPriceInfo>();
							string[] strArray2 = str4.Split(';');
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
									cpList.Add(closingPriceInfo);
								} catch (Exception ex) {
									ServerMethods.LogError("UpdateClosingPrices[Row:" + strArray2[index3] + "]", ex);
									throw ex;
								}
							}
							FileService.WriteClosingPrices(cpList);
							if (this.isVisual && cpList.Count > 0) {
								InstrumentInfo instrumentInfo = StaticData.Instruments.Find((Predicate<InstrumentInfo>)(p => p.InsCode == cpList[0].InsCode));
								this.rtbOperationLog.AppendText("\n\t\tبروز رسانی اطلاعات " + instrumentInfo.Symbol + " (" + instrumentInfo.Name + ")");
								this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
								this.rtbOperationLog.ScrollToCaret();
							}
						}
					}
					if (this.isVisual) {
						this.progressBar.Value = Convert.ToInt32((double)(index2 + 1) / (double)num1 * 100.0);
						this.lblProgress.Text = Convert.ToInt32((double)(index2 + 1) / (double)num1 * 100.0).ToString() + "%";
						Application.DoEvents();
					}
				}
				if (this.isVisual) {
					if (num1 == 0) {
						this.progressBar.Value = 100;
						this.lblProgress.Text = "100%";
						Application.DoEvents();
					}
					this.rtbOperationLog.AppendText("\n\tبروز رسانی اطلاعات نمادها با موفقیت انجام گردید\t ");
					this.rtbOperationLog.AppendText("\n\tجهت ایجاد خروجی جدید بر اساس اطلاعات بروز شده از دکمه تولید خروجی استفاده کنید ");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
				}
				return true;
			} catch (Exception ex) {
				if (ex.Message.Contains("The magic number in GZip header is not correct") && settings.EnableDecompression) {
					settings.EnableDecompression = false;
					settings.Save();
					this.owner.TabSwitcher(Tabs.Update);
					return false;
				}
				if (this.isVisual) {
					this.rtbOperationLog.AppendText("\n\tبروز رسانی اطلاعات نمادها ناموفق بود. ");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
					this.rtbOperationLog.AppendText(ServerMethods.LogError(nameof(UpdateClosingPrices), ex));
				}
				try {
					if (FileService.LogErrorFile("[ UpdateClosingPrices (" + StaticData.Version + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1) {
						if (this.isVisual) {
							int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
						}
					}
				} catch {
					this.rtbOperationLog.AppendText("\n\tثبت خطا در فایل ناموفق بود");
				}
				return false;
			}
		}

		private void btnOpenFolder_Click(object sender, EventArgs e) {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			try {
				if (settings.AdjustPricesCondition == 0)
					Process.Start(settings.StorageLocation);
				else
					Process.Start(settings.AdjustedStorageLocation);
			} catch (Exception ex) {
				int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد");
			}
		}

		private void btnStep3Next_Click_1(object sender, EventArgs e) {
			if (this.readyToExit)
				Application.Exit();
			if (this.GnerateFiles() && this.chkAutomaticOpenFolder.Checked) {
				// ISSUE: object of a compiler-generated type is created
				// ISSUE: variable of a compiler-generated type
				Settings settings = new Settings();
				try {
					if (settings.AdjustPricesCondition == 0)
						Process.Start(settings.StorageLocation);
					else
						Process.Start(settings.AdjustedStorageLocation);
				} catch (Exception ex) {
					int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد");
				}
			}
			this.btnStep3Next.Text = "خروج";
			this.readyToExit = true;
		}

		public bool GnerateFiles() {
			try {
				if (this.isVisual) {
					this.rtbOperationLog.AppendText("\n\tایجاد فایلهای خروجی ... ");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
					this.progressBar.Value = 0;
					this.lblProgress.Text = "0%";
					Application.DoEvents();
				}
				Settings settings = new Settings();
				int cond = settings.AdjustPricesCondition;
				string path = cond != 0 ? settings.AdjustedStorageLocation : settings.StorageLocation;
				if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) {
					if (this.isVisual) {
						this.rtbOperationLog.AppendText("\n\tمقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
						this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
						this.rtbOperationLog.ScrollToCaret();
					}
					return false;
				}
				int startDeven = 0;
				//settings.StartDate.Replace("/", "").ToString(); // unnecessary
				DateTime dateTime = Utility.ConvertJalaliStringToDateTime(settings.StartDate);
				startDeven = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
				int num1 = 0;
				using (List<string>.Enumerator enumerator = StaticData.SelectedInstruments.GetEnumerator()) {
					while (enumerator.MoveNext()) {
						string currentItemInscode = enumerator.Current;
						List<ClosingPriceInfo> cp = FileService.ClosingPrices(Convert.ToInt64(currentItemInscode));
						cp = cp.FindAll((Predicate<ClosingPriceInfo>)(p => p.DEven >= startDeven));
						if ((cond == 1 || cond == 2) && cp.Count > 1) {
							List<ClosingPriceInfo> closingPriceInfoList = new List<ClosingPriceInfo>();
							Decimal num2 = new Decimal(1);
							closingPriceInfoList.Add(cp[cp.Count - 1]);
							double gaps = 0.0;
							if (cond == 1) {
								for (int index = cp.Count - 2; index >= 0; --index) {
									if (cp[index].PClosing != cp[index + 1].PriceYesterday)
										++gaps;
								}
							}
							if (cond == 1 && gaps / cp.Count < 0.08 || cond == 2) {
								for (int i = cp.Count - 2; i >= 0; --i) {
									ClosingPriceInfo curr = cp[i];
									ClosingPriceInfo next = cp[i + 1];
									Predicate<TseShareInfo> aShareThatsDifferent = p => {
										if (p.InsCode.ToString().Equals(currentItemInscode)) {
											return p.DEven == next.DEven;
										}
										return false;
									};
									bool pricesDontMatch = curr.PClosing != next.PriceYesterday;

									if (cond == 1 && pricesDontMatch)
										num2 = num2 * next.PriceYesterday / curr.PClosing;
									else if (cond == 2 && pricesDontMatch && StaticData.TseShares.Exists(aShareThatsDifferent)) {
										var something = StaticData.TseShares.Find(aShareThatsDifferent);
										decimal oldShares = something.NumberOfShareOld;
										decimal newShares = something.NumberOfShareNew;
										num2 = (num2 * oldShares) / newShares;
									}

									decimal
									close = Math.Round(num2 * curr.PClosing, 2),
									last  = Math.Round(num2 * curr.PDrCotVal, 2),
									low   = Math.Round(num2 * curr.PriceMin),
									high  = Math.Round(num2 * curr.PriceMax),
									yday  = Math.Round(num2 * curr.PriceYesterday),
									first = Math.Round(num2 * curr.PriceFirst, 2);

									closingPriceInfoList.Add(new ClosingPriceInfo() {
										InsCode        = curr.InsCode,
										DEven          = curr.DEven,
										PClosing       = close,
										PDrCotVal      = last,
										ZTotTran       = curr.ZTotTran,
										QTotTran5J     = curr.QTotTran5J,
										QTotCap        = curr.QTotCap,
										PriceMin       = low,
										PriceMax       = high,
										PriceYesterday = yday,
										PriceFirst     = first
									});
								}
								cp.Clear();
								for (int i = closingPriceInfoList.Count - 1; i >= 0; --i)
									cp.Add(closingPriceInfoList[i]);
							}
						}
						InstrumentInfo instrument = StaticData.Instruments.Find((Predicate<InstrumentInfo>)(p => p.InsCode.ToString().Equals(currentItemInscode)));
						if (!settings.ExcelOutput)
							FileService.WriteOutputFile(instrument, cp, !this.chkRemoveOldFiles.Checked);
						else
							FileService.WriteOutputExcel(instrument, cp);
						++num1;
						if (this.isVisual) {
							this.progressBar.Value = Convert.ToInt32((double)num1 / (double)StaticData.SelectedInstruments.Count * 100.0);
							this.lblProgress.Text = Convert.ToInt32((double)num1 / (double)StaticData.SelectedInstruments.Count * 100.0).ToString() + "%";
							this.rtbOperationLog.AppendText("\n\t\t " + instrument.Symbol + " (" + instrument.Name + ")");
							this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
							this.rtbOperationLog.ScrollToCaret();
							Application.DoEvents();
						}
					}
				}
				if (this.isVisual) {
					this.rtbOperationLog.AppendText("\n\tعملیات ایجاد فایلهای خروجی با موفقیت انجام گردید.");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
				}
				return true;
			} catch (Exception ex) {
				if (this.isVisual) {
					this.rtbOperationLog.AppendText("\n\t");
					this.rtbOperationLog.AppendText("\n\tعملیات ایجاد فایلهای خروجی ناموفق بود. ");
					this.rtbOperationLog.SelectionStart = this.rtbOperationLog.Text.Length;
					this.rtbOperationLog.ScrollToCaret();
				}
				if (this.isVisual)
					this.rtbOperationLog.AppendText(ServerMethods.LogError("UpdateClosingPrices", ex));
				else
					ServerMethods.LogError("UpdateClosingPrices", ex);
				try {
					if (FileService.LogErrorFile("[ Generating Output Files (" + StaticData.Version + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1) {
						if (this.isVisual) {
							int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
						}
					}
				} catch {
					if (this.isVisual)
						this.rtbOperationLog.AppendText("\n\tثبت خطا در فایل ناموفق بود");
				}
				return false;
			}
		}

		private void chkRemoveOldFiles_CheckedChanged(object sender, EventArgs e) {
			// ISSUE: object of a compiler-generated type is created
			new Settings() {
				RemoveOldFiles = this.chkRemoveOldFiles.Checked
			}.Save();
		}

		private void chkAutomaticOpenFolder_CheckedChanged(object sender, EventArgs e) {
			// ISSUE: object of a compiler-generated type is created
			new Settings() {
				AutomaticOpenFolder = this.chkAutomaticOpenFolder.Checked
			}.Save();
		}

		private void cbxAdjustPricesCondition_SelectedIndexChanged(object sender, EventArgs e) {
			// ISSUE: object of a compiler-generated type is created
			new Settings() {
				AdjustPricesCondition = this.cbxAdjustPricesCondition.SelectedIndex
			}.Save();
		}
	}
}
