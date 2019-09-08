// Decompiled with JetBrains decompiler
// Type: TseClient.cDate
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;

namespace TseClient {
	public class cDate {
		public int calendarType;
		private string[] jalaliMonth;
		public string[] jalaliWeekDays;
		private string[] arabicMonth;
		private string[] arabicWeekDays;
		private double gregorianEPOCH;
		private double jalaliEPOCH;
		private double arabicEPOCH;
		public double jd;

		public cDate(int cTypes) {
			this.calendarType = cTypes;
			this.jalaliMonth = new string[12]
			{
				"ÝÑæÑÏíä",
				"ÇÑÏíÈåÔÊ",
				"ÎÑÏÇÏ",
				"ÊíÑ",
				"ãÑÏÇÏ",
				"ÔåÑíæÑ",
				"ãåÑ",
				"ÂÈÇä",
				"ÂÐÑ",
				"Ïí",
				"Èåãä",
				"ÇÓÝäÏ"
			};
			this.jalaliWeekDays = new string[7]
			{
				"ÔäÈå",
				"íß ÔäÈå",
				"ÏæÔäÈå",
				"Óå ÔäÈå",
				"\x008DåÇÑÔäÈå",
				"\x0081äÌ ÔäÈå",
				"ÌãÚå"
			};
			this.arabicMonth = new string[12]
			{
				"ãÍÑã",
				"ÕÝÑ",
				"ÑÈíÚ ÇáÇæá",
				"ÑÈíÚ ÇáËÇäí",
				"ÌãÇÏí ÇáÇæá",
				"ÌãÇÏí ÇáËÇäí",
				"ÑÌÈ",
				"ÔÚÈÇä",
				"ÑãÖÇä",
				"ÔæÇá",
				"ÐíÞÚÏå",
				"ÐíÍÌå"
			};
			this.arabicWeekDays = new string[7]
			{
				"ÔäÈå",
				"íß ÔäÈå",
				"ÏæÔäÈå",
				"Óå ÔäÈå",
				"\x008DåÇÑÔäÈå",
				"\x0081äÌ ÔäÈå",
				"ÌãÚå"
			};
			this.gregorianEPOCH = 1721426.0;
			this.jalaliEPOCH = 1948321.0;
			this.arabicEPOCH = 1948440.0;
		}

		public void fromGregorain(DateTime gDate) {
			this.fromGregorain(gDate.Year, gDate.Month, gDate.Day);
		}

		public void fromGregorain(int gYear, int gMonth, int gDay) {
			this.jd = this.gregorian_to_jd(gYear, gMonth, gDay);
		}

		public void fromArabic(int aYear, int aMonth, int aDay) {
			this.jd = this.arabic_to_jd(aYear, aMonth, aDay);
		}

		public void fromJalali(int jYear, int jMonth, int jDay) {
			this.jd = this.jalali_to_jd(jYear, jMonth, jDay);
		}

		public void fromJalali(string JalaliDate) {
			int length = JalaliDate.IndexOf("/");
			int num = JalaliDate.LastIndexOf("/");
			int jYear = Convert.ToInt32(JalaliDate.Substring(0, length));
			int int32_1 = Convert.ToInt32(JalaliDate.Substring(length + 1, num - length - 1));
			int int32_2 = Convert.ToInt32(JalaliDate.Substring(num + 1));
			if (jYear < 1000)
				jYear = 1300 + jYear;
			this.jd = this.jalali_to_jd(jYear, int32_1, int32_2);
		}

		private double gregorian_to_jd(int gYear, int gMonth, int gDay) {
			return this.gregorianEPOCH - 1.0 + (double)(365 * (gYear - 1)) + Math.Floor((double)((gYear - 1) / 4)) + -Math.Floor((double)((gYear - 1) / 100)) + Math.Floor((double)((gYear - 1) / 400)) + Math.Floor((double)((367 * gMonth - 362) / 12 + (gMonth <= 2 ? 0 : (cDate.leap_gregorian(gYear) ? -1 : -2)) + gDay));
		}

