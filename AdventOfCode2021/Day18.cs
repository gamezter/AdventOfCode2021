using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day18
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day18.txt");

            List<char> sum = new List<char>();

            for (int i = 0; i < lines[0].Length; ++i)
            {
                char c = lines[0][i];
                if (c == ',')
                    continue;

                if (c == '[' || c == ']')
                    sum.Add(c);
                else
                    sum.Add((char)(c - '0'));
            }


            for(int i = 1; i < lines.Length; ++i)
            {
                sum = Add(sum, lines[i]);

                restart:
                if (Explode(sum))
                    goto restart;
                if (Split(sum))
                    goto restart;
            }

            int index = 0;

            int magnitude()
            {
                while(sum[index] == ']')
                    index++;

                if (sum[index] < 10)
                    return sum[index++];
                else
                {
                    index++;
                    return 3 * magnitude() + 2 * magnitude();
                }
            }

            Console.WriteLine(magnitude());
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day18.txt");

            int maxMagnitude = 0;

            for(int left = 0; left < lines.Length; ++left)
            {
                for(int right = 0; right < lines.Length; ++right)
                {
                    if (left == right)
                        continue;

                    List<char> sum = Add(lines[left], lines[right]);

                    restart:
                    if (Explode(sum))
                        goto restart;
                    if (Split(sum))
                        goto restart;

                    int index = 0;

                    int magnitude()
                    {
                        while (sum[index] == ']')
                            index++;

                        if (sum[index] < 10)
                            return sum[index++];
                        else
                        {
                            index++;
                            return 3 * magnitude() + 2 * magnitude();
                        }
                    }

                    int mag = magnitude();

                    if (mag > maxMagnitude)
                        maxMagnitude = mag;

                }
            }


            Console.WriteLine(maxMagnitude);
            Console.Read();
        }

        static List<char> Add(List<char> left, string right)
        {
            List<char> ret = new List<char> { '[' };
            ret.AddRange(left);
            for (int i = 0; i < right.Length; ++i)
            {
                char c = right[i];
                if (c == ',')
                    continue;

                if (c == '[' || c == ']')
                    ret.Add(c);
                else
                    ret.Add((char)(c - '0'));
            }
            ret.Add(']');
            return ret;
        }

        static List<char> Add(string left, string right)
        {
            List<char> ret = new List<char> { '[' };
            for (int i = 0; i < left.Length; ++i)
            {
                char c = left[i];
                if (c == ',')
                    continue;

                if (c == '[' || c == ']')
                    ret.Add(c);
                else
                    ret.Add((char)(c - '0'));
            }
            for (int i = 0; i < right.Length; ++i)
            {
                char c = right[i];
                if (c == ',')
                    continue;

                if (c == '[' || c == ']')
                    ret.Add(c);
                else
                    ret.Add((char)(c - '0'));
            }
            ret.Add(']');
            return ret;
        }

        static bool Explode(List<char> sum)
        {
            int depth = 0;
            for(int i = 0; i < sum.Count; ++i)
            {
                if (sum[i] == '[')
                    depth++;
                else if (sum[i] == ']')
                    depth--;

                if(depth == 5)
                {
                    int leftIndex = sum.FindLastIndex(i, i, c => c != '[' && c != ']');
                    if(leftIndex != -1)
                        sum[leftIndex] = (char)(sum[leftIndex] + sum[i + 1]);

                    int rightIndex = sum.FindIndex(i + 3, c => c != '[' && c != ']');
                    if (rightIndex != -1)
                        sum[rightIndex] = (char)(sum[rightIndex] + sum[i + 2]);

                    sum[i] = (char)0;
                    sum.RemoveRange(i + 1, 3);

                    return true;
                }
            }
            return false;
        }

        static bool Split(List<char> sum)
        {
            for (int i = 0; i < sum.Count; ++i)
            {
                if (sum[i] != '[' && sum[i] != ']' && sum[i] > 9)
                {
                    int value = sum[i];
                    int left = value / 2;
                    int right = value - left;
                    sum[i] = '[';
                    sum.InsertRange(i + 1, new[] { (char)left, (char)right, ']' });
                    return true;
                }
            }
            return false;
        }
    }
}
