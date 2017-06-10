//////////////////////////////////////////////////////////////////
///////
/////// Copyright 2016, Pamukcu, All rights reserved
///////
///////
//////////////////////////////////////////////////////////////////


using System;

namespace Pamukcu.Interviews.CTCI.Question_01_01_IsUnique
{
    public class BruteForceSolution
    {
        public bool IsUnique(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
