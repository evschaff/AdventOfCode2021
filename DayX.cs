using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class DayX
    {
        private List<object> inputs;

        private List<object> GetInputs()
        {
            if (this.inputs != null)
            {
                return this.inputs;
            }

            this.inputs = File.ReadAllLines("input.txt").Select(x => (object)x).ToList();

            return this.inputs;
        }


        [TestMethod]
        public void Part1()
        {
            var inputs = this.GetInputs();

            // Debug.WriteLine();
        }

        [TestMethod]
        public void Part2()
        {
            var inputs = this.GetInputs();

            // Debug.WriteLine();
        }
    }
}
