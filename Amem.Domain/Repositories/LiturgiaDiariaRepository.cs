using Amem.Domain.Entities;
using Amem.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Amem.Domain.Repositories;

public class LiturgiaDiariaRepository : ILiturgiaDiariaRepository
{
    private readonly AppDbContext _context;

    public LiturgiaDiariaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date)
    {
        return await _context.LiturgiasDiarias.FirstOrDefaultAsync(x=>x.Data.Equals(date));
    }
}

public interface ILiturgiaDiariaRepository
{
    Task<LiturgiaDiaria> GetLiturgiaDiariaByDateAsync(DateOnly date);
}