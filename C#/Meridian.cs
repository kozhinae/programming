using Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meridian : Ship
{
    public Meridian(IEngine impulseEngine, IDeflector? deflector, ICorpusStrength corpusStrength, ConcreteAntinitrineEmitter antinitrineEmitter, PhotonDeflector? photonDeflector)
        : base(impulseEngine, null, deflector, corpusStrength, RouteResultType.Success, antinitrineEmitter, photonDeflector)
    {
    }
}