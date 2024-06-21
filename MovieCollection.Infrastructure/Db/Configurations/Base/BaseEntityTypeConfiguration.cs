using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCollection.Domain.Models;
using MovieCollection.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollection.Infrastructure.Db.Configurations.Base
{
    public class BaseEntityTypeConfiguration<T>:IEntityTypeConfiguration<T> where T: class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<Guid>("OwnerId")
                .HasDefaultValue(new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC"))
                .IsRequired();
            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("OwnerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<Guid>("CreatedBy")
                .HasDefaultValue(new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC"))
                .IsRequired();
            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("CreatedOn")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();

            builder.Property<Guid>("ModifiedBy")
                .HasDefaultValue(new Guid("2DA93C56-0722-4772-BCB3-2CB11B694ADC"))
                .IsRequired();
            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("ModifiedBy")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("ModifiedOn")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();
        }
    }
}
