namespace Amem.Domain.Entities;

public class LiturgiaDiaria
{
    public Guid Id { get; set; }
    public DateOnly Data { get; set; }
    public string? PrimeiraLeitura { get; set; }
    public string? SalmoResponsorial { get; set; }
    public string? SegundaLeitura { get; set; } // Apenas para domingos e festas
    public string? Evangelho { get; set; }
}