using Ardalis.Specification.EntityFrameworkCore;
using Hoatzin.Domain.Core;

namespace Hoatzin.Infrastructure;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot {
  public Repository(HoatzinDbContext dbContext) : base(dbContext) { }
}