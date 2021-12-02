using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day2
    {
        enum Direction
        {
            Forward,
            Down,
            Up
        }

        private List<(Direction direction, int count)> directions;

        private List<(Direction direction, int count)> GetDirections()
        {
            if (this.directions != null)
            {
                return this.directions;
            }

            this.directions = File.ReadAllLines("directions.txt").Select(x =>
            {
                var parts = x.Split(' ');

                Direction d = Direction.Up;
                if (string.Equals(parts[0], "forward", StringComparison.OrdinalIgnoreCase))
                {
                    d = Direction.Forward;
                }
                else if (string.Equals(parts[0], "down", StringComparison.OrdinalIgnoreCase))
                {
                    d = Direction.Down;
                }

                return (d, Int32.Parse(parts[1]));
            }).ToList();

            return this.directions;
        }


        [TestMethod]
        public void Part1()
        {
            var directions = this.GetDirections();

            var depth = 0;
            var horizontal = 0;

            foreach (var d in directions)
            {
                if (d.direction == Direction.Up)
                {
                    depth -= d.count;
                }
                else if (d.direction == Direction.Down)
                {
                    depth += d.count;
                }
                else
                {
                    horizontal += d.count;
                }
            }

            Debug.WriteLine(depth * horizontal);
        }

        [TestMethod]
        public void Part2()
        {
            var directions = this.GetDirections();

            var aim = 0;
            var depth = 0;
            var horizontal = 0;

            foreach (var d in directions)
            {
                if (d.direction == Direction.Up)
                {
                    aim -= d.count;
                }
                else if (d.direction == Direction.Down)
                {
                    aim += d.count;
                }
                else
                {
                    horizontal += d.count;
                    depth += aim * d.count;
                }
            }

            Debug.WriteLine(depth * horizontal);
        }
    }
}
