// Decompiled with JetBrains decompiler
// Type: TseClient.UCStepSettings
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient
{
  public class UCStepSettings : UserControl
  {
    private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    private IContainer components;
    private Button btnStep2Next;
    private GroupBox groupBoxContainer;
    private Button btnStep2Back;
    private Button btnSettings;
    private Label label1;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label lblProxy;
    private Label lblStorageLocation;
    private Label lblExportDaysWithoutTrade;
    private TextBox txtSelectedColumns;
    private Label label5;
    private Label lblWait;
    private Label lblFileType;
    private Label label6;
    private Label lblAdjustedStorageLocation;
    private Label label8;
    private MainForm owner;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btnStep2Next = new Button();
      this.groupBoxContainer = new GroupBox();
      this.lblAdjustedStorageLocation = new Label();
      this.label8 = new Label();
      this.lblFileType = new Label();
      this.label6 = new Label();
      this.lblWait = new Label();
      this.txtSelectedColumns = new TextBox();
      this.lblProxy = new Label();
      this.label4 = new Label();
      this.lblStorageLocation = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.lblExportDaysWithoutTrade = new Label();
      this.label1 = new Label();
      this.btnStep2Back = new Button();
      this.btnSettings = new Button();
      this.label5 = new Label();
      this.groupBoxContainer.SuspendLayout();
      this.SuspendLayout();
      this.btnStep2Next.Enabled = false;
      this.btnStep2Next.Location = new Point(10, 352);
      this.btnStep2Next.Name = "btnStep2Next";
      this.btnStep2Next.Size = new Size(86, 26);
      this.btnStep2Next.TabIndex = 4;
      this.btnStep2Next.Text = "مرحله بعد";
      this.btnStep2Next.UseVisualStyleBackColor = true;
      this.btnStep2Next.Click += new EventHandler(this.btnStep2Next_Click);
      this.groupBoxContainer.Controls.Add((Control) this.lblAdjustedStorageLocation);
      this.groupBoxContainer.Controls.Add((Control) this.label8);
      this.groupBoxContainer.Controls.Add((Control) this.lblFileType);
      this.groupBoxContainer.Controls.Add((Control) this.label6);
      this.groupBoxContainer.Controls.Add((Control) this.lblWait);
      this.groupBoxContainer.Controls.Add((Control) this.txtSelectedColumns);
      this.groupBoxContainer.Controls.Add((Control) this.lblProxy);
      this.groupBoxContainer.Controls.Add((Control) this.label4);
      this.groupBoxContainer.Controls.Add((Control) this.lblStorageLocation);
      this.groupBoxContainer.Controls.Add((Control) this.label3);
      this.groupBoxContainer.Controls.Add((Control) this.label2);
      this.groupBoxContainer.Controls.Add((Control) this.lblExportDaysWithoutTrade);
      this.groupBoxContainer.Controls.Add((Control) this.label1);
      this.groupBoxContainer.Location = new Point(10, 22);
      this.groupBoxContainer.Name = "groupBoxContainer";
      this.groupBoxContainer.Size = new Size(773, 324);
      this.groupBoxContainer.TabIndex = 3;
      this.groupBoxContainer.TabStop = false;
      this.groupBoxContainer.Text = "نمایش تنظیمات";
      this.lblAdjustedStorageLocation.AutoSize = true;
      this.lblAdjustedStorageLocation.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblAdjustedStorageLocation.Location = new Point(576, 120);
      this.lblAdjustedStorageLocation.Name = "lblAdjustedStorageLocation";
      this.lblAdjustedStorageLocation.Size = new Size(12, 13);
      this.lblAdjustedStorageLocation.TabIndex = 7;
      this.lblAdjustedStorageLocation.Text = "-";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(594, 120);
      this.label8.Name = "label8";
      this.label8.Size = new Size(162, 13);
      this.label8.TabIndex = 6;
      this.label8.Text = "- محل ذخیره فایلهای تعدیل شده :";
      this.lblFileType.AutoSize = true;
      this.lblFileType.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblFileType.Location = new Point(658, 200);
      this.lblFileType.Name = "lblFileType";
      this.lblFileType.Size = new Size(12, 13);
      this.lblFileType.TabIndex = 5;
      this.lblFileType.Text = "-";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(678, 200);
      this.label6.Name = "label6";
      this.label6.Size = new Size(74, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "- نوع خروجی :";
      this.lblWait.AutoSize = true;
      this.lblWait.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblWait.Location = new Point(370, 100);
      this.lblWait.Name = "lblWait";
      this.lblWait.Size = new Size(120, 16);
      this.lblWait.TabIndex = 3;
      this.lblWait.Text = "در حال بارگذاری ...";
      this.txtSelectedColumns.BorderStyle = BorderStyle.None;
      this.txtSelectedColumns.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.txtSelectedColumns.Location = new Point(119, 240);
      this.txtSelectedColumns.Multiline = true;
      this.txtSelectedColumns.Name = "txtSelectedColumns";
      this.txtSelectedColumns.ReadOnly = true;
      this.txtSelectedColumns.Size = new Size(511, 53);
      this.txtSelectedColumns.TabIndex = 2;
      this.txtSelectedColumns.Text = "-";
      this.lblProxy.AutoSize = true;
      this.lblProxy.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblProxy.Location = new Point(678, 160);
      this.lblProxy.Name = "lblProxy";
      this.lblProxy.Size = new Size(12, 13);
      this.lblProxy.TabIndex = 1;
      this.lblProxy.Text = "-";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(696, 160);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "- پراکسی :";
      this.lblStorageLocation.AutoSize = true;
      this.lblStorageLocation.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblStorageLocation.Location = new Point(640, 80);
      this.lblStorageLocation.Name = "lblStorageLocation";
      this.lblStorageLocation.Size = new Size(12, 13);
      this.lblStorageLocation.TabIndex = 1;
      this.lblStorageLocation.Text = "-";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(658, 80);
      this.label3.Name = "label3";
      this.label3.Size = new Size(98, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "- محل ذخیره فایلها :";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(636, 240);
      this.label2.Name = "label2";
      this.label2.Size = new Size(120, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "- ستونهای انتخاب شده :";
      this.lblExportDaysWithoutTrade.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblExportDaysWithoutTrade.AutoSize = true;
      this.lblExportDaysWithoutTrade.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 178);
      this.lblExportDaysWithoutTrade.Location = new Point(592, 40);
      this.lblExportDaysWithoutTrade.Name = "lblExportDaysWithoutTrade";
      this.lblExportDaysWithoutTrade.Size = new Size(12, 13);
      this.lblExportDaysWithoutTrade.TabIndex = 0;
      this.lblExportDaysWithoutTrade.Text = "-";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(610, 40);
      this.label1.Name = "label1";
      this.label1.Size = new Size(146, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "- نمایش روزهای بدون معامله :";
      this.btnStep2Back.Enabled = false;
      this.btnStep2Back.Location = new Point(102, 352);
      this.btnStep2Back.Name = "btnStep2Back";
      this.btnStep2Back.Size = new Size(86, 26);
      this.btnStep2Back.TabIndex = 5;
      this.btnStep2Back.Text = "مرحله قبل";
      this.btnStep2Back.UseVisualStyleBackColor = true;
      this.btnStep2Back.Click += new EventHandler(this.btnStep2Back_Click);
      this.btnSettings.Enabled = false;
      this.btnSettings.Location = new Point(194, 352);
      this.btnSettings.Name = "btnSettings";
      this.btnSettings.Size = new Size(86, 26);
      this.btnSettings.TabIndex = 6;
      this.btnSettings.Text = "تغییر تنظیمات";
      this.btnSettings.UseVisualStyleBackColor = true;
      this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(445, 359);
      this.label5.Name = "label5";
      this.label5.Size = new Size(341, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "برای عوض کردن تنظیمات برنامه، بر روی دکمه \"تغییر تنظیمات\" کلیک کنید.";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.btnSettings);
      this.Controls.Add((Control) this.btnStep2Back);
      this.Controls.Add((Control) this.btnStep2Next);
      this.Controls.Add((Control) this.groupBoxContainer);
      this.Controls.Add((Control) this.label5);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 178);
      this.Name = nameof (UCStepSettings);
      this.RightToLeft = RightToLeft.Yes;
      this.Size = new Size(800, 420);
      this.Load += new EventHandler(this.UCStepSettings_Load);
      this.groupBoxContainer.ResumeLayout(false);
      this.groupBoxContainer.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public UCStepSettings(MainForm owner)
    {
      this.owner = owner;
      this.InitializeComponent();
    }

    private void UCStepSettings_Load(object sender, EventArgs e)
    {
      this.groupBoxContainer.Text = "نمایش تنظیمات ( در حال بارگذاری ... )";
      Application.DoEvents();
      this.t.Interval = 500;
      this.t.Tick += new EventHandler(this.t_Tick);
      this.t.Start();
    }

    private void t_Tick(object sender, EventArgs e)
    {
      this.t.Stop();
      this.FillLabels();
      this.btnSettings.Enabled = true;
      this.btnStep2Back.Enabled = true;
      this.btnStep2Next.Enabled = true;
    }

    private void FillLabels()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      this.lblExportDaysWithoutTrade.Left += this.lblExportDaysWithoutTrade.Width;
      this.lblExportDaysWithoutTrade.Text = settings.ExportDaysWithoutTrade ? "بلی" : "خیر";
      this.lblExportDaysWithoutTrade.Left -= this.lblExportDaysWithoutTrade.Width;
      this.lblStorageLocation.Left += this.lblStorageLocation.Width;
      this.lblStorageLocation.Text = settings.StorageLocation;
      this.lblStorageLocation.Left -= this.lblStorageLocation.Width;
      this.lblAdjustedStorageLocation.Left += this.lblAdjustedStorageLocation.Width;
      this.lblAdjustedStorageLocation.Text = settings.AdjustedStorageLocation;
      this.lblAdjustedStorageLocation.Left -= this.lblAdjustedStorageLocation.Width;
      this.lblFileType.Left += this.lblFileType.Width;
      this.lblFileType.Text = settings.ExcelOutput ? "Excel" : "CSV";
      this.lblFileType.Left -= this.lblFileType.Width;
      this.lblProxy.Left += this.lblProxy.Width;
      try
      {
        IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
        string str1 = defaultWebProxy.GetProxy(new Uri("http://www.tsetmc.com")).Host.ToString();
        string str2 = defaultWebProxy.GetProxy(new Uri("http://www.tsetmc.com")).Port.ToString();
        if (str1.Equals("www.tsetmc.com") && str2.Equals("80"))
          this.lblProxy.Text = "ندارد";
        else
          this.lblProxy.Text = "دارد";
      }
      catch
      {
        this.lblProxy.Text = "خطا در دریافت اطلاعات پراکسی";
      }
      this.lblProxy.Left -= this.lblProxy.Width;
      this.txtSelectedColumns.Text = "";
      foreach (ColumnInfo columnInfo in StaticData.ColumnsInfo)
      {
        if (columnInfo.Visible)
        {
          TextBox txtSelectedColumns = this.txtSelectedColumns;
          txtSelectedColumns.Text = txtSelectedColumns.Text + FormFillMethods.GetColumnHeader(columnInfo.Type) + ",";
        }
      }
      this.txtSelectedColumns.Text = this.txtSelectedColumns.Text.Substring(0, this.txtSelectedColumns.Text.Length - 1);
      this.groupBoxContainer.Text = "نمایش تنظیمات";
      this.lblWait.Visible = false;
    }

    private void btnStep2Next_Click(object sender, EventArgs e)
    {
      this.owner.TabSwitcher(Tabs.Update);
    }

    private void btnStep2Back_Click(object sender, EventArgs e)
    {
      this.owner.TabSwitcher(Tabs.Instruments);
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
      int num = (int) new SettingsContainerForms(this.owner).ShowDialog();
      this.FillLabels();
      if (!this.owner.GlobalFilesClear)
        return;
      this.owner.GlobalFilesClear = false;
      this.owner.TabSwitcher(Tabs.Instruments);
    }
  }
}
