using LoggerPgm.Core;

namespace LoggerPgm
{
    public class Launcher
    {
        public static void Main()
        {
            Controller controller = new Controller();
            controller.Start();
        }
    }
}
