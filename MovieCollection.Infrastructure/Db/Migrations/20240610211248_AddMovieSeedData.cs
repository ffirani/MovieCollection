using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollection.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "ReleaseData", "Title" },
                values: new object[] { new Guid("f1b98d06-944d-4f30-90bd-d8f1c600c33a"), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f1b98d06-944d-4f30-90bd-d8f1c600c33a"));
        }
    }
}