		private double arabic_to_jd(int aYear, int aMonth, int aDay) {
			return (double)aDay + Math.Ceiling(29.5 * (double)(aMonth - 1)) + (double)((aYear - 1) * 354) + Math.Floor((double)((3 + 11 * aYear) / 30)) + this.arabicEPOCH - 1.0;
		}

		private double jalali_to_jd(int jYear, int jMonth, int jDay) {
			double num1 = (double)(jYear - (jYear >= 0 ? 474 : 473));
			double num2 = 474.0 + num1 % 2820.0;
			return (double)(jDay + (jMonth <= 7 ? (jMonth - 1) * 31 : (jMonth - 1) * 30 + 6)) + Math.Floor((num2 * 682.0 - 110.0) / 2816.0) + (num2 - 1.0) * 365.0 + Math.Floor(num1 / 2820.0) * 1029983.0 + (this.jalaliEPOCH - 1.0);
		}

		private static bool leap_gregorian(int gYear) {
			if (gYear % 4 != 0)
				return false;
			if (gYear % 100 == 0)
				return gYear % 400 == 0;
			return true;
		}

		public DateTime ToDateTime() {
			int[] numArray = this.ToInt();
			return new DateTime(numArray[0], numArray[1], numArray[2]);
		}

		public string ToShortString() {
			int[] numArray = this.ToInt();
			switch (this.calendarType) {
				case 1:
					return DateTime.MinValue.AddYears(numArray[0] - 1).AddMonths(numArray[1] - 1).AddDays((double)(numArray[2] - 1)).ToShortDateString();
				case 2:
				case 3:
					return numArray[0].ToString() + "/" + numArray[1].ToString() + "/" + numArray[2].ToString();
				default:
					return "";
			}
		}

		public string ToLongString() {
			return this.ToShortString();
		}

		public int[] ToInt() {
			switch (this.calendarType) {
				case 1:
					return this.jd_to_gregorian();
				case 2:
					return this.jd_to_jalali();
				case 3:
					return this.jd_to_arabic();
				default:
					return new int[3];
			}
		}

		private int[] jd_to_gregorian() {
			DateTime dateTime = new DateTime(2005, 9, 20).AddDays(this.jd - 2453634.0);
			return new int[3]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day
			};
		}

		private int[] jd_to_jalali() {
			double num1 = Math.Floor(this.jd) + 0.5;
			double num2 = num1 - this.jalali_to_jd(475, 1, 1);
			double num3 = Math.Floor(num2 / 1029983.0);
			double num4 = num2 % 1029983.0;
			double num5;
			if (num4 == 1029982.0) {
				num5 = 2820.0;
			} else {
				double num6 = Math.Floor(num4 / 366.0);
				double num7 = num4 % 366.0;
				num5 = Math.Floor((2134.0 * num6 + 2816.0 * num7 + 2815.0) / 1028522.0) + num6 + 1.0;
			}
			int jYear = (int)(num5 + 2820.0 * num3 + 474.0);
			if (jYear <= 0)
				--jYear;
			double num8 = num1 - this.jalali_to_jd(jYear, 1, 1) + 0.5;
			int jMonth = num8 <= 186.0 ? (int)Math.Ceiling(num8 / 31.0) : (int)Math.Ceiling((num8 - 6.0) / 30.0);
			int num9 = (int)(num1 - this.jalali_to_jd(jYear, jMonth, 1)) + 1;
			if (jMonth == 0 && num9 == 31) {
				--jYear;
				jMonth = 12;
				num9 = 30;
			}
			return new int[3] { jYear, jMonth, num9 };
		}

		private int[] jd_to_arabic() {
			double num1 = Math.Floor(this.jd) + 0.5;
			int aYear = (int)Math.Floor((30.0 * (num1 - this.arabicEPOCH) + 10646.0) / 10631.0);
			int aMonth = (int)Math.Min(12.0, Math.Ceiling((num1 - (29.0 + this.arabic_to_jd(aYear, 1, 1))) / 29.5) + 1.0);
			int num2 = (int)(num1 - this.arabic_to_jd(aYear, aMonth, 1) + 1.0);
			return new int[3] { aYear, aMonth, num2 };
		}
	}
}
