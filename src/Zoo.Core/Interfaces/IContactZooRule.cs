using Zoo.Core.Animals;

namespace Zoo.Core.Interfaces;

public interface IContactZooRule
{
    public bool Check(Animal animal);
}