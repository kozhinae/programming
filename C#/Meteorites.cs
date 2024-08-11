using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorites : IObstacle
{
    private int quantity;

    public Meteorites(int damage)
    {
        this.quantity = damage;
    }

    public void InteractWithShip(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "The parameter 'ship' cannot be null.");
        }

        if (ship.Deflector == null)
        {
            throw new ArgumentNullException(nameof(ship.Deflector), "The parameter 'Deflector' cannot be null.");
        }

        ship.Deflector.DeflectObstacles(this, quantity);
        if (ship.Deflector.GetIsActivated() == false)
        {
            ship.CorpusStrength.ReceiveDamage(this, ship.Deflector.GetNonDeflectedObstacles());
            if (ship.CorpusStrength.GetIsActivated() == false)
            {
                ship.SetCondition(RouteResultType.ShipDestruction);
            }
            else
            {
                ship.SetCondition(RouteResultType.Success);
            }
        }
        else
        {
            ship.SetCondition(RouteResultType.Success);
        }
    }
}