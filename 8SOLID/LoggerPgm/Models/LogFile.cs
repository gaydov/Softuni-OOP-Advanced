using System.IO;
using System.Linq;
using System.Text;

namespace LoggerPgm.Models
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";
        private readonly StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size
        {
            get { return this.CalcLogSize(); }
        }

        public void Write(string message, int messagesAppended)
        {
            this.sb.AppendLine(message);

            if (messagesAppended == 0 && File.Exists(DefaultFileName))
            {
                File.Delete(DefaultFileName);
            }

            File.AppendAllText(DefaultFileName, message);
        }

        private int CalcLogSize()
        {
            return this.sb
                .ToString()
                .Trim()
                .Where(char.IsLetter)
                .Sum(c => c);
        }
    }
}