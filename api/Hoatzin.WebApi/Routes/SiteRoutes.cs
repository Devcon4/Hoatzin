using Hoatzin.BusinessLogic.Sites;
using MediatR;

namespace Hoatzin.WebApi.Controllers;

public class SiteRoutes : IRouteBundle {
  public void RegisterRoutes(WebApplication app) {
    var group = app.MapGroup("/api/sites").WithTags("Sites");

    group.MapGet("", GetSitesRoute);
    group.MapGet("{id}", GetSiteRoute);
  }

  public async Task<IEnumerable<SiteDto>> GetSitesRoute(IMediator mediator) => await mediator.Send(new GetSites.Query());
  public async Task<SiteDto> GetSiteRoute(IMediator mediator, Guid id) => await mediator.Send(new GetSite.Query(id));
}