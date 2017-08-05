using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HarvestingFieldsPgm.Engine
{
    public class Engine
    {
        public static string GetFields(string accessModifier)
        {
            Type classType = Type.GetType(typeof(HarvestingFields).Name);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            FieldInfo[] selectedFields;

            switch (accessModifier)
            {
                case "private":
                    selectedFields = fields.Where(f => f.IsPrivate).ToArray();
                    break;

                case "protected":
                    selectedFields = fields.Where(f => f.IsFamily).ToArray();
                    break;

                case "public":
                    selectedFields = fields.Where(f => f.IsPublic).ToArray();
                    break;

                case "all":
                    selectedFields = fields;
                    break;

                default:
                    throw new ArgumentException("Invalid access modifier.");
            }

            StringBuilder result = new StringBuilder();

            foreach (FieldInfo field in selectedFields)
            {
                result.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
            }

            return result.ToString().Trim();
        }
    }
}