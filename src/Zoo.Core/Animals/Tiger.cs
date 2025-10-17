namespace Zoo.Core.Animals;

public class Tiger : Predator
{
    public Tiger(int number, int food) 
        : base(number, food)
    {
    }
    public override string ToString()
    {
        return $"Tiger {Number}, {Food}";
    }
}