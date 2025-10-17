using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Things;
using Zoo.Core.Zoo;

namespace Zoo.Tests;

public class CoreIntegrationTests
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
    public void Things_ToString_AreReadable()
    {
        var c = new Computer(123);
        var t = new Table(7);
        Assert.Equal("Computer 123", c.ToString());
        Assert.Equal("Table 7", t.ToString());
    }

    [Fact]
    public void Service_HasAtLeastRabbitAndComputer()
    {
        var service = MakeService();
        var animals = service.GetSpiciesNames();
        var things = service.GetTypesNames();
        Assert.Contains("Rabbit", animals.Keys);
        Assert.Contains("Computer", things.Keys);
    }

    [Fact]
    public void AddRabbit_IncreasesCount()
    {
        var service = MakeService();
        var before = service.GetAnimalCount();
        var values = new Dictionary<string, string>
        {
            ["Food"] = "2",
            ["Kindness"] = "5"
        };
        var res = service.AddAnimal("Rabbit", values);
        var after = service.GetAnimalCount();
        Assert.True(res.Success);
        Assert.Equal(before + 1, after);
    }
}