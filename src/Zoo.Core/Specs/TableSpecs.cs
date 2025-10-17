using Zoo.Core.Interfaces;

namespace Zoo.Core.Specs;

public class TableSpecs : IThingSpecs
{
    public string Type => "Table";

    public ThingParameter[] GetSpecs()
    {
        return [];
    }
}