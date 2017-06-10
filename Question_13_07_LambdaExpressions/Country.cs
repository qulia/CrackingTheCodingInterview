namespace Question_13_07_LambdaExpressions
{
    public class Country
    {
        public Country(int population, string continent)
        {
            Population = population;
            Continent = continent;
        }

        public int Population
        {
            get;
            set;
        }

        public string Continent
        {
            get;
            set;
        }
    }
}
