using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public abstract class ShipSelection
{
    public static Ship? SelectShip(IEnumerable<Ship> ship, IEnumerable<IObstacle> obstacles, ISpace space)
    {
        var shipSuccess = new List<Ship>();
        foreach (Ship ship1 in ship)
        {
            space.Sail(ship1, obstacles);
            if (ship1.GetCondition() == RouteResultType.Success)
            {
                shipSuccess.Add(ship1);
            }
        }

        if (shipSuccess.Count == 0)
        {
            return null;
        }
        else
        {
            int minPrice = StockExchange.SailPrice(shipSuccess[0], space);
            Ship minShip = shipSuccess[0];
            foreach (Ship ship1 in shipSuccess)
            {
                int price = StockExchange.SailPrice(ship1, space);
                if (price < minPrice)
                {
                    minPrice = price;
                    minShip = ship1;
                }
            }

            return minShip;
        }
    }
}
