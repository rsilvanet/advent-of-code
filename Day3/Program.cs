using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var regex1 = "[0-9]+,[0-9]+";
            var regex2 = "[0-9]+x[0-9]+";
            
            var input = File.ReadAllLines("input.txt")
                .Select(x => 
                {
                    var match1 = Regex.Match(x, regex1)
                        .ToString()
                        .Split(',')
                        .Select(z => int.Parse(z))
                        .ToArray();

                    var match2 = Regex.Match(x, regex2)
                        .ToString()
                        .Split('x')
                        .Select(z => int.Parse(z))
                        .ToArray();

                    return new Claim()
                    {
                        FromTheLeft = match1[0],
                        FromTheTop = match1[1],
                        Width = match2[0],
                        Height = match2[1]
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

            foreach (var claim in input)
            {
                for (int i = claim.FromTheLeft; i < claim.FromTheLeft + claim.Width; i++)
                {
                    for (int j = claim.FromTheTop; j < claim.FromTheTop + claim.Height; j++)
                    {
                        fabric[i,j] = fabric[i,j] + 1;

                        if (fabric[i,j] == 2)
                        {
                            result++;
                        }
                    }
                }
            }
            
            Console.WriteLine("Day 3 - Part 1");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("End");
        }

        public static void RunPart2(Claim[] input)
        {
            
        }

        public class Claim
        {
            public int FromTheLeft { get; set; }
            public int FromTheTop { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }
}
