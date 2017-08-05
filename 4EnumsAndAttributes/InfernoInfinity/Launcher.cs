using System;
using InfernoInfinity.Core;

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
