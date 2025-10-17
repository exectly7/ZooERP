using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Zoo;

namespace Zoo.Tests;

public class TigerTests
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
    public void AddTiger_IncreasesFood()
    {
        var service = MakeService();
        var foodBefore = service.GetAllFoodAmount();

        var add = service.AddAnimal("Tiger", new Dictionary<string, string>
        {
            ["Food"] = "7"
        });

        var foodAfter = service.GetAllFoodAmount();

        Assert.True(add.Success);
        Assert.Equal(foodBefore.Number + 7, foodAfter.Number);
    }

    [Fact]
    public void AddTiger_InvalidFood_Fails()
    {
        var service = MakeService();
        var add = service.AddAnimal("Tiger", new Dictionary<string, string>
        {
            ["Food"] = "abc"
        });
        Assert.False(add.Success);
    }
}