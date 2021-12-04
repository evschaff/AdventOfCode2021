using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    [TestClass]
    public class Day4
    {
        private class Cell
        {
            public Cell(int value)
            {
                this.Value = value;
                this.Called = false;
            }

            public int Value { get; set; }

            public bool Called { get; set; }
        }

        private List<int> numbers;
        private List<List<List<Cell>>> boards;

        private List<int> GetNumbers()
        {
            if (this.numbers != null)
            {
                return this.numbers;
            }

            var allText = File.ReadAllLines("bingo.txt").ToList();
            this.numbers = allText[0].Split(",").Select(x => Int32.Parse(x)).ToList();

            return this.numbers;
        }

        private List<List<List<Cell>>> GetBoards()
        {
            if (this.boards != null)
            {
                return this.boards;
            }

            var allText = File.ReadAllLines("bingo.txt").ToList();

            this.boards = new List<List<List<Cell>>>();

            for (var i = 2; i < allText.Count; i += 6)
            {
                var board = new List<List<Cell>>();

                board.Add(allText[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Cell(Int32.Parse(x))).ToList());
                board.Add(allText[i + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Cell(Int32.Parse(x))).ToList());
                board.Add(allText[i + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Cell(Int32.Parse(x))).ToList());
                board.Add(allText[i + 3].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Cell(Int32.Parse(x))).ToList());
                board.Add(allText[i + 4].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => new Cell(Int32.Parse(x))).ToList());

                this.boards.Add(board);
            }

            return this.boards;
        }


        private bool MarkAndCheckForBingo(List<List<Cell>> board, int markValue)
        {
            for (var i = 0; i < board.Count; ++i)
            {
                for (var j = 0; j < board[i].Count; ++j)
                {
                    if (board[i][j].Value == markValue)
                    {
                        board[i][j].Called = true;

                        bool horizonal = true;
                        for (var r = 0; r < board.Count; ++r)
                        {
                            if (!board[r][j].Called)
                            {
                                horizonal = false;
                            }
                        }

                        bool verical = true;
                        for (var r = 0; r < board.Count; ++r)
                        {
                            if (!board[i][r].Called)
                            {
                                verical = false;
                            }
                        }

                        bool diag = true;
                        for (var r = 0; r < board.Count; ++r)
                        {
                            for (var s = 0; s < board.Count; ++s)
                            {
                                if (!board[r][s].Called)
                                {
                                    diag = false;
                                }
                            }
                        }

                        bool diag2 = true;
                        for (var r = 0; r < board.Count; ++r)
                        {
                            for (var s = board.Count - 1; s >= 0; --s)
                            {
                                if (!board[r][s].Called)
                                {
                                    diag2 = false;
                                }
                            }
                        }

                        bool bingo = horizonal || verical || diag || diag2;
                        return bingo;

                    }
                }
            }

            return false;
        }


        [TestMethod]
        public void Part1()
        {
            var numbers = this.GetNumbers();
            var boards = this.GetBoards();

            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    var hasBingo = this.MarkAndCheckForBingo(board, number);

                    if (hasBingo)
                    {
                        var total = 0;
                        foreach (var row in board)
                        {
                            foreach (var col in row)
                            {
                                if (!col.Called)
                                {
                                    total += col.Value;
                                }
                            }
                        }

                        Debug.WriteLine(total * number);
                        return;
                    }
                }
            }
        }

        [TestMethod]
        public void Part2()
        {
            var numbers = this.GetNumbers();
            var boards = this.GetBoards();

            foreach (var number in numbers)
            {
                for (var i = boards.Count - 1; i >= 0; --i)
                {
                    var hasBingo = this.MarkAndCheckForBingo(boards[i], number);

                    if (boards.Count == 1 && hasBingo)
                    {
                        var total = 0;
                        foreach (var row in boards[i])
                        {
                            foreach (var col in row)
                            {
                                if (!col.Called)
                                {
                                    total += col.Value;
                                }
                            }
                        }

                        Debug.WriteLine(total * number);
                    }

                    if (hasBingo)
                    {
                        boards.RemoveAt(i);
                    }
                }
            }
        }
    }
}
