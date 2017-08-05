using System;
using System.Linq;
using System.Reflection;
using TrackerPgm;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(Launcher);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (MethodInfo methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
