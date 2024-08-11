using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class RouteSegmentResult
{
    public RouteResultType ResultType { get; set; }
    public TimeSpan Duration { get; set; }
    public double FuelConsumed { get; set; }
}