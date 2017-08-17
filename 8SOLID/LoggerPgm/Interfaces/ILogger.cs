using System.Collections.Generic;

namespace LoggerPgm.Interfaces
{
    public interface ILogger
    {
        IList<IAppender> Appenders { get; }

        void Info(string timeStamp, string message);

        void Warning(string timeStamp, string message);

        void Error(string timeStamp, string message);

        void Critical(string timeStamp, string message);

        void Fatal(string timeStamp, string message);
    }
}