using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class GammaEngine : IJumpEngineType
{
    private const int FuelConsumption = 20;
    private const int MaxDistance = 100;
    public void Start()
    {
        Console.WriteLine("Class GammaEngine started.");
    }

    public int GetMaxDistance() => MaxDistance;

    public int GetFuelConsumption() => FuelConsumption;
    public string GetEngineType()
    {
        return "JumpEngine";
    }

    public int FuelConsumed(int distance)
    {
        return distance * FuelConsumption * FuelConsumption;
    }
}
