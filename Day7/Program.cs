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
                .Select(line => (line.Substring(6, 1), line.Substring(37, 1)))
                .ToArray();
        }

        private static Item FindItem(Item currentItem, string letter)
        {
            if (currentItem.Letter == letter)
            {
                return currentItem;
            }

            foreach (var item in currentItem.ItemsBefore)
            {
                return FindItem(currentItem);
            }

            return null;
        }

        public static void RunPart1((string, string)[] input)
        {
            var itemsList = new List<Item>();

            foreach (var item in input)
            {
                if (currentItem == null)
                {
                    var newItem = new Item(item.Item2);
                    var newItemBefore = new Item(item.Item1);
                    
                    newItem.ItemsBefore.Add(newItemBefore);

                    itemsList.Add(newItem);
                    itemsList.Add(newItemBefore);
                }

                var newItem = new Item(item.Item2);
                var newItemBefore = new Item(item.Item1);
                
                newItem.ItemsBefore.Add(newItemBefore);
            }
        }


        public class Item
        {
            public Item(string letter)
            {
                Letter = letter;
                ItemsBefore = new List<Item>();
            }

            public string Letter { get; set; }
            public List<Item> ItemsBefore { get; set; }
        }
    }
}
