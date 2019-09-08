// Decompiled with JetBrains decompiler
// Type: TseClient.FileService
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TseClient.Properties;

namespace TseClient
{
  public class FileService
  {
    public static void CheckAppFolder()
    {
      if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) || !Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files"))
      {
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files");
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments");
        foreach (string file in Directory.GetFiles("Files"))
          File.Copy(file, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\" + Path.GetFileName(file));
        if (Directory.Exists("Files\\Instruments"))
        {
          foreach (string file in Directory.GetFiles("Files\\Instruments"))
            File.Copy(file, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + Path.GetFileName(file));
        }
      }
      foreach (string file in Directory.GetFiles("Files"))
      {
        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\" + Path.GetFileName(file)))
          File.Copy(file, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\" + Path.GetFileName(file));
      }
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      if (!string.IsNullOrEmpty(settings.StorageLocation))
      {
        if (FileService.HasAccessToWrite(settings.StorageLocation))
          goto label_21;
      }
      try
      {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        if (!Directory.Exists(folderPath + "\\TseClient 2.0"))
          Directory.CreateDirectory(folderPath + "\\TseClient 2.0");
        if (!FileService.HasAccessToWrite(folderPath + "\\TseClient 2.0"))
          throw new Exception("Access to Storage Location denied");
        settings.StorageLocation = folderPath + "\\TseClient 2.0";
        settings.Save();
      }
      catch
      {
      }
label_21:
      if (!string.IsNullOrEmpty(settings.AdjustedStorageLocation))
      {
        if (FileService.HasAccessToWrite(settings.AdjustedStorageLocation))
          return;
      }
      try
      {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        if (!Directory.Exists(folderPath + "\\TseClient 2.0\\Adjusted"))
          Directory.CreateDirectory(folderPath + "\\TseClient 2.0\\Adjusted");
        if (!FileService.HasAccessToWrite(folderPath + "\\TseClient 2.0\\Adjusted"))
          throw new Exception("Access to Storage Location denied");
        settings.AdjustedStorageLocation = folderPath + "\\TseClient 2.0\\Adjusted";
        settings.Save();
      }
      catch
      {
      }
    }

    public static bool HasAccessToWrite(string path)
    {
      try
      {
        using (File.Create(Path.Combine(path, "Access.txt"), 1, FileOptions.DeleteOnClose))
          ;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static List<ColumnInfo> ColumnsInfo()
    {
      return FileService.ColumnsInfo("Columns.csv");
    }

    public static List<ColumnInfo> DefaultColumnsInfo()
    {
      return FileService.ColumnsInfo("DeafultColumns.csv");
    }

    public static List<ColumnInfo> ColumnsInfo(string fileName)
    {
      FileService.CheckAppFolder();
      List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\" + fileName)))
        {
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split(',');
            columnInfoList.Add(new ColumnInfo()
            {
              Index = Convert.ToInt32(strArray[0].ToString()),
              Type = (ColumnType) Enum.Parse(typeof (ColumnType), strArray[1].ToString()),
              Header = strArray[2].ToString(),
              Visible = strArray[3].ToString().Equals("1")
            });
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return columnInfoList;
    }

    public static string ColumnsInfoInString()
    {
      FileService.CheckAppFolder();
      string str = "Columns.csv";
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\" + str)))
        {
          while (!streamReader.EndOfStream)
          {
            stringBuilder.Append(streamReader.ReadLine());
            stringBuilder.Append('\n');
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return stringBuilder.ToString();
    }

    public static void WriteColumnsInfo(string input)
    {
      FileService.CheckAppFolder();
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Columns.csv"))
      {
        text.Write(input);
        text.Flush();
      }
    }

    public static List<InstrumentInfo> Instruments()
    {
      FileService.CheckAppFolder();
      List<InstrumentInfo> instrumentInfoList = new List<InstrumentInfo>();
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments.csv")))
        {
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split(',');
            instrumentInfoList.Add(new InstrumentInfo()
            {
              InsCode = Convert.ToInt64(strArray[0].ToString()),
              InstrumentID = strArray[1].ToString(),
              LatinSymbol = strArray[2].ToString(),
              LatinName = strArray[3].ToString(),
              CompanyCode = strArray[4].ToString(),
              Symbol = strArray[5].ToString(),
              Name = strArray[6].ToString(),
              CIsin = strArray[7].ToString(),
              DEven = Convert.ToInt32(strArray[8].ToString()),
              Flow = Convert.ToByte(strArray[9].ToString()),
              LSoc30 = strArray[10].ToString(),
              CGdSVal = strArray[11].ToString(),
              CGrValCot = strArray[12].ToString(),
              YMarNSC = strArray[13].ToString(),
              CComVal = strArray[14].ToString(),
              CSecVal = strArray[15].ToString(),
              CSoSecVal = strArray[16].ToString(),
              YVal = strArray[17].ToString()
            });
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return instrumentInfoList;
    }

    public static void WriteInstruments()
    {
      FileService.CheckAppFolder();
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments.csv"))
      {
        foreach (InstrumentInfo instrument in StaticData.Instruments)
        {
          text.Write(instrument.InsCode);
          text.Write(',');
          text.Write(instrument.InstrumentID);
          text.Write(',');
          text.Write(instrument.LatinSymbol);
          text.Write(',');
          text.Write(instrument.LatinName);
          text.Write(',');
          text.Write(instrument.CompanyCode);
          text.Write(',');
          text.Write(instrument.Symbol);
          text.Write(',');
          text.Write(instrument.Name);
          text.Write(',');
          text.Write(instrument.CIsin);
          text.Write(',');
          text.Write(instrument.DEven);
          text.Write(',');
          text.Write((int) instrument.Flow);
          text.Write(',');
          text.Write(instrument.LSoc30);
          text.Write(',');
          text.Write(instrument.CGdSVal);
          text.Write(',');
          text.Write(instrument.CGrValCot);
          text.Write(',');
          text.Write(instrument.YMarNSC);
          text.Write(',');
          text.Write(instrument.CComVal);
          text.Write(',');
          text.Write(instrument.CSecVal);
          text.Write(',');
          text.Write(instrument.CSoSecVal);
          text.Write(',');
          text.Write(instrument.YVal);
          text.Write('\n');
        }
        text.Flush();
      }
    }

    public static void CopyInstrumentsToOutput()
    {
      FileService.CheckAppFolder();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string str = settings.StorageLocation;
      if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
        str = settings.AdjustedStorageLocation;
      using (TextWriter text = (TextWriter) File.CreateText(str + "\\Instruments." + settings.FileExtension))
      {
        text.Write("InsCode");
        text.Write(',');
        text.Write("InstrumentID");
        text.Write(',');
        text.Write("CValMne");
        text.Write(',');
        text.Write("LVal18");
        text.Write(',');
        text.Write("CSocCSAC");
        text.Write(',');
        text.Write("LVal18AFC");
        text.Write(',');
        text.Write("LVal30");
        text.Write(',');
        text.Write("CIsin");
        text.Write(',');
        text.Write("DTYYYYMMDD");
        text.Write(',');
        text.Write("Flow");
        text.Write(',');
        text.Write("LSoc30");
        text.Write(',');
        text.Write("CGdSVal");
        text.Write(',');
        text.Write("CGrValCot");
        text.Write(',');
        text.Write("YMarNSC");
        text.Write(',');
        text.Write("CComVal");
        text.Write(',');
        text.Write("CSecVal");
        text.Write(',');
        text.Write("CSoSecVal");
        text.Write(',');
        text.Write("YVal");
        text.Write('\n');
        foreach (InstrumentInfo instrument in StaticData.Instruments)
        {
          text.Write(instrument.InsCode);
          text.Write(',');
          text.Write(instrument.InstrumentID);
          text.Write(',');
          text.Write(instrument.LatinSymbol);
          text.Write(',');
          text.Write(instrument.LatinName);
          text.Write(',');
          text.Write(instrument.CompanyCode);
          text.Write(',');
          text.Write(instrument.Symbol);
          text.Write(',');
          text.Write(instrument.Name);
          text.Write(',');
          text.Write(instrument.CIsin);
          text.Write(',');
          text.Write(instrument.DEven);
          text.Write(',');
          text.Write((int) instrument.Flow);
          text.Write(',');
          text.Write(instrument.LSoc30);
          text.Write(',');
          text.Write(instrument.CGdSVal);
          text.Write(',');
          text.Write(instrument.CGrValCot);
          text.Write(',');
          text.Write(instrument.YMarNSC);
          text.Write(',');
          text.Write(instrument.CComVal);
          text.Write(',');
          text.Write(instrument.CSecVal);
          text.Write(',');
          text.Write(instrument.CSoSecVal);
          text.Write(',');
          text.Write(instrument.YVal);
          text.Write('\n');
        }
        text.Flush();
      }
    }

    public static List<string> SelectedInstruments()
    {
      FileService.CheckAppFolder();
      List<string> stringList = new List<string>();
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\SelectedInstruments.csv")))
        {
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split(',');
            stringList.Add(strArray[0].ToString());
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return stringList;
    }

    public static void WriteSelectedInstruments()
    {
      FileService.CheckAppFolder();
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\SelectedInstruments.csv"))
      {
        foreach (string selectedInstrument in StaticData.SelectedInstruments)
        {
          text.Write(selectedInstrument);
          text.Write('\n');
        }
        text.Flush();
      }
    }

    public static int LastDeven(string insCode)
    {
      FileService.CheckAppFolder();
      int num = 0;
      try
      {
        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + insCode + ".csv"))
          return 0;
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + insCode + ".csv")))
        {
          string str = "";
          while (!streamReader.EndOfStream)
            str = streamReader.ReadLine();
          num = Convert.ToInt32(str.Split(',')[1].ToString());
        }
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public static List<ClosingPriceInfo> ClosingPrices(long insCode)
    {
      FileService.CheckAppFolder();
      List<ClosingPriceInfo> closingPriceInfoList = new List<ClosingPriceInfo>();
      try
      {
        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + insCode.ToString() + ".csv"))
          return closingPriceInfoList;
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + insCode.ToString() + ".csv")))
        {
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split(',');
            closingPriceInfoList.Add(new ClosingPriceInfo()
            {
              InsCode = Convert.ToInt64(strArray[0].ToString()),
              DEven = Convert.ToInt32(strArray[1].ToString()),
              PClosing = Convert.ToDecimal(strArray[2].ToString()),
              PDrCotVal = Convert.ToDecimal(strArray[3].ToString()),
              ZTotTran = Convert.ToDecimal(strArray[4].ToString()),
              QTotTran5J = Convert.ToDecimal(strArray[5].ToString()),
              QTotCap = Convert.ToDecimal(strArray[6].ToString()),
              PriceMin = Convert.ToDecimal(strArray[7].ToString()),
              PriceMax = Convert.ToDecimal(strArray[8].ToString()),
              PriceYesterday = Convert.ToDecimal(strArray[9].ToString()),
              PriceFirst = Convert.ToDecimal(strArray[10].ToString())
            });
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return closingPriceInfoList;
    }

    public static void WriteClosingPrices(List<ClosingPriceInfo> input)
    {
      FileService.CheckAppFolder();
      if (input.Count == 0)
        return;
      string str = input[0].InsCode.ToString();
      List<ClosingPriceInfo> closingPriceInfoList1 = new List<ClosingPriceInfo>();
      List<ClosingPriceInfo> closingPriceInfoList2 = new List<ClosingPriceInfo>();
      List<ClosingPriceInfo> closingPriceInfoList3 = FileService.ClosingPrices(Convert.ToInt64(str));
      foreach (ClosingPriceInfo closingPriceInfo in input)
        closingPriceInfoList2.Add(closingPriceInfo);
      using (List<ClosingPriceInfo>.Enumerator enumerator = closingPriceInfoList3.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          ClosingPriceInfo item = enumerator.Current;
          if (closingPriceInfoList2.Find((Predicate<ClosingPriceInfo>) (p => p.DEven == item.DEven)) == null)
            closingPriceInfoList2.Add(item);
        }
      }
      closingPriceInfoList2.Sort((Comparison<ClosingPriceInfo>) ((s1, s2) => s1.DEven.CompareTo(s2.DEven)));
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments\\" + str + ".csv"))
      {
        foreach (ClosingPriceInfo closingPriceInfo in closingPriceInfoList2)
        {
          text.Write(closingPriceInfo.InsCode);
          text.Write(',');
          text.Write(closingPriceInfo.DEven);
          text.Write(',');
          text.Write(closingPriceInfo.PClosing);
          text.Write(',');
          text.Write(closingPriceInfo.PDrCotVal);
          text.Write(',');
          text.Write(closingPriceInfo.ZTotTran);
          text.Write(',');
          text.Write(closingPriceInfo.QTotTran5J);
          text.Write(',');
          text.Write(closingPriceInfo.QTotCap);
          text.Write(',');
          text.Write(closingPriceInfo.PriceMin);
          text.Write(',');
          text.Write(closingPriceInfo.PriceMax);
          text.Write(',');
          text.Write(closingPriceInfo.PriceYesterday);
          text.Write(',');
          text.Write(closingPriceInfo.PriceFirst);
          text.Write('\n');
        }
        text.Flush();
      }
    }

    public static void WriteOutputFile(
      InstrumentInfo instrument,
      List<ClosingPriceInfo> cp,
      bool appendExistingFile)
    {
      FileService.CheckAppFolder();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string str1 = settings.StorageLocation;
      if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
        str1 = settings.AdjustedStorageLocation;
      string str2 = settings.Delimeter.ToString();
      string str3;
      switch (Convert.ToInt32(settings.FileName))
      {
        case 0:
          str3 = instrument.CIsin;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-i";
              break;
            }
            break;
          }
          break;
        case 1:
          str3 = instrument.LatinName;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-i";
              break;
            }
            break;
          }
          break;
        case 2:
          str3 = instrument.LatinSymbol;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-i";
              break;
            }
            break;
          }
          break;
        case 3:
          str3 = instrument.Name;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-ت";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-ا";
              break;
            }
            break;
          }
          break;
        case 4:
          str3 = instrument.Symbol;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-ت";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-ا";
              break;
            }
            break;
          }
          break;
        default:
          str3 = instrument.CIsin;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str3 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str3 += "-i";
              break;
            }
            break;
          }
          break;
      }
      string str4 = str3.Replace('\\', ' ').Replace('/', ' ').Replace('*', ' ').Replace(':', ' ').Replace('>', ' ').Replace('<', ' ').Replace('?', ' ').Replace('|', ' ').Replace('^', ' ').Replace('"', ' ');
      int num = 0;
      if (appendExistingFile)
      {
        if (!File.Exists(str1 + "\\" + str4 + "." + settings.FileExtension))
        {
          appendExistingFile = false;
        }
        else
        {
          int indexOfDate = 0;
          bool isShamsiDate = false;
          foreach (ColumnInfo columnInfo in StaticData.ColumnsInfo)
          {
            if (columnInfo.Type == ColumnType.Date && columnInfo.Visible)
            {
              indexOfDate = columnInfo.Index - 1;
              isShamsiDate = false;
              break;
            }
            if (columnInfo.Type == ColumnType.ShamsiDate && columnInfo.Visible)
            {
              indexOfDate = columnInfo.Index;
              isShamsiDate = true;
            }
          }
          num = FileService.OutputFileLastDeven(instrument, indexOfDate, isShamsiDate);
        }
      }
      List<ColumnInfo> columnInfoList = FileService.ColumnsInfo();
      Encoding utF8 = Encoding.UTF8;
      Encoding encoding;
      switch (Convert.ToInt32(settings.Encoding))
      {
        case 0:
          encoding = Encoding.Unicode;
          break;
        case 1:
          encoding = Encoding.UTF8;
          break;
        case 2:
          encoding = Encoding.GetEncoding(1256);
          break;
        default:
          encoding = Encoding.UTF8;
          break;
      }
      TextWriter textWriter = (TextWriter) new StreamWriter(str1 + "\\" + str4 + "." + settings.FileExtension, appendExistingFile, encoding);
      columnInfoList.Sort((Comparison<ColumnInfo>) ((s1, s2) => s1.Index.CompareTo(s2.Index)));
      string str5 = "";
      if (settings.ShowHeaders && num == 0)
      {
        foreach (ColumnInfo columnInfo in columnInfoList)
        {
          if (columnInfo.Visible)
          {
            str5 += columnInfo.Header;
            str5 += str2;
          }
        }
        string str6 = str5.Substring(0, str5.Length - 1);
        textWriter.WriteLine(str6);
      }
      foreach (ClosingPriceInfo closingPriceInfo in cp)
      {
        if ((!appendExistingFile || closingPriceInfo.DEven > num) && (settings.ExportDaysWithoutTrade || !(closingPriceInfo.ZTotTran == new Decimal(0))))
        {
          string str6 = "";
          foreach (ColumnInfo columnInfo in columnInfoList)
          {
            if (columnInfo.Visible)
            {
              switch (columnInfo.Type)
              {
                case ColumnType.CompanyCode:
                  str6 += instrument.CompanyCode.ToString();
                  break;
                case ColumnType.LatinName:
                  str6 += instrument.LatinName.ToString();
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                    {
                      str6 += "-a";
                      break;
                    }
                    if (settings.AdjustPricesCondition == 2)
                    {
                      str6 += "-i";
                      break;
                    }
                    break;
                  }
                  break;
                case ColumnType.Symbol:
                  str6 += instrument.Symbol.Replace(" ", "_").ToString();
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                    {
                      str6 += "-ت";
                      break;
                    }
                    if (settings.AdjustPricesCondition == 2)
                    {
                      str6 += "-ا";
                      break;
                    }
                    break;
                  }
                  break;
                case ColumnType.Name:
                  str6 += instrument.Name.Replace(" ", "_").ToString();
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                    {
                      str6 += "-ت";
                      break;
                    }
                    if (settings.AdjustPricesCondition == 2)
                    {
                      str6 += "-ا";
                      break;
                    }
                    break;
                  }
                  break;
                case ColumnType.Date:
                  str6 += closingPriceInfo.DEven.ToString();
                  break;
                case ColumnType.ShamsiDate:
                  str6 += Utility.ConvertGregorianIntToJalaliInt(closingPriceInfo.DEven).ToString();
                  break;
                case ColumnType.PriceFirst:
                  str6 += closingPriceInfo.PriceFirst.ToString();
                  break;
                case ColumnType.PriceMax:
                  str6 += closingPriceInfo.PriceMax.ToString();
                  break;
                case ColumnType.PriceMin:
                  str6 += closingPriceInfo.PriceMin.ToString();
                  break;
                case ColumnType.LastPrice:
                  str6 += closingPriceInfo.PDrCotVal.ToString();
                  break;
                case ColumnType.ClosingPrice:
                  str6 += closingPriceInfo.PClosing.ToString();
                  break;
                case ColumnType.Price:
                  str6 += closingPriceInfo.QTotCap.ToString();
                  break;
                case ColumnType.Volume:
                  str6 += closingPriceInfo.QTotTran5J.ToString();
                  break;
                case ColumnType.Count:
                  str6 += closingPriceInfo.ZTotTran.ToString();
                  break;
                case ColumnType.PriceYesterday:
                  str6 += closingPriceInfo.PriceYesterday.ToString();
                  break;
              }
              str6 += str2;
            }
          }
          string str7 = str6.Substring(0, str6.Length - 1);
          textWriter.WriteLine(str7);
        }
      }
      textWriter.Flush();
      textWriter.Dispose();
    }

    public static void RenameOutputFiles()
    {
      FileService.CheckAppFolder();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string str1 = settings.StorageLocation;
      if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
        str1 = settings.AdjustedStorageLocation;
      foreach (InstrumentInfo instrument in StaticData.Instruments)
      {
        string str2;
        switch (Convert.ToInt32(settings.FileName))
        {
          case 0:
            str2 = instrument.CIsin;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 1:
            str2 = instrument.LatinName;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 2:
            str2 = instrument.LatinSymbol;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 3:
            str2 = instrument.Name;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-ت";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-ا";
                break;
              }
              break;
            }
            break;
          case 4:
            str2 = instrument.Symbol;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-ت";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-ا";
                break;
              }
              break;
            }
            break;
          default:
            str2 = instrument.CIsin;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
        }
        string str3 = str2.Replace('\\', ' ').Replace('/', ' ').Replace('*', ' ').Replace(':', ' ').Replace('>', ' ').Replace('<', ' ').Replace('?', ' ').Replace('|', ' ').Replace('^', ' ').Replace('"', ' ');
        if (File.Exists(str1 + "\\" + str3 + "." + settings.FileExtension))
        {
          File.Copy(str1 + "\\" + str3 + "." + settings.FileExtension, str1 + "\\" + str3 + "[" + (object) DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "-" + (object) DateTime.Now.Hour + "-" + DateTime.Now.Minute.ToString("00") + "-" + DateTime.Now.Second.ToString("00") + "]." + settings.FileExtension);
          File.Delete(str1 + "\\" + str3 + "." + settings.FileExtension);
        }
      }
    }

    public static int OutputFileLastDeven(
      InstrumentInfo instrument,
      int indexOfDate,
      bool isShamsiDate)
    {
      FileService.CheckAppFolder();
      int num = 0;
      try
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        Settings settings = new Settings();
        string str1 = settings.StorageLocation;
        if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
          str1 = settings.AdjustedStorageLocation;
        string str2;
        switch (Convert.ToInt32(settings.FileName))
        {
          case 0:
            str2 = instrument.CIsin;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 1:
            str2 = instrument.LatinName;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 2:
            str2 = instrument.LatinSymbol;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
          case 3:
            str2 = instrument.Name;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-ت";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-ا";
                break;
              }
              break;
            }
            break;
          case 4:
            str2 = instrument.Symbol;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-ت";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-ا";
                break;
              }
              break;
            }
            break;
          default:
            str2 = instrument.CIsin;
            if (instrument.YMarNSC != "ID")
            {
              if (settings.AdjustPricesCondition == 1)
              {
                str2 += "-a";
                break;
              }
              if (settings.AdjustPricesCondition == 2)
              {
                str2 += "-i";
                break;
              }
              break;
            }
            break;
        }
        string str3 = str2.Replace('\\', ' ').Replace('/', ' ').Replace('*', ' ').Replace(':', ' ').Replace('>', ' ').Replace('<', ' ').Replace('?', ' ').Replace('|', ' ').Replace('^', ' ').Replace('"', ' ');
        if (!File.Exists(str1 + "\\" + str3 + "." + settings.FileExtension))
          return 0;
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(str1 + "\\" + str3 + "." + settings.FileExtension)))
        {
          string str4 = "";
          while (!streamReader.EndOfStream)
            str4 = streamReader.ReadLine();
          string[] strArray = str4.Split(',');
          num = isShamsiDate ? Utility.ConvertJalaliStringToGregorianInt(strArray[indexOfDate].ToString()) : Convert.ToInt32(strArray[indexOfDate].ToString());
        }
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public static void WriteOutputExcel(InstrumentInfo instrument, List<ClosingPriceInfo> cp)
    {
      FileService.CheckAppFolder();
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string str1 = settings.StorageLocation;
      if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
        str1 = settings.AdjustedStorageLocation;
      string str2;
      switch (Convert.ToInt32(settings.FileName))
      {
        case 0:
          str2 = instrument.CIsin;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-i";
              break;
            }
            break;
          }
          break;
        case 1:
          str2 = instrument.LatinName;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-i";
              break;
            }
            break;
          }
          break;
        case 2:
          str2 = instrument.LatinSymbol;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-i";
              break;
            }
            break;
          }
          break;
        case 3:
          str2 = instrument.Name;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-ت";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-ا";
              break;
            }
            break;
          }
          break;
        case 4:
          str2 = instrument.Symbol;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-ت";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-ا";
              break;
            }
            break;
          }
          break;
        default:
          str2 = instrument.CIsin;
          if (instrument.YMarNSC != "ID")
          {
            if (settings.AdjustPricesCondition == 1)
            {
              str2 += "-a";
              break;
            }
            if (settings.AdjustPricesCondition == 2)
            {
              str2 += "-i";
              break;
            }
            break;
          }
          break;
      }
      string str3 = str2.Replace('\\', ' ').Replace('/', ' ').Replace('*', ' ').Replace(':', ' ').Replace('>', ' ').Replace('<', ' ').Replace('?', ' ').Replace('|', ' ').Replace('^', ' ').Replace('"', ' ');
      List<ColumnInfo> columnInfoList = FileService.ColumnsInfo();
      string file = str1 + "\\" + str3 + ".xls";
      Workbook workbook = new Workbook();
      Worksheet worksheet = new Worksheet(instrument.InstrumentID);
      columnInfoList.Sort((Comparison<ColumnInfo>) ((s1, s2) => s1.Index.CompareTo(s2.Index)));
      int index1 = 0;
      int index2 = 0;
      if (settings.ShowHeaders)
      {
        foreach (ColumnInfo columnInfo in columnInfoList)
        {
          if (columnInfo.Visible)
          {
            worksheet.Cells[index1, index2] = new Cell((object) columnInfo.Header);
            ++index2;
          }
        }
        ++index1;
      }
      foreach (ClosingPriceInfo closingPriceInfo in cp)
      {
        if (settings.ExportDaysWithoutTrade || !(closingPriceInfo.ZTotTran == new Decimal(0)))
        {
          int index3 = 0;
          foreach (ColumnInfo columnInfo in columnInfoList)
          {
            if (columnInfo.Visible)
            {
              switch (columnInfo.Type)
              {
                case ColumnType.CompanyCode:
                  worksheet.Cells[index1, index3] = new Cell((object) instrument.CompanyCode.ToString());
                  ++index3;
                  continue;
                case ColumnType.LatinName:
                  string str4 = "";
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                      str4 = "-a";
                    else if (settings.AdjustPricesCondition == 2)
                      str4 = "-i";
                  }
                  worksheet.Cells[index1, index3] = new Cell((object) (instrument.LatinName.ToString() + str4));
                  ++index3;
                  continue;
                case ColumnType.Symbol:
                  string str5 = "";
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                      str5 = "-ت";
                    else if (settings.AdjustPricesCondition == 2)
                      str5 = "-ا";
                  }
                  worksheet.Cells[index1, index3] = new Cell((object) (instrument.Symbol.ToString() + str5));
                  ++index3;
                  continue;
                case ColumnType.Name:
                  string str6 = "";
                  if (instrument.YMarNSC != "ID")
                  {
                    if (settings.AdjustPricesCondition == 1)
                      str6 = "-ت";
                    else if (settings.AdjustPricesCondition == 2)
                      str6 = "-ا";
                  }
                  worksheet.Cells[index1, index3] = new Cell((object) (instrument.Name.ToString() + str6));
                  ++index3;
                  continue;
                case ColumnType.Date:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.DEven.ToString());
                  ++index3;
                  continue;
                case ColumnType.ShamsiDate:
                  worksheet.Cells[index1, index3] = new Cell((object) Utility.ConvertGregorianIntToJalaliInt(closingPriceInfo.DEven).ToString());
                  ++index3;
                  continue;
                case ColumnType.PriceFirst:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PriceFirst.ToString());
                  ++index3;
                  continue;
                case ColumnType.PriceMax:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PriceMax.ToString());
                  ++index3;
                  continue;
                case ColumnType.PriceMin:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PriceMin.ToString());
                  ++index3;
                  continue;
                case ColumnType.LastPrice:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PDrCotVal.ToString());
                  ++index3;
                  continue;
                case ColumnType.ClosingPrice:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PClosing.ToString());
                  ++index3;
                  continue;
                case ColumnType.Price:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.QTotCap.ToString());
                  ++index3;
                  continue;
                case ColumnType.Volume:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.QTotTran5J.ToString());
                  ++index3;
                  continue;
                case ColumnType.Count:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.ZTotTran.ToString());
                  ++index3;
                  continue;
                case ColumnType.PriceYesterday:
                  worksheet.Cells[index1, index3] = new Cell((object) closingPriceInfo.PriceYesterday.ToString());
                  ++index3;
                  continue;
                default:
                  continue;
              }
            }
          }
          ++index1;
        }
      }
      workbook.Worksheets.Add(worksheet);
      workbook.Save(file);
    }

    public static int LogErrorFile(string message)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      string path = settings.StorageLocation;
      if (settings.AdjustPricesCondition == 1 || settings.AdjustPricesCondition == 2)
        path = settings.AdjustedStorageLocation;
      if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
        return -1;
      using (TextWriter text = (TextWriter) File.CreateText(path + "\\error.log"))
      {
        text.Write(message);
        text.Flush();
      }
      return 1;
    }

    public static void EraseCurrentFiles()
    {
      FileService.CheckAppFolder();
      foreach (FileSystemInfo file in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments").GetFiles())
        file.Delete();
      FileInfo fileInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Instruments.csv");
      fileInfo.Delete();
      fileInfo.Create();
    }

    public static string ReadVersionFileContent()
    {
      FileService.CheckAppFolder();
      string str = "";
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Version.txt")))
          str = streamReader.ReadToEnd();
      }
      catch (Exception ex)
      {
      }
      return str;
    }

    public static void WriteVersionFileContent(string version)
    {
      FileService.CheckAppFolder();
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\Version.txt"))
      {
        text.Write(version);
        text.Flush();
      }
    }

    public static List<TseShareInfo> TseShares()
    {
      FileService.CheckAppFolder();
      List<TseShareInfo> tseShareInfoList = new List<TseShareInfo>();
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\TseShares.csv")))
        {
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split(',');
            tseShareInfoList.Add(new TseShareInfo()
            {
              Idn = Convert.ToInt64(strArray[0].ToString()),
              InsCode = Convert.ToInt64(strArray[1].ToString()),
              DEven = Convert.ToInt32(strArray[2].ToString()),
              NumberOfShareNew = Convert.ToDecimal(strArray[3].ToString()),
              NumberOfShareOld = Convert.ToDecimal(strArray[4].ToString())
            });
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return tseShareInfoList;
    }

    public static void WriteTseShares()
    {
      FileService.CheckAppFolder();
      using (TextWriter text = (TextWriter) File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TseClient 2.0\\Files\\TseShares.csv"))
      {
        foreach (TseShareInfo tseShare in StaticData.TseShares)
        {
          text.Write(tseShare.Idn);
          text.Write(',');
          text.Write(tseShare.InsCode);
          text.Write(',');
          text.Write(tseShare.DEven);
          text.Write(',');
          text.Write(tseShare.NumberOfShareNew);
          text.Write(',');
          text.Write(tseShare.NumberOfShareOld);
          text.Write('\n');
        }
        text.Flush();
      }
    }
  }
}
