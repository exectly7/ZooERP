using Zoo.Core.Animals;
using Zoo.Core.Interfaces;

namespace Zoo.Core.Zoo;

public class VetClinic : IVetClinic
{
    public bool Check(Animal animal)
    {
        return new Random().Next(1, 10) != 1;
    }
}