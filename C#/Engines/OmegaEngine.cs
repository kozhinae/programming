using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class OmegaEngine : IJumpEngineType
{
    private const int FuelConsumption = 15;
    private const int MaxDistance = 75;
    public void Start()
    {
        Console.WriteLine("Class OmegaEngine started.");
    }

    public int GetMaxDistance() => MaxDistance;

    public int GetFuelConsumption() => FuelConsumption;
    public string GetEngineType()
    {
        return "JumpEngine";
    }

    public int FuelConsumed(int distance)
    {
        return (int)(distance * FuelConsumption * Math.Log2(FuelConsumption));
    }
}
