using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIteratorPgm
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
                }

                input = Console.ReadLine();
            }
        }
    }
}
