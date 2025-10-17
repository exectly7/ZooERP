using Zoo.Core.Animals;
using Zoo.Core.Interfaces;
using Zoo.Core.Things;

namespace Zoo.Core.Zoo;

public class Zoo(IVetClinic vetClinic, IContactZooRule contactZooRule)
{
    public List<Animal> Animals { get; } = [];
    public List<Thing> Things { get; } = [];
    private IVetClinic VetClinic { get; } = vetClinic;
    private IContactZooRule ContactZooRule { get; } = contactZooRule;

    public bool AddAnimal(Animal animal)
    {
        if (VetClinic.Check(animal))
        {
            Animals.Add(animal);
            return true;
        }   
        else
        {
            return false;
        }
    }
    
    public bool AddThing(Thing thing)
    {
        Things.Add(thing);
        return true;
    }

    public List<Animal> GetAnimalsForContactZoo()
    {
        List<Animal> contactZooCandidats = [];
        foreach (var animal in Animals)
        {
            if (ContactZooRule.Check(animal))
            {
                contactZooCandidats.Add(animal);
            }
        }

        return contactZooCandidats;
    }
}