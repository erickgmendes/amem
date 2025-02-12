using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class LeiturasDto
{
    [JsonPropertyName("primeiraLeitura")]
    public List<LeituraDto>? PrimeiraLeitura { get; set; }
    [JsonPropertyName("segundaLeitura")]
    public List<LeituraDto>? SegundaLeitura { get; set; }
    [JsonPropertyName("evangelho")]
    public List<LeituraDto>? Evangelho { get; set; }
    [JsonPropertyName("salmo")]
    public List<SalmoDto>? Salmo { get; set; }
    [JsonPropertyName("extras")]
    public List<LeituraExtraDto>? Extras { get; set; }
}