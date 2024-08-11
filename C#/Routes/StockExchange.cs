using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public static class StockExchange
{
    private const int FuelPrice = 100;

    public static int SailPrice(Ship ship, ISpace space)
    {
        int impulsedistance = space.GetDistance();
        int jumpdistance = ship.JumpEngine?.GetMaxDistance() ?? 0;
        return FuelPrice * (ship.ImpulseEngine.FuelConsumed(impulsedistance) + (ship.JumpEngine?.FuelConsumed(jumpdistance) ?? 0));
    }
}
