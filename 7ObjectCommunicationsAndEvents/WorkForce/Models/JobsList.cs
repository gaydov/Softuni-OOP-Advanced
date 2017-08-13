using System.Collections.Generic;

namespace WorkForce.Models
{
    public class JobsList : List<Job>
    {
        public void OnJobDone(object source, JobEventArgs args)
        {
            args.Job.JobDone -= this.OnJobDone;
            this.Remove(args.Job);
        }
    }
}