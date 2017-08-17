using System.Text;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string timeStamp, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{timeStamp}</date>");
            sb.AppendLine($"    <level>{reportLevel}</level>");
            sb.AppendLine($"    <message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString();
        }
    }
}