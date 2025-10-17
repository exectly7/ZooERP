namespace Zoo.Core.Requests;

public sealed record GetNumberRequest(
    bool Success,
    int Number,
    string? Error = null)
{
    public static GetNumberRequest Ok(int number) => new(true, number);
    public static GetNumberRequest Fail(string error) => new(false, 0, error);
}