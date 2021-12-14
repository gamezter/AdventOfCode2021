using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day14
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day14.txt");

            List<(string, char)> rules = new List<(string, char)>();
            Regex r = new Regex(@"(?<pair>\w\w) -> (?<single>\w)");

            for(int i = 2; i < lines.Length; ++i)
            {
                Match m = r.Match(lines[i]);
                rules.Add((m.Groups["pair"].Value, m.Groups["single"].Value[0]));
            }

            int[] counts = new int[26];

            int length = lines[0].Length;

            for (int i = 0; i < length - 1; ++i)
                func(lines[0][i], lines[0][i + 1], 10);
            counts[lines[0][length - 1] - 'A']++;

            void func(char a, char b, int depth)
            {
                if (depth == 0)
                {
                    counts[a - 'A']++;
                    return;
                }

                var v = rules.Find(rule => rule.Item1[0] == a && rule.Item1[1] == b);

                func(a, v.Item2, depth - 1);
                func(v.Item2, b, depth - 1);
            }

            int max = 0;
            int min = int.MaxValue;

            foreach(var el in counts)
            {
                if (el < min && el != 0)
                    min = el;
                if (el > max)
                    max = el;
            }

            Console.WriteLine(max - min);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day14.txt");

            List<(string, char)> rules = new List<(string, char)>();
            Regex r = new Regex(@"(?<pair>\w\w) -> (?<single>\w)");

            for (int i = 2; i < lines.Length; ++i)
            {
                Match m = r.Match(lines[i]);
                rules.Add((m.Groups["pair"].Value, m.Groups["single"].Value[0]));
            }

            long[] counts = new long[26];

            int length = lines[0].Length;

            for (int i = 0; i < length - 1; ++i)
                func(lines[0][i], lines[0][i + 1], 40);
            counts[lines[0][length - 1] - 'A']++;

            void func(char a, char b, int depth)
            {
                if (depth == 0)
                {
                    counts[a - 'A']++;
                    return;
                }

                var v = rules.Find(rule => rule.Item1[0] == a && rule.Item1[1] == b);

                func(a, v.Item2, depth - 1);
                func(v.Item2, b, depth - 1);
            }

            long max = 0;
            long min = long.MaxValue;

            foreach (var el in counts)
            {
                if (el < min && el != 0)
                    min = el;
                if (el > max)
                    max = el;
            }

            Console.WriteLine(max - min);
            Console.Read();
        }
    }
}
