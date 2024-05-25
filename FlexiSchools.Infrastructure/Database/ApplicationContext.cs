using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using FlexiSchools.Core.Entities;
using FlexiSchools.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Infrastructure.Database
{
    public class ApplicationContext : IdentityDbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {

        }
        public DbSet<SeedingEntry> SeedingEntries { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        DatabaseFacade IApplicationContext.Database => this.Database;

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public new DbSet<T> Set<T>()
            where T : BaseEntity
        {
            return base.Set<T>();
        }

        public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
