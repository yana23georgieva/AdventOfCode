using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8TreetopTreeHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int col = lines[0].ToCharArray().Length;
            int count = 2 * col + 2 * (lines.Length - 2);
            List<char[]> matrix = new List<char[]>();
            int max = 0;

            foreach (var item in lines)
            {
                matrix.Add(item.ToCharArray());
            }

            for (int i = 1; i < lines.Length - 1; i++)
            {
                for (int j = 1; j < col - 1; j++)
                {
                    char current = matrix[i][j];

                    //int left = matrix[i].Take(j).Where(x => x >= current).Count();
                    //int right = matrix[i].Skip(j + 1).Where(x => x >= current).Count();
                    //int top = matrix.Select(x => x[j]).Take(i).Where(x => x >= current).Count();
                    //int bottom = matrix.Select(x => x[j]).Skip(i + 1).Where(x => x >= current).Count();

                    //if (left == 0 || right == 0 || top == 0 || bottom == 0)
                    //{
                    //    count++;
                    //}

                    //Part 2
                    var h = matrix[i].Skip(j + 1).TakeWhile(x => x < current).ToArray();

                    int left = matrix[i].Take(j).Reverse().TakeWhile(x => x < current).Count();
                    int right = matrix[i].Skip(j + 1).TakeWhile(x => x < current).Count();
                    int top = matrix.Select(x => x[j]).Take(i).Reverse().TakeWhile(x => x < current).Count();
                    int bottom = matrix.Select(x => x[j]).Skip(i + 1).TakeWhile(x => x < current).Count();

                    if (left < matrix[i].Take(j).Count())
                    {
                        left++;
                    }

                    if (right < matrix[i].Skip(j + 1).Count())
                    {
                        right++;
                    }

                    if (top < matrix.Select(x => x[j]).Take(i).Count())
                    {
                        top++;
                    }

                    if (bottom < matrix.Select(x => x[j]).Skip(i + 1).Count())
                    {
                        bottom++;
                    }

                    int sum = left * right * bottom * top;

                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }

            //Console.WriteLine(count);
            //Part 2
            Console.WriteLine(max);
        }
    }
}
