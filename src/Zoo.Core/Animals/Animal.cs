using Zoo.Core.Interfaces;
using Zoo.Core.ValueTypes;

namespace Zoo.Core.Animals;

public class Animal(int number, int food) : IAlive, IInventory
{
    public InventoryNumber Number { get; } = new (number);
    public FoodAmount Food { get; } = new (food);
}