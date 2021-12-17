using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Day16
    {
        public static void part1()
        {
            string line = File.ReadAllLines("day16.txt")[0];
            byte[] bytes = new byte[line.Length / 2];

            for(int i = 0; i < line.Length; i += 2)
            {
                int upper, lower;
                if (line[i] > '9')
                    upper = (byte)((line[i] - 'A') + 10);
                else
                    upper = (byte)(line[i] - '0');

                if (line[i + 1] > '9')
                    lower = (byte)((line[i + 1] - 'A') + 10);
                else
                    lower = (byte)(line[i + 1] - '0');

                bytes[i / 2] = (byte)((upper << 4) + lower);
            }

            int nBits = line.Length * 4;

            int bitOffset = 0;

            int sum = 0;

            int nextNBits(int n)
            {
                int ret = 0;
                for(int i = 0; i < n; ++i)
                {
                    int offset = (7 - (bitOffset % 8));
                    ret = (ret << 1) + ((bytes[bitOffset / 8] >> offset) & 1);
                    bitOffset++;
                }
                return ret;
            }

            while((bitOffset + 6) < nBits)
            {
                int version = nextNBits(3);
                int typeID = nextNBits(3);

                sum += version;

                if (typeID == 4) // literal value
                {
                    int next = nextNBits(5);
                    int num = (next & 0b1111);
                    while (next >= 0b10000)
                    {
                        next = nextNBits(5);
                        num = (num << 4) + (next & 0b1111);
                    }
                }
                else //operator
                {
                    int lengthTypeID = nextNBits(1);
                    if(lengthTypeID == 1)
                    {
                        int nSubPackets = nextNBits(11);
                    }
                    else
                    {
                        int totalLength = nextNBits(15);
                    }
                }
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
