namespace Utilities
{
    public class Math
    {
        public static int Factorial(int input)
        {
            if (input == 0)
            {
                return 1;
            }

            return input * Factorial(input - 1);
        }
    }
}
