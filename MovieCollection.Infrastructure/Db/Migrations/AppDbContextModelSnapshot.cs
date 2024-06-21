﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCollection.Infrastructure.Db;

#nullable disable

namespace MovieCollection.Infrastructure.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.CastAndCrew", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("MovieId", "PersonId", "RoleId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("CastAndCrews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c73e32a-9d87-4d99-a181-a1d57093eee5"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4974),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4978),
                            MovieId = new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"),
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            PersonId = new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"),
                            RoleId = new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8")
                        },
                        new
                        {
                            Id = new Guid("00c4cc97-bea5-43dc-af36-470b18ad8d23"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4989),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4992),
                            MovieId = new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"),
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            PersonId = new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"),
                            RoleId = new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8")
                        });
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.ToTable("Genre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("953ac4a5-83e5-4193-ba2e-2e8f9e0b5c82"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4417),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4421),
                            Name = "Action",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("66b3d3b6-5f34-4ddd-a956-7131f23ba629"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4431),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4434),
                            Name = "Adventure",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("16b3f007-ffb8-422d-9ff7-87f4876eba64"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4442),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4444),
                            Name = "Comedy",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("0fbbacd4-b09b-43f7-9b7a-32e9a715e3db"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4452),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4455),
                            Name = "Drama",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("f493129b-db9a-4584-af4b-a1ce8369d027"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4462),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4465),
                            Name = "Horror",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("5c7aeeeb-c34a-4dc2-b337-24ece8eb3fad"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4717),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4723),
                            Name = "Science fiction",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        });
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<decimal>("ImdbRate")
                        .HasColumnType("decimal(2, 1)")
                        .HasColumnName("ImdbRate");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime?>("ReleaseData")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("ReleaseData");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.ToTable("Movie", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4911),
                            ImdbRate = 0m,
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4917),
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ReleaseData = new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Shawshank Redemption"
                        });
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.MovieRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MovieRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2e642c97-af61-458e-81ed-86f8ade9f61c"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4327),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4335),
                            Name = "Director",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4344),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4348),
                            Name = "Actor",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("2c5bfc7b-34be-4519-9e79-142d3ac7a5aa"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4355),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4359),
                            Name = "Actress",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("26c48d3b-c5f9-465c-aba2-e98c105e95ef"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4367),
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4371),
                            Name = "Writer",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        });
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.MovieSelection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.ToTable("MovieSelection", (string)null);
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.MovieSelectionMovie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieSelectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.HasKey("Id");

                    b.HasAlternateKey("MovieId", "MovieSelectionId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("MovieSelectionId");

                    b.HasIndex("OwnerId");

                    b.ToTable("MovieSelectionMovie", (string)null);
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<Guid>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("LastName");

                    b.Property<Guid>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"));

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4814),
                            FirstName = "Tim",
                            LastName = "Robinson",
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4821),
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        },
                        new
                        {
                            Id = new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4830),
                            FirstName = "Morgan",
                            LastName = "Freeman",
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4835),
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        });
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            CreatedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4073),
                            LastName = "Admin",
                            ModifiedBy = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                            ModifiedOn = new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4096),
                            Name = "System",
                            OwnerId = new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.CastAndCrew", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.Movie", "Movie")
                        .WithMany("CastAndCrews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.Person", "Person")
                        .WithMany("CastAndCrews")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.MovieRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Genre", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Movie", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.MovieSelection", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.MovieSelectionMovie", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.MovieSelection", "MovieSelection")
                        .WithMany()
                        .HasForeignKey("MovieSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("MovieSelection");
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Person", b =>
                {
                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieCollection.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Movie", b =>
                {
                    b.Navigation("CastAndCrews");
                });

            modelBuilder.Entity("MovieCollection.Domain.Models.Person", b =>
                {
                    b.Navigation("CastAndCrews");
                });
#pragma warning restore 612, 618
        }
    }
}
