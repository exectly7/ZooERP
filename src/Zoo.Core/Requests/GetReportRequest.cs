namespace Zoo.Core.Requests;

public sealed record GetReportRequest(
    bool Success,
    List<string> Report,
    string? Error = null)
{
    public static GetReportRequest Ok(List<string> report) => new(true, report);
    public static GetReportRequest Fail(string error) => new(false, [], error);
}