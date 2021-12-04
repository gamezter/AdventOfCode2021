using System;
using System.IO;

namespace AdventOfCode2021
{
    class Day1
    {
        public static void part1()
        {
            string[] numbers = File.ReadAllLines("day1.txt");
            int[] n = new int[numbers.Length];
            for(int i = 0; i < n.Length; i++)
            {
                n[i] = int.Parse(numbers[i]);
            }

            int increases = 0;

            for(int i = 0; i < n.Length - 1; ++i)
            {
                if (n[i] < n[i + 1])
                    increases++;
            }
            
            Console.WriteLine(increases);
            Console.Read();
        }

        public static void part2()
        {
            string[] numbers = File.ReadAllLines("day1.txt");
            int[] n = new int[numbers.Length];
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = int.Parse(numbers[i]);
            }

            int increases = 0;

            for (int i = 0; i < n.Length - 3; ++i)
            {
                if (n[i] < n[i + 3])
                    increases++;
            }

            Console.WriteLine(increases);
            Console.Read();
        }
    }
}
