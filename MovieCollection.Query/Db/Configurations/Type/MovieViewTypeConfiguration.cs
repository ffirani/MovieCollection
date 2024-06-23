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
    public class MovieViewTypeConfiguration : BaseEntityTypeConfiguration<MovieView>
    {
        public override void Configure(EntityTypeBuilder<MovieView> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(m => m.Id);

            builder
                .Property<string>("Title")
                .HasColumnName("Title");

            builder
                .Property<DateTime?>("ReleaseData")
                .HasColumnName("ReleaseData");
            builder
                .Property<decimal>("ImdbRate")
                .HasColumnName("ImdbRate")
                .HasColumnType("decimal(2, 1)");

            base.Configure(builder);
        }
    }
}
