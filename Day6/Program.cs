using System;
using System.IO;
using System.Linq;

namespace Day6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")
                .Select(line => 
                {
                    var split = line.Split(",");
                    var cordX = int.Parse(split[0].Trim());
                    var cordY = int.Parse(split[1].Trim());

                    return (cordX, cordY);
                });

            RunPart1(input);
            //RunPart2(input);
        }

        public void RunPart1((int x, int t)[] input)
        {
            var maxX = input.Max(cord => cord.x);
            var maxY = input.Max(cord => cord.x);
            var matrix = new char[maxX, maxY];

            for (int i = 0; i < input.Length; i++)
            {
                var cord = input[i];
                var code = i + 65;

                matrix[cord.x, cord.y] = code;
            }
            
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (matrix[x,y] != default(char))
                    {
                        continue;
                    }

                    var distances = new int[input.Length];
                    var minDistanceIndex = 0;
                    var minDistanceValue = int.MaxValue;

                    for (int i = 0; i < input.Length; i++)
                    {
                        var cord = input[i];
                        var distX = Math.Abs(cordX - x);
                        var distY = Math.Abs(cordY - y);

                        distances[i] = distX + distY;

                        if (distances[i] < minDistanceValue)
                        {
                            minDistanceIndex = i;
                            minDistanceValue = distances[i];
                        }

                        if (distances.Count(dist => dist == minDistanceValue) > 1)
                        {
                            matrix[x, y] = '.';
                        }
                        else 
                        {
                            matrix[x, y] = matrix[cordX, cordY]; 
                        }
                    }
                }
            }
        }
    }
}
