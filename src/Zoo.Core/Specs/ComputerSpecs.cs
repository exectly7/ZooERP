using Zoo.Core.Interfaces;

namespace Zoo.Core.Specs;

public class ComputerSpecs : IThingSpecs
{
    public string Type => "Computer";

    public ThingParameter[] GetSpecs()
    {
        return [];
    }
}