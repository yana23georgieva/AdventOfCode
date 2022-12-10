using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day5SupplySnacks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Input.txt");
            List<string> products = new List<string>();
            List<string> actions = new List<string>();
            List<Stack<string>> elements = new List<Stack<string>>();
            bool commands = false;

            foreach (var item in lines)
            {
                if (item == String.Empty)
                {
                    commands = true;
                    continue;
                }

                if (!commands)
                {
                    products.Add(item);
                }
                else
                {
                    actions.Add(item);
                }
            }

            int max = products[products.Count - 2].Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

            for (int i = 0; i < max; i++)
            {
                elements.Add(new Stack<string>());
            }

            for (int i = products.Count - 2; i >= 0; i--)
            {
                char[] curentRow = products[i].ToCharArray();
                int index = 0;

                for (int j = 0; j < curentRow.Length; j += 4)
                {
                    string currentElement = curentRow[j + 1].ToString();

                    if (!String.IsNullOrWhiteSpace(currentElement))
                    {
                        elements[index].Push(currentElement);
                    }
                    index++;
                }
            }

            foreach (var item in actions)
            {
                string[] currentAction = item.Split(" ");
                int countElements = int.Parse(currentAction[1]);
                int sourceIndex = int.Parse(currentAction[3]) - 1;
                int destinationIndex = int.Parse(currentAction[5]) - 1;

                Stack<string> move = new Stack<string>();

                for (int i = 0; i < countElements; i++)
                {
                    //elements[destinationIndex].Push(elements[sourceIndex].Peek());
                    //elements[sourceIndex].Pop();

                    //Part 2
                    move.Push(elements[sourceIndex].Peek());
                    elements[sourceIndex].Pop();
                }

                foreach (var element in move)
                {
                    elements[destinationIndex].Push(element);
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (var item in elements)
            {
                result.Append(item.Peek());
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
