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
    public class UserViewTypeConfiguration : BaseEntityTypeConfiguration<UserView>
    {
        public override void Configure(EntityTypeBuilder<UserView> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Email)
                .IsRequired(false);

            base.Configure(builder);
        }
    }
}
