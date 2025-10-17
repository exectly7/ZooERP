using Zoo.Core.Animals;
using Zoo.Core.Interfaces;
using Zoo.Core.ValueTypes;

namespace Zoo.Core.Zoo;

public class ContactZooRule : IContactZooRule
{
    private readonly KindnessLevel _defaultKindnessLevel = new KindnessLevel(5);
    
    public bool Check(Animal animal)
    {
        return animal is Herbo herbo && herbo.KindnessLevel > _defaultKindnessLevel;
    }
}