using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7NoSpaceLeftOnDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int sum;
            Dictionary<string, int> tree = new Dictionary<string, int>();
            Stack<string> currentDir = new Stack<string>();
            int id = 1;

            foreach (var item in lines)
            {
                string[] currentLine = item.Split(" ");
                if (currentLine[0] == "$")
                {
                    if (currentLine[1] == "cd")
                    {
                        if (currentLine[2] == "..")
                        {
                            string dir = currentDir.Peek();
                            currentDir.Pop();
                            tree[currentDir.Peek()] += tree[dir];
                        }
                        else
                        {
                            string directory = currentLine[2] + id.ToString();
                            id++;
                            tree.Add(directory, 0);
                            currentDir.Push(directory);
                        }
                    }
                }
                else
                {
                    if (currentLine[0] != "dir")
                    {
                        tree[currentDir.Peek()] += int.Parse(currentLine[0]);
                    }
                }
            }

            while (currentDir.Count > 1)
            {
                string dir = currentDir.Peek();
                currentDir.Pop();
                tree[currentDir.Peek()] += tree[dir];
            }

            //Part1
            //sum = tree.Where(x => x.Value <= 100000).Sum(x => x.Value);

            int freeSpace = 70_000_000 - tree["/1"];
            int needed = 30_000_000 - freeSpace;
            int size = tree.OrderBy(x => x.Value).First(x => x.Value >= needed).Value;

            Console.WriteLine(size);
        }
    }
}
