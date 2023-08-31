using Ardalis.Specification;
using Hoatzin.Domain.Aggregates.CheckAggregate;

namespace Hoatzin.BusinessLogic.Checks;

public class GetStartedChecksSpec : Specification<Check> {
  public GetStartedChecksSpec(DateTime olderThan) {
    Query
      .Where(check => check.Status.Value == CheckProgress.Started && check.DateCreated >= olderThan)
      .OrderByDescending(check => check.DateCreated);
  }
}