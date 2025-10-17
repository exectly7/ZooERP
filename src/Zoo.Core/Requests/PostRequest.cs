namespace Zoo.Core.Requests;

public sealed record PostRequest(bool Success, string? Error = null)
{
    public static PostRequest Ok() => new(true);
    public static PostRequest Fail(string error) => new(false, error);
}