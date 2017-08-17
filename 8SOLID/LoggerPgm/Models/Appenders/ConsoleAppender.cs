using LoggerPgm.Core.IO;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            this.Layout = layout;
        }

        public override void Append(string timeStamp, string reportLevel, string message)
        {
            ConsoleWriter.WriteLine(this.Layout.FormatMessage(timeStamp, reportLevel, message));
            this.MessagesAppended++;
        }
    }
}