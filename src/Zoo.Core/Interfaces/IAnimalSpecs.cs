using Zoo.Core.Specs;

namespace Zoo.Core.Interfaces;

public interface IAnimalSpecs
{
    public string Species { get; }
    public AnimalParameter[] GetSpecs();
}