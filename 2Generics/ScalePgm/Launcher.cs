using System;

namespace ScalePgm
{
    public class Launcher
    {
        public static void Main()
        {
            Scale<int> scaleInts = new Scale<int>(1, 5);
            Scale<bool> scaleBool = new Scale<bool>(true, true);
            Scale<string> scaleStrings = new Scale<string>("hi", "hi");

            // The scale method is with a wrong name due to a wrong name in the Softuni's judge system
            Console.WriteLine(scaleInts.GetHavier());
            Console.WriteLine(scaleBool.GetHavier()); // the default value of bool is "false"
            Console.WriteLine(scaleStrings.GetHavier()); // empty line because the default value of string is null
        }
    }
}
