using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day20
    {
        public static (int, int, int)[] kernel = new (int, int, int)[] { (-1, -1, 1 << 8), (0, -1, 1 << 7), (1, -1, 1 << 6), (-1, 0, 1 << 5), (0, 0, 1 << 4), (1, 0, 1 << 3), (-1, 1, 1 << 2), (0, 1, 1 << 1), (1, 1, 1) };
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day20.txt");

            string key = lines[0];
            int width = lines[2].Length;
            int height = lines.Length - 2;
            int[,] map = new int[height, width];

            for(int y = 0; y < height; ++y)
            {
                for(int x = 0; x < width; ++x)
                {
                    map[y, x] = lines[y + 2][x] == '#' ? 1 : 0;
                }
            }

            for(int i = 0; i < 2; ++i)
            {
                height += 2;
                width += 2;
                int[,] newMap = new int[height, width];

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        int offset = 0;
                        foreach(var (dx, dy, bit) in kernel)
                        {
                            int nx = x + dx - 1;
                            int ny = y + dy - 1;
                            if (nx < 0 || nx >= (width - 2) || ny < 0 || ny >= (height - 2))
                            {
                                if (i % 2 == 1) // because of key, if kernel is all 0, next phase will become 1, if kernel is all 1, next phase will become 0. On odd phases the infinite map is 1 everywhere outside of map
                                    offset += bit;

                                continue;
                            }

                            if (map[ny, nx] == 1)
                                offset += bit;
                        }
                        newMap[y, x] = key[offset] == '#' ? 1 : 0;
                    }
                }

                map = newMap;
            }

            int count = 0;
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (map[y, x] == 1)
                        count++;
                }
            }


            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day20.txt");

            string key = lines[0];
            int width = lines[2].Length;
            int height = lines.Length - 2;
            int[,] map = new int[height, width];

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    map[y, x] = lines[y + 2][x] == '#' ? 1 : 0;
                }
            }

            for (int i = 0; i < 50; ++i) // only change this to 50 for part 2
            {
                height += 2;
                width += 2;
                int[,] newMap = new int[height, width];

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        int offset = 0;
                        foreach (var (dx, dy, bit) in kernel)
                        {
                            int nx = x + dx - 1;
                            int ny = y + dy - 1;
                            if (nx < 0 || nx >= (width - 2) || ny < 0 || ny >= (height - 2))
                            {
                                if (i % 2 == 1) // because of key, if kernel is all 0, next phase will become 1, if kernel is all 1, next phase will become 0. On odd phases the infinite map is 1 everywhere outside of map
                                    offset += bit;

                                continue;
                            }

                            if (map[ny, nx] == 1)
                                offset += bit;
                        }
                        newMap[y, x] = key[offset] == '#' ? 1 : 0;
                    }
                }

                map = newMap;
            }

            int count = 0;
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (map[y, x] == 1)
                        count++;
                }
            }


            Console.WriteLine(count);
            Console.Read();
        }
    }
}
