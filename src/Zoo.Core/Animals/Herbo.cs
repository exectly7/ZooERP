using Zoo.Core.ValueTypes;

namespace Zoo.Core.Animals;

public class Herbo(int number, int food, int kindness) : Animal(number, food)
{
    public KindnessLevel KindnessLevel { get; } = new (kindness);
}