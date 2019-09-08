// Decompiled with JetBrains decompiler
// Type: TseClient.ConfirmationForm
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TseClient
{
  public class ConfirmationForm : Form
  {
    private IContainer components;
    private Button btnNo;
    private Button btnYes;
    private Label lblMessage;
    private Label lblMessage2;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConfirmationForm));
      this.btnNo = new Button();
      this.btnYes = new Button();
      this.lblMessage = new Label();
      this.lblMessage2 = new Label();
      this.SuspendLayout();
      this.btnNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnNo.Location = new Point(93, 86);
      this.btnNo.Name = "btnNo";
      this.btnNo.Size = new Size(75, 23);
      this.btnNo.TabIndex = 0;
      this.btnNo.Text = "خیر";
      this.btnNo.UseVisualStyleBackColor = true;
      this.btnNo.Click += new EventHandler(this.btnNo_Click);
      this.btnYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnYes.Location = new Point(12, 86);
      this.btnYes.Name = "btnYes";
      this.btnYes.Size = new Size(75, 23);
      this.btnYes.TabIndex = 1;
      this.btnYes.Text = "بله";
      this.btnYes.UseVisualStyleBackColor = true;
      this.btnYes.Click += new EventHandler(this.btnYes_Click);
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new Point(223, 38);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new Size(35, 13);
      this.lblMessage.TabIndex = 2;
      this.lblMessage.Text = "label1";
      this.lblMessage2.AutoSize = true;
      this.lblMessage2.ForeColor = Color.Red;
      this.lblMessage2.Location = new Point(232, 92);
      this.lblMessage2.Name = "lblMessage2";
      this.lblMessage2.Size = new Size(0, 13);
      this.lblMessage2.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(452, 114);
      this.Controls.Add((Control) this.lblMessage2);
      this.Controls.Add((Control) this.lblMessage);
      this.Controls.Add((Control) this.btnYes);
      this.Controls.Add((Control) this.btnNo);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximumSize = new Size(468, 152);
      this.MinimumSize = new Size(468, 152);
      this.Name = nameof (ConfirmationForm);
      this.RightToLeft = RightToLeft.Yes;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "اخطار!";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public ConfirmationForm(string message)
    {
      this.InitializeComponent();
      this.lblMessage.Text = message;
      this.lblMessage.Left = (this.Width - this.lblMessage.Width) / 2;
      this.MinimumSize = new Size(this.Width, this.Height + this.lblMessage.Height);
      this.MaximumSize = new Size(this.Width, this.Height + this.lblMessage.Height);
    }

    public ConfirmationForm(string message, string message2)
    {
      this.InitializeComponent();
      this.lblMessage.Text = message;
      this.lblMessage.Left = (this.Width - this.lblMessage.Width) / 2;
      this.lblMessage2.Text = message2;
      this.lblMessage2.Top = this.lblMessage.Top + this.lblMessage.Height + 20;
      this.lblMessage2.Left = this.Width - (this.Width - (this.lblMessage.Left + this.lblMessage.Width) + this.lblMessage2.Width);
      this.MinimumSize = new Size(this.Width, this.Height + this.lblMessage.Height + this.lblMessage2.Height + 20);
      this.MaximumSize = new Size(this.Width, this.Height + this.lblMessage.Height + this.lblMessage2.Height + 20);
    }

    private void btnNo_Click(object sender, EventArgs e)
    {
      MainForm.ConfirmationResult = false;
      this.Close();
    }

    private void btnYes_Click(object sender, EventArgs e)
    {
      MainForm.ConfirmationResult = true;
      this.Close();
    }
  }
}
