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
    public class LecturesConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("lecture");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("lec_id")
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => x.SubjectId)
              .HasColumnName("sub_id")
              .HasColumnType("int");

            builder.Property(x => x.LectureTheatreId)
                .HasColumnName("lect_id")
                .HasColumnType("int");

            builder.Property(x => x.DayOfWeek)
                .HasColumnName("dow")
                .HasColumnType("int");

            builder.Property(x => x.StartTime)
                .HasColumnName("start_time")
                .HasColumnType("datetime(7)");

            builder.Property(x => x.DurationInMinutes)
                .HasColumnName("dim")
                .HasColumnType("int");

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Lectures)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.LectureTheatre)
               .WithMany(x => x.Lectures)
               .HasForeignKey(x => x.LectureTheatreId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
