using System;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToArray();
        
            RunPart1(input);
            RunPart2(input);
            Console.Read();
        }

        public static void RunPart1(string[] input)
        {
            var counterOf2 = 0;
            var counterOf3 = 0;

            foreach (var item in input)
            {
                var group = item.GroupBy(x => x);

                if (group.Any(z => z.Count() == 2))
                {
                    counterOf2++;
                }

                if (group.Any(z => z.Count() == 3))
                {
                    counterOf3++;
                }
            }

            Console.WriteLine("Day 2 - Part 1");
            Console.WriteLine("Result: " + counterOf2 * counterOf3);
            Console.WriteLine("End");            
        }

        public static void RunPart2(string[] input)
        {
            var result = string.Empty;

            foreach (var item1 in input)
            {
                foreach (var item2 in input)
                {
                    if (item1 == item2)
                    {
                        continue;
                    }

                    var diffCount = 0;
                    var diffResult = string.Empty;

                    for (int i = 0; i < item1.Length; i++)
                    {
                        if (item1[i] != item2[i])
                        {
                            diffCount++;
                        }
                        else
                        {
                            diffResult += item1[i];
                        }

                        if (diffCount > 1)
                        {
                            break;
                        }
                    }

                    if (diffCount == 1)
                    {
                        result = diffResult;
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    break;
                }
            }

            Console.WriteLine("Day 2 - Part 2");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("End");
        }
    }
}
