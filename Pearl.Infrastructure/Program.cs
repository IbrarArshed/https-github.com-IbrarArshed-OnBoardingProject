using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pearl.Infrastructure.Database;

namespace Pearl.Infrastructure
{
    public class Program : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);

            SetupDatabaseMigrationAndSeed(services);
        }

        public ApplicationContext CreateDbContext(string[] args)
        {
            var startup = new Startup();

            DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(
                    startup.Configuration.GetConnectionString("dbConnection"),
                    x =>
                    {
                        x.MigrationsAssembly(typeof(DbContextExtensions).Assembly.GetName().Name);
                    });

            return new ApplicationContext(optionsBuilder.Options);
        }

        private static void SetupDatabaseMigrationAndSeed(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IServiceScope scope = serviceProvider.CreateScope();

            // create and seed data
            //services.SeedPearlPOSData(scope);
        }
    }
}
