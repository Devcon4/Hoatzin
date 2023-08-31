using Ardalis.Specification;
using Hoatzin.Domain.Aggregates.CheckAggregate;

namespace Hoatzin.BusinessLogic.Checks;

public class GetChecksSpec : Specification<Check> {
  public GetChecksSpec(int count) {
    Query
      .OrderByDescending(check => check.DateCreated)
      .Take(count);
  }
}