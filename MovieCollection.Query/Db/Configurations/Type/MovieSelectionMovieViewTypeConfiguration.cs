using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCollection.Query.Db.Configurations.Base;
using MovieCollection.Query.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.Db.Configurations.Type
{
    public class MovieSelectionMovieViewTypeConfiguration : BaseEntityTypeConfiguration<MovieSelectionMovieView>
    {
        public override void Configure(EntityTypeBuilder<MovieSelectionMovieView> builder)
        {
            builder
                .ToTable("MovieSelectionMovie");

            builder
                .HasKey(msm => new { msm.Id });

            builder
                .HasOne(msm => msm.Movie)
                .WithMany();

            builder
                .HasOne(msm => msm.MovieSelection)
                .WithMany();
            base.Configure(builder);
        }
    }
}
