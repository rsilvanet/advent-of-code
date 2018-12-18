using System;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")
                .Select(line => 
                {
                    var split = line.Split(",");
                    var cordX = int.Parse(split[0].Trim());
                    var cordY = int.Parse(split[1].Trim());

                    return new Point(cordX, cordY);
                })
                .ToArray();

            var matrix = RunPart1(input);
            RunPart2(input, matrix);
        }

        public static char?[,] RunPart1(Point[] input)
        {
            var maxX = input.Max(point => point.X) + 1;
            var maxY = input.Max(point => point.Y) + 1;
            var matrix = new char?[maxX, maxY];

            for (int i = 0; i < input.Length; i++)
            {
                var point = input[i];
                var character = Convert.ToChar(i + 65);

                point.Value = character;
                matrix[point.X, point.Y] = character;
                point.Size++;
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (matrix[x, y] == null)
                    {
                        var closerDistancePoint = input
                            .GroupBy(p => p.CalculateDistance(x, y))
                            .OrderBy(g => g.Key)
                            .First();

                        if (closerDistancePoint.Count() > 1)
                        {
                            matrix[x, y] = '.';
                        }
                        else
                        {
                            var point = closerDistancePoint.First();
                            matrix[x, y] = point.Value;
                            point.Size++;

                            if (x == 0 || y == 0 || x == maxX || y == maxY)
                            {
                                point.Infinite = true;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Day 6 - Part 1");
            Console.WriteLine("Result: " + input.Where(p => !p.Infinite).Max(p => p.Size));
            Console.WriteLine("End");

            return matrix;
        }

        public static void RunPart2(Point[] input, char?[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] == '.')
                    {
                        continue;
                    }

                    var distance = 0;

                    foreach (var point in input)
                    {
                        distance += point.CalculateDistance(x, y);
                    }

                    if (distance < 10000)
                    {
                        var point = input
                            .Where(p => p.Value == matrix[x, y])
                            .Single();
                        
                        point.CountInRange++;
                    }
                }
            }

            Console.WriteLine("Day 6 - Part 2");
            Console.WriteLine("Result: " + input.Where(p => p.Size == p.CountInRange).Count());
            Console.WriteLine("End");
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public char? Value { get; set; }
            public int Size { get; set; }
            public bool Infinite { get; set; }
            public int CountInRange { get; set; }

            public int CalculateDistance(int x, int y)
            {
                return Math.Abs(X - x) + Math.Abs(Y - y);
            }
        }
    }
}
