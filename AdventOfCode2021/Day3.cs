using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            int min = 0;
            int max = numbers.Length;


            for(int i = 0; i < n && (max - min) != 1; ++i)
            {
                int bit = 1 << (n - i - 1);
                int sample = numbers[(max + min) / 2];

                if((sample & bit) > 0)
                {
                    for(int j = min; j < max; ++j)
                    {
                        if((numbers[j] & bit) > 0)
                        {
                            min = j;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = max - 1; j > min; --j)
                    {
                        if ((numbers[j] & bit) > 0)
                        {
                            max = j;
                        }
                        else break;
                    }
                }
            }

            int min2 = 0;
            int max2 = numbers.Length;

            for (int i = 0; i < n && (max2 - min2) != 1; ++i)
            {
                int bit = 1 << (n - i - 1);
                int sample = numbers[(max2 + min2) / 2];

                if ((sample & bit) > 0)
                {
                    for (int j = max2 - 1; j > min2; --j)
                    {
                        if ((numbers[j] & bit) > 0)
                        {
                            max2 = j;
                        }
                        else break;
                    }
                }
                else
                {
                    for (int j = min2; j < max2; ++j)
                    {
                        if ((numbers[j] & bit) > 0)
                        {
                            min2 = j;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(numbers[min] * numbers[min2]);
            Console.Read();
        }
    }
}
