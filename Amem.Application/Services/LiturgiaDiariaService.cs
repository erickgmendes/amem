using System.Text.Json;
using Amem.Application.Dto.Response;
using Amem.Domain.Repositories;
using Amem.Infra.Configurations;
using Microsoft.Extensions.Options;

namespace Amem.Application.Services;

public class LiturgiaDiariaService : ILiturgiaDiariaService
{
    private readonly ILiturgiaDiariaRepository _liturgiaDiariaRepository;
    private readonly ExternalApiSettings _externalApiSettings;
    private readonly IExternalApiService _externalApiService;

    public LiturgiaDiariaService(
        ILiturgiaDiariaRepository liturgiaDiariaRepository,
        IOptions<ExternalApiSettings> externalApiSettings,
        IExternalApiService externalApiService)
    {
        _liturgiaDiariaRepository = liturgiaDiariaRepository;
        _externalApiSettings = externalApiSettings.Value;
        _externalApiService = externalApiService;
    }

    public async Task<LiturgiaDto> GetLiturgiaDiariaByDateAsync(DateOnly date)
    {
        var dia = date.ToString("dd");
        var mes = date.ToString("MM");
        var ano = date.ToString("yyyy");
        var uri = new Uri($"{_externalApiSettings.ApiUrl}dia={dia}&mes={mes}&ano={ano}");
        var json = await _externalApiService.GetDataFromExternalApiAsync(uri.ToString());

        try
        {
            return JsonSerializer.Deserialize<LiturgiaDto>(json)!;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
            return null;
        }
    }
}

public interface ILiturgiaDiariaService
{
    Task<LiturgiaDto> GetLiturgiaDiariaByDateAsync(DateOnly date);
}