using Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Augur : Ship
{
    public Augur(IEngine impulseEngine, IJumpEngineType jumpEngine, IDeflector? deflector, ICorpusStrength corpusStrength, PhotonDeflector? photonDeflector)
        : base(impulseEngine, jumpEngine, deflector, corpusStrength, RouteResultType.Success, null, photonDeflector)
    {
    }
}