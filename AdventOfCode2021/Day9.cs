using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day9
    {
        static (int, int)[] offsets = new[] { (-1, 0), (0, -1), (1, 0), (0, 1) };
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day9.txt");

            int sum = 0;

            for(int y = 0; y < lines.Length; ++y)
            {
                string line = lines[y];
                for(int x = 0; x < line.Length; ++x)
                {
                    int center = line[x] - '0';
                    for(int i = 0; i < 4; ++i)
                    {
                        int nx = x + offsets[i].Item1;
                        int ny = y + offsets[i].Item2;
                        if (nx < 0 || nx >= lines.Length || ny < 0 || ny >= line.Length)
                            continue;

                        if ((lines[ny][nx] - '0') <= center)
                            goto skip;
                    }
                    sum += center + 1;
skip:               ;
                }
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
