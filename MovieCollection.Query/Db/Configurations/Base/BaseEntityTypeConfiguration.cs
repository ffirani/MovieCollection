using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCollection.Query.View;
using MovieCollection.Query.View.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Query.Db.Configurations.Base
{
    public class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseView
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
            builder.Property("OwnerId")
                .HasColumnName("OwnerId");
            builder
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p=>p.OwnerId);
            
            builder.Property(p => p.CreatedBy)
                .HasColumnName("CreatedBy");
            builder
                .HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedBy);
            
            builder.Property<DateTime>("CreatedOn");

            builder.Property(p => p.ModifiedBy)
                .HasColumnName("ModifiedBy");
            builder
                .HasOne(p => p.ModifiedByUser)
                .WithMany()
                .HasForeignKey(p => p.ModifiedBy);
            
            builder.Property<DateTime>("ModifiedOn");

            if (typeof(T) != typeof(UserView))
            {
                builder.Navigation(p => p.Owner).AutoInclude();
                builder.Navigation(p => p.CreatedByUser).AutoInclude();
                builder.Navigation(p => p.ModifiedByUser).AutoInclude();
            }

        }
    }
}
