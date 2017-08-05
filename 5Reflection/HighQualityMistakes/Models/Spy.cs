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

        object instance = Activator.CreateInstance(classType, new object[] { });
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Class under investigation: {classType}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return result.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] privateMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            result.AppendLine($"{field} must be private!");
        }

        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        foreach (MethodInfo method in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        return result.ToString().Trim();
    }
}
