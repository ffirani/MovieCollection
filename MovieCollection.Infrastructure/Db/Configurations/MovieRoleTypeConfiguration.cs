using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class MovieRoleTypeConfiguration:BaseEntityTypeConfiguration<MovieRole>
    {
        public override void Configure(EntityTypeBuilder<MovieRole> movieRoleConfiguration) 
        {
            movieRoleConfiguration
                .HasKey(mr => mr.Id);
            movieRoleConfiguration
                .Property<string>("Name")
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
