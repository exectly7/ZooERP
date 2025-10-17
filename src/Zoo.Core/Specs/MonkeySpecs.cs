using Zoo.Core.Interfaces;

namespace Zoo.Core.Specs;

public class MonkeySpecs : IAnimalSpecs
{
    public string Species => "Monkey";

    private readonly AnimalParameter _food = new("Food", "int", "Food kg per day");
    private readonly AnimalParameter _kindness = new("Kindness", "int", "Kindness from 1 to 10");
    
    public AnimalParameter[] GetSpecs()
    {
        return [_food, _kindness];
    }
}