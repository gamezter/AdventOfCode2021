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

            Dictionary<(char, char), char> rules = new Dictionary<(char, char), char>();

            for (int i = 2; i < lines.Length; ++i)
            {
                string line = lines[i];
                rules.Add((line[0], line[1]), line[6]);
            }

            int Os = 0;
            int Vs = 0;

            int length = lines[0].Length;

            for (int i = 0; i < length - 1; ++i)
                func(lines[0][i], lines[0][i + 1], 10);

            char last = lines[0][length - 1];
            if (last == 'O')
                Os++;
            else if (last == 'V')
                Vs++;

            void func(char a, char b, int depth)
            {
                if (depth == 0)
                {
                    if (a == 'O')
                        Os++;
                    else if (a == 'V')
                        Vs++;
                    return;
                }

                char c = rules[(a, b)];

                func(a, c, depth - 1);
                func(c, b, depth - 1);
            }

            Console.WriteLine(Os - Vs);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day14.txt");

            Dictionary<(char, char), char> rules = new Dictionary<(char, char), char>();
            Dictionary<(char, char, int), (long, long)> memo = new Dictionary<(char, char, int), (long, long)>();

            for (int i = 2; i < lines.Length; ++i)
            {
                string line = lines[i];
                rules.Add((line[0], line[1]), line[6]);
            }

            long Os = 0;
            long Vs = 0;

            long[] counts = new long[26];

            int length = lines[0].Length;

            for (int i = 0; i < length - 1; ++i)
            {
                var v = func(lines[0][i], lines[0][i + 1], 40);
                Os += v.Item1;
                Vs += v.Item2;
            }

            char last = lines[0][length - 1];
            if (last == 'O')
                Os++;
            else if (last == 'V')
                Vs++;

            (long, long) func(char a, char b, int depth)
            {
                if (depth == 0)
                {
                    if (a == 'O')
                        return (1, 0);
                    else if (a == 'V')
                        return (0, 1);
                    else
                        return (0, 0);
                }

                char c = rules[(a, b)];

                long os = 0;
                long vs = 0;

                if(memo.TryGetValue((a, c, depth - 1), out var value))
                {
                    os += value.Item1;
                    vs += value.Item2;
                }
                else
                {
                    var v = func(a, c, depth - 1);
                    os += v.Item1;
                    vs += v.Item2;
                    memo[(a, c, depth - 1)] = (v.Item1, v.Item2);
                }

                if (memo.TryGetValue((c, b, depth - 1), out var value2))
                {
                    os += value2.Item1;
                    vs += value2.Item2;
                }
                else
                {
                    var v = func(c, b, depth - 1);
                    os += v.Item1;
                    vs += v.Item2;
                    memo[(c, b, depth - 1)] = (v.Item1, v.Item2);
                }

                return (os, vs);
            }

            Console.WriteLine(Os - Vs);
            Console.Read();
        }
    }
}
