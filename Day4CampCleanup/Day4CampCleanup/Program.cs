using System;
using System.IO;
using System.Linq;

namespace Day4CampCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int count = 0;

            foreach (var item in lines)
            {
                string[] pairs = item.Split(",");
                int[] firstPair = pairs[0].Split("-").Select(int.Parse).ToArray();
                int[] secondPair = pairs[1].Split("-").Select(int.Parse).ToArray();

                if ((firstPair[0] <= secondPair[0] && firstPair[1] >= secondPair[1]) ||
                    (secondPair[0] <= firstPair[0] && secondPair[1] >= firstPair[1]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
