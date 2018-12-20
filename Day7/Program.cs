using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")
                .Select(line => (line.Substring(5, 1), line.Substring(36, 1)))
                .ToArray();

            RunPart1(input);
        }

        public static void RunPart1((string first, string second)[] input)
        {
            var items = new List<Item>();

            foreach (var line in input)
            {
                var first = items.Where(x => x.Letter == line.first).FirstOrDefault();

                if (first == null)
                {
                    first = new Item(line.first);
                    items.Add(first);
                }

                var second = items.Where(x => x.Letter == line.second).FirstOrDefault();

                if (second == null)
                {
                    second = new Item(line.second);
                    items.Add(second);
                }

                second.ItemsBefore.Add(first);
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(items.Single(x => !x.ItemsBefore.Any()).Letter);
        }

        public class Item
        {
            public Item(string letter)
            {
                Letter = letter;
                ItemsBefore = new List<Item>();
                Available = true;
            }

            public string Letter { get; set; }
            public List<Item> ItemsBefore { get; set; }
            public bool Available { get; set; }
        }
    }
}
