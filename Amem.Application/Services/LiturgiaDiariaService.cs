using Amem.Domain.Entities;
using Amem.Domain.Repositories;

namespace Amem.Application.Services;

public class LiturgiaDiariaService : ILiturgiaDiariaService
{
    private readonly ILiturgiaDiariaRepository _liturgiaDiariaRepository;

    public LiturgiaDiariaService(ILiturgiaDiariaRepository liturgiaDiariaRepository)
    {
        _liturgiaDiariaRepository = liturgiaDiariaRepository;
    }

    public async Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date)
    {
        return await _liturgiaDiariaRepository.GetLiturgiaDiariaByDateAsync(date);
    }
}

public interface ILiturgiaDiariaService
{
    Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date);
}