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
    public class PersonViewTypeConfiguration : BaseEntityTypeConfiguration<PersonView>
    {
        public override void Configure(EntityTypeBuilder<PersonView> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(m => m.Id);

            builder
                .Property<string>("FirstName")
                .HasColumnName("FirstName");

            builder
                .Property<string>("LastName")
                .HasColumnName("LastName");

            builder
                .Property<DateTime?>("BirthDate")
                .HasColumnName("BirthDate");
            base.Configure(builder);
        }
    }
}
