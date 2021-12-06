using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    class Day5
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day5.txt");

            Regex regex = new Regex(@"(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)");

            Dictionary<(int, int), int> points = new Dictionary<(int, int), int>();

            for (var i = 0; i < lines.Length; ++i)
            {
                var m = regex.Match(lines[i]);
                int x1 = int.Parse(m.Groups["x1"].Value);
                int y1 = int.Parse(m.Groups["y1"].Value);
                int x2 = int.Parse(m.Groups["x2"].Value);
                int y2 = int.Parse(m.Groups["y2"].Value);

                if (x1 != x2 && y1 != y2)
                    continue;

                int dx = x2.CompareTo(x1);
                int dy = y2.CompareTo(y1);

                int x = x1;
                int y = y1;

                while(x != x2 || y != y2)
                {
                    if(points.TryGetValue((x, y), out int c))
                        points[(x, y)] = c + 1;
                    else
                        points.Add((x, y), 1);

                    x += dx;
                    y += dy;
                }

                if (points.TryGetValue((x2, y2), out int c2))
                    points[(x2, y2)] = c2 + 1;
                else
                    points.Add((x2, y2), 1);
            }

            int count = 0;
            foreach(var kvp in points)
            {
                if (kvp.Value > 1)
                    count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day5.txt");

            Regex regex = new Regex(@"(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)");

            Dictionary<(int, int), int> points = new Dictionary<(int, int), int>();

            for (var i = 0; i < lines.Length; ++i)
            {
                var m = regex.Match(lines[i]);
                int x1 = int.Parse(m.Groups["x1"].Value);
                int y1 = int.Parse(m.Groups["y1"].Value);
                int x2 = int.Parse(m.Groups["x2"].Value);
                int y2 = int.Parse(m.Groups["y2"].Value);

                int dx = x2.CompareTo(x1);
                int dy = y2.CompareTo(y1);

                int x = x1;
                int y = y1;

                while (x != x2 || y != y2)
                {
                    if (points.TryGetValue((x, y), out int c))
                        points[(x, y)] = c + 1;
                    else
                        points.Add((x, y), 1);

                    x += dx;
                    y += dy;
                }

                if (points.TryGetValue((x2, y2), out int c2))
                    points[(x2, y2)] = c2 + 1;
                else
                    points.Add((x2, y2), 1);
            }

            int count = 0;
            foreach (var kvp in points)
            {
                if (kvp.Value > 1)
                    count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
