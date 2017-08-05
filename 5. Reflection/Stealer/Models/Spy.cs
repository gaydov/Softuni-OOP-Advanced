using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                                    BindingFlags.NonPublic | BindingFlags.Public);

        Object instance = Activator.CreateInstance(classType, new object[] { });
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Class under investigation: {classType}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return result.ToString().Trim();
    }
}
