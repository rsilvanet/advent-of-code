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
                item.Prerequisites = items.Where(x => x.NextItems.Any(z => z.Letter == item.Letter)).ToList();

                if (!item.Prerequisites.Any())
                {
                    root.NextItems.Add(item);
                }           
            }

            var result = string.Empty;

            while (items.Any(x => x.Available))
            {
                result += GetNext(root).Letter;
            }

            Console.WriteLine("Day 7 - Part 1");
            Console.WriteLine("Result: " + result);
            Console.WriteLine("End");
        }

        private static Item GetNext(Item root)
        {
            var possibleNextItems = new List<Item>();

            foreach (var item in root.NextItems)
            {
                AddPossibleNextItems(item, possibleNextItems);
            }

            var next = possibleNextItems.OrderBy(x => x.Letter).First();

            next.Available = false;

            return next;
        }

        private static void AddPossibleNextItems(Item start, IList<Item> possibleNextItems)
        {
            if (start.Available && !start.Prerequisites.Any(x => x.Available))
            {
                possibleNextItems.Add(start);
            }
            else
            {
                foreach (var item in start.NextItems)
                {
                    if (item.Available && !item.Prerequisites.Any(x => x.Available))
                    {
                        possibleNextItems.Add(item);
                    }
                    else 
                    {
                        foreach (var item2 in item.NextItems)
                        {
                            AddPossibleNextItems(item2, possibleNextItems);
                        }
                    }
                }
            }
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
            public List<Item> Prerequisites { get; set; }
            public bool Available { get; set; }

            public override string ToString()
            {
                var result = Letter;

                foreach (var item in NextItems)
                {
                    result +=  " -> " + item.Letter;
                }

                return result;
            }
        }
    }
}
