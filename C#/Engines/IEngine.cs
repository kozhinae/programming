using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngine
{
    void Start();
    string GetEngineType();
    int FuelConsumed(int distance);
    int GetMaxDistance();
}

public class ImpulseEngineClassC : IEngine
{
    private const int FuelConsumption = 10;
    private const int MaxDistance = 30;

    public void Start()
    {
        Console.WriteLine("Class C engine started.");
    }

    public int GetMaxDistance() => MaxDistance;

    public string GetEngineType()
    {
        return "ImpulseEngineClassC";
    }

    public int FuelConsumed(int distance)
    {
        return distance * FuelConsumption;
    }
}
