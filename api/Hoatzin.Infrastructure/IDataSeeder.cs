namespace Hoatzin.Infrastructure;

public interface IDataSeeder {
  Task SeedAsync();
}

public interface IDevOnlyDataSeeder : IDataSeeder {
  Task DevOnlySeedAsync();
}