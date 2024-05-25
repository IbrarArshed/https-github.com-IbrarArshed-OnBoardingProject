using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pearl.Infrastructure
{
    public class Startup
    {
        public Startup()
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Database.json", optional: false, reloadOnChange: true);

            this.Configuration = configBuilder.Build();
        }

        internal IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationContext(this.Configuration);
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(this.Configuration);
        }
    }
}
