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

            //Part2
            for (int i = 0; i < lines.Length; i += 3)
            {
                char[] first = lines[i].ToCharArray();
                char[] second = lines[i + 1].ToCharArray();
                char[] third = lines[i + 2].ToCharArray();

                char[] diff = first.Intersect(second).ToArray();
                char[] finalDiff = diff.Intersect(third).ToArray();

                if (char.IsUpper(finalDiff[0]))
                {
                    sum += (finalDiff[0] - 38);
                }
                else
                {
                    sum += (finalDiff[0] - 96);
                }
            }

            //Part 1
            /*foreach (var item in lines)
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
            }*/

            Console.WriteLine(sum);
        }
    }
}
