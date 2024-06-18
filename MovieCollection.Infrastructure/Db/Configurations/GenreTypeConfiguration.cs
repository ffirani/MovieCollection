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
    public class GenreTypeConfiguration:BaseEntityTypeConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> genreConfiguration)
        {
            genreConfiguration.Ignore("UpdatedProperties");
            genreConfiguration.ToTable("Genre");

            genreConfiguration.HasKey(m => m.Id);

            genreConfiguration
                .Property<string>("Name")
                .HasColumnName("Name")
                .HasMaxLength(150)
                .IsRequired();

            base.Configure(genreConfiguration);
        }
    }
}
