using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day5
    {
        class Coord
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        class Line
        {
            public Coord Start { get; set; }

            public Coord End { get; set; }
        }

        private List<Line> inputs;

        private int maxSize = 0;

        private List<Line> GetInputs()
        {
            if (this.inputs != null)
            {
                return this.inputs;
            }

            this.inputs = File.ReadAllLines("lines.txt").Select(x =>
            {
                var line = new Line();
                line.Start = new Coord();
                line.End = new Coord();

                var coords = x.Split("->");
                var startCoords = coords[0].Split(',');
                var endCoords = coords[1].Split(',');

                line.Start.X = Int32.Parse(startCoords[0]);
                line.Start.Y = Int32.Parse(startCoords[1]);

                line.End.X = Int32.Parse(endCoords[0]);
                line.End.Y = Int32.Parse(endCoords[1]);

                maxSize = Math.Max(maxSize, line.Start.X);
                maxSize = Math.Max(maxSize, line.Start.Y);
                maxSize = Math.Max(maxSize, line.End.X);
                maxSize = Math.Max(maxSize, line.End.Y);

                return line;
            }).ToList();

            return this.inputs;
        }


        [TestMethod]
        public void Part1()
        {
            var lines = this.GetInputs();

            var grid = new int[maxSize + 1, maxSize + 1];

            foreach (var line in lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var start = Math.Min(line.Start.Y, line.End.Y);
                    var end = Math.Max(line.Start.Y, line.End.Y);

                    for (int i = start; i <= end; ++i)
                    {
                        grid[line.Start.X, i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var start = Math.Min(line.Start.X, line.End.X);
                    var end = Math.Max(line.Start.X, line.End.X);

                    for (int i = start; i <= end; ++i)
                    {
                        grid[i, line.Start.Y]++;
                    }
                }
            }

            int count = 0;
            foreach (var cell in grid)
            {
                if (cell >= 2)
                {
                    ++count;
                }
            }

            Debug.WriteLine(count);
        }

        [TestMethod]
        public void Part2()
        {
            var lines = this.GetInputs();

            var grid = new int[maxSize + 1, maxSize + 1];

            foreach (var line in lines)
            {
                if (line.Start.X == line.End.X)
                {
                    var start = Math.Min(line.Start.Y, line.End.Y);
                    var end = Math.Max(line.Start.Y, line.End.Y);

                    for (int i = start; i <= end; ++i)
                    {
                        grid[line.Start.X, i]++;
                    }
                }
                else if (line.Start.Y == line.End.Y)
                {
                    var start = Math.Min(line.Start.X, line.End.X);
                    var end = Math.Max(line.Start.X, line.End.X);

                    for (int i = start; i <= end; ++i)
                    {
                        grid[i, line.Start.Y]++;
                    }
                }
                else if (line.Start.Y - line.End.Y == line.Start.X - line.End.X)
                {
                    var startX = Math.Min(line.Start.X, line.End.X);
                    var startY = Math.Min(line.Start.Y, line.End.Y);

                    var length = Math.Abs(line.Start.Y - line.End.Y);

                    for (int i = 0; i <= length; ++i)
                    {
                        grid[startX + i, startY + i]++;
                    }
                }
                else if (line.Start.Y - line.End.Y == -(line.Start.X - line.End.X))
                {
                    var startX = Math.Min(line.Start.X, line.End.X);
                    var startY = Math.Max(line.Start.Y, line.End.Y);

                    var length = Math.Abs(line.Start.Y - line.End.Y);

                    for (int i = 0; i <= length; ++i)
                    {
                        grid[startX + i, startY - i]++;
                    }
                }
            }

            int count = 0;
            foreach (var cell in grid)
            {
                if (cell >= 2)
                {
                    ++count;
                }
            }

            Debug.WriteLine(count);
        }
    }
}
