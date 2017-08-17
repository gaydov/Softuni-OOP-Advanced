using LoggerPgm.Interfaces;

namespace LoggerPgm.Models.Appenders
{
    internal class FileAppender : Appender
    {
        public FileAppender(ILayout layout, LogFile logfile)
            : base(layout)
        {
            this.File = logfile;
        }

        public LogFile File { get; }

        public override void Append(string timeStamp, string reportLevel, string message)
        {
            string formattedMessage = this.Layout.FormatMessage(timeStamp, reportLevel, message);
            this.File.Write(formattedMessage, this.MessagesAppended);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}