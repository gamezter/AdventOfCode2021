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
                    foreach(var (dx, dy) in offsets)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
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

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day9.txt");
            int maxY = lines.Length;
            int maxX = lines[0].Length;

            int[,] map = new int[maxX, maxY];

            for (int y = 0; y < maxY; ++y)
                for (int x = 0; x < maxX; ++x)
                    map[x,y] = lines[y][x] - '0';

            List<int> basins = new List<int>();

            for (int y = 0; y < maxY; ++y)
            {
                for (int x = 0; x < maxX; ++x)
                {
                    int center = map[x,y];
                    for (int i = 0; i < 4; ++i)
                    {
                        var (dx, dy) = offsets[i];
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx < 0 || nx >= maxX || ny < 0 || ny >= maxY)
                            continue;

                        if (map[nx, ny] <= center)
                            goto skip;
                    }
                    //found low point

                    int size = 0;

                    Queue<(int, int, int)> toVisit = new Queue<(int, int, int)>();
                    toVisit.Enqueue((x, y, -1));

                    while(toVisit.Count > 0)
                    {
                        var (nx, ny, prev) = toVisit.Dequeue();
                        if (nx < 0 || nx >= maxX || ny < 0 || ny >= maxY || map[nx, ny] == 9)
                            continue;

                        if (map[nx, ny] > prev)
                        {
                            foreach (var (dx, dy) in offsets)
                                toVisit.Enqueue((nx + dx, ny + dy, map[nx, ny]));
                            map[nx, ny] = 9;
                            size++;
                        }
                    }
                    basins.Add(size);
skip:               ;
                }
            }

            basins.Sort();

            Console.WriteLine(basins[basins.Count - 3] * basins[basins.Count - 2] * basins[basins.Count - 1]);
            Console.Read();
        }
    }
}
