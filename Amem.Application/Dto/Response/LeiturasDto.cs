using System.Text.Json.Serialization;

namespace Amem.Application.Dto.Response;

public class LeiturasDto
{
    [JsonPropertyName("primeiraLeitura")]
    public ICollection<LeituraDto>? PrimeiraLeitura { get; set; }
    [JsonPropertyName("segundaLeitura")]
    public ICollection<LeituraDto>? SegundaLeitura { get; set; }
    [JsonPropertyName("evangelho")]
    public ICollection<LeituraDto>? Evangelho { get; set; }
    [JsonPropertyName("salmo")]
    public ICollection<SalmoDto>? Salmo { get; set; }
    [JsonPropertyName("extras")]
    public ICollection<LeituraExtraDto>? Extras { get; set; }
}