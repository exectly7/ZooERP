using Zoo.Core.Specs;

namespace Zoo.Core.Interfaces;

public interface IThingSpecs
{
    public string Type { get; }
    public ThingParameter[] GetSpecs();
}