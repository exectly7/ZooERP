using Zoo.Core.Animals;

namespace Zoo.Core.Requests;

public sealed record GetAnimalsRequest(
    bool Success,
    List<Animal> Animals,
    string? Error = null)
{
    public static GetAnimalsRequest Ok(List<Animal> animals) => new(true, animals);
    public static GetAnimalsRequest Fail(string error) => new(false, [], error);
}