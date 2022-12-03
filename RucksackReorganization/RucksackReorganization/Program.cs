using System;
using System.IO;
using System.Linq;

namespace RucksackReorganization
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            int sum = 0;

            foreach (var item in lines)
            {
                char[] items = item.ToCharArray();
                char[] firstPart = items.Take(items.Length / 2).ToArray();
                char[] secondPart = items.Skip(items.Length / 2).ToArray();

                char[] diff = firstPart.Intersect(secondPart).ToArray();
                if (char.IsUpper(diff[0]))
                {
                    sum += (diff[0] - 38);
                }
                else
                {
                    sum += (diff[0] - 96);
                }
            }

            Console.WriteLine(sum);
        }
    }
}
