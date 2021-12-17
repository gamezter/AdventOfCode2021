using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day17
    {
        public static void part1()
        {
            int minX = 88;
            int maxX = 125;
            int minY = -157;
            int maxY = -103;

            int MAXY = -3000;

            for(int y = -160; y < 160; ++y) // tested range that falls in rect
            {
                int dy = y;
                int py = 0;
                int t = 0;

                int MaxY2 = -3000;

                while(py >= minY)
                {
                    if (py > MaxY2)
                        MaxY2 = py;
                    if (py <= maxY)
                    {
                        if (MaxY2 > MAXY)
                            MAXY = MaxY2;
                        Console.WriteLine("dy: " + y + " at tick: " + t);
                    }

                    py += dy;
                    dy--;
                    t++;
                }
            }

            Console.WriteLine(MAXY);
            Console.Read();
        }

        public static void part2()
        {
            int minX = 88;
            int maxX = 125;
            int minY = -157;
            int maxY = -103;

            int maxTicks = 350;

            List<int>[] ticks = new List<int>[maxTicks]; // no initial dy lands in rect after 350 ticks

            for (int y = -160; y < 160; ++y) // tested range that falls in rect
            {
                int dy = y;
                int py = 0;
                int t = 0;

                while (py >= minY)
                {
                    if (py <= maxY)
                    {
                        if (ticks[t] == null)
                            ticks[t] = new List<int>();
                        ticks[t].Add(y);
                        Console.WriteLine("dy: " + y + " at tick: " + t);
                    }

                    py += dy;
                    dy--;
                    t++;
                }
            }

            Console.WriteLine();

            HashSet<(int, int)> pairs = new HashSet<(int, int)>();

            for (int x = 0; x < 130; ++x) // tested range that falls in rect
            {
                int dx = x;
                int px = 0;
                int t = 0;

                while (px <= maxX && t < maxTicks)
                {
                    if (px >= minX)
                    {
                        if(ticks[t] != null)
                        {
                            foreach (var y in ticks[t])
                                pairs.Add((x, y));
                        }
                        Console.WriteLine("dx: " + x + " at tick: " + t);
                    }

                    px += dx;
                    if (dx > 0)
                        dx--;
                    t++;
                }
            }

            Console.WriteLine(pairs.Count);
            Console.Read();
        }
    }
}
