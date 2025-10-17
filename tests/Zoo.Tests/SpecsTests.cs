using Zoo.Core.Specs;

namespace Zoo.Tests;

public class SpecsTests
{
    [Fact]
    public void RabbitSpecs_HasFoodAndKindness()
    {
        var specs = new RabbitSpecs();
        var parameters = specs.GetSpecs();
        Assert.Equal("Rabbit", specs.Species);
        Assert.Equal(2, parameters.Length);
        Assert.Contains(parameters, p => p.Name == "Food" && p.TypeHint == "int");
        Assert.Contains(parameters, p => p.Name == "Kindness" && p.TypeHint == "int");
    }

    [Fact]
    public void MonkeySpecs_HasFoodAndKindness()
    {
        var specs = new MonkeySpecs();
        var parameters = specs.GetSpecs();
        Assert.Equal("Monkey", specs.Species);
        Assert.Equal(2, parameters.Length);
        Assert.Contains(parameters, p => p.Name == "Food" && p.TypeHint == "int");
        Assert.Contains(parameters, p => p.Name == "Kindness" && p.TypeHint == "int");
    }

    [Fact]
    public void WolfSpecs_OnlyFood()
    {
        var specs = new WolfSpecs();
        var parameters = specs.GetSpecs();
        Assert.Equal("Wolf", specs.Species);
        Assert.Single(parameters);
        Assert.Equal("Food", parameters.Single().Name);
    }

    [Fact]
    public void TigerSpecs_OnlyFood()
    {
        var specs = new TigerSpecs();
        var parameters = specs.GetSpecs();
        Assert.Equal("Tiger", specs.Species);
        Assert.Single(parameters);
        Assert.Equal("Food", parameters.Single().Name);
    }
}