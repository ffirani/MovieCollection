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
    public class MovieRoleViewTypeConfiguration : BaseEntityTypeConfiguration<MovieRoleView>
    {
        public override void Configure(EntityTypeBuilder<MovieRoleView> builder)
        {
            builder.ToTable("MovieRole");
            builder
                .HasKey(mr => mr.Id);
            builder
                .Property<string>("Name")
                .HasColumnName("Name");
            base.Configure(builder);
        }
    }
}
