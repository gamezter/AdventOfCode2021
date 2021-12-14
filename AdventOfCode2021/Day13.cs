using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day13
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day13.txt");

            List<(int x, int y)> coords = new List<(int, int)>();
            Regex r = new Regex(@"fold along (?<axis>x|y)=(?<coord>\d+)");

            foreach(var line in lines)
            {
                string[] pos = line.Split(',');
                if (pos.Length == 2) {
                    coords.Add((int.Parse(pos[0]), int.Parse(pos[1])));
                }
                else if(r.IsMatch(line))
                {
                    Match m = r.Match(line);
                    int coord = int.Parse(m.Groups["coord"].Value);
                    if(m.Groups["axis"].Value == "x")
                    {
                        for(int i = 0; i < coords.Count; ++i)
                        {
                            var (x, y) = coords[i];

                            if (x > coord)
                                x = coord * 2 - x;
                            coords[i] = (x, y);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < coords.Count; ++i)
                        {
                            var (x, y) = coords[i];

                            if (y > coord)
                                y = coord * 2 - y;
                            coords[i] = (x, y);
                        }
                    }

                    HashSet<(int, int)> set = new HashSet<(int, int)>();

                    foreach(var c in coords)
                    {
                        set.Add(c);
                    }

                    Console.WriteLine(set.Count);
                    Console.Read();

                    break;
                }
            }
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day13.txt");

            List<(int x, int y)> coords = new List<(int, int)>();
            Regex r = new Regex(@"fold along (?<axis>x|y)=(?<coord>\d+)");

            foreach (var line in lines)
            {
                string[] pos = line.Split(',');
                if (pos.Length == 2)
                {
                    coords.Add((int.Parse(pos[0]), int.Parse(pos[1])));
                }
                else if (r.IsMatch(line))
                {
                    Match m = r.Match(line);
                    int coord = int.Parse(m.Groups["coord"].Value);
                    if (m.Groups["axis"].Value == "x")
                    {
                        for (int i = 0; i < coords.Count; ++i)
                        {
                            var (x, y) = coords[i];

                            if (x > coord)
                                x = coord * 2 - x;
                            coords[i] = (x, y);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < coords.Count; ++i)
                        {
                            var (x, y) = coords[i];

                            if (y > coord)
                                y = coord * 2 - y;
                            coords[i] = (x, y);
                        }
                    }
                }
            }

            foreach(var (x, y) in coords) 
            {
                Console.SetCursorPosition(x, y);
                Console.Write('X');
            }

            Console.Read();
        }
    }
}
