using Ardalis.GuardClauses;
using Hoatzin.Domain.Core;

namespace Hoatzin.Domain.Aggregates.CheckAggregate;

public class CheckProgress : ValueObject {
  public string Value { get; set; }

  public const string Started = "Started";
  public const string Completed = "Completed";
  public const string Failed = "Failed";

  public CheckProgress(string value) {
    Value = Guard.Against.InvalidInput(value, nameof(value), v => v == Started || v == Completed || v == Failed);
  }

  protected override IEnumerable<IComparable> GetEqualityComponents() {
    yield return Value;
  }
}