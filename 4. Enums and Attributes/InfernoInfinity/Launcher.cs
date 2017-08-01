using InfernoInfinity.Core;
using System;

namespace InfernoInfinity
{
    public class Launcher
    {
        public static void Main()
        {
            try
            {
                Engine engine = new Engine();
                engine.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
