using System;
using System.IO;

namespace AdventOfCode2021
{
    class Day6
    {
        public static void part1()
        {
            string[] numbers = File.ReadAllLines("day6.txt")[0].Split(',');

            int[] lanternFish = new int[9];

            for(int i = 0; i < numbers.Length; ++i)
            {
                lanternFish[int.Parse(numbers[i])]++;
            }

            for(int i = 0; i < 80; ++i)
            {
                int temp = lanternFish[1];
                lanternFish[1] = lanternFish[2];
                lanternFish[2] = lanternFish[3];
                lanternFish[3] = lanternFish[4];
                lanternFish[4] = lanternFish[5];
                lanternFish[5] = lanternFish[6];
                lanternFish[6] = lanternFish[7] + lanternFish[0];
                lanternFish[7] = lanternFish[8];
                lanternFish[8] = lanternFish[0];
                lanternFish[0] = temp;
            }

            int sum = lanternFish[0] + lanternFish[1] + lanternFish[2] + lanternFish[3] + lanternFish[4] + lanternFish[5] + lanternFish[6] + lanternFish[7] + lanternFish[8];

            Console.WriteLine(sum);
            Console.Read();
        }

        public static void part2()
        {
            string[] numbers = File.ReadAllLines("day6.txt")[0].Split(',');

            long[] lanternFish = new long[9];

            for (int i = 0; i < numbers.Length; ++i)
            {
                lanternFish[int.Parse(numbers[i])]++;
            }

            for (int i = 0; i < 256; ++i)
            {
                long temp = lanternFish[1];
                lanternFish[1] = lanternFish[2];
                lanternFish[2] = lanternFish[3];
                lanternFish[3] = lanternFish[4];
                lanternFish[4] = lanternFish[5];
                lanternFish[5] = lanternFish[6];
                lanternFish[6] = lanternFish[7] + lanternFish[0];
                lanternFish[7] = lanternFish[8];
                lanternFish[8] = lanternFish[0];
                lanternFish[0] = temp;
            }

            long sum = lanternFish[0] + lanternFish[1] + lanternFish[2] + lanternFish[3] + lanternFish[4] + lanternFish[5] + lanternFish[6] + lanternFish[7] + lanternFish[8];

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
