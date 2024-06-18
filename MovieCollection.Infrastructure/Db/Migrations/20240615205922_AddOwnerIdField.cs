using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollection.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f1b98d06-944d-4f30-90bd-d8f1c600c33a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "OwnerId", "ReleaseData", "Title" },
                values: new object[] { new Guid("a91d712a-97c0-4f6b-8ab6-2398a4033fdb"), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("a91d712a-97c0-4f6b-8ab6-2398a4033fdb"));

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Movie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "SYSDATETIME()");

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "ReleaseData", "Title" },
                values: new object[] { new Guid("f1b98d06-944d-4f30-90bd-d8f1c600c33a"), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3b40d6b-8bcf-4969-a000-659062f888c2"), new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" });
        }
    }
}
