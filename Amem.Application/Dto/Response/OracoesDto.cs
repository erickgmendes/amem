using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class OracoesDto
{
    [JsonPropertyName("coleta")]
    public string? Coleta { get; set; }
    [JsonPropertyName("oferendas")]
    public string? Oferendas { get; set; }
    [JsonPropertyName("comunhao")]
    public string? Comunhao { get; set; }
    [JsonPropertyName("extras")]
    public ICollection<OracaoExtraDto>? Extras { get; set; }
}