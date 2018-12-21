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
                var current = items.Where(x => x.Letter == line.first).FirstOrDefault();

                if (current == null)
                {
                    current = new Item(line.first);
                    items.Add(current);
                }

                var next = items.Where(x => x.Letter == line.second).FirstOrDefault();

                if (next == null)
                {
                    next = new Item(line.second);
                    items.Add(next);
                }

                current.NextItems.Add(next);
            }

            var root = new Item("ROOT");

            foreach (var item in items)
            {
                if (items.Any(x => x.NextItems.Any(z => z.Letter == item.Letter)))
                {
                    continue;
                }

                root.NextItems.Add(item);
            }

            Console.WriteLine(root.NextItems.Count);
        }

        public class Item
        {
            public Item(string letter)
            {
                Letter = letter;
                NextItems = new List<Item>();
                Available = true;
            }

            public string Letter { get; set; }
            public List<Item> NextItems { get; set; }
            public bool Available { get; set; }
        }
    }
}
