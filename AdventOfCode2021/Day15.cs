using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day15
    {
        static (int, int)[] offsets = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day15.txt");

            Queue<(int, int)> open = new Queue<(int, int)>();
            open.Enqueue((0, 0));

            int width = lines[0].Length;
            int height = lines.Length;

            int[,] distances = new int[width, height];
            bool[,] visited = new bool[width, height];

            for (int x = 0; x < width; ++x)
                for (int y = 0; y < height; ++y)
                    distances[x, y] = int.MaxValue;
            distances[0, 0] = 0;

            while(open.Count > 0)
            {
                var (x, y) = open.Dequeue();

                if (visited[x, y])
                    continue;

                int dist = distances[x, y];

                foreach(var (dx, dy) in offsets)
                {
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx < 0 || nx >= width || ny < 0 || ny >= height)
                        continue;

                    int newDist = dist + (lines[ny][nx] - '0');

                    if (newDist < distances[nx, ny])
                    {
                        distances[nx, ny] = newDist;
                        visited[nx, ny] = false;
                    }

                    open.Enqueue((nx, ny));
                }
                visited[x, y] = true;
            }

            Console.WriteLine(distances[width - 1, height - 1]);
            Console.Read();
        }
    }
}
