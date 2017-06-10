using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Question_17_08_CircusTower.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void BuildTowerTest()
        {
            Person person1 = new Person(5, 100);
            Person person2 = new Person(6, 200);
            Person person3 = new Person(5.4, 150);
            Person person4 = new Person(4.8, 120);

            List<Person> people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);

            Solution solution = new Solution();
            var tower = solution.BuildTower(people);
            Trace.Write(tower);            
        }

        [TestMethod]
        public void BuildTowerTest2()
        {
            Person person1 = new Person(6.1, 161);
            Person person2 = new Person(6.3, 197);
            Person person3 = new Person(5, 176);
            Person person4 = new Person(6.2, 137);
            List<Person> people = new List<Person>();

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);

            Solution solution = new Solution();
            var tower = solution.BuildTower(people);
            Trace.Write(tower);
        }

        [TestMethod]
        public void BuildTowerEqualHeightTest()
        {
            Person person1 = new Person(6, 161);
            Person person2 = new Person(6, 197);
            Person person3 = new Person(5, 176);
            Person person4 = new Person(6, 137);
            List<Person> people = new List<Person>();

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);

            Solution solution = new Solution();
            var tower = solution.BuildTower(people);
            Trace.Write(tower);
        }

        [TestMethod]
        public void BuildTowerTest3()
        {
            Person person1 = new Person(5.30, 162.45);
            Person person2 = new Person(5.69, 171.53);
            Person person3 = new Person(5.21, 151.51);
            Person person4 = new Person(5.94, 125.40);
            Person person5 = new Person(5.96, 152.82);

            List<Person> people = new List<Person>();

            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            people.Add(person5);

            Solution solution = new Solution();
            var tower = solution.BuildTower(people);
            Trace.Write(tower);
        }

        [TestMethod]
        public void BuildTowerRandomTest1()
        {
            int count = 5;
            Random random = new Random();
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                var person = new Person(5 + random.NextDouble(), 100 + random.NextDouble() * 100);
                people.Add(person);
            }

            var tower = new Solution().BuildTower(people);
            Trace.Write(tower);
        }

        [TestMethod]
        public void BuildTowerRandomLargeTest1()
        {
            int count = 1000;
            Random random = new Random();
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                var person = new Person(5 + random.NextDouble(), 100 + random.NextDouble() * 100);
                people.Add(person);
                Trace.Write(person);
            }

            var tower = new Solution().BuildTower(people);
            Trace.Write(tower);
        }
    }
}