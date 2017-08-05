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

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in privateMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        foreach (MethodInfo method in methods.Where(m => m.Name.Contains("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in methods.Where(m => m.Name.Contains("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
        }

        return result.ToString().Trim();
    }
}
