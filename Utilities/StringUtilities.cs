using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class StringUtilities
    {
        static Random random = new Random();

        public static string CreateLargeString(uint length = 4096)
        {
            return CreateStringRandom('a', 'z', length);
        }

        public static string CreateStringRandom(char startRange, char endRange, uint length)
        {
            uint lowerCaseAlphabetStart = startRange;
            uint count = (uint)endRange - startRange;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                uint randomAlphabetIndex = (uint)random.Next(0, (int)count + 1);
                char currentChar = (char)(lowerCaseAlphabetStart + randomAlphabetIndex);
                builder.Append(currentChar);
            }

            return builder.ToString();
        }
    }
}
