using System;
using System.Collections.Generic;
using System.Linq;
using WorkForce.Interfaces;
using WorkForce.Models;

namespace WorkForce
{
    public class Launcher
    {
        public static void Main()
        {
            JobsList jobs = new JobsList();
            IList<IEmployee> employees = new List<IEmployee>();

            string[] input = Console.ReadLine().Split();

            while (!input[0].Equals("End"))
            {
                switch (input[0])
                {
                    case "Job":
                        Job currentJob = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name.Equals(input[3])));
                        jobs.Add(currentJob);
                        currentJob.JobDone += jobs.OnJobDone;
                        break;

                    case "StandartEmployee":
                        StandartEmployee standartEmployee = new StandartEmployee(input[1]);
                        employees.Add(standartEmployee);
                        break;

                    case "PartTimeEmployee":
                        PartTimeEmployee parttimeEmployee = new PartTimeEmployee(input[1]);
                        employees.Add(parttimeEmployee);
                        break;

                    case "Pass":

                        //// Not itterating properly with this approach - 80/100
                        //// for (int i = jobs.Count - 1; i >= 0; i--)
                        //// {
                        ////     jobs[i].Update();
                        //// }

                        foreach (Job job in jobs.ToArray())
                        {
                            job.Update();
                        }

                        break;

                    case "Status":

                        foreach (Job job in jobs)
                        {
                            Console.WriteLine(job);
                        }

                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}