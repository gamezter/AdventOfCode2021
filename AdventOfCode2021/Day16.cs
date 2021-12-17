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

                    int b = nibble >> (rightOffset - bitsInNibble); // place bits in nibble on far right end
                    int mask = (1 << bitsInNibble) - 1; // create mask with bitsInNibble * 1s
                    ret = (ret << bitsInNibble) + (b & mask); // move existing bits to the left and add new bits

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

        public static void part2()
        {
            string line = File.ReadAllLines("day16.txt")[0];

            int bitOffset = 0;

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

                    int b = nibble >> (rightOffset - bitsInNibble); // place bits in nibble on far right end
                    int mask = (1 << bitsInNibble) - 1; // create mask with bitsInNibble * 1s
                    ret = (ret << bitsInNibble) + (b & mask); // move existing bits to the left and add new bits

                    n -= bitsInNibble;
                    bitOffset += bitsInNibble;
                    rightOffset = 4 - (bitOffset % 4);
                    bitsInNibble = Math.Min(rightOffset, n);
                } while (bitsInNibble > 0);

                return ret;
            }

            long parse()
            {
                int version = nextNBits(3); // ignore
                int typeID = nextNBits(3);

                if (typeID == 4) // literal value
                {
                    int next = nextNBits(5);
                    long num = (next & 0b1111);
                    while (next >= 0b10000)
                    {
                        next = nextNBits(5);
                        num = (num << 4) + (next & 0b1111);
                    }

                    return num;
                }

                int lengthTypeID = nextNBits(1);
                int length = lengthTypeID == 1 ? nextNBits(11) : nextNBits(15);

                switch (typeID)
                {
                    case 0:
                        long sum = 0;
                        if (lengthTypeID == 1)
                        {
                            for(int i = 0; i < length; ++i)
                                sum += parse();
                        }
                        else
                        {
                            int startBitOffset = bitOffset;
                            while (bitOffset - startBitOffset < length)
                                sum += parse();
                        }
                        return sum;
                    case 1:
                        long product = 1;
                        if (lengthTypeID == 1)
                        {
                            for (int i = 0; i < length; ++i)
                                product *= parse();
                        }
                        else
                        {
                            int startBitOffset = bitOffset;
                            while (bitOffset - startBitOffset < length)
                                product *= parse();
                        }
                        return product;
                    case 2:
                        if (lengthTypeID == 1)
                        {
                            long min = parse();
                            for (int i = 1; i < length; ++i)
                                min = Math.Min(min, parse());
                            return min;
                        }
                        else
                        {
                            int startBitOffset = bitOffset;
                            long min = parse();
                            while (bitOffset - startBitOffset < length)
                                min = Math.Min(min, parse());
                            return min;
                        }
                    case 3:
                        if (lengthTypeID == 1)
                        {
                            long max = parse();
                            for (int i = 1; i < length; ++i)
                                max = Math.Max(max, parse());
                            return max;
                        }
                        else
                        {
                            int startBitOffset = bitOffset;
                            long max = parse();
                            while (bitOffset - startBitOffset < length)
                                max = Math.Max(max, parse());
                            return max;
                        }
                    case 5:
                        return parse() > parse() ? 1 : 0;
                    case 6:
                        return parse() < parse() ? 1 : 0;
                    case 7:
                        return parse() == parse() ? 1 : 0;
                }

                return 0;
            }

            Console.WriteLine(parse());
            Console.Read();
        }
    }
}
