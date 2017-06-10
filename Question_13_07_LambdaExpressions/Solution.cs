using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_13_07_LambdaExpressions
{
    public class Solution
    {
        public int GetPopulation(List<Country> countries, string inContinent)
        {
            var countriesInContinent = countries.FindAll((country) => country.Continent == inContinent);
            var population = 
                countriesInContinent.Aggregate(
                    0, 
                    (currentPopulation, currentCountry) => currentPopulation + currentCountry.Population);

            return population;
        }

        public int GetPopulationApproach2(List<Country> countries, string inContinent)
        {
            var population =
                countries.Aggregate(
                    0,
                    (currentPopulation, currentCountry) => currentPopulation + 
                    (currentCountry.Continent == inContinent ? currentCountry.Population : 0));

            return population;
        }
    }
}
