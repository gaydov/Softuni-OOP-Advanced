using System;

namespace TrackerPgm
{
    [SoftUni("Georgi")]
    public class Launcher
    {
        [SoftUni("Ivan")]
        public static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
