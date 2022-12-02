using System;
using System.Collections.Generic;
using System.IO;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int sum = 0;

            foreach (var item in lines)
            {
                string[] items = item.Split(" ");
                char playerOne = char.Parse(items[0]);
                char playerTwo = char.Parse(items[1]);

                if (playerOne == 'A')
                {
                    switch (playerTwo)
                    {
                        case 'X':
                            sum += 4;
                            break;
                        case 'Y':
                            sum += 8;
                            break;
                        case 'Z':
                            sum += 3;
                            break;
                        default:
                            break;
                    }
                }
                else if (playerOne == 'B')
                {
                    switch (playerTwo)
                    {
                        case 'X':
                            sum += 1;
                            break;
                        case 'Y':
                            sum += 5;
                            break;
                        case 'Z':
                            sum += 9;
                            break;
                        default:
                            break;
                    }
                }
                else if (playerOne == 'C')
                {
                    switch (playerTwo)
                    {
                        case 'X':
                            sum += 7;
                            break;
                        case 'Y':
                            sum += 2;
                            break;
                        case 'Z':
                            sum += 6;
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
