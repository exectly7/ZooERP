namespace Zoo.Core.Animals;

public class Rabbit(int number, int food, int kindness) : Herbo(number, food, kindness)
{
    public override string ToString()
    {
        return $"Rabbit {Number}, {Food}, {KindnessLevel}";
    }
}