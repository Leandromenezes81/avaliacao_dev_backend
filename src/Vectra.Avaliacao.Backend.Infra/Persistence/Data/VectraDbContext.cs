using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Infra.Persistence.Data;

public class VectraDbContext : DbContext
{
    public VectraDbContext(DbContextOptions<VectraDbContext> options) : base(options)
    {
    }

    public DbSet<Account>? Accounts { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
