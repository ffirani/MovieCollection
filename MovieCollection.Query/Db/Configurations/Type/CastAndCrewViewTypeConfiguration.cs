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
    public class CastAndCrewViewTypeConfiguration : BaseEntityTypeConfiguration<CastAndCrewView>
    {
        public override void Configure(EntityTypeBuilder<CastAndCrewView> builder)
        {
            builder.ToTable("CastAndCrew");
            builder
                .HasKey(cc => new { cc.Id });

            builder
                .HasOne(cc => cc.Movie)
                .WithMany();

            builder
                .HasOne(cc => cc.Person)
                .WithMany();

            builder
                .HasOne(cc => cc.Role)
                .WithMany();
            base.Configure(builder);
        }
    }
}
