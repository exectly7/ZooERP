namespace Zoo.Core.Interfaces;

public class InventoryNumberGenerator : IInventoryNumberGenerator
{
    private int _counter;
    
    public int Generate()
    {
        return ++_counter;
    }
}