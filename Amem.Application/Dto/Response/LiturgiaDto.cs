using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class LiturgiaDto
{
    [JsonPropertyName("data")]
    public string? Data { get; set; }
    [JsonPropertyName("liturgia")]
    public string? Liturgia { get; set; }
    [JsonPropertyName("cor")]
    public string? Cor { get; set; }
    [JsonPropertyName("oracoes")]
    public OracoesDto? Oracoes { get; set; }
    [JsonPropertyName("leituras")]
    public LeiturasDto? Leituras { get; set; }
}