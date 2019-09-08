// Decompiled with JetBrains decompiler
// Type: TseClient.FormFillMethods
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

namespace TseClient
{
  public class FormFillMethods
  {
    public static string GetColumnHeader(ColumnType columnType)
    {
      switch (columnType)
      {
        case ColumnType.CompanyCode:
          return "کد شرکت";
        case ColumnType.LatinName:
          return "نام لاتین";
        case ColumnType.Symbol:
          return "نماد";
        case ColumnType.Name:
          return "نام";
        case ColumnType.Date:
          return "تاریخ میلادی";
        case ColumnType.ShamsiDate:
          return "تاریخ شمسی";
        case ColumnType.PriceFirst:
          return "اولین قیمت";
        case ColumnType.PriceMax:
          return "بیشترین قیمت";
        case ColumnType.PriceMin:
          return "کمترین قیمت";
        case ColumnType.LastPrice:
          return "آخرین قیمت";
        case ColumnType.ClosingPrice:
          return "قیمت پایانی";
        case ColumnType.Price:
          return "ارزش";
        case ColumnType.Volume:
          return "حجم";
        case ColumnType.Count:
          return "تعداد معاملات";
        case ColumnType.PriceYesterday:
          return "قیمت دیروز";
        default:
          return "";
      }
    }
  }
}
