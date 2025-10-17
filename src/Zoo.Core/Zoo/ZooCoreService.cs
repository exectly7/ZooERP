using Zoo.Core.Animals;
using Zoo.Core.Interfaces;
using Zoo.Core.Requests;
using Zoo.Core.Specs;
using Zoo.Core.Things;

namespace Zoo.Core.Zoo;

public class ZooCoreService(IVetClinic vet, IContactZooRule rule, IInventoryNumberGenerator numbers)
{
    private readonly Zoo _zoo = new(vet, rule);

    public Dictionary<string, IAnimalSpecs> GetSpiciesNames()
    {
        Dictionary<string, IAnimalSpecs> animalSpecs = new()
        {
            { "Rabbit", new RabbitSpecs() },
            { "Monkey", new MonkeySpecs() },
            { "Tiger", new TigerSpecs() },
            { "Wolf", new WolfSpecs() }
        };
        return animalSpecs;
    }
    
    public Dictionary<string, IThingSpecs> GetTypesNames()
    {
        Dictionary<string, IThingSpecs> thingsSpecs = new()
        {
            { "Computer", new ComputerSpecs() },
            { "Table", new TableSpecs() }
        };
        return thingsSpecs;
    }

    public PostRequest AddAnimal(string species, Dictionary<string, string> values)
    {
        var inv = numbers.Generate();
        Animal animal;
        try
        {
            animal = species.ToLower() switch
            {
                "rabbit" => new Rabbit(inv, int.Parse(values["Food"]), int.Parse(values["Kindness"])),
                "monkey" => new Monkey(inv, int.Parse(values["Food"]), int.Parse(values["Kindness"])),
                "tiger" => new Tiger(inv, int.Parse(values["Food"])),
                "wolf" => new Wolf(inv, int.Parse(values["Food"])),
                _ => throw new ArgumentOutOfRangeException(nameof(species))
            };
        }
        catch (Exception)
        {
            return PostRequest.Fail("invalid data");
        }
        

        return _zoo.AddAnimal(animal) ? PostRequest.Ok() : PostRequest.Fail("VetRejected");
    }
    
    public PostRequest AddThing(string type, Dictionary<string, string> values)
    {
        var inv = numbers.Generate();

        Thing thing = type.ToLower() switch
        {
            "computer" => new Computer(inv),
            "table" => new Table(inv),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

        return _zoo.AddThing(thing) ? PostRequest.Ok() : PostRequest.Fail("Error");
    }

    public GetAnimalsRequest ContactZooCandidates()
    {
        var candidates = _zoo.GetAnimalsForContactZoo();
        if (candidates.Count == 0)
        {
            return GetAnimalsRequest.Fail("No animals can be placed into contact zoo");
        }
        else
        {
            return GetAnimalsRequest.Ok(candidates);
        }
    }

    public GetNumberRequest GetAllFoodAmount()
    {
        int counter = 0;
        foreach (var animal in _zoo.Animals)
        {
            counter += animal.Food.Value;
        }
        return GetNumberRequest.Ok(counter);
    }

    public GetReportRequest GetReport()
    {
        List<string> report = [];
        foreach (var animal in _zoo.Animals)
        {
            report.Add(animal.ToString() ?? string.Empty);
        }
        foreach (var thing in _zoo.Things)
        {
            report.Add(thing.ToString() ?? string.Empty);
        }

        return GetReportRequest.Ok(report);
    }

    public int GetAnimalCount() => _zoo.Animals.Count();
}