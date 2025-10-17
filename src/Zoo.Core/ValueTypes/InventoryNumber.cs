namespace Zoo.Core.ValueTypes;

public readonly record struct InventoryNumber
{
    private readonly int Value { get; }
    
    public InventoryNumber(int inventoryNumber)
    {
        if (inventoryNumber < 0)
        {
            throw new ArgumentException("Inventory number cannot be negative");
        }
        Value = inventoryNumber;
    }
    
    public override string ToString() => $"{Value}";
}