using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLights
{
    public class Launcher
    {
        public static void Main()
        {
            IList<TrafficLight> trafficLights = new List<TrafficLight>();
            string[] signalsInput = Console.ReadLine().Split();
            foreach (string signal in signalsInput)
            {
                TrafficLight currentTrafficLight = new TrafficLight(signal);
                trafficLights.Add(currentTrafficLight);
            }

            int switchesCount = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < switchesCount; i++)
            {
                foreach (TrafficLight trafficLight in trafficLights)
                {
                    trafficLight.SwitchLight();
                    result.Append($"{trafficLight} ");
                }
                result.AppendLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
