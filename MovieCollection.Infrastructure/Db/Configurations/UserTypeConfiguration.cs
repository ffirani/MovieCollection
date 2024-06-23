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
    public class UserTypeConfiguration : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("User");
            userConfiguration.HasKey(u => u.Id);

            userConfiguration
                .Property(u => u.Email)
                .IsRequired(false);

            base.Configure(userConfiguration);
        }
    }
}
