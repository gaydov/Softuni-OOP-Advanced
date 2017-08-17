using System;
using System.Collections.Generic;
using System.Text;
using LoggerPgm.Enums;
using LoggerPgm.Interfaces;

namespace LoggerPgm.Models
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IList<IAppender> Appenders { get; }

        public void Info(string timeStamp, string message)
        {
            this.Log(timeStamp, nameof(this.Info), message);
        }

        public void Warning(string timeStamp, string message)
        {
            this.Log(timeStamp, nameof(this.Warning), message);
        }

        public void Error(string timeStamp, string message)
        {
            this.Log(timeStamp, nameof(this.Error), message);
        }

        public void Critical(string timeStamp, string message)
        {
            this.Log(timeStamp, nameof(this.Critical), message);
        }

        public void Fatal(string timeStamp, string message)
        {
            this.Log(timeStamp, nameof(this.Fatal), message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().Trim();
        }

        private void Log(string timeStamp, string reportLevel, string message)
        {
            foreach (IAppender appender in this.Appenders)
            {
                ReportLevel reportLevelTreshold = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if (reportLevelTreshold >= appender.ReportLevel)
                {
                    appender.Append(timeStamp, reportLevel.ToUpper(), message);
                }
            }
        }
    }
}