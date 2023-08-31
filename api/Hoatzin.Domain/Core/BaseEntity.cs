namespace Hoatzin.Domain.Core;

public abstract class BaseEntity<TId> {
  public TId Id { get; set; } = default !;
}