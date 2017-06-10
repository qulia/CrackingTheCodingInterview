using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_16_23_Rand7FromRand5
{
    // TODO: Revisit this solution
    public class Solution
    {
        Random random = new Random();
        public int Rand5()
        {
            return random.Next(0, 5);
        }

        // Add rand5 results 7 times with shifted values to give each int from 0 to 6 equal chance
        public int Rand7()
        {
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                sum = sum + i + Rand5();
            }

            return sum % 7;
        }
    }
}
