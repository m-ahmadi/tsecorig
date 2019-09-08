// Decompiled with JetBrains decompiler
// Type: TseClient.SettingsContainerForms
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient {
	public class SettingsContainerForms : Form {
		private Process process = new Process();
		private System.Windows.Forms.Timer processKiller = new System.Windows.Forms.Timer();
		private IContainer components;
		private TabControl tabControlSettings;
		private TabPage tabPageGeneral;
		private TabPage tabPageFiles;
		private Button btnSave;
		private Button btnReset;
		protected GroupBox groupBoxExportDaysWithoutTrade;
		protected RadioButton rbnNo;
		protected RadioButton rbnYes;
		protected GroupBox groupBoxColumns;
		protected Panel panel1;
		protected CheckBox chkShowHeaders;
		protected CheckBox chkColumn8;
		protected CheckBox chkColumn12;
		protected CheckBox chkColumn4;
		protected CheckBox chkColumn14;
		protected CheckBox chkColumn6;
		protected CheckBox chkColumn10;
		protected CheckBox chkColumn2;
		protected CheckBox chkColumn15;
		protected CheckBox chkColumn7;
		protected CheckBox chkColumn11;
		protected CheckBox chkColumn3;
		protected CheckBox chkColumn13;
		protected CheckBox chkColumn5;
		protected CheckBox chkColumn9;
		protected CheckBox chkColumn1;
		protected TextBox txtHeader8;
		protected TextBox txtHeader12;
		protected TextBox txtHeader4;
		protected TextBox txtHeader14;
		protected TextBox txtHeader6;
		protected TextBox txtHeader10;
		protected TextBox txtHeader2;
		protected TextBox txtHeader15;
		protected TextBox txtHeader7;
		protected TextBox txtHeader11;
		protected TextBox txtHeader3;
		protected TextBox txtHeader13;
		protected TextBox txtHeader5;
		protected TextBox txtHeader9;
		protected TextBox txtHeader1;
		protected ComboBox cbxColumn8;
		protected ComboBox cbxColumn12;
		protected ComboBox cbxColumn4;
		protected ComboBox cbxColumn14;
		protected ComboBox cbxColumn6;
		protected ComboBox cbxColumn10;
		protected ComboBox cbxColumn2;
		protected ComboBox cbxColumn15;
		protected ComboBox cbxColumn7;
		protected ComboBox cbxColumn11;
		protected ComboBox cbxColumn3;
		protected ComboBox cbxColumn13;
		protected ComboBox cbxColumn5;
		protected ComboBox cbxColumn9;
		protected ComboBox cbxColumn1;
		protected Label label13;
		protected Label label20;
		protected Label label9;
		protected Label label19;
		protected Label label12;
		protected Label label18;
		protected Label label8;
		protected Label label17;
		protected Label label11;
		protected Label label16;
		protected Label label7;
		protected Label label15;
		protected Label label10;
		protected Label label14;
		protected Label label6;
		protected Label label5;
		protected Label label4;
		protected Label label3;
		protected Label label2;
		protected Label label1;
		protected GroupBox groupBoxOutputFileFormat;
		protected ComboBox cbxEncoding;
		protected Label label23;
		protected TextBox txtStartDate;
		protected Label label25;
		protected TextBox txtDelimiter;
		protected Label label24;
		protected TextBox txtFileExtension;
		protected Label label22;
		protected ComboBox cbxFileName;
		protected Label label21;
		protected GroupBox groupBoxStorageLocation;
		protected Button btnStorageLocation;
		protected TextBox txtStorageLocation;
		private TabPage tabPageProxy;
		protected GroupBox groupBox1;
		protected Label label27;
		protected Label label26;
		protected Label lblHasProxy;
		protected Label label28;
		private Button btnSystemProxy;
		protected Label lblPort;
		protected Label lblIP;
		protected Label label29;
		private RadioButton rbnExcel;
		private RadioButton rbnCSV;
		protected GroupBox groupBox2;
		protected Button AdjustedStorageLocation;
		protected TextBox txtAdjustedStorageLocation;
		private Button btnClear;
		private MainForm mainForm;
		private Thread threadProxyLabels;
		private bool stop;
		private string columnsCommaSeperated;
		public bool confirmationResult;

		protected override void Dispose(bool disposing) {
			if (disposing && this.components != null)
				this.components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(SettingsContainerForms));
			this.tabControlSettings = new TabControl();
			this.tabPageGeneral = new TabPage();
			this.groupBoxExportDaysWithoutTrade = new GroupBox();
			this.rbnNo = new RadioButton();
			this.rbnYes = new RadioButton();
			this.groupBoxColumns = new GroupBox();
			this.panel1 = new Panel();
			this.chkShowHeaders = new CheckBox();
			this.chkColumn8 = new CheckBox();
			this.chkColumn12 = new CheckBox();
			this.chkColumn4 = new CheckBox();
			this.chkColumn14 = new CheckBox();
			this.chkColumn6 = new CheckBox();
			this.chkColumn10 = new CheckBox();
			this.chkColumn2 = new CheckBox();
			this.chkColumn15 = new CheckBox();
			this.chkColumn7 = new CheckBox();
			this.chkColumn11 = new CheckBox();
			this.chkColumn3 = new CheckBox();
			this.chkColumn13 = new CheckBox();
			this.chkColumn5 = new CheckBox();
			this.chkColumn9 = new CheckBox();
			this.chkColumn1 = new CheckBox();
			this.txtHeader8 = new TextBox();
			this.txtHeader12 = new TextBox();
			this.txtHeader4 = new TextBox();
			this.txtHeader14 = new TextBox();
			this.txtHeader6 = new TextBox();
			this.txtHeader10 = new TextBox();
			this.txtHeader2 = new TextBox();
			this.txtHeader15 = new TextBox();
			this.txtHeader7 = new TextBox();
			this.txtHeader11 = new TextBox();
			this.txtHeader3 = new TextBox();
			this.txtHeader13 = new TextBox();
			this.txtHeader5 = new TextBox();
			this.txtHeader9 = new TextBox();
			this.txtHeader1 = new TextBox();
			this.cbxColumn8 = new ComboBox();
			this.cbxColumn12 = new ComboBox();
			this.cbxColumn4 = new ComboBox();
			this.cbxColumn14 = new ComboBox();
			this.cbxColumn6 = new ComboBox();
			this.cbxColumn10 = new ComboBox();
			this.cbxColumn2 = new ComboBox();
			this.cbxColumn15 = new ComboBox();
			this.cbxColumn7 = new ComboBox();
			this.cbxColumn11 = new ComboBox();
			this.cbxColumn3 = new ComboBox();
			this.cbxColumn13 = new ComboBox();
			this.cbxColumn5 = new ComboBox();
			this.cbxColumn9 = new ComboBox();
			this.cbxColumn1 = new ComboBox();
			this.label13 = new Label();
			this.label20 = new Label();
			this.label9 = new Label();
			this.label19 = new Label();
			this.label12 = new Label();
			this.label18 = new Label();
			this.label8 = new Label();
			this.label17 = new Label();
			this.label11 = new Label();
			this.label16 = new Label();
			this.label7 = new Label();
			this.label15 = new Label();
			this.label10 = new Label();
			this.label14 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.tabPageFiles = new TabPage();
			this.groupBox2 = new GroupBox();
			this.AdjustedStorageLocation = new Button();
			this.txtAdjustedStorageLocation = new TextBox();
			this.groupBoxOutputFileFormat = new GroupBox();
			this.rbnExcel = new RadioButton();
			this.rbnCSV = new RadioButton();
			this.label29 = new Label();
			this.cbxEncoding = new ComboBox();
			this.label23 = new Label();
			this.txtStartDate = new TextBox();
			this.label25 = new Label();
			this.txtDelimiter = new TextBox();
			this.label24 = new Label();
			this.txtFileExtension = new TextBox();
			this.label22 = new Label();
			this.cbxFileName = new ComboBox();
			this.label21 = new Label();
			this.groupBoxStorageLocation = new GroupBox();
			this.btnStorageLocation = new Button();
			this.txtStorageLocation = new TextBox();
			this.tabPageProxy = new TabPage();
			this.groupBox1 = new GroupBox();
			this.btnSystemProxy = new Button();
			this.lblHasProxy = new Label();
			this.label28 = new Label();
			this.lblPort = new Label();
			this.label27 = new Label();
			this.lblIP = new Label();
			this.label26 = new Label();
			this.btnSave = new Button();
			this.btnReset = new Button();
			this.btnClear = new Button();
			this.tabControlSettings.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.groupBoxExportDaysWithoutTrade.SuspendLayout();
			this.groupBoxColumns.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPageFiles.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBoxOutputFileFormat.SuspendLayout();
			this.groupBoxStorageLocation.SuspendLayout();
			this.tabPageProxy.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			this.tabControlSettings.Controls.Add((Control)this.tabPageGeneral);
			this.tabControlSettings.Controls.Add((Control)this.tabPageFiles);
			this.tabControlSettings.Controls.Add((Control)this.tabPageProxy);
			this.tabControlSettings.Dock = DockStyle.Top;
			this.tabControlSettings.Location = new Point(0, 0);
			this.tabControlSettings.Name = "tabControlSettings";
			this.tabControlSettings.RightToLeft = RightToLeft.Yes;
			this.tabControlSettings.RightToLeftLayout = true;
			this.tabControlSettings.SelectedIndex = 0;
			this.tabControlSettings.Size = new Size(454, 357);
			this.tabControlSettings.TabIndex = 0;
			this.tabPageGeneral.Controls.Add((Control)this.groupBoxExportDaysWithoutTrade);
			this.tabPageGeneral.Controls.Add((Control)this.groupBoxColumns);
			this.tabPageGeneral.Location = new Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new Padding(3);
			this.tabPageGeneral.Size = new Size(446, 331);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "عمومی";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			this.groupBoxExportDaysWithoutTrade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBoxExportDaysWithoutTrade.Controls.Add((Control)this.rbnNo);
			this.groupBoxExportDaysWithoutTrade.Controls.Add((Control)this.rbnYes);
			this.groupBoxExportDaysWithoutTrade.Location = new Point(21, 4);
			this.groupBoxExportDaysWithoutTrade.Name = "groupBoxExportDaysWithoutTrade";
			this.groupBoxExportDaysWithoutTrade.Size = new Size(407, 46);
			this.groupBoxExportDaysWithoutTrade.TabIndex = 8;
			this.groupBoxExportDaysWithoutTrade.TabStop = false;
			this.groupBoxExportDaysWithoutTrade.Text = "نمایش روزهای بدون معامله";
			this.rbnNo.AutoSize = true;
			this.rbnNo.Location = new Point(273, 19);
			this.rbnNo.Name = "rbnNo";
			this.rbnNo.Size = new Size(41, 17);
			this.rbnNo.TabIndex = 1;
			this.rbnNo.TabStop = true;
			this.rbnNo.Text = "خیر";
			this.rbnNo.UseVisualStyleBackColor = true;
			this.rbnYes.AutoSize = true;
			this.rbnYes.Location = new Point(333, 19);
			this.rbnYes.Name = "rbnYes";
			this.rbnYes.Size = new Size(42, 17);
			this.rbnYes.TabIndex = 0;
			this.rbnYes.TabStop = true;
			this.rbnYes.Text = "بلی";
			this.rbnYes.UseVisualStyleBackColor = true;
			this.groupBoxColumns.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBoxColumns.Controls.Add((Control)this.panel1);
			this.groupBoxColumns.Location = new Point(21, 56);
			this.groupBoxColumns.Name = "groupBoxColumns";
			this.groupBoxColumns.Size = new Size(407, 272);
			this.groupBoxColumns.TabIndex = 9;
			this.groupBoxColumns.TabStop = false;
			this.groupBoxColumns.Text = "فرمت ذخیره فایل ها";
			this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.panel1.AutoScroll = true;
			this.panel1.AutoScrollMargin = new Size(0, 10);
			this.panel1.Controls.Add((Control)this.chkShowHeaders);
			this.panel1.Controls.Add((Control)this.chkColumn8);
			this.panel1.Controls.Add((Control)this.chkColumn12);
			this.panel1.Controls.Add((Control)this.chkColumn4);
			this.panel1.Controls.Add((Control)this.chkColumn14);
			this.panel1.Controls.Add((Control)this.chkColumn6);
			this.panel1.Controls.Add((Control)this.chkColumn10);
			this.panel1.Controls.Add((Control)this.chkColumn2);
			this.panel1.Controls.Add((Control)this.chkColumn15);
			this.panel1.Controls.Add((Control)this.chkColumn7);
			this.panel1.Controls.Add((Control)this.chkColumn11);
			this.panel1.Controls.Add((Control)this.chkColumn3);
			this.panel1.Controls.Add((Control)this.chkColumn13);
			this.panel1.Controls.Add((Control)this.chkColumn5);
			this.panel1.Controls.Add((Control)this.chkColumn9);
			this.panel1.Controls.Add((Control)this.chkColumn1);
			this.panel1.Controls.Add((Control)this.txtHeader8);
			this.panel1.Controls.Add((Control)this.txtHeader12);
			this.panel1.Controls.Add((Control)this.txtHeader4);
			this.panel1.Controls.Add((Control)this.txtHeader14);
			this.panel1.Controls.Add((Control)this.txtHeader6);
			this.panel1.Controls.Add((Control)this.txtHeader10);
			this.panel1.Controls.Add((Control)this.txtHeader2);
			this.panel1.Controls.Add((Control)this.txtHeader15);
			this.panel1.Controls.Add((Control)this.txtHeader7);
			this.panel1.Controls.Add((Control)this.txtHeader11);
			this.panel1.Controls.Add((Control)this.txtHeader3);
			this.panel1.Controls.Add((Control)this.txtHeader13);
			this.panel1.Controls.Add((Control)this.txtHeader5);
			this.panel1.Controls.Add((Control)this.txtHeader9);
			this.panel1.Controls.Add((Control)this.txtHeader1);
			this.panel1.Controls.Add((Control)this.cbxColumn8);
			this.panel1.Controls.Add((Control)this.cbxColumn12);
			this.panel1.Controls.Add((Control)this.cbxColumn4);
			this.panel1.Controls.Add((Control)this.cbxColumn14);
			this.panel1.Controls.Add((Control)this.cbxColumn6);
			this.panel1.Controls.Add((Control)this.cbxColumn10);
			this.panel1.Controls.Add((Control)this.cbxColumn2);
			this.panel1.Controls.Add((Control)this.cbxColumn15);
			this.panel1.Controls.Add((Control)this.cbxColumn7);
			this.panel1.Controls.Add((Control)this.cbxColumn11);
			this.panel1.Controls.Add((Control)this.cbxColumn3);
			this.panel1.Controls.Add((Control)this.cbxColumn13);
			this.panel1.Controls.Add((Control)this.cbxColumn5);
			this.panel1.Controls.Add((Control)this.cbxColumn9);
			this.panel1.Controls.Add((Control)this.cbxColumn1);
			this.panel1.Controls.Add((Control)this.label13);
			this.panel1.Controls.Add((Control)this.label20);
			this.panel1.Controls.Add((Control)this.label9);
			this.panel1.Controls.Add((Control)this.label19);
			this.panel1.Controls.Add((Control)this.label12);
			this.panel1.Controls.Add((Control)this.label18);
			this.panel1.Controls.Add((Control)this.label8);
			this.panel1.Controls.Add((Control)this.label17);
			this.panel1.Controls.Add((Control)this.label11);
			this.panel1.Controls.Add((Control)this.label16);
			this.panel1.Controls.Add((Control)this.label7);
			this.panel1.Controls.Add((Control)this.label15);
			this.panel1.Controls.Add((Control)this.label10);
			this.panel1.Controls.Add((Control)this.label14);
			this.panel1.Controls.Add((Control)this.label6);
			this.panel1.Controls.Add((Control)this.label5);
			this.panel1.Controls.Add((Control)this.label4);
			this.panel1.Controls.Add((Control)this.label3);
			this.panel1.Controls.Add((Control)this.label2);
			this.panel1.Controls.Add((Control)this.label1);
			this.panel1.Location = new Point(3, 18);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(401, 248);
			this.panel1.TabIndex = 0;
			this.chkShowHeaders.AutoSize = true;
			this.chkShowHeaders.Location = new Point(245, 10);
			this.chkShowHeaders.Name = "chkShowHeaders";
			this.chkShowHeaders.Size = new Size(129, 17);
			this.chkShowHeaders.TabIndex = 0;
			this.chkShowHeaders.Text = "نمایش عنوان ستون ها";
			this.chkShowHeaders.UseVisualStyleBackColor = true;
			this.chkColumn8.AutoSize = true;
			this.chkColumn8.Location = new Point(12, 259);
			this.chkColumn8.Name = "chkColumn8";
			this.chkColumn8.Size = new Size(55, 17);
			this.chkColumn8.TabIndex = 8;
			this.chkColumn8.Text = "انتخاب";
			this.chkColumn8.UseVisualStyleBackColor = true;
			this.chkColumn12.AutoSize = true;
			this.chkColumn12.Location = new Point(12, 366);
			this.chkColumn12.Name = "chkColumn12";
			this.chkColumn12.Size = new Size(55, 17);
			this.chkColumn12.TabIndex = 8;
			this.chkColumn12.Text = "انتخاب";
			this.chkColumn12.UseVisualStyleBackColor = true;
			this.chkColumn4.AutoSize = true;
			this.chkColumn4.Location = new Point(12, 152);
			this.chkColumn4.Name = "chkColumn4";
			this.chkColumn4.Size = new Size(55, 17);
			this.chkColumn4.TabIndex = 8;
			this.chkColumn4.Text = "انتخاب";
			this.chkColumn4.UseVisualStyleBackColor = true;
			this.chkColumn14.AutoSize = true;
			this.chkColumn14.Location = new Point(12, 420);
			this.chkColumn14.Name = "chkColumn14";
			this.chkColumn14.Size = new Size(55, 17);
			this.chkColumn14.TabIndex = 8;
			this.chkColumn14.Text = "انتخاب";
			this.chkColumn14.UseVisualStyleBackColor = true;
			this.chkColumn6.AutoSize = true;
			this.chkColumn6.Location = new Point(12, 206);
			this.chkColumn6.Name = "chkColumn6";
			this.chkColumn6.Size = new Size(55, 17);
			this.chkColumn6.TabIndex = 8;
			this.chkColumn6.Text = "انتخاب";
			this.chkColumn6.UseVisualStyleBackColor = true;
			this.chkColumn10.AutoSize = true;
			this.chkColumn10.Location = new Point(12, 313);
			this.chkColumn10.Name = "chkColumn10";
			this.chkColumn10.Size = new Size(55, 17);
			this.chkColumn10.TabIndex = 8;
			this.chkColumn10.Text = "انتخاب";
			this.chkColumn10.UseVisualStyleBackColor = true;
			this.chkColumn2.AutoSize = true;
			this.chkColumn2.Location = new Point(12, 99);
			this.chkColumn2.Name = "chkColumn2";
			this.chkColumn2.Size = new Size(55, 17);
			this.chkColumn2.TabIndex = 8;
			this.chkColumn2.Text = "انتخاب";
			this.chkColumn2.UseVisualStyleBackColor = true;
			this.chkColumn15.AutoSize = true;
			this.chkColumn15.Location = new Point(12, 446);
			this.chkColumn15.Name = "chkColumn15";
			this.chkColumn15.Size = new Size(55, 17);
			this.chkColumn15.TabIndex = 8;
			this.chkColumn15.Text = "انتخاب";
			this.chkColumn15.UseVisualStyleBackColor = true;
			this.chkColumn7.AutoSize = true;
			this.chkColumn7.Location = new Point(12, 232);
			this.chkColumn7.Name = "chkColumn7";
			this.chkColumn7.Size = new Size(55, 17);
			this.chkColumn7.TabIndex = 8;
			this.chkColumn7.Text = "انتخاب";
			this.chkColumn7.UseVisualStyleBackColor = true;
			this.chkColumn11.AutoSize = true;
			this.chkColumn11.Location = new Point(12, 339);
			this.chkColumn11.Name = "chkColumn11";
			this.chkColumn11.Size = new Size(55, 17);
			this.chkColumn11.TabIndex = 8;
			this.chkColumn11.Text = "انتخاب";
			this.chkColumn11.UseVisualStyleBackColor = true;
			this.chkColumn3.AutoSize = true;
			this.chkColumn3.Location = new Point(12, 125);
			this.chkColumn3.Name = "chkColumn3";
			this.chkColumn3.Size = new Size(55, 17);
			this.chkColumn3.TabIndex = 8;
			this.chkColumn3.Text = "انتخاب";
			this.chkColumn3.UseVisualStyleBackColor = true;
			this.chkColumn13.AutoSize = true;
			this.chkColumn13.Location = new Point(12, 393);
			this.chkColumn13.Name = "chkColumn13";
			this.chkColumn13.Size = new Size(55, 17);
			this.chkColumn13.TabIndex = 8;
			this.chkColumn13.Text = "انتخاب";
			this.chkColumn13.UseVisualStyleBackColor = true;
			this.chkColumn5.AutoSize = true;
			this.chkColumn5.Location = new Point(12, 179);
			this.chkColumn5.Name = "chkColumn5";
			this.chkColumn5.Size = new Size(55, 17);
			this.chkColumn5.TabIndex = 8;
			this.chkColumn5.Text = "انتخاب";
			this.chkColumn5.UseVisualStyleBackColor = true;
			this.chkColumn9.AutoSize = true;
			this.chkColumn9.Location = new Point(12, 286);
			this.chkColumn9.Name = "chkColumn9";
			this.chkColumn9.Size = new Size(55, 17);
			this.chkColumn9.TabIndex = 8;
			this.chkColumn9.Text = "انتخاب";
			this.chkColumn9.UseVisualStyleBackColor = true;
			this.chkColumn1.AutoSize = true;
			this.chkColumn1.Location = new Point(12, 72);
			this.chkColumn1.Name = "chkColumn1";
			this.chkColumn1.Size = new Size(55, 17);
			this.chkColumn1.TabIndex = 8;
			this.chkColumn1.Text = "انتخاب";
			this.chkColumn1.UseVisualStyleBackColor = true;
			this.txtHeader8.Location = new Point(224, 257);
			this.txtHeader8.Name = "txtHeader8";
			this.txtHeader8.Size = new Size(100, 21);
			this.txtHeader8.TabIndex = 7;
			this.txtHeader12.Location = new Point(224, 364);
			this.txtHeader12.Name = "txtHeader12";
			this.txtHeader12.Size = new Size(100, 21);
			this.txtHeader12.TabIndex = 7;
			this.txtHeader4.Location = new Point(224, 150);
			this.txtHeader4.Name = "txtHeader4";
			this.txtHeader4.Size = new Size(100, 21);
			this.txtHeader4.TabIndex = 7;
			this.txtHeader14.Location = new Point(224, 418);
			this.txtHeader14.Name = "txtHeader14";
			this.txtHeader14.Size = new Size(100, 21);
			this.txtHeader14.TabIndex = 7;
			this.txtHeader6.Location = new Point(224, 204);
			this.txtHeader6.Name = "txtHeader6";
			this.txtHeader6.Size = new Size(100, 21);
			this.txtHeader6.TabIndex = 7;
			this.txtHeader10.Location = new Point(224, 311);
			this.txtHeader10.Name = "txtHeader10";
			this.txtHeader10.Size = new Size(100, 21);
			this.txtHeader10.TabIndex = 7;
			this.txtHeader2.Location = new Point(224, 97);
			this.txtHeader2.Name = "txtHeader2";
			this.txtHeader2.Size = new Size(100, 21);
			this.txtHeader2.TabIndex = 7;
			this.txtHeader15.Location = new Point(224, 444);
			this.txtHeader15.Name = "txtHeader15";
			this.txtHeader15.Size = new Size(100, 21);
			this.txtHeader15.TabIndex = 7;
			this.txtHeader7.Location = new Point(224, 230);
			this.txtHeader7.Name = "txtHeader7";
			this.txtHeader7.Size = new Size(100, 21);
			this.txtHeader7.TabIndex = 7;
			this.txtHeader11.Location = new Point(224, 337);
			this.txtHeader11.Name = "txtHeader11";
			this.txtHeader11.Size = new Size(100, 21);
			this.txtHeader11.TabIndex = 7;
			this.txtHeader3.Location = new Point(224, 123);
			this.txtHeader3.Name = "txtHeader3";
			this.txtHeader3.Size = new Size(100, 21);
			this.txtHeader3.TabIndex = 7;
			this.txtHeader13.Location = new Point(224, 391);
			this.txtHeader13.Name = "txtHeader13";
			this.txtHeader13.Size = new Size(100, 21);
			this.txtHeader13.TabIndex = 7;
			this.txtHeader5.Location = new Point(224, 177);
			this.txtHeader5.Name = "txtHeader5";
			this.txtHeader5.Size = new Size(100, 21);
			this.txtHeader5.TabIndex = 7;
			this.txtHeader9.Location = new Point(224, 284);
			this.txtHeader9.Name = "txtHeader9";
			this.txtHeader9.Size = new Size(100, 21);
			this.txtHeader9.TabIndex = 7;
			this.txtHeader1.Location = new Point(224, 70);
			this.txtHeader1.Name = "txtHeader1";
			this.txtHeader1.Size = new Size(100, 21);
			this.txtHeader1.TabIndex = 7;
			this.cbxColumn8.FormattingEnabled = true;
			this.cbxColumn8.Location = new Point(84, 257);
			this.cbxColumn8.Name = "cbxColumn8";
			this.cbxColumn8.Size = new Size(135, 21);
			this.cbxColumn8.TabIndex = 6;
			this.cbxColumn12.FormattingEnabled = true;
			this.cbxColumn12.Location = new Point(84, 364);
			this.cbxColumn12.Name = "cbxColumn12";
			this.cbxColumn12.Size = new Size(135, 21);
			this.cbxColumn12.TabIndex = 6;
			this.cbxColumn4.FormattingEnabled = true;
			this.cbxColumn4.Location = new Point(84, 150);
			this.cbxColumn4.Name = "cbxColumn4";
			this.cbxColumn4.Size = new Size(135, 21);
			this.cbxColumn4.TabIndex = 6;
			this.cbxColumn14.FormattingEnabled = true;
			this.cbxColumn14.Location = new Point(84, 418);
			this.cbxColumn14.Name = "cbxColumn14";
			this.cbxColumn14.Size = new Size(135, 21);
			this.cbxColumn14.TabIndex = 6;
			this.cbxColumn6.FormattingEnabled = true;
			this.cbxColumn6.Location = new Point(84, 204);
			this.cbxColumn6.Name = "cbxColumn6";
			this.cbxColumn6.Size = new Size(135, 21);
			this.cbxColumn6.TabIndex = 6;
			this.cbxColumn10.FormattingEnabled = true;
			this.cbxColumn10.Location = new Point(84, 311);
			this.cbxColumn10.Name = "cbxColumn10";
			this.cbxColumn10.Size = new Size(135, 21);
			this.cbxColumn10.TabIndex = 6;
			this.cbxColumn2.FormattingEnabled = true;
			this.cbxColumn2.Location = new Point(84, 97);
			this.cbxColumn2.Name = "cbxColumn2";
			this.cbxColumn2.Size = new Size(135, 21);
			this.cbxColumn2.TabIndex = 6;
			this.cbxColumn15.FormattingEnabled = true;
			this.cbxColumn15.Location = new Point(84, 444);
			this.cbxColumn15.Name = "cbxColumn15";
			this.cbxColumn15.Size = new Size(135, 21);
			this.cbxColumn15.TabIndex = 6;
			this.cbxColumn7.FormattingEnabled = true;
			this.cbxColumn7.Location = new Point(84, 230);
			this.cbxColumn7.Name = "cbxColumn7";
			this.cbxColumn7.Size = new Size(135, 21);
			this.cbxColumn7.TabIndex = 6;
			this.cbxColumn11.FormattingEnabled = true;
			this.cbxColumn11.Location = new Point(84, 337);
			this.cbxColumn11.Name = "cbxColumn11";
			this.cbxColumn11.Size = new Size(135, 21);
			this.cbxColumn11.TabIndex = 6;
			this.cbxColumn3.FormattingEnabled = true;
			this.cbxColumn3.Location = new Point(84, 123);
			this.cbxColumn3.Name = "cbxColumn3";
			this.cbxColumn3.Size = new Size(135, 21);
			this.cbxColumn3.TabIndex = 6;
			this.cbxColumn13.FormattingEnabled = true;
			this.cbxColumn13.Location = new Point(84, 391);
			this.cbxColumn13.Name = "cbxColumn13";
			this.cbxColumn13.Size = new Size(135, 21);
			this.cbxColumn13.TabIndex = 6;
			this.cbxColumn5.FormattingEnabled = true;
			this.cbxColumn5.Location = new Point(84, 177);
			this.cbxColumn5.Name = "cbxColumn5";
			this.cbxColumn5.Size = new Size(135, 21);
			this.cbxColumn5.TabIndex = 6;
			this.cbxColumn9.FormattingEnabled = true;
			this.cbxColumn9.Location = new Point(84, 284);
			this.cbxColumn9.Name = "cbxColumn9";
			this.cbxColumn9.Size = new Size(135, 21);
			this.cbxColumn9.TabIndex = 6;
			this.cbxColumn1.FormattingEnabled = true;
			this.cbxColumn1.Location = new Point(84, 70);
			this.cbxColumn1.Name = "cbxColumn1";
			this.cbxColumn1.Size = new Size(135, 21);
			this.cbxColumn1.TabIndex = 6;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(330, 260);
			this.label13.Name = "label13";
			this.label13.Size = new Size(50, 13);
			this.label13.TabIndex = 5;
			this.label13.Text = "ستون 8 :";
			this.label20.AutoSize = true;
			this.label20.Location = new Point(330, 367);
			this.label20.Name = "label20";
			this.label20.Size = new Size(53, 13);
			this.label20.TabIndex = 5;
			this.label20.Text = "ستون 12:";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(330, 153);
			this.label9.Name = "label9";
			this.label9.Size = new Size(50, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "ستون 4 :";
			this.label19.AutoSize = true;
			this.label19.Location = new Point(330, 447);
			this.label19.Name = "label19";
			this.label19.Size = new Size(53, 13);
			this.label19.TabIndex = 5;
			this.label19.Text = "ستون 15:";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(330, 233);
			this.label12.Name = "label12";
			this.label12.Size = new Size(50, 13);
			this.label12.TabIndex = 5;
			this.label12.Text = "ستون 7 :";
			this.label18.AutoSize = true;
			this.label18.Location = new Point(330, 340);
			this.label18.Name = "label18";
			this.label18.Size = new Size(53, 13);
			this.label18.TabIndex = 5;
			this.label18.Text = "ستون 11:";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(330, 126);
			this.label8.Name = "label8";
			this.label8.Size = new Size(50, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "ستون 3 :";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(330, 421);
			this.label17.Name = "label17";
			this.label17.Size = new Size(53, 13);
			this.label17.TabIndex = 5;
			this.label17.Text = "ستون 14:";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(330, 207);
			this.label11.Name = "label11";
			this.label11.Size = new Size(50, 13);
			this.label11.TabIndex = 5;
			this.label11.Text = "ستون 6 :";
			this.label16.AutoSize = true;
			this.label16.Location = new Point(330, 314);
			this.label16.Name = "label16";
			this.label16.Size = new Size(53, 13);
			this.label16.TabIndex = 5;
			this.label16.Text = "ستون 10:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(330, 100);
			this.label7.Name = "label7";
			this.label7.Size = new Size(50, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "ستون 2 :";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(330, 394);
			this.label15.Name = "label15";
			this.label15.Size = new Size(53, 13);
			this.label15.TabIndex = 5;
			this.label15.Text = "ستون 13:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(330, 180);
			this.label10.Name = "label10";
			this.label10.Size = new Size(50, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "ستون 5 :";
			this.label14.AutoSize = true;
			this.label14.Location = new Point(330, 287);
			this.label14.Name = "label14";
			this.label14.Size = new Size(50, 13);
			this.label14.TabIndex = 5;
			this.label14.Text = "ستون 9 :";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(330, 73);
			this.label6.Name = "label6";
			this.label6.Size = new Size(50, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "ستون 1 :";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(344, 35);
			this.label5.Name = "label5";
			this.label5.Size = new Size(34, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "ستون";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(294, 35);
			this.label4.Name = "label4";
			this.label4.Size = new Size(33, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "عنوان";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(197, 35);
			this.label3.Name = "label3";
			this.label3.Size = new Size(25, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "داده";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(11, 48);
			this.label2.Name = "label2";
			this.label2.Size = new Size(367, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "____________________________________________________________";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(10, 22);
			this.label1.Name = "label1";
			this.label1.Size = new Size(60, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "نمایش/\r\nعدم نمایش";
			this.tabPageFiles.Controls.Add((Control)this.groupBox2);
			this.tabPageFiles.Controls.Add((Control)this.groupBoxOutputFileFormat);
			this.tabPageFiles.Controls.Add((Control)this.groupBoxStorageLocation);
			this.tabPageFiles.Location = new Point(4, 22);
			this.tabPageFiles.Name = "tabPageFiles";
			this.tabPageFiles.Padding = new Padding(3);
			this.tabPageFiles.Size = new Size(446, 331);
			this.tabPageFiles.TabIndex = 1;
			this.tabPageFiles.Text = "پیشرفته";
			this.tabPageFiles.UseVisualStyleBackColor = true;
			this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox2.Controls.Add((Control)this.AdjustedStorageLocation);
			this.groupBox2.Controls.Add((Control)this.txtAdjustedStorageLocation);
			this.groupBox2.Location = new Point(22, 65);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(407, 53);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "محل ذخیره فایل های تعدیل شده";
			this.AdjustedStorageLocation.Location = new Point(16, 18);
			this.AdjustedStorageLocation.Name = "AdjustedStorageLocation";
			this.AdjustedStorageLocation.Size = new Size(52, 22);
			this.AdjustedStorageLocation.TabIndex = 1;
			this.AdjustedStorageLocation.Text = "...";
			this.AdjustedStorageLocation.UseVisualStyleBackColor = true;
			this.AdjustedStorageLocation.Click += new EventHandler(this.AdjustedStorageLocation_Click);
			this.txtAdjustedStorageLocation.Location = new Point(74, 20);
			this.txtAdjustedStorageLocation.Name = "txtAdjustedStorageLocation";
			this.txtAdjustedStorageLocation.RightToLeft = RightToLeft.No;
			this.txtAdjustedStorageLocation.Size = new Size(328, 21);
			this.txtAdjustedStorageLocation.TabIndex = 0;
			this.groupBoxOutputFileFormat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.rbnExcel);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.rbnCSV);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label29);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.cbxEncoding);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label23);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.txtStartDate);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label25);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.txtDelimiter);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label24);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.txtFileExtension);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label22);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.cbxFileName);
			this.groupBoxOutputFileFormat.Controls.Add((Control)this.label21);
			this.groupBoxOutputFileFormat.Location = new Point(22, 124);
			this.groupBoxOutputFileFormat.Name = "groupBoxOutputFileFormat";
			this.groupBoxOutputFileFormat.Size = new Size(407, 201);
			this.groupBoxOutputFileFormat.TabIndex = 6;
			this.groupBoxOutputFileFormat.TabStop = false;
			this.groupBoxOutputFileFormat.Text = "فرمت فایل خروجی";
			this.rbnExcel.AutoSize = true;
			this.rbnExcel.Location = new Point(213, 29);
			this.rbnExcel.Name = "rbnExcel";
			this.rbnExcel.Size = new Size(51, 17);
			this.rbnExcel.TabIndex = 14;
			this.rbnExcel.TabStop = true;
			this.rbnExcel.Text = "Excel";
			this.rbnExcel.UseVisualStyleBackColor = true;
			this.rbnCSV.AutoSize = true;
			this.rbnCSV.Location = new Point(269, 29);
			this.rbnCSV.Name = "rbnCSV";
			this.rbnCSV.Size = new Size(46, 17);
			this.rbnCSV.TabIndex = 13;
			this.rbnCSV.TabStop = true;
			this.rbnCSV.Text = "CSV";
			this.rbnCSV.UseVisualStyleBackColor = true;
			this.rbnCSV.CheckedChanged += new EventHandler(this.rbnCSV_CheckedChanged);
			this.label29.AutoSize = true;
			this.label29.Location = new Point(356, 33);
			this.label29.Name = "label29";
			this.label29.Size = new Size(51, 13);
			this.label29.TabIndex = 12;
			this.label29.Text = "نوع فایل :";
			this.cbxEncoding.FormattingEnabled = true;
			this.cbxEncoding.Items.AddRange(new object[3]
			{
				(object) "Unicode",
				(object) "UTF8",
				(object) "ASCII"
			});
			this.cbxEncoding.Location = new Point(176, 114);
			this.cbxEncoding.Name = "cbxEncoding";
			this.cbxEncoding.Size = new Size(137, 21);
			this.cbxEncoding.TabIndex = 11;
			this.label23.AutoSize = true;
			this.label23.Location = new Point(348, 117);
			this.label23.Name = "label23";
			this.label23.Size = new Size(57, 13);
			this.label23.TabIndex = 10;
			this.label23.Text = "Encoding :";
			this.txtStartDate.Location = new Point(176, 171);
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.Size = new Size(137, 21);
			this.txtStartDate.TabIndex = 9;
			this.label25.AutoSize = true;
			this.label25.Location = new Point(341, 174);
			this.label25.Name = "label25";
			this.label25.Size = new Size(66, 13);
			this.label25.TabIndex = 8;
			this.label25.Text = "تاریخ شروع :";
			this.txtDelimiter.Location = new Point(176, 144);
			this.txtDelimiter.Name = "txtDelimiter";
			this.txtDelimiter.Size = new Size(137, 21);
			this.txtDelimiter.TabIndex = 9;
			this.label24.AutoSize = true;
			this.label24.Location = new Point(348, 147);
			this.label24.Name = "label24";
			this.label24.Size = new Size(57, 13);
			this.label24.TabIndex = 8;
			this.label24.Text = "جدا کننده :";
			this.txtFileExtension.Location = new Point(176, 86);
			this.txtFileExtension.Name = "txtFileExtension";
			this.txtFileExtension.Size = new Size(137, 21);
			this.txtFileExtension.TabIndex = 9;
			this.label22.AutoSize = true;
			this.label22.Location = new Point(340, 89);
			this.label22.Name = "label22";
			this.label22.Size = new Size(65, 13);
			this.label22.TabIndex = 8;
			this.label22.Text = "پسوند فایل :";
			this.cbxFileName.FormattingEnabled = true;
			this.cbxFileName.Items.AddRange(new object[6]
			{
				(object) "کد Isin",
				(object) "نام لاتین",
				(object) "نماد لاتین",
				(object) "نام",
				(object) "نماد",
				(object) ""
			});
			this.cbxFileName.Location = new Point(176, 59);
			this.cbxFileName.Name = "cbxFileName";
			this.cbxFileName.Size = new Size(137, 21);
			this.cbxFileName.TabIndex = 7;
			this.label21.AutoSize = true;
			this.label21.Location = new Point(356, 62);
			this.label21.Name = "label21";
			this.label21.Size = new Size(49, 13);
			this.label21.TabIndex = 1;
			this.label21.Text = "نام فایل :";
			this.groupBoxStorageLocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBoxStorageLocation.Controls.Add((Control)this.btnStorageLocation);
			this.groupBoxStorageLocation.Controls.Add((Control)this.txtStorageLocation);
			this.groupBoxStorageLocation.Location = new Point(22, 6);
			this.groupBoxStorageLocation.Name = "groupBoxStorageLocation";
			this.groupBoxStorageLocation.Size = new Size(407, 53);
			this.groupBoxStorageLocation.TabIndex = 5;
			this.groupBoxStorageLocation.TabStop = false;
			this.groupBoxStorageLocation.Text = "محل ذخیره فایل ها";
			this.btnStorageLocation.Location = new Point(16, 18);
			this.btnStorageLocation.Name = "btnStorageLocation";
			this.btnStorageLocation.Size = new Size(52, 22);
			this.btnStorageLocation.TabIndex = 1;
			this.btnStorageLocation.Text = "...";
			this.btnStorageLocation.UseVisualStyleBackColor = true;
			this.btnStorageLocation.Click += new EventHandler(this.btnStorageLocation_Click);
			this.txtStorageLocation.Location = new Point(74, 20);
			this.txtStorageLocation.Name = "txtStorageLocation";
			this.txtStorageLocation.RightToLeft = RightToLeft.No;
			this.txtStorageLocation.Size = new Size(328, 21);
			this.txtStorageLocation.TabIndex = 0;
			this.tabPageProxy.Controls.Add((Control)this.groupBox1);
			this.tabPageProxy.Location = new Point(4, 22);
			this.tabPageProxy.Name = "tabPageProxy";
			this.tabPageProxy.Padding = new Padding(3);
			this.tabPageProxy.Size = new Size(446, 331);
			this.tabPageProxy.TabIndex = 2;
			this.tabPageProxy.Text = "پراکسی";
			this.tabPageProxy.UseVisualStyleBackColor = true;
			this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox1.Controls.Add((Control)this.btnSystemProxy);
			this.groupBox1.Controls.Add((Control)this.lblHasProxy);
			this.groupBox1.Controls.Add((Control)this.label28);
			this.groupBox1.Controls.Add((Control)this.lblPort);
			this.groupBox1.Controls.Add((Control)this.label27);
			this.groupBox1.Controls.Add((Control)this.lblIP);
			this.groupBox1.Controls.Add((Control)this.label26);
			this.groupBox1.Location = new Point(20, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(415, 262);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "پراکسی";
			this.btnSystemProxy.Location = new Point(249, 125);
			this.btnSystemProxy.Name = "btnSystemProxy";
			this.btnSystemProxy.Size = new Size(133, 23);
			this.btnSystemProxy.TabIndex = 12;
			this.btnSystemProxy.Text = "تغییر پراکسی سیستم";
			this.btnSystemProxy.UseVisualStyleBackColor = true;
			this.btnSystemProxy.Click += new EventHandler(this.btnSystemProxy_Click);
			this.lblHasProxy.AutoSize = true;
			this.lblHasProxy.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			this.lblHasProxy.Location = new Point(193, 29);
			this.lblHasProxy.Name = "lblHasProxy";
			this.lblHasProxy.RightToLeft = RightToLeft.Yes;
			this.lblHasProxy.Size = new Size(28, 13);
			this.lblHasProxy.TabIndex = 11;
			this.lblHasProxy.Text = "دارد";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(223, 29);
			this.label28.Name = "label28";
			this.label28.RightToLeft = RightToLeft.Yes;
			this.label28.Size = new Size(162, 13);
			this.label28.TabIndex = 11;
			this.label28.Text = "پراکسی تنظیم شده در سیستم :";
			this.lblPort.AutoSize = true;
			this.lblPort.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			this.lblPort.Location = new Point(57, 95);
			this.lblPort.Name = "lblPort";
			this.lblPort.RightToLeft = RightToLeft.No;
			this.lblPort.Size = new Size(37, 13);
			this.lblPort.TabIndex = 11;
			this.lblPort.Text = "Port :";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(16, 95);
			this.label27.Name = "label27";
			this.label27.RightToLeft = RightToLeft.No;
			this.label27.Size = new Size(34, 13);
			this.label27.TabIndex = 11;
			this.label27.Text = "Port :";
			this.lblIP.AutoSize = true;
			this.lblIP.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			this.lblIP.Location = new Point(57, 69);
			this.lblIP.Name = "lblIP";
			this.lblIP.RightToLeft = RightToLeft.No;
			this.lblIP.Size = new Size(25, 13);
			this.lblIP.TabIndex = 11;
			this.lblIP.Text = "IP :";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(16, 69);
			this.label26.Name = "label26";
			this.label26.RightToLeft = RightToLeft.No;
			this.label26.Size = new Size(24, 13);
			this.label26.TabIndex = 11;
			this.label26.Text = "IP :";
			this.btnSave.Location = new Point(4, 378);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new Size(110, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "ذخیره";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnReset.Location = new Point(120, 378);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new Size(110, 23);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "تنظیمات پیش فرض";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new EventHandler(this.btnReset_Click);
			this.btnClear.Location = new Point(236, 378);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new Size(110, 23);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "پاک کردن اطلاعات";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(454, 412);
			this.Controls.Add((Control)this.btnClear);
			this.Controls.Add((Control)this.btnReset);
			this.Controls.Add((Control)this.btnSave);
			this.Controls.Add((Control)this.tabControlSettings);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
			this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			this.MaximumSize = new Size(470, 450);
			this.MinimumSize = new Size(470, 450);
			this.Name = nameof(SettingsContainerForms);
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "تنظیمات";
			this.Load += new EventHandler(this.SettingsContainerForms_Load);
			this.Leave += new EventHandler(this.SettingsContainerForms_Leave);
			this.tabControlSettings.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.groupBoxExportDaysWithoutTrade.ResumeLayout(false);
			this.groupBoxExportDaysWithoutTrade.PerformLayout();
			this.groupBoxColumns.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPageFiles.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBoxOutputFileFormat.ResumeLayout(false);
			this.groupBoxOutputFileFormat.PerformLayout();
			this.groupBoxStorageLocation.ResumeLayout(false);
			this.groupBoxStorageLocation.PerformLayout();
			this.tabPageProxy.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}

		public SettingsContainerForms(MainForm mainForm) {
			this.InitializeComponent();
			this.mainForm = mainForm;
		}

		private void SettingsContainerForms_Load(object sender, EventArgs e) {
			this.FillControls();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			this.ProcessColumns();
		}

		private void btnReset_Click(object sender, EventArgs e) {
			this.ResetSettings();
		}

		private void btnStorageLocation_Click(object sender, EventArgs e) {
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
				return;
			this.txtStorageLocation.Text = folderBrowserDialog.SelectedPath;
		}

		private void FillControls() {
			Control.CheckForIllegalCrossThreadCalls = false;
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			if (settings.ExportDaysWithoutTrade) {
				this.rbnYes.Checked = true;
				this.rbnNo.Checked = false;
			} else {
				this.rbnYes.Checked = false;
				this.rbnNo.Checked = true;
			}
			this.chkShowHeaders.Checked = settings.ShowHeaders;
			for (int index = 1; index <= 15; ++index) {
				ComboBox comboBox = this.Controls.Find("cbxColumn" + (object)index, true)[0] as ComboBox;
				comboBox.Items.Clear();
				comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				if (settings.Language == "English") {
					comboBox.Items.Add((object)"CompanyCode");
					comboBox.Items.Add((object)"LatinName");
					comboBox.Items.Add((object)"Symbol");
					comboBox.Items.Add((object)"Name");
					comboBox.Items.Add((object)"Date");
					comboBox.Items.Add((object)"ShamsiDate");
					comboBox.Items.Add((object)"PriceFirst");
					comboBox.Items.Add((object)"PriceMax");
					comboBox.Items.Add((object)"PriceMin");
					comboBox.Items.Add((object)"LastPrice");
					comboBox.Items.Add((object)"ClosingPrice");
					comboBox.Items.Add((object)"Price");
					comboBox.Items.Add((object)"Volume");
					comboBox.Items.Add((object)"Count");
					comboBox.Items.Add((object)"PriceYesterday");
				} else {
					comboBox.Items.Add((object)"کد شرکت");
					comboBox.Items.Add((object)"نام لاتین");
					comboBox.Items.Add((object)"نماد");
					comboBox.Items.Add((object)"نام");
					comboBox.Items.Add((object)"تاریخ میلادی");
					comboBox.Items.Add((object)"تاریخ شمسی");
					comboBox.Items.Add((object)"اولین قیمت");
					comboBox.Items.Add((object)"بیشترین قیمت");
					comboBox.Items.Add((object)"کمترین قیمت");
					comboBox.Items.Add((object)"آخرین قیمت");
					comboBox.Items.Add((object)"قیمت پایانی");
					comboBox.Items.Add((object)"ارزش");
					comboBox.Items.Add((object)"حجم");
					comboBox.Items.Add((object)"تعداد معاملات");
					comboBox.Items.Add((object)"قیمت دیروز");
				}
			}
			foreach (ColumnInfo columnInfo in StaticData.ColumnsInfo) {
				this.Controls.Find("txtHeader" + (object)columnInfo.Index, true)[0].Text = columnInfo.Header;
				(this.Controls.Find("chkColumn" + (object)columnInfo.Index, true)[0] as CheckBox).Checked = columnInfo.Visible;
				(this.Controls.Find("cbxColumn" + (object)columnInfo.Index, true)[0] as ComboBox).SelectedIndex = (int)columnInfo.Type;
			}
			if (settings.ExcelOutput) {
				this.rbnExcel.Checked = true;
				this.rbnCSV.Checked = false;
				this.txtFileExtension.Enabled = false;
				this.cbxEncoding.Enabled = false;
				this.txtDelimiter.Enabled = false;
			} else {
				this.rbnExcel.Checked = false;
				this.rbnCSV.Checked = true;
				this.txtFileExtension.Enabled = true;
				this.cbxEncoding.Enabled = true;
				this.txtDelimiter.Enabled = true;
			}
			this.txtStorageLocation.Text = settings.StorageLocation;
			this.txtAdjustedStorageLocation.Text = settings.AdjustedStorageLocation;
			this.cbxFileName.SelectedIndex = (int)System.Enum.Parse(typeof(FileNameOption), settings.FileName);
			this.txtFileExtension.Text = settings.FileExtension;
			this.cbxEncoding.SelectedIndex = (int)System.Enum.Parse(typeof(EncodingOption), settings.Encoding);
			this.txtDelimiter.Text = settings.Delimeter.ToString();
			this.txtStartDate.Text = settings.StartDate;
			this.GetSystemProxy();
		}

		private void GetSystemProxy() {
			try {
				IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
				string str1 = defaultWebProxy.GetProxy(new Uri("http://www.tsetmc.com")).Host.ToString();
				string str2 = defaultWebProxy.GetProxy(new Uri("http://www.tsetmc.com")).Port.ToString();
				if (str1.Equals("www.tsetmc.com") && str2.Equals("80")) {
					this.lblIP.Text = "-";
					this.lblPort.Text = "-";
					this.lblHasProxy.Text = "ندارد";
				} else {
					this.lblIP.Text = str1;
					this.lblPort.Text = str2;
					this.lblHasProxy.Text = "دارد";
				}
			} catch (Exception ex) {
				this.lblIP.Text = "-";
				this.lblPort.Text = "-";
				this.lblHasProxy.Text = "خطا در دریافت اطلاعات پراکسی";
			}
			Application.DoEvents();
		}

		public bool IsInteger(string input) {
			try {
				Convert.ToInt32(input);
				return true;
			} catch {
				return false;
			}
		}

		private bool ValidateFields() {
			if (!FileService.HasAccessToWrite(this.txtStorageLocation.Text)) {
				int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل ها نامعتبر و یا غیر قابل دسترسی توسط برنامه می باشد");
				return false;
			}
			if (!FileService.HasAccessToWrite(this.txtAdjustedStorageLocation.Text)) {
				int num = (int)MessageBox.Show("مقدار فیلد محل ذخیره فایل های با قیمت تعدیل شده نامعتبر و یا غیر قابل دسترسی توسط برنامه می باشد");
				return false;
			}
			if (this.txtStartDate.Text.Length != 10 || !this.IsInteger(this.txtStartDate.Text.Substring(0, 4)) || (!this.IsInteger(this.txtStartDate.Text.Substring(5, 2)) || !this.IsInteger(this.txtStartDate.Text.Substring(8, 2)))) {
				int num = (int)MessageBox.Show("مقدار فیلد تاریخ شروع معتبر نمی باشد");
				return false;
			}
			bool flag = false;
			for (int index = 1; index <= 15; ++index) {
				ComboBox comboBox = this.Controls.Find("cbxColumn" + (object)index, true)[0] as ComboBox;
				CheckBox checkBox = this.Controls.Find("chkColumn" + (object)index, true)[0] as CheckBox;
				if ((comboBox.SelectedIndex == 4 || comboBox.SelectedIndex == 5) && checkBox.Checked)
					flag = true;
			}
			if (flag)
				return true;
			int num1 = (int)MessageBox.Show("حداقل یکی از ستونهای تاریخ میلادی یا شمسی باید انتخاب شده باشد");
			return false;
		}

		private void ProcessColumns() {
			StringBuilder stringBuilder = new StringBuilder();
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			for (int index = 1; index <= 15; ++index) {
				ComboBox comboBox = this.Controls.Find("cbxColumn" + (object)index, true)[0] as ComboBox;
				TextBox textBox = this.Controls.Find("txtHeader" + (object)index, true)[0] as TextBox;
				CheckBox checkBox = this.Controls.Find("chkColumn" + (object)index, true)[0] as CheckBox;
				stringBuilder.Append(index);
				stringBuilder.Append(',');
				stringBuilder.Append(comboBox.SelectedIndex);
				stringBuilder.Append(',');
				stringBuilder.Append(textBox.Text);
				stringBuilder.Append(',');
				stringBuilder.Append(checkBox.Checked ? "1" : "0");
				stringBuilder.Append('\n');
			}
			this.columnsCommaSeperated = stringBuilder.ToString();
			if (this.columnsCommaSeperated.Equals(FileService.ColumnsInfoInString())) {
				if (this.txtDelimiter.Text.Equals(settings.Delimeter.ToString())) {
					this.SaveSettings();
				} else {
					int num = (int)new ConfirmationForm("فیلد جدا کننده تغییر کرده است، در صورت ادامه، فایل های خروجی موجود\n با نامی جدید شامل تاریخ و ساعت فعلی ذخیره خواهند شد. آیا می خواهید ادامه دهید؟").ShowDialog();
					Application.DoEvents();
					if (!MainForm.ConfirmationResult)
						return;
					MainForm.ConfirmationResult = false;
					FileService.RenameOutputFiles();
					this.SaveSettings();
				}
			} else {
				int num = (int)new ConfirmationForm("تنظیمات ستون ها تغییر کرده است، در صورت ادامه، فایل های خروجی موجود\n با نامی جدید شامل تاریخ و ساعت فعلی ذخیره خواهند شد. آیا می خواهید ادامه دهید؟").ShowDialog();
				Application.DoEvents();
				if (!MainForm.ConfirmationResult)
					return;
				MainForm.ConfirmationResult = false;
				FileService.RenameOutputFiles();
				this.SaveSettings();
			}
		}

		private void SaveSettings() {
			if (!this.ValidateFields())
				return;
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			settings.ExportDaysWithoutTrade = this.rbnYes.Checked;
			settings.ShowHeaders = this.chkShowHeaders.Checked;
			FileService.WriteColumnsInfo(this.columnsCommaSeperated);
			settings.ExcelOutput = !this.rbnCSV.Checked;
			settings.StorageLocation = this.txtStorageLocation.Text;
			settings.AdjustedStorageLocation = this.txtAdjustedStorageLocation.Text;
			settings.FileName = this.cbxFileName.SelectedIndex.ToString();
			settings.FileExtension = this.txtFileExtension.Text;
			settings.Encoding = this.cbxEncoding.SelectedIndex.ToString();
			settings.Delimeter = !string.IsNullOrEmpty(this.txtDelimiter.Text) ? this.txtDelimiter.Text[0] : ',';
			settings.StartDate = this.txtStartDate.Text;
			settings.Save();
			StaticData.FillStaticData();
			this.Close();
		}

		private void ResetSettings() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			settings.ExportDaysWithoutTrade = true;
			settings.AdjustPricesCondition = 0;
			settings.ShowHeaders = true;
			List<ColumnInfo> columnInfoList = FileService.DefaultColumnsInfo();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ColumnInfo columnInfo in columnInfoList) {
				stringBuilder.Append(columnInfo.Index);
				stringBuilder.Append(',');
				stringBuilder.Append((int)columnInfo.Type);
				stringBuilder.Append(',');
				stringBuilder.Append(columnInfo.Header);
				stringBuilder.Append(',');
				stringBuilder.Append(columnInfo.Visible ? "1" : "0");
				stringBuilder.Append('\n');
			}
			FileService.WriteColumnsInfo(stringBuilder.ToString());
			settings.StorageLocation = "";
			settings.AdjustedStorageLocation = "";
			settings.FileName = "0";
			settings.FileExtension = "csv";
			settings.Encoding = "0";
			settings.Delimeter = ',';
			settings.StartDate = "1380/01/01";
			settings.UseProxy = false;
			settings.IP = "";
			settings.Port = "";
			settings.UserName = "";
			settings.Password = "";
			settings.EnableDecompression = true;
			settings.UseWebService = true;
			settings.Save();
			StaticData.FillStaticData();
		}

		private void btnSystemProxy_Click(object sender, EventArgs e) {
			this.process.StartInfo = new ProcessStartInfo() {
				WindowStyle = ProcessWindowStyle.Hidden,
				FileName = "cmd.exe",
				Arguments = "/C rundll32.exe shell32.dll,Control_RunDLL inetcpl.cpl,,4"
			};
			this.process.Start();
			this.processKiller.Interval = 2000;
			this.processKiller.Tick += new EventHandler(this.processKiller_Tick);
			this.processKiller.Start();
			if (this.threadProxyLabels != null)
				return;
			this.threadProxyLabels = new Thread(new ThreadStart(this.ProxyLabelsRefresher));
			this.threadProxyLabels.IsBackground = true;
			this.threadProxyLabels.Priority = ThreadPriority.Lowest;
			this.threadProxyLabels.Start();
		}

		private void ProxyLabelsRefresher() {
			while (!this.stop) {
				this.GetSystemProxy();
				for (int index = 0; index < 20; ++index)
					Thread.Sleep(100);
			}
		}

		private void SettingsContainerForms_Leave(object sender, EventArgs e) {
			this.stop = true;
			if (this.threadProxyLabels != null)
				this.threadProxyLabels.Join();
			this.threadProxyLabels = (Thread)null;
		}

		private void rbnCSV_CheckedChanged(object sender, EventArgs e) {
			if (this.rbnCSV.Checked) {
				this.txtFileExtension.Enabled = true;
				this.cbxEncoding.Enabled = true;
				this.txtDelimiter.Enabled = true;
			} else {
				this.txtFileExtension.Enabled = false;
				this.cbxEncoding.Enabled = false;
				this.txtDelimiter.Enabled = false;
			}
		}

		private void processKiller_Tick(object sender, EventArgs e) {
			try {
				this.processKiller.Stop();
				this.process.Kill();
			} catch {
			}
		}

		private void AdjustedStorageLocation_Click(object sender, EventArgs e) {
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
				return;
			this.txtAdjustedStorageLocation.Text = folderBrowserDialog.SelectedPath;
		}

		private void btnClear_Click(object sender, EventArgs e) {
			int num = (int)new ConfirmationForm("در صورت تایید، کلیه فایلهای داخلی ذخیره شده حذف شده و برنامه برای ادامه کار\n نیاز به دریافت مجدد کلیه اطلاعات از سرور خواهد داشت. آیا مطمئنید؟ ").ShowDialog();
			Application.DoEvents();
			if (!MainForm.ConfirmationResult)
				return;
			MainForm.ConfirmationResult = false;
			FileService.EraseCurrentFiles();
			// ISSUE: object of a compiler-generated type is created
			new Settings() { LastInstrumentReceiveDate = 0 }.Save();
			StaticData.Instruments.Clear();
			this.mainForm.GlobalFilesClear = true;
			this.Close();
		}
	}
}
