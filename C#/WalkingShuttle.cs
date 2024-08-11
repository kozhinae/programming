using Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class WalkingShuttle : Ship
{
    public WalkingShuttle(IEngine impulseEngine, ICorpusStrength corpusStrength, PhotonDeflector? photonDeflector)
        : base(impulseEngine, null, null, corpusStrength, RouteResultType.Success, null, photonDeflector)
    {
    }
}