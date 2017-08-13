using System;
using WorkForce.Interfaces;

namespace WorkForce.Models
{
    public class Job
    {
        private readonly IEmployee employee;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.HoursRequired = hoursRequired;
            this.employee = employee;
        }

        public event EventHandler<JobEventArgs> JobDone;

        public string Name { get; }

        public int HoursRequired { get; private set; }

        public void Update()
        {
            this.HoursRequired -= this.employee.WorkHoursPerWeek;

            if (this.HoursRequired <= 0)
            {
                this.OnJobDone();
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursRequired}";
        }

        protected virtual void OnJobDone()
        {
            Console.WriteLine($"Job {this.Name} done!");

            if (this.JobDone != null)
            {
                this.JobDone(this, new JobEventArgs(this));
            }
        }
    }
}