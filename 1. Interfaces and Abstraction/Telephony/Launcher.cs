using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Launcher
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> URLs = Console.ReadLine().Split().ToList();

            Smartphone phone = new Smartphone(numbers, URLs);

            Console.WriteLine(phone);
        }
    }
}
