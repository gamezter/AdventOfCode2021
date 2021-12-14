using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day12
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day12.txt");

            List<(char, char)> links = new List<(char, char)>();

            foreach(var line in lines)
            {
                string[] nodes = line.Split('-');
                links.Add((nodes[0][0], nodes[1][0]));
            }

            int count = 0;

            Stack<char> temp = new Stack<char>();
            temp.Push('s');

            visit(temp);

            void visit(Stack<char> visited)
            {
                char lastVisited = visited.Peek();
                foreach (var (a, b) in links)
                {
                    char other;
                    if (a == lastVisited)
                        other = b;
                    else if (b == lastVisited)
                        other = a;
                    else continue;

                    if (char.IsLower(other) && visited.Contains(other))
                        continue;

                    if(other == 'e')
                    {
                        count++;
                    }
                    else
                    {
                        visited.Push(other);
                        visit(visited);
                    }
                }

                visited.Pop();
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day12.txt");

            List<(char, char)> links = new List<(char, char)>();

            foreach (var line in lines)
            {
                string[] nodes = line.Split('-');
                links.Add((nodes[0][0], nodes[1][0]));
            }

            int count = 0;

            Stack<char> temp = new Stack<char>();
            temp.Push('s');

            visit(temp, false);

            void visit(Stack<char> visited, bool already2)
            {
                char lastVisited = visited.Peek();
                foreach (var (a, b) in links)
                {
                    char other;
                    if (a == lastVisited)
                        other = b;
                    else if (b == lastVisited)
                        other = a;
                    else continue;

                    bool alreadyThere = char.IsLower(other) && visited.Contains(other);

                    if (other == 's')
                        continue;

                    if (alreadyThere && already2)
                        continue;

                    if (other == 'e')
                    {
                        count++;
                    }
                    else
                    {
                        visited.Push(other);
                        visit(visited, alreadyThere || already2);
                    }
                }

                visited.Pop();
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
