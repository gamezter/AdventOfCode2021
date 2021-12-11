using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day11
    {
        static (int, int)[] offsets = new[] { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day11.txt");
            int[,] map = new int[10, 10];

            for(int y = 0; y < 10; ++y)
            {
                for(int x = 0; x < 10; ++x)
                {
                    map[x, y] = lines[y][x] - '0';
                }
            }

            int flashes = 0;

            for (int i = 0; i < 100; ++i)
            {
                // increment all
                for (int y = 0; y < 10; ++y)
                {
                    for (int x = 0; x < 10; ++x)
                    {
                        map[x, y]++;
                    }
                }

                int[,] map2 = new int[10, 10];

                bool stillGoing = true;
                // flash

                while (stillGoing)
                {
                    stillGoing = false;
                    for (int y = 0; y < 10; ++y)
                    {
                        for (int x = 0; x < 10; ++x)
                        {
                            if (map[x, y] + map2[x, y] > 9)
                            {
                                foreach (var (dx, dy) in offsets)
                                {
                                    int nx = x + dx;
                                    int ny = y + dy;
                                    if (nx < 0 || nx > 9 || ny < 0 || ny > 9)
                                        continue;
                                    map2[nx, ny]++;
                                    stillGoing = true;
                                }
                                flashes++;
                                map[x, y] = 0;
                            }
                        }
                    }
                }

                // increment all
                for (int y = 0; y < 10; ++y)
                {
                    for (int x = 0; x < 10; ++x)
                    {
                        if(map[x,y] != 0)
                            map[x, y] += map2[x, y];
                    }
                }
            }

            Console.WriteLine(flashes);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day11.txt");
            int[,] map = new int[10, 10];

            for (int y = 0; y < 10; ++y)
            {
                for (int x = 0; x < 10; ++x)
                {
                    map[x, y] = lines[y][x] - '0';
                }
            }

            int flashes = 0;
            int turns = 0;
            while(flashes != 100)
            {
                turns++;
                flashes = 0;
                // increment all
                for (int y = 0; y < 10; ++y)
                {
                    for (int x = 0; x < 10; ++x)
                    {
                        map[x, y]++;
                    }
                }

                int[,] map2 = new int[10, 10];

                bool stillGoing = true;
                // flash

                while (stillGoing)
                {
                    stillGoing = false;
                    for (int y = 0; y < 10; ++y)
                    {
                        for (int x = 0; x < 10; ++x)
                        {
                            if (map[x, y] + map2[x, y] > 9)
                            {
                                foreach (var (dx, dy) in offsets)
                                {
                                    int nx = x + dx;
                                    int ny = y + dy;
                                    if (nx < 0 || nx > 9 || ny < 0 || ny > 9)
                                        continue;
                                    map2[nx, ny]++;
                                    stillGoing = true;
                                }
                                flashes++;
                                map[x, y] = 0;
                            }
                        }
                    }
                }

                // increment all
                for (int y = 0; y < 10; ++y)
                {
                    for (int x = 0; x < 10; ++x)
                    {
                        if (map[x, y] != 0)
                            map[x, y] += map2[x, y];
                    }
                }
            }

            Console.WriteLine(turns);
            Console.Read();
        }
    }
}
