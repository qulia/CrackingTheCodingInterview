using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question_15_07_FizzBuz
{
    public class Solution
    {
        int number = 0;
        int maxNumber;
        object sync = new object();
        Action<string> printer;

        Dictionary<Mode, Func<int, bool>> predicates = new Dictionary<Mode, Func<int, bool>>()
        {
            { Mode.None, new Func<int, bool>((value) => value % 5 != 0 && value %3 != 0 )},
            { Mode.Fizz, new Func<int, bool>((value) => value % 5 != 0 && value %3 == 0 )},
            { Mode.Buzz, new Func<int, bool>((value) => value % 5 == 0 && value %3 != 0 )},
            { Mode.FizzBuzz, new Func<int, bool>((value) => value % 5 == 0 && value %3 == 0 )},
        };

        Dictionary<Mode, Func<int, string>> printValues = new Dictionary<Mode, Func<int, string>>()
        {
            { Mode.None, new Func<int, string>((value) => value.ToString())},
            { Mode.Fizz, new Func<int, string>((value) => "Fizz")},
            { Mode.Buzz, new Func<int, string>((value) => "Buzz")},
            { Mode.FizzBuzz, new Func<int, string>((value) => "FizzBuzz" )},
        };

        public void PrintFizzBuzz(int number, Action<string> printer)
        {
            maxNumber = number;
            this.printer = printer;

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => { PrintNext(Mode.Fizz); }));
            tasks.Add(Task.Run(() => { PrintNext(Mode.Buzz); }));
            tasks.Add(Task.Run(() => { PrintNext(Mode.FizzBuzz); }));
            tasks.Add(Task.Run(() => { PrintNext(Mode.None); }));

            Task.WaitAll(tasks.ToArray());
        }

        public void PrintNext(Mode mode)
        {
           while (true)
            {
                lock (sync)
                {
                    if (number > maxNumber) return;
                    if (predicates[mode](number))
                    {
                        printer(printValues[mode](number));
                        number++;
                    }
                }
            }
        }
    }
}
