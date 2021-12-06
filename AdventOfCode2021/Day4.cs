using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    class Day4
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day4.txt");
            List<int[]> boards = new List<int[]>();

            int[] checks = new int[(lines.Length - 1) / 6];

            for(int i = 1; i < lines.Length; i += 6)
            {
                int[] board = new int[25];
                for(int j = 0; j < 5; ++j)
                {
                    string[] numbers = lines[i + j + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    board[j * 5 + 0] = int.Parse(numbers[0]);
                    board[j * 5 + 1] = int.Parse(numbers[1]); 
                    board[j * 5 + 2] = int.Parse(numbers[2]); 
                    board[j * 5 + 3] = int.Parse(numbers[3]);
                    board[j * 5 + 4] = int.Parse(numbers[4]);
                }

                boards.Add(board);
            }

            int[] tests = new[]
            {
                0x000001F, 0x00003E0, 0x0007C00, 0x00F8000, 0x1F00000,
                0x1084210, 0x0842108, 0x0421084, 0x0210842, 0x0108421,
                //0x1041041, 0x0111110
            };

            string[] randomNumbers = lines[0].Split(',');

            for(int i = 0; i < randomNumbers.Length; ++i)
            {
                int num = int.Parse(randomNumbers[i]);

                for(int j = 0; j < boards.Count; ++j)
                {
                    int index = Array.FindIndex(boards[j], n => n == num);

                    if(index >= 0)
                        checks[j] |= 1 << (24 - index);
                }

                for(int j = 0; j < checks.Length; ++j)
                {
                    for(int k = 0; k < tests.Length; ++k)
                    {
                        if((checks[j] & tests[k]) == tests[k])
                        {
                            int sum = 0;
                            for(int l = 0; l < 25; ++l)
                            {
                                if ((checks[j] & (1 << (24 - l))) == 0)
                                    sum += boards[j][l];
                            }
                            Console.WriteLine(sum * num);
                            Console.Read();
                        }
                    }
                }
            }
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day4.txt");
            List<int[]> boards = new List<int[]>();

            int[] checks = new int[(lines.Length - 1) / 6];

            for (int i = 1; i < lines.Length; i += 6)
            {
                int[] board = new int[27];
                for (int j = 0; j < 5; ++j)
                {
                    string[] numbers = lines[i + j + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    board[j * 5 + 0] = int.Parse(numbers[0]);
                    board[j * 5 + 1] = int.Parse(numbers[1]);
                    board[j * 5 + 2] = int.Parse(numbers[2]);
                    board[j * 5 + 3] = int.Parse(numbers[3]);
                    board[j * 5 + 4] = int.Parse(numbers[4]);
                }

                board[25] = 0; // check
                board[26] = 0; // turn that won board

                boards.Add(board);
            }

            string[] random = lines[0].Split(',');

            int[] randomNumbers = new int[random.Length];

            for (int i = 0; i < random.Length; ++i)
                randomNumbers[i] = int.Parse(random[i]);

            int[] tests = new[]
            {
                0x000001F, 0x00003E0, 0x0007C00, 0x00F8000, 0x1F00000,
                0x1084210, 0x0842108, 0x0421084, 0x0210842, 0x0108421,
                //0x1041041, 0x0111110
            };

            for (int i = 0; i < boards.Count; ++i)
            {
                int check = 0;
                var board = boards[i];

                for(int j = 0; j < randomNumbers.Length; ++j)
                {
                    int num = randomNumbers[j];

                    int index = Array.FindIndex(board, 0, 25, n => n == num);
                    if (index >= 0)
                        check |= 1 << (24 - index);

                    for (int k = 0; k < tests.Length; ++k)
                    {
                        if ((check & tests[k]) == tests[k])
                        {
                            board[25] = check;
                            board[26] = j;
                            goto nextBoard;
                        }
                    }
                }
nextBoard:      ;
            }

            boards.Sort((a, b) => a[26].CompareTo(b[26]));

            var lastBoard = boards[boards.Count - 1];

            int sum = 0;
            for (int l = 0; l < 25; ++l)
            {
                if ((lastBoard[25] & (1 << (24 - l))) == 0)
                    sum += lastBoard[l];
            }
            Console.WriteLine(sum * randomNumbers[lastBoard[26]]);
            Console.Read();
        }
    }
}
