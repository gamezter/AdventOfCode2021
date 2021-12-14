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

            List<char> curr = new List<char>();
            for (int i = 0; i < lines[0].Length; ++i)
                curr.Add(lines[0][i]);

            List<(string, char)> rules = new List<(string, char)>();
            Regex r = new Regex(@"(?<pair>\w\w) -> (?<single>\w)");

            for(int i = 2; i < lines.Length; ++i)
            {
                Match m = r.Match(lines[i]);
                rules.Add((m.Groups["pair"].Value, m.Groups["single"].Value[0]));
            }

            for(int i = 0; i < 10; ++i)
            {
                List<char> next = new List<char>(curr.Count * 2);
                for(int j = 0; j < curr.Count - 1; ++j)
                {
                    char a = curr[j];
                    char b = curr[j + 1];
                    next.Add(a);
                    var v = rules.Find(rule => rule.Item1[0] == a && rule.Item1[1] == b);
                    next.Add(v.Item2);
                }
                next.Add(curr[curr.Count - 1]);
                curr = next;
            }

            int[] counts = new int[26];

            foreach(var el in curr)
            {
                counts[el - 'A']++;
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
    }
}
