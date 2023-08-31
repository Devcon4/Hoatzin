using Ardalis.GuardClauses;
using Hoatzin.Domain.Aggregates.SiteAggregate;
using Hoatzin.Domain.Core;
using MediatR;

namespace Hoatzin.BusinessLogic.Sites;

public class GetSite {
  public record Query(Guid Id) : IRequest<SiteDto>;

  public class Handler : IRequestHandler<Query, SiteDto> {
    private readonly IRepository<Site> _repository;

    public Handler(IRepository<Site> repository) {
      _repository = repository;
    }

    public async Task<SiteDto> Handle(Query request, CancellationToken cancellationToken) {
      var site = await _repository.GetByIdAsync(request.Id, cancellationToken);
      if (site == null) {
        throw new NotFoundException(nameof(Site), request.Id.ToString());
      }

      return new SiteDto(site.Id, site.Name, site.Ordinal);
    }

  }
}