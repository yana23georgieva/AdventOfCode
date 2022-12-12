using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day10CathodeRayTube
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            List<int> signalsSum = new List<int>();
            int cycles = 0;
            int sum = 1;
            StringBuilder sb = new StringBuilder();
            int cyclesCRT = 0;

            foreach (var item in lines)
            {
                string[] currentLine = item.Split(" ");

                cycles++;
                cyclesCRT++;
                if (cyclesCRT >= sum && cyclesCRT <= sum + 2)
                {
                    sb.Append("#");
                }
                else
                {
                    sb.Append(".");
                }

                if (cyclesCRT >= 40)
                {
                    cyclesCRT -= 40;
                    sb.Append(Environment.NewLine);
                }
                Add(cycles, sum, signalsSum);

                if (currentLine[0] == "addx")
                {
                    cycles++;
                    cyclesCRT++;
                    if (cyclesCRT >= sum && cyclesCRT <= sum + 2)
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                    Add(cycles, sum, signalsSum);

                    sum += int.Parse(currentLine[1]);
                }
                if (cyclesCRT >= 40)
                {
                    cyclesCRT -= 40;
                    sb.Append(Environment.NewLine);
                }
            }

            Console.WriteLine(signalsSum.Sum(x => x));
            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Add(int cycles, int sum, List<int> signalsSum)
        {
            if (cycles == 20 || cycles == 60 || cycles == 100 || cycles == 140 || cycles == 180 || cycles == 220)
            {
                sum *= cycles;
                signalsSum.Add(sum);
            }
        }
    }
}
