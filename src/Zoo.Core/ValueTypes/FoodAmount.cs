namespace Zoo.Core.ValueTypes;

public readonly record struct FoodAmount
{
    public readonly int Value { get; }
    
    public FoodAmount(int foodAmount)
    {
        if (foodAmount < 0)
        {
            throw new ArgumentException("Food amount cannot be negative");
        }
        Value = foodAmount;
    }
    
    public override string ToString() => $"Количество еды: {Value}кг/день";
}