using System;
using System.Collections.Generic;
using System.IO;

namespace Day6TuningTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int count = 0;
            char[] letters = lines[0].ToCharArray();
            Queue<char> queue = new Queue<char>();

            foreach (var item in letters)
            {
                if (queue.Count == 14)
                {
                    break;
                }
                if (queue.Contains(item))
                {
                    while (queue.Peek() != item)
                    {
                        queue.Dequeue();
                    }
                    queue.Dequeue();
                }
                queue.Enqueue(item);
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
