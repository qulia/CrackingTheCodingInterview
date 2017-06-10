using System.Collections.Generic;
using Utilities;

namespace Question_17_08_CircusTower
{
    public class Solution
    {
        /// <summary>
        /// Example of Sort, Recurse with Memoization
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public Tower BuildTower(List<Person> people)
        {
            // Sort by height descending
            people.Sort();
            people.Print();
            Dictionary<int, Tower> map = new Dictionary<int, Tower>();

            Tower tallestTower = new Tower();
            for (int i = 0; i < people.Count; i++)
            {
                var towerWithBottomI = BuildTowerRecurse(people, i, map);
                if (tallestTower < towerWithBottomI)
                {
                    tallestTower = towerWithBottomI;
                }
            }

            return tallestTower;
        }

        private Tower BuildTowerRecurse(
            List<Person> people, 
            int index, 
            Dictionary<int, Tower> map)
        {
            if (map.ContainsKey(index))
            {
                return map[index];
            }
                        
            Tower towerWithIndexBottom = new Tower();
            towerWithIndexBottom.AddBottom(people[index]);

            var tallestTower = towerWithIndexBottom.Clone();

            // Try all higher index values if they can be placed on top
            // Find the max height of such tower
            for (int i = index + 1; i < people.Count; i++)
            {
                var currentTower = towerWithIndexBottom.Clone();

                if (people[i] < people[index])
                {
                    // Find the max tower with the bottom ith person
                    var aboveTower = BuildTowerRecurse(people, i, map);
                    currentTower.Merge(aboveTower);

                    if (currentTower > tallestTower)
                    {
                        tallestTower = currentTower;
                    }
                }
            }

            map[index] = tallestTower;
            return map[index];
        }
    }
}
