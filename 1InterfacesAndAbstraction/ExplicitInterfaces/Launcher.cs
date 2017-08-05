using System;

namespace ExplicitInterfaces
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] args = input.Split();
                string name = args[0];
                string country = args[1];
                int age = int.Parse(args[2]);

                Citizen currentCitizen = new Citizen(name, country, age);
                IPerson personCitizen = currentCitizen;
                IResident residentCitizen = currentCitizen;

                Console.WriteLine(personCitizen.GetName());
                Console.WriteLine(residentCitizen.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
