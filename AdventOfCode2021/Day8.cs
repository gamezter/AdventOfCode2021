using System;
using System.IO;

namespace AdventOfCode2021
{
    class Day8
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            int count = 0;
            foreach(var line in lines)
            {
                string[] digits = line.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 10; i < digits.Length; ++i)
                {
                    int length = digits[i].Length;

                    if (length == 2 || length == 3 || length == 4 || length == 7)
                        count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
