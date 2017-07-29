using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private readonly WeekDay weekDay;
    private readonly string notes;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, true, out this.weekDay);
        this.notes = notes;
    }

    public int CompareTo(WeeklyEntry other)
    {
        int result = this.weekDay.CompareTo(other.weekDay);

        if (result == 0)
        {
            result = this.notes.CompareTo(other.notes);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.weekDay} - {this.notes}";
    }
}
