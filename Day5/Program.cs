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
            RunPart2(input);
        }

        private static int DoReactions(string input)
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

            return input.Length;
        }

        public static void RunPart1(string input)
        {
            Console.WriteLine("Day 5 - Part 1");
            Console.WriteLine("Result: " + DoReactions(input));
            Console.WriteLine("End");
        }

        public static void RunPart2(string input)
        {
            var lowerLength = int.MaxValue;

            for (int i = 65; i <= 90; i++)
            {
                var tempChar = ((char)i).ToString();
                var tempInput = input.Replace(tempChar, string.Empty, StringComparison.InvariantCultureIgnoreCase);
                var lengthAfterReactions = DoReactions(tempInput);

                if (lengthAfterReactions < lowerLength)
                {
                    lowerLength = lengthAfterReactions;
                }
            }
            
            Console.WriteLine("Day 5 - Part 2");
            Console.WriteLine("Result: " + lowerLength);
            Console.WriteLine("End");
        }
    }
}
