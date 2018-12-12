using System;
using System.IO;

namespace Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            RunPart1(input);
        }

        public static void RunPart1(string input)
        {
            var stillRemoving = true;

            while (stillRemoving)
            {
                stillRemoving = false;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (Math.Abs((int)input[i] - (int)input[i+1]) == 32)
                    {
                        input = input.Remove(i, 2);
                        stillRemoving = true;
                    }
                }
            }

            Console.WriteLine("Day 5 - Part 1");
            Console.WriteLine("Result: " + input.Length);
            Console.WriteLine("End");
        }
    }
}
