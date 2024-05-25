using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FlexiSchools.Core.Model;
using FlexiSchools.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Infrastructure
{
    public static class DbContextExtensions
    {
        public static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("dbConnection"),
                    x =>
                    {
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName);
                        x.MigrationsAssembly(typeof(DbContextExtensions).Assembly.GetName().Name);
                    });
            });
        }

        //public static void SeedPearlPOSData(this IServiceCollection services, IServiceScope serviceScope)
        //{
        //    if (services is null)
        //    {
        //        throw new System.ArgumentNullException(nameof(services));
        //    }

        //    ApplicationContext context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

        //    // migrate database
        //    context.Database.Migrate();

        //    System.Reflection.Assembly assembly = typeof(DbContextExtensions).Assembly;
        //    string[] files = assembly.GetManifestResourceNames();

        //    SeedingEntry[] executedSeedings = context.SeedingEntries.ToArray();
        //    string filePrefix = $"{assembly.GetName().Name}.Seedings.Sql.";
        //    foreach (var file in files.Where(f => f.StartsWith(filePrefix) && f.EndsWith(".sql"))
        //                              .Select(f => new
        //                              {
        //                                  PhysicalFile = f,
        //                                  LogicalFile = f.Replace(filePrefix, string.Empty),
        //                              })
        //                              .OrderBy(f => f.LogicalFile))
        //    {
        //        if (executedSeedings.Any(e => e.Name == file.LogicalFile))
        //        {
        //            continue;
        //        }

        //        string command = string.Empty;
        //        using (Stream stream = assembly.GetManifestResourceStream(file.PhysicalFile))
        //        {
        //            StreamReader reader = new(stream);

        //            command = reader.ReadToEnd();
        //        }

        //        if (string.IsNullOrWhiteSpace(command))
        //        {
        //            continue;
        //        }

        //        IDbContextTransaction transaction = context.Database.BeginTransaction();

        //        try
        //        {
        //            context.Database.ExecuteSqlRaw(command);
        //            context.SeedingEntries.Add(new SeedingEntry() { Name = file.LogicalFile });
        //            context.SaveChanges();
        //            transaction.Commit();
        //        }
        //        catch
        //        {
        //            transaction.Rollback();
        //            throw;
        //        }
        //    }
        //}
    }
}
