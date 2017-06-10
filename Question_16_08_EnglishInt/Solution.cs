using System;
using System.Text;

namespace Question_16_08_EnglishInt
{
    public static class Solution
    {
        private static string[] zeroToNineteen = {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        private static string[] tens = {
            "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

        private static string[] threeMutliplePowersOfTen = {
            "one", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion"
            };

        private const string hundred = "hundred";
        private const string negative = "negative";
        private const string emptyString = " ";

        public static string ToEnglish(this int value)
        {
            StringBuilder builder = new StringBuilder();

            ConvertEnglishRecurse(value < 0 ? Math.Abs(value) : value, 1, builder);
            if (value < 0)
            {
                builder.Insert(0, emptyString);
                builder.Insert(0, negative);
            }

            return builder.ToString();
        }

        private static string LessThan100ToEnglish(this int value)
        {
            if (value < 0 || value > 99)
            {
                throw new ArgumentException();
            }

            if (value < 20)
            {
                return zeroToNineteen[value];
            }

            // 20 - 99
            StringBuilder builder = new StringBuilder();
            builder.Append(tens[value / 10]);

            if (value % 10 > 0)
            {
                builder.Append("-");
                builder.Append(zeroToNineteen[value % 10]);
            }

            return builder.ToString();
        }

        private static void ConvertEnglishRecurse(int value, int level, StringBuilder builder)
        {
            if (value == 0 && level > 1)
            {
                return; 
            }

            if (level % 3 == 1)
            {
                Convert2DigitValue(builder, value % 100, level);
                level += 2;
                value = value / 100;
            }
            else
            {
                Convert1DigitValue(builder, value % 10, level);
                level++;
                value = value / 10;
            }

            ConvertEnglishRecurse(value, level, builder);
        }

        private static void Convert1DigitValue(StringBuilder builder, int digit, int level)
        {
            if (digit == 0) return;

            builder.Insert(0, emptyString);
            builder.Insert(0, hundred);

            builder.Insert(0, emptyString);
            builder.Insert(0, digit.LessThan100ToEnglish());            
        }

        private static void Convert2DigitValue(StringBuilder builder, int value, int level)
        {
            if (level > 1 && level % 3 == 1)
            {
                builder.Insert(0, emptyString);
                builder.Insert(0, threeMutliplePowersOfTen[level / 3]);                
            }

            builder.Insert(0, emptyString);
            builder.Insert(0, value.LessThan100ToEnglish());            
        }
    }
}
