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
    public class PersonTypeConfiguration : BaseEntityTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> personConfiguration)
        {
            personConfiguration.ToTable("Person");
            personConfiguration.Ignore("UpdatedProperties");
            personConfiguration.HasKey(m => m.Id);

            personConfiguration
                .Property<string>("FirstName")
                .HasColumnName("FirstName")
                .HasMaxLength(100)
                .IsRequired();

            personConfiguration
                .Property<string>("LastName")
                .HasColumnName("LastName")
                .HasMaxLength(200)
                .IsRequired();

            personConfiguration
                .Property<DateTime?>("BirthDate")
                .HasColumnName("BirthDate");

            base.Configure(personConfiguration);
        }
    }
}
