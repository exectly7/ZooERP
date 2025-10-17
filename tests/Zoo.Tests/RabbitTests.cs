using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Zoo;

namespace Zoo.Tests;

public class RabbitTests
{
    private static ZooCoreService MakeService()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IVetClinic, VetClinic>();
        services.AddSingleton<IContactZooRule, ContactZooRule>();
        services.AddSingleton<IInventoryNumberGenerator, InventoryNumberGenerator>();
        services.AddSingleton<ZooCoreService>();
        using var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<ZooCoreService>();
    }

    [Fact]
    public void AddRabbit_IncreasesCountAndFood()
    {
        var service = MakeService();
        var countBefore = service.GetAnimalCount();
        var foodBefore = service.GetAllFoodAmount();

        var add = service.AddAnimal("Rabbit", new Dictionary<string, string>
        {
            ["Food"] = "3",
            ["Kindness"] = "6"
        });

        var countAfter = service.GetAnimalCount();
        var foodAfter = service.GetAllFoodAmount();

        Assert.True(add.Success);
        Assert.Equal(countBefore + 1, countAfter);
        Assert.Equal(foodBefore.Number + 3, foodAfter.Number);
    }

    [Fact]
    public void AddRabbit_MissingKindness_Fails()
    {
        var service = MakeService();
        var add = service.AddAnimal("Rabbit", new Dictionary<string, string>
        {
            ["Food"] = "2"
        });
        Assert.False(add.Success);
    }
}
