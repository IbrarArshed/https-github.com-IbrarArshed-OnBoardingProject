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
    public class LectureTheatresConfiguration : IEntityTypeConfiguration<LectureTheatre>
    {
        public void Configure(EntityTypeBuilder<LectureTheatre> builder)
        {
            builder.ToTable("lectureTheatre");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("lecth_id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
        .HasColumnName("lecth_name")
        .HasColumnType("nvarchar")
        .HasMaxLength(250);

            builder.Property(x => x.Capacity)
                .HasColumnName("lecth_capacity")
                .HasColumnType("int");
        }
    }
}
