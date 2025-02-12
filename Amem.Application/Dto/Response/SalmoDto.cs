using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class SalmoDto
{
    [JsonPropertyName("referencia")]
    public string? Referencia { get; set; }
    [JsonPropertyName("refrao")]
    public string? Refrao { get; set; }
    [JsonPropertyName("texto")]
    public string? Texto { get; set; }
}