using System;
using Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Ship
{
    private readonly IEngine impulseEngine;
    private readonly IJumpEngineType? jumpEngine;
    private readonly IDeflector? deflector;
    private readonly ICorpusStrength corpusStrength;
    private readonly AntinitrineEmitter? antinitrineEmitter;
    private readonly PhotonDeflector? photonDeflector;
    private RouteResultType condition;

    public Ship(IEngine impulseEngine, IJumpEngineType? jumpEngine, IDeflector? deflector, ICorpusStrength corpusStrength, RouteResultType condition, AntinitrineEmitter? antinitrineEmitter, PhotonDeflector? photonDeflector)
    {
        this.impulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        this.jumpEngine = jumpEngine;
        this.deflector = deflector;
        this.corpusStrength = corpusStrength ?? throw new ArgumentNullException(nameof(corpusStrength));
        this.condition = condition;
        this.photonDeflector = photonDeflector;
        this.antinitrineEmitter = antinitrineEmitter;
    }

    public IEngine ImpulseEngine => impulseEngine;

    public IJumpEngineType? JumpEngine => jumpEngine;
    public IDeflector? Deflector => deflector;
    public ICorpusStrength CorpusStrength => corpusStrength;
    public AntinitrineEmitter? AntinitrineEmitter => antinitrineEmitter;
    public PhotonDeflector? PhotonDeflector => photonDeflector;
    public RouteResultType GetCondition() => condition;
    public void StartImpulseEngine()
    {
        impulseEngine.Start();
    }

    public void StartJumpEngine()
    {
        jumpEngine?.Start();
    }

    public void SetCondition(RouteResultType conditions)
    {
        condition = conditions;
    }
}
