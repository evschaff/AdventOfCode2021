using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day1
    {
        private List<int> depths;

        private List<int> GetDepths()
        {
            if (this.depths != null)
            {
                return this.depths;
            }

            this.depths = File.ReadAllLines("depths.txt").Select(x => Int32.Parse(x)).ToList();

            return this.depths;
        }

        private int GetIncreaseCount(List<int> list)
        {
            Assert.IsTrue(depths.Count() > 1, "Invalid input");

            var increaseCount = 0;
            for (var i = 1; i < list.Count(); ++i)
            {
                if (list[i] > list[i - 1])
                {
                    increaseCount++;
                }
            }

            return increaseCount;
        }

        [TestMethod]
        public void Part1()
        {
            var depths = this.GetDepths();
            Assert.IsTrue(depths.Count() > 1, "depths input incorrectly parsed");

            var increaseCount = this.GetIncreaseCount(depths);
            Debug.WriteLine(increaseCount);
        }

        [TestMethod]
        public void Part2()
        {
            var depths = this.GetDepths();
            Assert.IsTrue(depths.Count() > 2, "depths input incorrectly parsed");

            var smoothedDepths = new List<int>();
            for (var i = 2; i < depths.Count(); ++i)
            {
                smoothedDepths.Add(depths[i - 2] + depths[i - 1] + depths[i]);
            }

            var increaseCount = this.GetIncreaseCount(smoothedDepths);
            Debug.WriteLine(increaseCount);
        }
    }
}
