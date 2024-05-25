using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using FlexiSchools.Core.Entities;
using FlexiSchools.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Infrastructure.Database
{
    public interface IApplicationContext : IDisposable
    {
        DatabaseFacade Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbSet<T> Set<T>()
            where T : BaseEntity;

        EntityEntry Entry(object entity);

        public DbSet<SeedingEntry> SeedingEntries { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureTheatre> LectureTheatres { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
