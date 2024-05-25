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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subjects");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("sub_id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
        .HasColumnName("sub_name")
        .HasColumnType("nvarchar")
        .HasMaxLength(250);
        }
    }
}
