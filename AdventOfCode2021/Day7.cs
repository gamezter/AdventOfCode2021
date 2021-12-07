using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day7
    {
        public static void part1()
        {
            string[] numbers = File.ReadAllLines("day7.txt")[0].Split(',');

            int[] positions = new int[numbers.Length];

            for (int i = 0; i < positions.Length; ++i)
                positions[i] = int.Parse(numbers[i]);

            List<int> costs = new List<int>();

            for(int i = 0; i < 2000; ++i)
            {
                int cost = 0;

                for (int j = 0; j < positions.Length; ++j)
                    cost += Math.Abs(positions[j] - i);
                costs.Add(cost);
            }

            costs.Sort();

            Console.WriteLine(costs[0]);
            Console.Read();
        }

        public static void part2()
        {
            string[] numbers = File.ReadAllLines("day7.txt")[0].Split(',');

            int[] positions = new int[numbers.Length];

            for (int i = 0; i < positions.Length; ++i)
                positions[i] = int.Parse(numbers[i]);

            List<int> costs = new List<int>();

            for (int i = 0; i < 2000; ++i)
            {
                int cost = 0;

                for (int j = 0; j < positions.Length; ++j)
                {
                    int abs = Math.Abs(positions[j] - i);
                    cost += abs * (abs + 1) / 2;
                }
                    
                costs.Add(cost);
            }

            costs.Sort();

            Console.WriteLine(costs[0]);
            Console.Read();
        }
    }
}
