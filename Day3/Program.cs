using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var regex1 = "#[0-9]+";
            var regex2 = "[0-9]+,[0-9]+";
            var regex3 = "[0-9]+x[0-9]+";
            
            var input = File.ReadAllLines("input.txt")
                .Select(x => 
                {
                    var match1 = Regex.Match(x, regex1)
                        .ToString()
                        .Replace("#", "");

                    var match2 = Regex.Match(x, regex2)
                        .ToString()
                        .Split(',')
                        .Select(z => int.Parse(z))
                        .ToArray();

                    var match3 = Regex.Match(x, regex3)
                        .ToString()
                        .Split('x')
                        .Select(z => int.Parse(z))
                        .ToArray();

                    return new Claim()
                    {
                        Id = match1,
                        FromTheLeft = match2[0],
                        FromTheTop = match2[1],
                        Width = match3[0],
                        Height = match3[1]
                    };
                })
                .ToArray();

            RunPart1(input);
            RunPart2(input);
            Console.Read();
        }

        public static void RunPart1(Claim[] input)
        {
            var result = 0;
            var fabric = new int[1000,1000];

            foreach (var (x,y) in input.SelectMany(x => x.GetInches()))
            {
                fabric[x,y]++;

                if (fabric[x,y] == 2)
                {
                    result++;
                }
            }
            
            Console.WriteLine("Day 3 - Part 1");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("End");
        }

        public static void RunPart2(Claim[] input)
        {
            var result = 0;
            var fabric = new int[1000,1000];

            Console.WriteLine("Day 3 - Part 2");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("End");
        }

        public class Claim
        {
            public string Id { get; set; }
            public int FromTheLeft { get; set; }
            public int FromTheTop { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public IList<(int,int)> GetInches()
            {
                var inches = new List<(int,int)>();

                for (int x = FromTheLeft; x < FromTheLeft + Width; x++)
                {
                    for (int y = FromTheTop; y < FromTheTop + Height; y++)
                    {
                        inches.Add((x, y));
                    }
                }

                return inches;
            }
        }
    }
}
