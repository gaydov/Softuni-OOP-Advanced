using System;
using System.Linq;

namespace Collection
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            ListyIterator<string> iterator = null;

            while (!input.Equals("END"))
            {
                string[] args = input.Split();

                switch (args[0])
                {
                    case "Create":

                        iterator = new ListyIterator<string>(args.Skip(1));
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":

                        try
                        {
                            Console.WriteLine(iterator.Print());
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }

                        break;

                    case "PrintAll":

                        foreach (string item in iterator)
                        {
                            Console.Write($"{item} ");
                        }

                        Console.WriteLine();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
