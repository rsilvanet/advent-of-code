using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")
                .Select(x => int.Parse(x))
                .ToArray();

            RunPart1(input);
            RunPart2(input);
            Console.Read();
        }

        public static void RunPart1(int[] input)
        {
            Console.WriteLine("Day 1 - Part 1");
            Console.WriteLine("Result: " + input.Sum(x => x));
            Console.WriteLine("End");
        }

        public static void RunPart2(int[] input)
        {
            var current = 0;
            var repeated = false;
            var results = new List<int>();

            while (!repeated)
            {
                foreach (var item in input)
                {
                    current += item;

                    if (results.Contains(current))
                    {
                        repeated = true;
                        break;
                    }

                    results.Add(current);
                }
            }

            Console.WriteLine("Day 1 - Part 2");
            Console.WriteLine("Result: " + current);
            Console.WriteLine("End");        
        }
    }
}
