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
    public class CastAndCrewTypeConfiguration:BaseEntityTypeConfiguration<CastAndCrew>
    {
        public override void Configure(EntityTypeBuilder<CastAndCrew> castAndCrewConfiguration)
        {
            castAndCrewConfiguration
                .HasKey(cc => new { cc.Id });

            castAndCrewConfiguration
                .HasAlternateKey(cc => new { cc.MovieId, cc.PersonId, cc.RoleId });

            castAndCrewConfiguration
                .HasOne(cc => cc.Movie)
                .WithMany(m => m.CastAndCrews)
                .HasForeignKey(cc => cc.MovieId);

            castAndCrewConfiguration
                .HasOne(cc => cc.Person)
                .WithMany(p => p.CastAndCrews)
                .HasForeignKey(cc => cc.PersonId);

            castAndCrewConfiguration
                .HasOne(cc => cc.Role)
                .WithMany()
                .HasForeignKey(cc => cc.RoleId);

            base.Configure(castAndCrewConfiguration);
        }
    }
}
