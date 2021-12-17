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

            int nBits = line.Length * 4;

            int bitOffset = 0;

            int sum = 0;

            int nextNBits(int n)
            {
                int rightOffset = 4 - (bitOffset % 4);
                int bitsInNibble = Math.Min(rightOffset, n);

                int ret = 0;
                do
                {
                    int nibble = line[bitOffset / 4];
                    if (nibble > '9')
                        nibble -= '7';
                    else
                        nibble -= '0';

                    int b = nibble >> (rightOffset - bitsInNibble);
                    int mask = (1 << bitsInNibble) - 1;
                    ret = (ret << bitsInNibble) + (b & mask);

                    n -= bitsInNibble;
                    bitOffset += bitsInNibble;
                    rightOffset = 4 - (bitOffset % 4);
                    bitsInNibble = Math.Min(rightOffset, n);
                }while (bitsInNibble > 0);

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
