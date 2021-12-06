using System;
using System.IO;

namespace AdventOfCode2021
{
    class Day3
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day3.txt");
            int[] numbers = new int[lines.Length];

            int n = lines[0].Length;
            for (int i = 0; i < lines.Length; ++i) 
            {
                for (int j = 0; j < n; ++j)
                {
                    numbers[i] += lines[i][j] == '1' ? 1 << (n - j - 1) : 0;
                }
            }

            int[] tally = new int[12];

            foreach(var number in numbers)
            {
                for(int i = 0; i < tally.Length; ++i)
                {
                    tally[i] += (number & 1 << (n - i - 1)) > 0 ? 1 : -1;
                }
            }

            int num = 0;
            int antiNum = 0;

            for(int i = 0; i < tally.Length; ++i)
            {
                num += tally[i] > 0 ? 1 << (tally.Length - i - 1) : 0;
                antiNum += tally[i] < 0 ? 1 << (tally.Length - i - 1) : 0;
            }

            Console.WriteLine(num * antiNum);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day3.txt");

            int[] numbers = new int[lines.Length];

            int n = lines[0].Length;
            for (int i = 0; i < lines.Length; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    numbers[i] += lines[i][j] == '1' ? 1 << (n - j - 1) : 0;
                }
            }

            Array.Sort(numbers);

            int oxyMin = 0;
            int oxyMax = numbers.Length;
            int co2Min = 0;
            int co2Max = numbers.Length;

            for (int i = 0; i < n; ++i)
            {
                int bit = 1 << (n - i - 1);

                if(oxyMax - oxyMin > 1)
                {
                    int bitSample = numbers[(oxyMax + oxyMin) / 2] & bit;

                    while ((numbers[oxyMin] & bit) != bitSample)
                        oxyMin++;

                    while ((numbers[oxyMax - 1] & bit) != bitSample)
                        oxyMax--;
                }

                if(co2Max - co2Min > 1)
                {
                    int bitSample = numbers[(co2Max + co2Min) / 2] & bit;

                    while ((numbers[co2Min] & bit) == bitSample)
                        co2Min++;

                    while ((numbers[co2Max - 1] & bit) == bitSample)
                        co2Max--;
                }
            }

            Console.WriteLine(numbers[oxyMin] * numbers[co2Min]);
            Console.Read();
        }
    }
}
