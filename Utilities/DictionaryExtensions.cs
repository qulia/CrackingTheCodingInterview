using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class DictionaryExtensions
    {
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, int> dictionary, TKey key, int incrementBy = 1)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] += incrementBy;
            }
            else
            {
                dictionary.Add(key, incrementBy);
            }
        }

        public static void RemoveOrDecrement<TKey>(this Dictionary<TKey, int> dictionary, TKey key, int decrementBy = 1)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] -= decrementBy;

                if (dictionary[key] == 0)
                {
                    dictionary.Remove(key);
                }
            }
        }        
    }
}
