using System;
using System.Diagnostics;

namespace DataStructures
{
    public class IntegerToBitSet
    {
        int[] bitArray;
        int maxIntegerValue;
        /// <summary>
        /// Allowed values are 1 to maxIntegerValue, included
        /// </summary>
        /// <param name="maxIntegerValue"></param>
        public IntegerToBitSet(int maxIntegerValue)
        {
            var maxEntry = maxIntegerValue >> 5; // divide by 32
            maxEntry = (maxIntegerValue & 0x1F) == 0 ? maxEntry : maxEntry + 1;
            bitArray = new int[maxEntry + 1];

            Trace.WriteLine($"rows: {bitArray.Length}");
            this.maxIntegerValue = maxIntegerValue;
        }

        public bool this[int index]
        {
            get
            {
                int location_x, location_y;
                GetLocation(index, out location_x, out location_y);
                return (bitArray[location_x] & (1 << location_y)) != 0;
            }
            set
            {
                int location_x, location_y;
                GetLocation(index, out location_x, out location_y);

                if (value)
                {
                    bitArray[location_x] |= 1 << location_y;
                }
                else
                {
                    bitArray[location_x] &= ~(1 << location_y);
                }
            }
        }

        private void GetLocation(int value, out int location_x, out int location_y)
        {
            if (value < 0 || value > maxIntegerValue)
            {
                throw new ArgumentException();
            }

            // int 4 bytes 32 bits
            // location_x is value/32, location_y is value % 32
            location_x = value >> 5;
            location_y = value & 0x1F;  // mod 32 (5 1's) 
        }
    }
}
