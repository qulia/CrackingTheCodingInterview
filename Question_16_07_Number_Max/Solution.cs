using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_16_07_Number_Max
{
    public class Solution
    {
        // No comparison operators are allowed
        public int GetMax(int number1, int number2)
        {
            int numberOfBits = sizeof(int) * 8;
            int numberOfShifts = numberOfBits - 1;
            int signBit1 = number1 >> numberOfShifts & 1;
            int signBit2 = number2 >> numberOfShifts & 1;
            int differentSigns = signBit1 ^ signBit2;

            // if they have the same sign check the difference,
            // overflow is not possible in this case
            int difference = number1 - number2;
            int differenceSignBit = difference >> numberOfShifts;
            int differenceNegative = ~differentSigns & differenceSignBit & 1;
            int differencePositive = ~differentSigns & ~differenceSignBit & 1;

            // if one is negative the other is positive, return the positive as max
            // otherwise decide the max based on the difference
            var result = (differentSigns * (signBit1 * number2 + signBit2 * number1)) +
               (differenceNegative * number2) + (differencePositive * number1);

            return result;
        }
    }
}
