using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Launcher
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<string> urls = Console.ReadLine().Split().ToList();

            Smartphone phone = new Smartphone(numbers, urls);

            Console.WriteLine(phone);
        }
    }
}
