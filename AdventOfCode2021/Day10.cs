using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day10
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day10.txt");

            int score = 0;
            foreach(var line in lines)
            {
                Stack<char> scopes = new Stack<char>();
                for(int i = 0; i < line.Length; ++i)
                {
                    char c = line[i];
                    if (c == '(' || c == '[' || c == '{' || c == '<')
                        scopes.Push(c);
                    else
                    {
                        char d = scopes.Peek();

                        if(Math.Abs(c - d) < 3)
                            scopes.Pop();
                        else
                        {
                            //found missmatch
                            switch (c)
                            {
                                case ')':
                                    score += 3;
                                    break;
                                case ']':
                                    score += 57;
                                    break;
                                case '}':
                                    score += 1197;
                                    break;
                                case '>':
                                    score += 25137;
                                    break;
                            }
                            goto skip;
                        }
                    }
                }
skip:           ;
            }

            Console.WriteLine(score);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day10.txt");

            List<long> scores = new List<long>();

            foreach (var line in lines)
            {
                long score = 0;
                Stack<char> scopes = new Stack<char>();
                for (int i = 0; i < line.Length; ++i)
                {
                    char c = line[i];
                    if (c == '(' || c == '<' || c == '{' || c == '[')
                        scopes.Push(c);
                    else
                    {
                        char d = scopes.Peek();

                        if (Math.Abs(c - d) < 3) // ascii brackets are never farther than 2 apart
                            scopes.Pop();
                        else
                        {
                            //found missmatch
                            goto skip;
                        }
                    }
                }

                while(scopes.Count > 0)// unfinished line
                {
                    //found missmatch
                    switch (scopes.Pop())
                    {
                        case '(':
                            score *= 5;
                            score += 1;
                            break;
                        case '[':
                            score *= 5;
                            score += 2;
                            break;
                        case '{':
                            score *= 5;
                            score += 3;
                            break;
                        case '<':
                            score *= 5;
                            score += 4;
                            break;
                    }
                }
                scores.Add(score);
                skip:;
            }

            scores.Sort();

            Console.WriteLine(scores[scores.Count / 2]);
            Console.Read();
        }
    }
}
