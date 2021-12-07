using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day7
    {
        private List<int> inputs;
        private Dictionary<int, int> stepCostCache = new Dictionary<int, int>();

        private List<int> GetInputs()
        {
            if (this.inputs != null)
            {
                return this.inputs;
            }

            this.inputs = File.ReadAllLines("crabLocations.txt").First().Split(',').Select(x => Int32.Parse(x)).ToList();

            return this.inputs;
        }

        private int GetCost(List<int> values, int change)
        {
            int sum = 0;
            foreach (var v in values)
            {
                sum += Math.Abs(v - change);
            }

            return sum;
        }

        private int GetCost2(List<int> values, int change)
        {
            int sum = 0;
            foreach (var v in values)
            {
                int steps = Math.Abs(v - change);

                if (stepCostCache.TryGetValue(steps, out int cachedCost))
                {
                    sum += cachedCost;
                }
                else
                {
                    int cost = 0;
                    for (int j = 1; j <= steps; ++j)
                    {
                        cost += j;
                    }

                    stepCostCache.Add(steps, cost);
                    sum += cost;
                }
            }

            return sum;
        }

        [TestMethod]
        public void Part1()
        {
            var crabLocations = this.GetInputs();
            var maxValue = crabLocations.Max();

            var allCosts = new List<int>();
            for (int i = 1; i < maxValue; ++i)
            {
                allCosts.Add(this.GetCost(crabLocations, i));
            }

            Debug.WriteLine(allCosts.Min());
        }

        [TestMethod]
        public void Part2()
        {
            var crabLocations = this.GetInputs();
            var maxValue = crabLocations.Max();

            var allCosts = new List<int>();
            for (int i = 1; i < maxValue; ++i)
            {
                allCosts.Add(this.GetCost2(crabLocations, i));
            }

            Debug.WriteLine(allCosts.Min());
        }
    }
}
