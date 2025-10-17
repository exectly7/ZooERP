using Zoo.Core.Interfaces;

namespace Zoo.Core.Specs;

public class WolfSpecs : IAnimalSpecs
{
    public string Species => "Wolf";

    private readonly AnimalParameter _food = new("Food", "int", "Food kg per day");
    
    public AnimalParameter[] GetSpecs()
    {
        return [_food];
    }
}