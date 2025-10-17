namespace Zoo.Core.Things;

public class Table(int number) : Thing(number)
{
    public override string ToString()
    {
        return $"Table {Number}";
    }
}