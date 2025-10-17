namespace Zoo.Core.Animals;

public class Monkey(int number, int food, int kindness) : Herbo(number, food, kindness)
{
    public override string ToString()
    {
        return $"Monkey {Number}, {Food}, {KindnessLevel}";
    }
}