using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class AlphaEngine : IJumpEngineType
{
    private const int FuelConsumption = 10;
    private const int MaxDistance = 50;
    public void Start()
    {
        Console.WriteLine("Class AlphaEngine started.");
    }

    public int GetMaxDistance() => MaxDistance;

    public int GetFuelConsumption() => FuelConsumption;
    public string GetEngineType()
    {
        return "JumpEngine";
    }

    public int FuelConsumed(int distance)
    {
        return distance * FuelConsumption;
    }
}