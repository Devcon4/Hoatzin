using Hoatzin.Domain.Aggregates.CheckAggregate;

namespace Hoatzin.BusinessLogic.Checks;

public record CheckDto(Guid id, Guid siteId, CheckProgress status, DateTime dateCreated, DateTime? dateCompleted);