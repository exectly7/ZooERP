using Zoo.Core.Interfaces;

namespace Zoo.Core.Specs;

public class TigerSpecs : IAnimalSpecs
{
    public string Species => "Tiger";

    private readonly AnimalParameter _food = new("Food", "int", "Food kg per day");
    
    public AnimalParameter[] GetSpecs()
    {
        return [_food];
    }
}