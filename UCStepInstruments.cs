// Decompiled with JetBrains decompiler
// Type: TseClient.UCStepInstruments
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient
{
  public class UCStepInstruments : UserControl
  {
    private bool isVisual = true;
    private MainForm owner;
    private bool goNextPage;
    private IContainer components;
    private Panel panelUCInstrumentsContainer;
    private Label lblUpdateError;
    private Button btnStep1Reserve;
    private Button btnStep1Next;
    private Label lblHelp;
    private Label lblConnecting;
    private Button btnSettings;

    public UCStepInstruments(MainForm owner)
    {
      this.owner = owner;
      this.InitializeComponent();
    }

    public UCStepInstruments()
    {
      this.isVisual = false;
      this.InitializeComponent();
    }

    private void UCStepInstruments_Load(object sender, EventArgs e)
    {
      if (this.UpdateInstruments())
      {
        this.goNextPage = true;
        Label lblUpdateError = this.lblUpdateError;
        lblUpdateError.Visible = false;
        this.panelUCInstrumentsContainer.Controls.Clear();
        UCInstruments ucInstruments = new UCInstruments();
        this.panelUCInstrumentsContainer.Controls.Add((Control) lblUpdateError);
        this.panelUCInstrumentsContainer.Controls.Add((Control) ucInstruments);
        this.lblHelp.Visible = true;
      }
      else
      {
        this.goNextPage = false;
        this.lblUpdateError.Visible = true;
        this.btnStep1Reserve.Visible = true;
        this.btnSettings.Visible = true;
      }
      this.lblConnecting.Visible = false;
      this.btnStep1Next.Enabled = true;
    }

    public bool UpdateInstruments()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string str1 = FileService.ReadVersionFileContent();
      if (this.isVisual)
      {
        if (!StaticData.Version.Equals(str1) && StaticData.Instruments.Count != 0)
        {
          int num = (int) new ConfirmationForm("ویرایش جدید نرم افزار نصب گردید. بانک اطلاعاتی قیمت ها  که توسط نرم افزار \nویرایش قبلی ساخته شده موجود می باشد. در صورتی که با داده های قبلی مشکل دارید\n( و یا کامل نیست ) اطلاعات را با انتخاب دکمه «بلی» حذف کنید.\nدر غیر اینصورت کلید «خیر» را انتخاب کنید.\nتوجه : شما در هر زمان که مایل باشید می توانید بانک اطلاعاتی را از طریق کلید \n«پاک کردن اطلاعات» در بخش تنظیمات حذف کرده و مجددا داده های جدید را دریافت کنید.\n", "شما می توانید در محیط Command Prompt دستور TseClient.exe fast را اجرا کنید\nدر اینصورت کلیه عملیات بروزرسانی و ایجاد فایلهای خروجی به صورت خودکار انجام خواهد شد.\n\nهمچنین امکان ایجاد خروجی تعدیل شده فقط با استفاده از افزایش سرمایه\n به امکانات نرم افزار اضافه شده است").ShowDialog();
          Application.DoEvents();
          if (MainForm.ConfirmationResult)
          {
            MainForm.ConfirmationResult = false;
            FileService.EraseCurrentFiles();
            settings.LastInstrumentReceiveDate = 0;
            settings.Save();
            StaticData.Instruments.Clear();
          }
          FileService.WriteVersionFileContent(StaticData.Version);
        }
        else if (StaticData.Instruments.Count == 0)
          FileService.WriteVersionFileContent(StaticData.Version);
      }
      if (Utility.ConvertDateTimeToGregorianInt(DateTime.Now) == settings.LastInstrumentReceiveDate)
      {
        if (Utility.ConvertDateTimeToGregorianInt(DateTime.Now) != 20140217)
          return true;
      }
      try
      {
        int lastDEven = 0;
        foreach (InstrumentInfo instrument in StaticData.Instruments)
        {
          if (instrument.DEven > lastDEven)
            lastDEven = instrument.DEven;
        }
        long lastId = 0;
        foreach (TseShareInfo tseShare in StaticData.TseShares)
        {
          if (tseShare.Idn > lastId)
            lastId = tseShare.Idn;
        }
        Application.DoEvents();
        string str2 = ServerMethods.InstrumentAndShare(lastDEven, lastId);
        string str3 = str2.Split('@')[0];
        if (!string.IsNullOrEmpty(str3))
        {
          if (str3.Equals("*"))
          {
            if (this.isVisual)
            {
              this.lblUpdateError.Text = "بروز رسانی اطلاعات در حد فاصل ساعت هشت صبح تا یک بعد از ظهر روزهای شنبه تا چهارشنبه امکان پذیر نمی باشد. \nجهت مشاهده لیست فعلی نمادها روی دکمه مرحله بعد کلیک کنید.";
              this.lblUpdateError.Left = (this.panelUCInstrumentsContainer.Width - this.lblUpdateError.Width) / 2;
            }
            return false;
          }
          string str4 = str3;
          char[] chArray = new char[1]{ ';' };
          foreach (string str5 in str4.Split(chArray))
          {
            string[] row = str5.Split(',');
            int index = StaticData.Instruments.FindIndex((Predicate<InstrumentInfo>) (p => p.InsCode == Convert.ToInt64(row[0])));
            if (index < 0)
            {
              StaticData.Instruments.Add(new InstrumentInfo()
              {
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
            }
            else
            {
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
        string str6 = str2.Split('@')[1];
        if (!string.IsNullOrEmpty(str6))
        {
          string str4 = str6;
          char[] chArray = new char[1]{ ';' };
          foreach (string str5 in str4.Split(chArray))
          {
            string[] row = str5.Split(',');
            int index = StaticData.TseShares.FindIndex((Predicate<TseShareInfo>) (p => p.Idn == Convert.ToInt64(row[0])));
            if (index < 0)
            {
              StaticData.TseShares.Add(new TseShareInfo()
              {
                Idn = Convert.ToInt64(row[0].ToString()),
                InsCode = Convert.ToInt64(row[1].ToString()),
                DEven = Convert.ToInt32(row[2].ToString()),
                NumberOfShareNew = Convert.ToDecimal(row[3].ToString()),
                NumberOfShareOld = Convert.ToDecimal(row[4].ToString())
              });
            }
            else
            {
              StaticData.TseShares[index].InsCode = Convert.ToInt64(row[1].ToString());
              StaticData.TseShares[index].DEven = Convert.ToInt32(row[2].ToString());
              StaticData.TseShares[index].NumberOfShareNew = Convert.ToDecimal(row[3].ToString());
              StaticData.TseShares[index].NumberOfShareOld = Convert.ToDecimal(row[4].ToString());
            }
          }
          FileService.WriteTseShares();
        }
        return true;
      }
      catch (Exception ex)
      {
        if (ex.Message.Contains("The magic number in GZip header is not correct") && settings.EnableDecompression)
        {
          settings.EnableDecompression = false;
          settings.Save();
          if (this.isVisual)
            this.owner.TabSwitcher(Tabs.Instruments);
          return false;
        }
        if (this.isVisual)
          this.lblUpdateError.Text += ServerMethods.LogError("Instrument", ex);
        try
        {
          if (FileService.LogErrorFile("[ Instrument (" + StaticData.Version + ") (compression:" + settings.EnableDecompression.ToString() + ") ] " + ex.Message + "(" + (ex.InnerException != null ? ex.InnerException.Message ?? "" : "") + ")") == -1)
          {
            if (this.isVisual)
            {
              int num = (int) MessageBox.Show("مقدار فیلد محل ذخیره فایل ها صحیح نمی باشد ");
            }
          }
        }
        catch
        {
        }
        Application.DoEvents();
        return false;
      }
    }

    private void btnStep1Reserve_Click(object sender, EventArgs e)
    {
      this.owner.TabSwitcher(Tabs.Instruments);
    }

    private void btnStep1Next_Click(object sender, EventArgs e)
    {
      if (this.goNextPage)
      {
        this.owner.TabSwitcher(Tabs.Settings);
      }
      else
      {
        Label lblUpdateError = this.lblUpdateError;
        lblUpdateError.Visible = false;
        this.panelUCInstrumentsContainer.Controls.Clear();
        UCInstruments ucInstruments = new UCInstruments();
        this.panelUCInstrumentsContainer.Controls.Add((Control) lblUpdateError);
        this.panelUCInstrumentsContainer.Controls.Add((Control) ucInstruments);
        this.lblHelp.Visible = true;
        this.btnSettings.Visible = false;
        this.btnStep1Reserve.Text = "مرحله قبل";
        this.goNextPage = true;
      }
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
      int num = (int) new SettingsContainerForms(this.owner).ShowDialog();
      if (!this.owner.GlobalFilesClear)
        return;
      this.owner.GlobalFilesClear = false;
      this.owner.TabSwitcher(Tabs.Instruments);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panelUCInstrumentsContainer = new Panel();
      this.lblConnecting = new Label();
      this.lblUpdateError = new Label();
      this.btnStep1Reserve = new Button();
      this.btnStep1Next = new Button();
      this.lblHelp = new Label();
      this.btnSettings = new Button();
      this.panelUCInstrumentsContainer.SuspendLayout();
      this.SuspendLayout();
      this.panelUCInstrumentsContainer.Controls.Add((Control) this.lblConnecting);
      this.panelUCInstrumentsContainer.Controls.Add((Control) this.lblUpdateError);
      this.panelUCInstrumentsContainer.Location = new Point(8, 22);
      this.panelUCInstrumentsContainer.Name = "panelUCInstrumentsContainer";
      this.panelUCInstrumentsContainer.Size = new Size(777, 324);
      this.panelUCInstrumentsContainer.TabIndex = 7;
      this.lblConnecting.AutoSize = true;
      this.lblConnecting.Location = new Point(565, 26);
      this.lblConnecting.Name = "lblConnecting";
      this.lblConnecting.Size = new Size(172, 13);
      this.lblConnecting.TabIndex = 1;
      this.lblConnecting.Text = "تلاش برای برقراری ارتباط با سرور ...";
      this.lblUpdateError.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblUpdateError.AutoSize = true;
      this.lblUpdateError.ForeColor = Color.Red;
      this.lblUpdateError.Location = new Point(94, 148);
      this.lblUpdateError.Name = "lblUpdateError";
      this.lblUpdateError.RightToLeft = RightToLeft.Yes;
      this.lblUpdateError.Size = new Size(607, 26);
      this.lblUpdateError.TabIndex = 0;
      this.lblUpdateError.Text = "عملیات ارتباط با سرور و بروز رسانی لیست نمادها ناموفق بود. جهت مشاهده لیست فعلی نمادها روی دکمه \"مرحله بعد\" کلیک کنید.\r\n در صورت نیاز به فعال کردن پراکسی به بخش تنظیمات مراجعه کنید";
      this.lblUpdateError.Visible = false;
      this.btnStep1Reserve.Location = new Point(102, 352);
      this.btnStep1Reserve.Name = "btnStep1Reserve";
      this.btnStep1Reserve.Size = new Size(86, 26);
      this.btnStep1Reserve.TabIndex = 6;
      this.btnStep1Reserve.Text = "تلاش مجدد";
      this.btnStep1Reserve.UseVisualStyleBackColor = true;
      this.btnStep1Reserve.Visible = false;
      this.btnStep1Reserve.Click += new EventHandler(this.btnStep1Reserve_Click);
      this.btnStep1Next.Enabled = false;
      this.btnStep1Next.Location = new Point(10, 352);
      this.btnStep1Next.Name = "btnStep1Next";
      this.btnStep1Next.Size = new Size(86, 26);
      this.btnStep1Next.TabIndex = 5;
      this.btnStep1Next.Text = "مرحله بعد";
      this.btnStep1Next.UseVisualStyleBackColor = true;
      this.btnStep1Next.Click += new EventHandler(this.btnStep1Next_Click);
      this.lblHelp.AutoSize = true;
      this.lblHelp.Location = new Point(382, 352);
      this.lblHelp.Name = "lblHelp";
      this.lblHelp.Size = new Size(406, 26);
      this.lblHelp.TabIndex = 8;
      this.lblHelp.Text = "برای دریافت خروجی اطلاعات نمادهای مورد نظرتان، آنها را از لیست سمت چپ پیدا کرده \r\nو با دبل کلیک در لیست سمت راست ( نمادهای انتخاب شده ) قراردهید.";
      this.lblHelp.Visible = false;
      this.btnSettings.Location = new Point(194, 352);
      this.btnSettings.Name = "btnSettings";
      this.btnSettings.Size = new Size(86, 26);
      this.btnSettings.TabIndex = 9;
      this.btnSettings.Text = "تنظیمات";
      this.btnSettings.UseVisualStyleBackColor = true;
      this.btnSettings.Visible = false;
      this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.btnSettings);
      this.Controls.Add((Control) this.lblHelp);
      this.Controls.Add((Control) this.panelUCInstrumentsContainer);
      this.Controls.Add((Control) this.btnStep1Reserve);
      this.Controls.Add((Control) this.btnStep1Next);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (UCStepInstruments);
      this.RightToLeft = RightToLeft.Yes;
      this.Size = new Size(800, 420);
      this.Load += new EventHandler(this.UCStepInstruments_Load);
      this.panelUCInstrumentsContainer.ResumeLayout(false);
      this.panelUCInstrumentsContainer.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
