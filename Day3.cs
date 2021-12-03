using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day3
    {
        private List<string> inputs;

        private List<string> GetInputs()
        {
            if (this.inputs != null)
            {
                return this.inputs;
            }

            this.inputs = File.ReadAllLines("diagnostics.txt").ToList();

            return this.inputs;
        }

        private (int zeros, int ones) CountBitsInCol(List<string> rows, int col)
        {
            int oneCount = 0;
            int zeroCount = 0;

            for (var j = 0; j < rows.Count; ++j)
            {
                if (rows[j][col] == '0')
                {
                    zeroCount++;
                }
                else
                {
                    oneCount++;
                }
            }

            return (zeros: zeroCount, ones: oneCount);
        }

        [TestMethod]
        public void Part1()
        {
            var inputs = this.GetInputs();

            var gammaRateStr = new StringBuilder();
            var epsilonRateStr = new StringBuilder();

            var rowLength = inputs[0].Length;

            for (var i = 0; i < rowLength; ++i)
            {
                var columnInfo = this.CountBitsInCol(inputs, i);

                if (columnInfo.ones >= columnInfo.zeros)
                {
                    gammaRateStr.Append('1');
                    epsilonRateStr.Append('0');
                }
                else
                {
                    gammaRateStr.Append('0');
                    epsilonRateStr.Append('1');
                }
            }

            var gammaRate = Convert.ToInt32(gammaRateStr.ToString(), fromBase: 2);
            var epsilonRate = Convert.ToInt32(epsilonRateStr.ToString(), fromBase: 2);

            Debug.WriteLine(gammaRate * epsilonRate);
        }

        [TestMethod]
        public void Part2()
        {
            var inputs = this.GetInputs();

            var oxInputs = inputs;
            var coInputs = inputs.ToList();

            var rowLength = inputs[0].Length;

            for (var i = 0; i < rowLength; ++i)
            {
                if (oxInputs.Count > 1)
                {
                    var oxColumnInfo = this.CountBitsInCol(oxInputs, i);
                    if (oxColumnInfo.ones >= oxColumnInfo.zeros)
                    {
                        oxInputs.RemoveAll(x => x[i] != '1');
                    }
                    else
                    {
                        oxInputs.RemoveAll(x => x[i] != '0');
                    }
                }

                if (coInputs.Count > 1)
                {
                    var coColumnInfo = this.CountBitsInCol(coInputs, i);
                    if (coColumnInfo.ones >= coColumnInfo.zeros)
                    {
                        coInputs.RemoveAll(x => x[i] == '1');
                    }
                    else
                    {
                        coInputs.RemoveAll(x => x[i] == '0');
                    }
                }
            }

            var oxGenRating = Convert.ToInt32(oxInputs[0], 2);
            var coScrubRating = Convert.ToInt32(coInputs[0], 2);

            Debug.WriteLine(oxGenRating * coScrubRating);
        }
    }
}
