namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IJumpEngineType
{
    void Start();
    int GetMaxDistance();
    int GetFuelConsumption();
    string GetEngineType();
    int FuelConsumed(int distance);
}
