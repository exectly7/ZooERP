namespace Zoo.Core.Animals;

public class Wolf(int number, int food) : Predator(number, food)
{
    public override string ToString()
    {
        return $"Wolf {Number}, {Food}";
    }
}