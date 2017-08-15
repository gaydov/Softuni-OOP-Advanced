using System;
using Recharge.Models;

namespace Recharge
{
    public class Launcher
    {
        public static void Main()
        {
            Robot robot = new Robot("R2D2", 150);
            Worker employee = new Employee("Luk");
            RechargeStation station = new RechargeStation();
            station.Recharge(robot);
            robot.Work(12);
            employee.Work(8);

            Console.WriteLine(robot.CurrentPower);
        }
    }
}
