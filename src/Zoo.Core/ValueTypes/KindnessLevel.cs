namespace Zoo.Core.ValueTypes;

public readonly record struct KindnessLevel
{
    private readonly int Value { get; }
    
    public KindnessLevel(int kindnessLevel)
    {
        if (kindnessLevel is <= 10 and >= 1)
        {
            Value = kindnessLevel;
            return;
        }
        throw new ArgumentException("Kindness level must be between 1 and 10");
    }

    public static bool operator >(KindnessLevel left, KindnessLevel right) => left.Value > right.Value;
    public static bool operator <(KindnessLevel left, KindnessLevel right) => left.Value > right.Value;
    
    public override string ToString() => $"Уровень доброты: {Value}";
}