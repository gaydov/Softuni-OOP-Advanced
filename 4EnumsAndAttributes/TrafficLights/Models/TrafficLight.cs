using System;

public class TrafficLight
{
    private TrafficLightSignal light;

    public TrafficLight(string startLight)
    {
        this.light = (TrafficLightSignal)Enum.Parse(typeof(TrafficLightSignal), startLight);
    }

    public void SwitchLight()
    {
        int enumLength = Enum.GetNames(typeof(TrafficLightSignal)).Length;
        int currentIndex = (int)this.light;
        this.light = (TrafficLightSignal)((currentIndex + 1) % enumLength);
    }

    public override string ToString()
    {
        return $"{this.light}";
    }
}
