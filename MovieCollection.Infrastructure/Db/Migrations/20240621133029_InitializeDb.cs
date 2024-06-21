using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieCollection.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ReleaseData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImdbRate = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieSelection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSelection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieSelectionMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieSelectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSelectionMovie", x => x.Id);
                    table.UniqueConstraint("AK_MovieSelectionMovie_MovieId_MovieSelectionId", x => new { x.MovieId, x.MovieSelectionId });
                    table.ForeignKey(
                        name: "FK_MovieSelectionMovie_MovieSelection_MovieSelectionId",
                        column: x => x.MovieSelectionId,
                        principalTable: "MovieSelection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSelectionMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastAndCrews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc")),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastAndCrews", x => x.Id);
                    table.UniqueConstraint("AK_CastAndCrews_MovieId_PersonId_RoleId", x => new { x.MovieId, x.PersonId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_CastAndCrews_MovieRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "MovieRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastAndCrews_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastAndCrews_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("0fbbacd4-b09b-43f7-9b7a-32e9a715e3db"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4294), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4297), "Drama", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("16b3f007-ffb8-422d-9ff7-87f4876eba64"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4283), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4286), "Comedy", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("5c7aeeeb-c34a-4dc2-b337-24ece8eb3fad"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4317), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4320), "Science fiction", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("66b3d3b6-5f34-4ddd-a956-7131f23ba629"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4271), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4274), "Adventure", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("953ac4a5-83e5-4193-ba2e-2e8f9e0b5c82"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4257), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4261), "Action", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("f493129b-db9a-4584-af4b-a1ce8369d027"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4306), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4309), "Horror", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ImdbRate", "ModifiedBy", "ModifiedOn", "OwnerId", "ReleaseData", "Title" },
                values: new object[] { new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4475), 0m, new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4481), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" });

            migrationBuilder.InsertData(
                table: "MovieRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("26c48d3b-c5f9-465c-aba2-e98c105e95ef"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4204), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4209), "Writer", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("2c5bfc7b-34be-4519-9e79-142d3ac7a5aa"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4192), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4196), "Actress", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("2e642c97-af61-458e-81ed-86f8ade9f61c"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4161), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4170), "Director", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4179), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4184), "Actor", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "CreatedOn", "FirstName", "LastName", "ModifiedBy", "ModifiedOn", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"), null, new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4401), "Morgan", "Freeman", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4405), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") },
                    { new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"), null, new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4384), "Tim", "Robinson", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4390), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "LastName", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[] { new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(3855), null, "Admin", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(3883), "System", new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc") });

            migrationBuilder.InsertData(
                table: "CastAndCrews",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "MovieId", "OwnerId", "PersonId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("00c4cc97-bea5-43dc-af36-470b18ad8d23"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4542), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4545), new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"), new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8") },
                    { new Guid("3c73e32a-9d87-4d99-a181-a1d57093eee5"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4528), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4531), new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"), new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"), new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"), new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastAndCrews_PersonId",
                table: "CastAndCrews",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CastAndCrews_RoleId",
                table: "CastAndCrews",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelectionMovie_MovieSelectionId",
                table: "MovieSelectionMovie",
                column: "MovieSelectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastAndCrews");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "MovieSelectionMovie");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MovieRoles");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MovieSelection");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
