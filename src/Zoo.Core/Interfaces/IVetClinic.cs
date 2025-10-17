using Zoo.Core.Animals;

namespace Zoo.Core.Interfaces;

public interface IVetClinic
{
    public bool Check(Animal animal);
}