using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Zoo;

namespace Zoo.Tests;

public class MonkeyTests
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
    public void AddMonkey_IncreasesFood()
    {
        var service = MakeService();
        var foodBefore = service.GetAllFoodAmount();

        var add = service.AddAnimal("Monkey", new Dictionary<string, string>
        {
            ["Food"] = "2",
            ["Kindness"] = "7"
        });

        var foodAfter = service.GetAllFoodAmount();

        Assert.True(add.Success);
        Assert.Equal(foodBefore.Number + 2, foodAfter.Number);
    }

    [Fact]
    public void AddMonkey_MissingFood_Fails()
    {
        var service = MakeService();
        var add = service.AddAnimal("Monkey", new Dictionary<string, string>
        {
            ["Kindness"] = "5"
        });
        Assert.False(add.Success);
    }
}