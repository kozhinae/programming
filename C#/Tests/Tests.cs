using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.CorpusStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Spaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    public static IEnumerable<object[]> Test1()
    {
        yield return new object[] { new WalkingShuttle(new ImpulseEngineClassC(), new CorpusStrengthClass1(), null), RouteResultType.ShipDestruction };
        yield return new object[] { new Augur(new ImpulseEngineClassE(), new AlphaEngine(), new DeflectorClass3(), new CorpusStrengthClass3(), null), RouteResultType.ShipLoss };
    }

    public static IEnumerable<object[]> Test2()
    {
        yield return new object[] { new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), null), RouteResultType.CrewLoss };
        yield return new object[] { new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), new PhotonDeflector()), RouteResultType.Success };
    }

    public static IEnumerable<object[]> Test3()
    {
        yield return new object[] { new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), null), RouteResultType.ShipDestruction };
        yield return new object[] { new Augur(new ImpulseEngineClassE(), new AlphaEngine(), new DeflectorClass3(), new CorpusStrengthClass3(), null), RouteResultType.Success };
        yield return new object[] { new Meridian(new ImpulseEngineClassE(), new DeflectorClass2(), new CorpusStrengthClass2(), new ConcreteAntinitrineEmitter(), null), RouteResultType.Success };
    }

    [Theory]
    [MemberData(nameof(Test1))]
    public void TestAugurWalkingShuttleinHighDensitySpace(Ship ship, RouteResultType result)
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { };
        var space = new HighDensitySpace(100);
        var route = new Route(space, ship, obstacles);
        route.PassRoute();
        Assert.Equal(result, ship.GetCondition());
    }

    [Theory]
    [MemberData(nameof(Test2))]
    public void TestAntimatterFlashes(Ship ship, RouteResultType result)
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { new AntimatterFlashes(1) };
        var space = new HighDensitySpace(10);
        var route = new Route(space, ship, obstacles);
        route.PassRoute();
        Assert.Equal(result, ship.GetCondition());
    }

    [Theory]
    [MemberData(nameof(Test3))]
    public void TestSpaceWhaleinNitrinoParticleSpace(Ship ship, RouteResultType result)
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { new SpaceWhale(1) };
        var space = new NitrinoParticleSpace(15);
        var route = new Route(space, ship, obstacles);
        route.PassRoute();
        Assert.Equal(result, ship.GetCondition());
    }

    [Fact]
    public void TestNormalSpace()
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { };
        var space = new NormalSpace(20);
        var walkingshuttle = new WalkingShuttle(new ImpulseEngineClassC(), new CorpusStrengthClass1(), null);
        var vaklas = new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), null);
        IEnumerable<Ship> ships = new List<Ship> { walkingshuttle, vaklas };
        Ship? result = ShipSelection.SelectShip(ships, obstacles, space);
        Assert.Equal(walkingshuttle, result);
    }

    [Fact]
    public void TestHighDensitySpace()
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { };
        var space = new HighDensitySpace(60);
        var augur = new Augur(new ImpulseEngineClassE(), new AlphaEngine(), new DeflectorClass3(), new CorpusStrengthClass3(), null);
        var stella = new Stella(new ImpulseEngineClassC(), new OmegaEngine(), new DeflectorClass1(), new CorpusStrengthClass1(), null);
        IEnumerable<Ship> ships = new List<Ship> { augur, stella };
        Ship? result = ShipSelection.SelectShip(ships, obstacles, space);
        Assert.Equal(stella, result);
    }

    [Fact]
    public void TestNitrinoParticleSpace()
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { };
        var space = new NitrinoParticleSpace(40);
        var walkingshuttle = new WalkingShuttle(new ImpulseEngineClassC(), new CorpusStrengthClass1(), null);
        var vaklas = new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), null);
        IEnumerable<Ship> ships = new List<Ship> { walkingshuttle, vaklas };
        Ship? result = ShipSelection.SelectShip(ships, obstacles, space);
        Assert.Equal(vaklas, result);
    }

    [Fact]
    public void TestNormalspacewithAsteroids()
    {
        IEnumerable<IObstacle> obstacles = new List<IObstacle> { new Asteroids(4) };
        var space = new NormalSpace(20);
        var stella = new Stella(new ImpulseEngineClassC(), new OmegaEngine(), new DeflectorClass1(), new CorpusStrengthClass1(), null);
        var vaklas = new Vaklas(new ImpulseEngineClassE(), new GammaEngine(), new DeflectorClass1(), new CorpusStrengthClass2(), null);
        IEnumerable<Ship> ships = new List<Ship> { stella, vaklas };
        Ship? result = ShipSelection.SelectShip(ships, obstacles, space);
        Assert.Equal(vaklas, result);
    }
}
