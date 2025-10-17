using Zoo.Core.Interfaces;
using Zoo.Core.ValueTypes;

namespace Zoo.Core.Things;

public class Thing(int number) : IInventory
{
    public InventoryNumber Number { get; } = new(number);
}