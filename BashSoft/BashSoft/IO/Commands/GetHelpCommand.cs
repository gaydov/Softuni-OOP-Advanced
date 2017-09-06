using BashSoft.Attributes;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("help")]
    public class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine("make directory - mkdir: path ");
            OutputWriter.WriteMessageOnNewLine("traverse directory - ls: depth ");
            OutputWriter.WriteMessageOnNewLine("comparing files - cmp: path1 path2");
            OutputWriter.WriteMessageOnNewLine("change directory - cdrel: relative path");
            OutputWriter.WriteMessageOnNewLine("change directory - cdabs: absolute path");
            OutputWriter.WriteMessageOnNewLine("read students data base - readDb: path");
            OutputWriter.WriteMessageOnNewLine("filter {courseName} excellent/average/poor take 2/5/all students - (the output is written on the console)");
            OutputWriter.WriteMessageOnNewLine("order {courseName} ascending/descending take 20/10/all students - (the output is written on the console)");
            OutputWriter.WriteMessageOnNewLine("display data entities - display students/courses ascending/descending");
            OutputWriter.WriteMessageOnNewLine("get help – help");
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }
    }
}