using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class ImpulseEngineClassE : IEngine
{
    private const int FuelConsumption = 15;

    private const int MaxDistance = 50;

    public void Start()
    {
        Console.WriteLine("Class E engine started.");
    }

    public int GetMaxDistance() => MaxDistance;

    public string GetEngineType()
    {
        return "ImpulseEngineClassE";
    }

    public int FuelConsumed(int distance)
    {
        return distance * FuelConsumption;
    }
}