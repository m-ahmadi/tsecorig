// Decompiled with JetBrains decompiler
// Type: TseClient.ClosingPriceInfo
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;

namespace TseClient
{
  public class ClosingPriceInfo
  {
    public long InsCode { get; set; }

    public int DEven { get; set; }

    public Decimal PClosing { get; set; }

    public Decimal PDrCotVal { get; set; }

    public Decimal ZTotTran { get; set; }

    public Decimal QTotTran5J { get; set; }

    public Decimal QTotCap { get; set; }

    public Decimal PriceMin { get; set; }

    public Decimal PriceMax { get; set; }

    public Decimal PriceYesterday { get; set; }

    public Decimal PriceFirst { get; set; }
  }
}
