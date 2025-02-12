using System.Text.Json;
using System.Text.Json.Nodes;
using Amem.Application.Dto.JSonLeituras;
using Amem.Domain.Entities;
using Amem.Domain.Repositories;
using Amem.Infra.Configurations;
using Amem.Infra.Util;
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

    public async Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date)
    {
        var formattedDate = date.ToString("yyyy-MM-dd");
        var uri = new Uri($"{_externalApiSettings.ApiUrl}/{formattedDate}");
        var json = await _externalApiService.GetDataFromExternalApiAsync(uri.ToString());

        // Remove tags HTML e caracteres especiais
        var formattedJson = json.RemoveHtmlTags().RemoveCaracteres();

        // Configurações do JsonSerializer
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Ignora maiúsculas/minúsculas
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Mapeia nomes em camelCase
        };

        try
        {
            // Desserializa o JSON
            var jsonResponse = JsonSerializer.Deserialize<JsonResponse>(formattedJson, options);
            var jsonObj = jsonResponse?.Content;

            if (jsonObj != null)
            {
                var leituras = jsonObj.Body.SeparaLeituras();
                
                // Remove tags HTML e caracteres especiais (se necessário)
                //var formattedJson = json.RemoveHtmlTags().RemoveCaracteres();
                // Aqui você pode processar as leituras, se necessário
                // var leituras = jsonObj.SeparaLeituras();
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
        }

        // Retorna o objeto LiturgiaDiaria (ajuste conforme sua lógica)
        return await _liturgiaDiariaRepository.GetLiturgiaDiariaByDateAsync(date);
    }
}

public interface ILiturgiaDiariaService
{
    Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date);
}