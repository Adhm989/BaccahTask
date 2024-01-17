using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccahTask
{
	internal class NumberConverter
	{
		private static readonly Dictionary<int, string> ArabicUnits = new Dictionary<int, string>
	{
		{ 0, "" }, { 1, "واحد" }, { 2, "اثنان" }, { 3, "ثلاثة" }, { 4, "أربعة" }, { 5, "خمسة" }, { 6, "ستة" }, { 7, "سبعة" }, { 8, "ثمانية" }, { 9, "تسعة" }
	};

		private static readonly Dictionary<int, string> ArabicTeen = new Dictionary<int, string>
	{
		{ 10, "عشرة" }, { 11, "أحد عشر" }, { 12, "اثنا عشر" }, { 13, "ثلاثة عشر" }, { 14, "أربعة عشر" }, { 15, "خمسة عشر" }, { 16, "ستة عشر" }, { 17, "سبعة عشر" }, { 18, "ثمانية عشر" }, { 19, "تسعة عشر" }
	};

		private static readonly Dictionary<int, string> ArabicTens = new Dictionary<int, string>
	{
		{ 0, "" }, { 2, "عشرون" }, { 3, "ثلاثون" }, { 4, "أربعون" }, { 5, "خمسون" }, { 6, "ستون" }, { 7, "سبعون" }, { 8, "ثمانون" }, { 9, "تسعون" }
	};

		private static readonly Dictionary<int, string> ArabicHundreds = new Dictionary<int, string>
	{
		{ 0, "" }, { 1, "مائة" }, { 2, "مائتان" }, { 3, "ثلاثمائة" }, { 4, "أربعمائة" }, { 5, "خمسمائة" }, { 6, "ستمائة" }, { 7, "سبعمائة" }, { 8, "ثمانمائة" }, { 9, "تسعمائة" }
	};

		private static readonly Dictionary<int, string> EnglishUnits = new Dictionary<int, string>
	{
		{ 0, "" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }
	};

		private static readonly Dictionary<int, string> EnglishTeen = new Dictionary<int, string>
	{
		{ 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }
	};

		private static readonly Dictionary<int, string> EnglishTens = new Dictionary<int, string>
	{
		{ 0, "" }, { 2, "Twenty" }, { 3, "Thirty" }, { 4, "Forty" }, { 5, "Fifty" }, { 6, "Sixty" }, { 7, "Seventy" }, { 8, "Eighty" }, { 9, "Ninety" }
	};

		private static readonly Dictionary<int, string> EnglishHundreds = new Dictionary<int, string>
	{
		{ 0, "" }, { 1, "One Hundred" }, { 2, "Two Hundred" }, { 3, "Three Hundred" }, { 4, "Four Hundred" }, { 5, "Five Hundred" }, { 6, "Six Hundred" }, { 7, "Seven Hundred" }, { 8, "Eight Hundred" }, { 9, "Nine Hundred" }
	};

		private static string ConvertToText(int number, bool isArabic)
		{
			if (isArabic)
			{
				return ConvertToText(isArabic , number, ArabicUnits, ArabicTeen, ArabicTens, ArabicHundreds);
			}
			else
			{
				return ConvertToText(isArabic , number, EnglishUnits, EnglishTeen, EnglishTens, EnglishHundreds);
			}
		}

		public static string ConvertToText(float number, bool isArabic)
		{
			int wholePart = (int)number;
			int decimalPart = (int)((number - wholePart) * 100);

			string text = ConvertToText(wholePart, isArabic);
			if (decimalPart > 0)
			{
				text += isArabic ? " فاصلة " : " Point ";
				text += ConvertToText(decimalPart, isArabic);
			}

			return text;
		}
		private static string ConvertToText(bool isArabic ,int number, Dictionary<int, string> units, Dictionary<int, string> teen, Dictionary<int, string> tens, Dictionary<int, string> hundreds)
		{
			if (number == 0)
			{
				return units[0];
			}

			string text = "";

			if (number >= 1000000)
			{
				if (isArabic)
					text += $"{ConvertToText(isArabic, number / 1000000, units, teen, tens, hundreds)} مليون و ";
				else
					text += $"{ConvertToText(isArabic, number / 1000000, units, teen, tens, hundreds)} Million ";
				number %= 1000000;
			}

			if (number >= 1000)
			{
				if (isArabic)
					text += $"{ConvertToText(isArabic, number / 1000, units, teen, tens, hundreds)} الف و ";
				else
					text += $"{ConvertToText(isArabic, number / 1000, units, teen, tens, hundreds)} Thousand ";
				number %= 1000;
			}

			if (number >= 100)
			{
				text += $"{hundreds[number / 100]}";
				number %= 100;
			}

			if (number > 0)
			{
				if (text != "" && number != 1)  // Skip space after "واحد" (One)
				{
					text += isArabic ? " و " : " and ";
				}

				if (number < 10)
				{
					text += units[number];
				}
				else if (number < 20)
				{
					text += teen[number];
				}
				else
				{
					
					if (!isArabic)
					{
						text += $"{tens[number / 10]}";
						if (number % 10 > 0)
						{
							text += "-";
							text += units[number % 10];
						}
					}
					else
					{
						if (number %10 > 0)
						{
							text += $"{units[number % 10]} ";
							text += " و ";
						}
						text += $"{tens[number / 10]} ";
					}
				}
			}

			return text;
		}

	}
}
