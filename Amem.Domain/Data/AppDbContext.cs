using Amem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amem.Domain.Data;

public class AppDbContext : DbContext
{
    public DbSet<LiturgiaDiaria> LiturgiasDiarias { get; set; }
    
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}