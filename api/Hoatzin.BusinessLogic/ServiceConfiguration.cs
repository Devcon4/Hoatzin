using System.Reflection;
using Hoatzin.BusinessLogic.Sites;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace Hoatzin.BusinessLogic;

public static class ServiceConfiguration {
  public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration) {
    services.AddSingleton<IHoatzinJobQueue<SiteJobConfig>, HoatzinJobQueue<SiteJobConfig>>();
    services.AddHostedService<HoatzinJob<SiteJobConfig>>();
    services.AddHostedService<SiteJob>();
    services.AddHttpClient();

    services.Configure<SettingOptions>(configuration.GetSection("Hoatzin:Settings"));

    services.AddMediatR(config => {
      config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    });

    return services;
  }
}