using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")
                .OrderBy(x => x)
                .ToArray();

            RunPart1(input);
        }

        public static void RunPart1(string[] input)
        {
            var currentGuard = 0;
            var currentSleepMinute = 0;
            var regexGuard = "#[0-9]+";
            var regexHour = "[0-9]+:[0-9]+";
            var dictionary = new Dictionary<int, int[]>();

            foreach (var line in input)
            {
                var matchGuard = Regex.Match(line, regexGuard);

                if (matchGuard.Success)
                {
                    currentGuard = int.Parse(matchGuard.ToString().Replace("#", ""));
                }

                if (currentGuard > 0)
                {
                    if (!dictionary.ContainsKey(currentGuard))
                    {
                        dictionary.Add(currentGuard, new int[60]);
                    }

                    var matchHour = Regex.Match(line, regexHour);

                    if (line.Contains("falls asleep"))
                    {
                        currentSleepMinute = int.Parse(matchHour.ToString().Split(':')[1]);
                    }
                    else if (line.Contains("wakes up"))
                    {
                        var wakeMinute = int.Parse(matchHour.ToString().Split(':')[1]);

                        for (int i = currentSleepMinute; i < wakeMinute; i++)
                        {
                            dictionary[currentGuard][i]++;
                        }
                    }
                }
            }

            var topSleepGuard = dictionary.OrderBy(x => x.Value.Sum()).Last();
            var topSleepMinuteIndex = 0;            
            var topSleepMinuteValue = 0;
            

            for (int i = 0; i < 60; i++)
            {
                if (topSleepGuard.Value[i] > topSleepMinuteValue)
                {
                    topSleepMinuteIndex = i;
                    topSleepMinuteValue = topSleepGuard.Value[i];
                }
            }

            
            Console.WriteLine("Day 4 - Part 1");
            Console.WriteLine("Result: " + topSleepGuard.Key * topSleepMinuteIndex);
            Console.WriteLine("End");
        }
    }
}
