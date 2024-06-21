using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCollection.Domain.Models;
using MovieCollection.Infrastructure.Db.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Configurations
{
    public class MovieTypeConfiguration : BaseEntityTypeConfiguration<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> movieConfiguration)
        {
            movieConfiguration.ToTable("Movie");

            movieConfiguration.HasKey(m => m.Id);

            movieConfiguration
                .Property<string>("Title")
                .HasColumnName("Title")
                .HasMaxLength(250)
                .IsRequired();

            movieConfiguration
                .Property<DateTime?>("ReleaseData")
                .HasColumnName("ReleaseData")
                .IsRequired();
            movieConfiguration
                .Property<decimal>("ImdbRate")
                .HasColumnName("ImdbRate")
                .HasColumnType("decimal(2, 1)");

            movieConfiguration
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies);


            base.Configure(movieConfiguration);
        }
    }
}
