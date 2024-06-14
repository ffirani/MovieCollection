using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Configurations.Base
{
    public class BaseEntityTypeConfiguration<T>:IEntityTypeConfiguration<T> where T: class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<Guid>("CreatedBy")
            .IsRequired();
            builder.Property<DateTime>("CreatedOn")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();
            builder.Property<Guid>("ModifiedBy")
            .IsRequired();
            builder.Property<DateTime>("ModifiedOn")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();
        }
    }
}
