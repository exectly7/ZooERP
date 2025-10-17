namespace Zoo.Core.Things;

public class Computer(int number) : Thing(number)
{
    public override string ToString()
    {
        return $"Computer {Number}";
    }
}