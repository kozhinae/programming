using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlashes : IObstacle
{
    private int quantity;

    public AntimatterFlashes(int damage)
    {
        this.quantity = damage;
    }

    public void InteractWithShip(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "The parameter 'ship' cannot be null.");
        }

        if (ship.PhotonDeflector == null)
        {
            ship.SetCondition(RouteResultType.CrewLoss);
            return;
        }

        ship.PhotonDeflector.DeflectObstacles(this, quantity);
        if (ship.PhotonDeflector.GetIsActivated() == false)
        {
            ship.SetCondition(RouteResultType.CrewLoss);
        }
        else
        {
            ship.SetCondition(RouteResultType.Success);
        }
    }
}