using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day8
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            Regex r = new Regex(@"(\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) (\w+) \| (\w+) (\w+) (\w+) (\w+)");

            int count = 0;
            foreach(var line in lines)
            {
                Match m = r.Match(line);

                for (int i = 11; i < 15; ++i)
                {
                    int length = m.Groups[i].Value.Length;

                    if (length == 2 || length == 3 || length == 4 || length == 7)
                        count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
