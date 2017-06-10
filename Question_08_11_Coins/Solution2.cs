namespace Question_08_11_Coins
{
    public class Solution2 : ISolution
    {
        public int MakeChange(int amount)
        {
            return MakeChangeRecurse(amount, ChangeLevel.TwentyFive);
        }

        private int MakeChangeRecurse(int amount, ChangeLevel changeLevel)
        {
            if (amount == 0 || (changeLevel == ChangeLevel.One && amount > 0))
            {
                return 1;
            }

            if (amount < 0)
            {
                return 0;
            }

            // To prevent duplicates only branch to the level that is lower 
            // From 25 branch to 25, 10 and 1
            // From 10 branch to 10 and 1
            // From 1 add 1 if the amount is > 0
            int count = 0;
            switch (changeLevel)
            {
                case ChangeLevel.TwentyFive:
                    count += MakeChangeRecurse(amount - 25, ChangeLevel.TwentyFive);
                    count += MakeChangeRecurse(amount - 10, ChangeLevel.Ten);
                    count += MakeChangeRecurse(amount - 1, ChangeLevel.One);
                    break;

                case ChangeLevel.Ten:
                    count += MakeChangeRecurse(amount - 10, ChangeLevel.Ten);
                    count += MakeChangeRecurse(amount - 1, ChangeLevel.One);
                    break;

                case ChangeLevel.One:
                    count += MakeChangeRecurse(amount - 1, ChangeLevel.One);
                    break;
                default:
                    break;
            }

            return count;
        }
    }
}
