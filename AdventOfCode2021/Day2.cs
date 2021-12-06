using System;
using System.IO;

namespace AdventOfCode2021
{
    class Day2
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day2.txt");

            int depth = 0;
            int position = 0;

            for(int i = 0; i < lines.Length; ++i)
            {
                string[] line = lines[i].Split();
                int val = int.Parse(line[1]);
                switch (line[0])
                {
                    case "forward":
                        position += val;
                        break;
                    case "up":
                        depth -= val;
                        break;
                    case "down":
                        depth += val;
                        break;

                }
            }

            Console.WriteLine(depth * position);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day2.txt");

            int depth = 0;
            int position = 0;
            int aim = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                string[] line = lines[i].Split();
                int val = int.Parse(line[1]);
                switch (line[0])
                {
                    case "forward":
                        position += val;
                        depth += val * aim;
                        break;
                    case "up":
                        aim -= val;
                        break;
                    case "down":
                        aim += val;
                        break;

                }
            }

            Console.WriteLine(depth * position);
            Console.Read();
        }
    }
}
