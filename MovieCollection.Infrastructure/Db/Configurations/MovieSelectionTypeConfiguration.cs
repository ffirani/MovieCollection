using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCollection.Domain.Models;
using MovieCollection.Infrastructure.Db.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Configurations
{
    public class MovieSelectionTypeConfiguration: BaseEntityTypeConfiguration<MovieSelection>
    {
        public override void Configure(EntityTypeBuilder<MovieSelection> movieSelectionConfiguration)
        {
            movieSelectionConfiguration.ToTable("MovieSelection");

            movieSelectionConfiguration.HasKey(m => m.Id);

            movieSelectionConfiguration
                .Property<string>("Name")
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();

            movieSelectionConfiguration
                .Property<string>("Description")
                .HasColumnName("Description")
                .HasMaxLength(10000)
                .IsRequired();
            
            base.Configure(movieSelectionConfiguration);
        }
    }
}
