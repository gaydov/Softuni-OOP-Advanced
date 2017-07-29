using System.Collections.Generic;
using Weekdays;

public class WeeklyCalendar
{
    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }

    public IList<WeeklyEntry> WeeklySchedule { get; }

    public void AddEntry(string weekday, string notes)
    {
        this.WeeklySchedule.Add(new WeeklyEntry(weekday, notes));
    }
}
