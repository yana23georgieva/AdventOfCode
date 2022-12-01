using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            List<int> elves = new List<int>();
            int index = 0;
            elves.Add(0);

            foreach (var item in lines)
            {
                if(item == String.Empty)
                {
                    elves.Add(0);
                    index++;
                    continue;
                }
                elves[index] += int.Parse(item);
            }

            elves = elves.OrderByDescending(x => x).ToList();
            Console.WriteLine(elves[0]);
        }
    }
}
