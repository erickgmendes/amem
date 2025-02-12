using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class OracaoExtraDto
{
    [JsonPropertyName("titulo")]
    public string? Titulo { get; set; }
    [JsonPropertyName("texto")]
    public string? Texto { get; set; }
}