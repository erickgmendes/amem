using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class LeituraExtraDto
{
    [JsonPropertyName("tipo")]
    public string? Tipo { get; set; }
    [JsonPropertyName("referencia")]
    public string? Referencia { get; set; }
    [JsonPropertyName("titulo")]
    public string? Titulo { get; set; }
    [JsonPropertyName("texto")]
    public string? Texto { get; set; }
}
