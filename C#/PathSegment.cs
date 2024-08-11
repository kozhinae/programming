using Itmo.ObjectOrientedProgramming.Lab1.Spaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class PathSegment
{
    public PathSegment(double distance, ISpace space)
    {
        Distance = distance;
        Space = space;
    }

    public double Distance { get; set; }
    public ISpace Space { get; set; }
}