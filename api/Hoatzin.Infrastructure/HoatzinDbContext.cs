using System.Reflection;
using Hoatzin.Domain.Aggregates.CheckAggregate;
using Hoatzin.Domain.Aggregates.SiteAggregate;
using Microsoft.EntityFrameworkCore;

namespace Hoatzin.Infrastructure;

public class HoatzinDbContext : DbContext {
  public DbSet<Site> Sites => Set<Site>();
  public DbSet<Check> Checks => Set<Check>();

  public HoatzinDbContext(DbContextOptions<HoatzinDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(modelBuilder);
  }
}