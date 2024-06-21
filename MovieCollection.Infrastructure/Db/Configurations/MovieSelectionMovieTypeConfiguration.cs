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
    public class MovieSelectionMovieTypeConfiguration:BaseEntityTypeConfiguration<MovieSelectionMovie>
    {
        public override void Configure(EntityTypeBuilder<MovieSelectionMovie> movieSelectionMovieConfiguration)
        {
            movieSelectionMovieConfiguration
                .ToTable("MovieSelectionMovie");

            movieSelectionMovieConfiguration
                .HasKey(msm => new {msm.Id });

            movieSelectionMovieConfiguration
                .HasAlternateKey(msm => new { msm.MovieId, msm.MovieSelectionId });

            movieSelectionMovieConfiguration
                .HasOne(msm => msm.Movie)
                .WithMany()
                .HasForeignKey(msm => msm.MovieId);

            movieSelectionMovieConfiguration
                .HasOne(msm => msm.MovieSelection)
                .WithMany()
                .HasForeignKey(msm => msm.MovieSelectionId);

            base.Configure(movieSelectionMovieConfiguration);
        }
    }
}
