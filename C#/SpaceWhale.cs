using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhale : IObstacle
{
    private int quantity;
    public SpaceWhale(int density)
    {
        this.quantity = density;
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

        if (ship.AntinitrineEmitter == null)
        {
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
}