namespace Amem.Application.Services;

public class ExternalApiService : IExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDataFromExternalApiAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            // Lança uma exceção se o status code não for bem-sucedido
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            // Trate a exceção conforme necessário
            Console.WriteLine($"Erro ao acessar a API externa: {ex.Message}");
            throw;
        }
    }
}

public interface IExternalApiService
{
    Task<string> GetDataFromExternalApiAsync(string url);
}
