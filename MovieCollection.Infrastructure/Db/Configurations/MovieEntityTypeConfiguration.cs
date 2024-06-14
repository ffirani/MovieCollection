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
    public class MovieEntityTypeConfiguration : BaseEntityTypeConfiguration<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> moviewConfiguration)
        {
            moviewConfiguration.ToTable("Movie");

            moviewConfiguration.HasKey(m => m.Id);

            moviewConfiguration
                .Property<string>("Title")
                .HasColumnName("Title")
                .IsRequired();

            moviewConfiguration
                .Property<DateTime>("ReleaseData")
                .HasColumnName("ReleaseData")
                .IsRequired();
            base.Configure(moviewConfiguration);
        }
    }
}
