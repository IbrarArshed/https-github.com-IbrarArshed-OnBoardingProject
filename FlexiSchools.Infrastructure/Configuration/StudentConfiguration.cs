using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FlexiSchools.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiSchools.Infrastructure.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("std_id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.FullName)
        .HasColumnName("std_name")
        .HasColumnType("nvarchar")
        .HasMaxLength(250);
        }
    }
}
