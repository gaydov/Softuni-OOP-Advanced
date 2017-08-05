using System;
using System.Linq;

namespace Stack
{
    public class Launcher
    {
        public static void Main()
        {
            CustomStack<int> myStack = new CustomStack<int>();
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                string[] args = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];

                switch (command)
                {
                    case "Push":

                        myStack.Push(args.Skip(1).Select(int.Parse));
                        break;

                    case "Pop":

                        try
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int element in myStack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
