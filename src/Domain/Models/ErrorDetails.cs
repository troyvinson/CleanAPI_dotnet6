using System.Text.Json;

namespace Domain.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;

    public override string ToString() => JsonSerializer.Serialize(this);
}
