using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day6
    {
        private List<int> inputs;

        private List<int> GetInputs()
        {
            if (this.inputs != null)
            {
                return this.inputs;
            }

            this.inputs = File.ReadAllLines("state.txt").First().Split(',').Select(x => Int32.Parse(x)).ToList();

            return this.inputs;
        }

        public long[] AddDay(long[] fishOnCycle)
        {
            var newCycle = new long[9];

            for (var i = 0; i < fishOnCycle.Length - 1; ++i)
            {
                newCycle[i] = fishOnCycle[i + 1];
            }

            newCycle[6] += fishOnCycle[0];
            newCycle[8] = fishOnCycle[0];

            return newCycle;
        }

        [TestMethod]
        public void Part1()
        {
            var state = this.GetInputs();

            var fishOnCycle = new long[9];
            foreach (var fish in state)
            {
                fishOnCycle[fish]++;
            }

            for (int i = 0; i < 80; ++i)
            {
                fishOnCycle = this.AddDay(fishOnCycle);
            }

            Debug.WriteLine(fishOnCycle.Sum());
        }

        [TestMethod]
        public void Part2()
        {
            var state = this.GetInputs();

            var fishOnCycle = new long[9];
            foreach (var fish in state)
            {
                fishOnCycle[fish]++;
            }

            for (int i = 0; i < 256; ++i)
            {
                fishOnCycle = this.AddDay(fishOnCycle);
            }

            Debug.WriteLine(fishOnCycle.Sum());
        }
    }
}
