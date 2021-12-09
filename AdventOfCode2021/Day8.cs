using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    class Day8
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            int count = 0;
            foreach(var line in lines)
            {
                string[] digits = line.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 10; i < digits.Length; ++i)
                {
                    int length = digits[i].Length;

                    if (length == 2 || length == 3 || length == 4 || length == 7)
                        count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }

        //aaaa
        //b  c
        //b  c
        //dddd
        //e  f
        //e  f
        //gggg

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            int sum = 0;
            foreach (var line in lines)
            {
                string[] digits = line.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                int[] mappings = new[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

                while (mappings[10] == -1 || mappings[11] == -1 || mappings[12] == -1 || mappings[13] == -1)
                {
                    for (int i = 0; i < 14; ++i)
                    {
                        if (mappings[i] != -1)
                            continue;
                        string segments = digits[i];
                        switch (segments.Length)
                        {
                            case 2: // 1 
                                mappings[i] = 1;
                                break;
                            case 3: // 7
                                mappings[i] = 7;
                                break;
                            case 4: // 4
                                mappings[i] = 4;
                                break;
                            case 5: // 2, 3, 5
                                {
                                    int index = Array.IndexOf(mappings, 1);
                                    if (index != -1
                                    && segments.IndexOf(digits[index][0]) != -1
                                    && segments.IndexOf(digits[index][1]) != -1) // if has all chars of 1, then it must be 3
                                    {
                                        mappings[i] = 3;
                                        break;
                                    }

                                    if(Array.IndexOf(mappings, 3) != -1) // if 3 is found
                                    {
                                        index = Array.IndexOf(mappings, 4);

                                        if(index != -1)
                                        {
                                            string other = digits[index];
                                            int count = 0;
                                            count += segments.IndexOf(other[0]) != -1 ? 1 : 0;
                                            count += segments.IndexOf(other[1]) != -1 ? 1 : 0;
                                            count += segments.IndexOf(other[2]) != -1 ? 1 : 0; 
                                            count += segments.IndexOf(other[3]) != -1 ? 1 : 0;

                                            if (count == 3)
                                                mappings[i] = 5;
                                            else
                                                mappings[i] = 2;
                                        }
                                    }
                                    break;
                                }
                            case 6: // 0, 6, 9
                                {
                                    int index = Array.IndexOf(mappings, 4);
                                    if (index != -1
                                    && segments.IndexOf(digits[index][0]) != -1
                                    && segments.IndexOf(digits[index][1]) != -1
                                    && segments.IndexOf(digits[index][2]) != -1
                                    && segments.IndexOf(digits[index][3]) != -1) // if has all chars of 4, then it must be 9
                                    {
                                        mappings[i] = 9;
                                        break;
                                    }

                                    if (Array.IndexOf(mappings, 9) != -1) // if 9 is found
                                    {
                                        index = Array.IndexOf(mappings, 1);
                                        if (index != -1
                                        && segments.IndexOf(digits[index][0]) != -1
                                        && segments.IndexOf(digits[index][1]) != -1) // if has all chars of 1, then it must be 0
                                            mappings[i] = 0;
                                        else
                                            mappings[i] = 6;
                                    }
                                    break;
                                }
                            case 7: // 8
                                mappings[i] = 8;
                                break;
                        }
                    }
                }
                sum += mappings[10] * 1000 + mappings[11] * 100 + mappings[12] * 10 + mappings[13];
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
