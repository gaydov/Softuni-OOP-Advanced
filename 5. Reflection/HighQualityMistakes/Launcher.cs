using System;

namespace HighQualityMistakes
{
    public class Launcher
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
