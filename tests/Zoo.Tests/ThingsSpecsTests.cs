using Microsoft.Extensions.DependencyInjection;
using Zoo.Core.Interfaces;
using Zoo.Core.Zoo;

namespace Zoo.Tests;

public class ThingsSpecsTests
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
    public void Types_Available_ContainsComputer()
    {
        var service = MakeService();
        var types = service.GetTypesNames();
        Assert.NotEmpty(types);
        Assert.Contains("Computer", types.Keys);
    }

    [Fact]
    public void AddThing_ForEachAvailableType_Succeeds()
    {
        var service = MakeService();
        var types = service.GetTypesNames();
        foreach (var t in types.Keys.ToList())
        {
            var res = service.AddThing(t, new Dictionary<string, string>());
            Assert.True(res.Success);
        }
    }
}