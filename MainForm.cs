// Decompiled with JetBrains decompiler
// Type: TseClient.MainForm
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace TseClient
{
  public class MainForm : Form
  {
    private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
    public bool GlobalFilesClear;
    public static bool ConfirmationResult;
    private IContainer components;
    private FolderBrowserDialog folderBrowserDialogStorageLocation;
    private Label lblWait;

    public MainForm()
    {
      ServicePointManager.Expect100Continue = true;
      this.InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      this.t.Interval = 1000;
      this.t.Tick += new EventHandler(this.t_Tick);
      this.t.Start();
    }

    private void t_Tick(object sender, EventArgs e)
    {
      this.t.Stop();
      StaticData.FillStaticData();
      this.TabSwitcher(Tabs.Instruments);
    }

    public void TabSwitcher(Tabs tab)
    {
      UserControl userControl1 = (UserControl) null;
      switch (tab)
      {
        case Tabs.Instruments:
          this.Controls.Clear();
          userControl1 = (UserControl) null;
          UserControl userControl2 = (UserControl) new UCStepInstruments(this);
          userControl2.Dock = DockStyle.Fill;
          this.Controls.Add((Control) userControl2);
          break;
        case Tabs.Settings:
          this.Controls.Clear();
          userControl1 = (UserControl) null;
          Application.DoEvents();
          UserControl userControl3 = (UserControl) new UCStepSettings(this);
          userControl3.Dock = DockStyle.Fill;
          this.Controls.Add((Control) userControl3);
          break;
        case Tabs.Update:
          this.Controls.Clear();
          userControl1 = (UserControl) null;
          UserControl userControl4 = (UserControl) new UCStepUpdate(this);
          userControl4.Dock = DockStyle.Fill;
          this.Controls.Add((Control) userControl4);
          break;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.folderBrowserDialogStorageLocation = new FolderBrowserDialog();
      this.lblWait = new Label();
      this.SuspendLayout();
      this.lblWait.AutoSize = true;
      this.lblWait.Location = new Point(329, 176);
      this.lblWait.Name = "lblWait";
      this.lblWait.RightToLeft = RightToLeft.Yes;
      this.lblWait.Size = new Size(85, 13);
      this.lblWait.TabIndex = 2;
      this.lblWait.Text = "لطفا صبر کنید ...";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(794, 412);
      this.Controls.Add((Control) this.lblWait);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximumSize = new Size(810, 450);
      this.MinimumSize = new Size(810, 450);
      this.Name = nameof (MainForm);
      this.Text = "TseClient 2.0";
      this.Load += new EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
