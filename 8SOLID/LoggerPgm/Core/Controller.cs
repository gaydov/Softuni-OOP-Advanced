using System;
using System.Reflection;
using LoggerPgm.Core.Factories;
using LoggerPgm.Core.IO;
using LoggerPgm.Enums;
using LoggerPgm.Interfaces;
using LoggerPgm.Models;

namespace LoggerPgm.Core
{
    public class Controller
    {
        private const string EndCommand = "END";
        private IAppender[] appenders;
        private ILogger logger;

        public void Start()
        {
            this.ReadAppendersInfo();

            this.logger = new Logger(this.appenders);

            this.ReadInput();

            ConsoleWriter.WriteLine(this.logger);
        }

        private string ConvertStringToTitleCase(string inputString)
        {
            string inputStrToLower = inputString.ToLower();

            return char.ToUpper(inputStrToLower[0]) + inputStrToLower.Substring(1);
        }

        private void ReadAppendersInfo()
        {
            int appendersCount = int.Parse(ConsoleReader.ReadLine());
            this.appenders = new IAppender[appendersCount];

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = ConsoleReader.ReadLine().Split();
                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout);

                if (appenderInfo.Length > 2)
                {
                    string reportLevel = this.ConvertStringToTitleCase(appenderInfo[2]);
                    appender.ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
                }

                this.appenders[i] = appender;
            }
        }

        private void ReadInput()
        {
            string input = ConsoleReader.ReadLine();

            while (!input.Equals(EndCommand))
            {
                string[] messageInfo = input.Split('|');
                string reportLevel = messageInfo[0];
                string dateAndTime = messageInfo[1];
                string messageText = messageInfo[2];

                string methodName = this.ConvertStringToTitleCase(reportLevel);
                MethodInfo currentMethod = typeof(Logger).GetMethod(methodName);
                currentMethod.Invoke(this.logger, new object[] { dateAndTime, messageText });

                input = ConsoleReader.ReadLine();
            }
        }
    }
}