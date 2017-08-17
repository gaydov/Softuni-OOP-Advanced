using LoggerPgm.Enums;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; protected set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; protected set; }

        public abstract void Append(string timeStamp, string reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";
        }
    }
}