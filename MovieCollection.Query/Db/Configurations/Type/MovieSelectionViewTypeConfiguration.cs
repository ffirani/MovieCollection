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
    public class MovieSelectionViewTypeConfiguration : BaseEntityTypeConfiguration<MovieSelectionView>
    {
        public override void Configure(EntityTypeBuilder<MovieSelectionView> builder)
        {
            builder.ToTable("MovieSelection");

            builder.HasKey(m => m.Id);

            builder
                .Property<string>("Name")
                .HasColumnName("Name");

            builder
                .Property<string>("Description")
                .HasColumnName("Description");
            base.Configure(builder);
        }
    }
}
