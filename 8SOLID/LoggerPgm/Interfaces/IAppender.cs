using LoggerPgm.Enums;

namespace LoggerPgm.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        void Append(string timeStamp, string reportLevel, string message);
    }
}