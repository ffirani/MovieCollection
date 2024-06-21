using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollection.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddUserConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CastAndCrews",
                keyColumn: "Id",
                keyValue: new Guid("00c4cc97-bea5-43dc-af36-470b18ad8d23"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4989), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "CastAndCrews",
                keyColumn: "Id",
                keyValue: new Guid("3c73e32a-9d87-4d99-a181-a1d57093eee5"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4974), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0fbbacd4-b09b-43f7-9b7a-32e9a715e3db"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4452), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("16b3f007-ffb8-422d-9ff7-87f4876eba64"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4442), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4444) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("5c7aeeeb-c34a-4dc2-b337-24ece8eb3fad"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4717), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("66b3d3b6-5f34-4ddd-a956-7131f23ba629"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4431), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("953ac4a5-83e5-4193-ba2e-2e8f9e0b5c82"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4417), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("f493129b-db9a-4584-af4b-a1ce8369d027"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4462), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4465) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4911), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("26c48d3b-c5f9-465c-aba2-e98c105e95ef"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4367), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5bfc7b-34be-4519-9e79-142d3ac7a5aa"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4355), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e642c97-af61-458e-81ed-86f8ade9f61c"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4327), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4344), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4830), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4814), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4073), new DateTime(2024, 6, 21, 17, 2, 19, 569, DateTimeKind.Local).AddTicks(4096) });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CreatedBy",
                table: "Person",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ModifiedBy",
                table: "Person",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OwnerId",
                table: "Person",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelectionMovie_CreatedBy",
                table: "MovieSelectionMovie",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelectionMovie_ModifiedBy",
                table: "MovieSelectionMovie",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelectionMovie_OwnerId",
                table: "MovieSelectionMovie",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelection_CreatedBy",
                table: "MovieSelection",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelection_ModifiedBy",
                table: "MovieSelection",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSelection_OwnerId",
                table: "MovieSelection",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CreatedBy",
                table: "Movie",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ModifiedBy",
                table: "Movie",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_OwnerId",
                table: "Movie",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_CreatedBy",
                table: "Genre",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ModifiedBy",
                table: "Genre",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_OwnerId",
                table: "Genre",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CastAndCrews_CreatedBy",
                table: "CastAndCrews",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CastAndCrews_ModifiedBy",
                table: "CastAndCrews",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CastAndCrews_OwnerId",
                table: "CastAndCrews",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastAndCrews_User_CreatedBy",
                table: "CastAndCrews",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CastAndCrews_User_ModifiedBy",
                table: "CastAndCrews",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CastAndCrews_User_OwnerId",
                table: "CastAndCrews",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_User_CreatedBy",
                table: "Genre",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_User_ModifiedBy",
                table: "Genre",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_User_OwnerId",
                table: "Genre",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_User_CreatedBy",
                table: "Movie",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_User_ModifiedBy",
                table: "Movie",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_User_OwnerId",
                table: "Movie",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelection_User_CreatedBy",
                table: "MovieSelection",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelection_User_ModifiedBy",
                table: "MovieSelection",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelection_User_OwnerId",
                table: "MovieSelection",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelectionMovie_User_CreatedBy",
                table: "MovieSelectionMovie",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelectionMovie_User_ModifiedBy",
                table: "MovieSelectionMovie",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSelectionMovie_User_OwnerId",
                table: "MovieSelectionMovie",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_User_CreatedBy",
                table: "Person",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_User_ModifiedBy",
                table: "Person",
                column: "ModifiedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_User_OwnerId",
                table: "Person",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastAndCrews_User_CreatedBy",
                table: "CastAndCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_CastAndCrews_User_ModifiedBy",
                table: "CastAndCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_CastAndCrews_User_OwnerId",
                table: "CastAndCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_User_CreatedBy",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_User_ModifiedBy",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_User_OwnerId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_User_CreatedBy",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_User_ModifiedBy",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_User_OwnerId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelection_User_CreatedBy",
                table: "MovieSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelection_User_ModifiedBy",
                table: "MovieSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelection_User_OwnerId",
                table: "MovieSelection");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelectionMovie_User_CreatedBy",
                table: "MovieSelectionMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelectionMovie_User_ModifiedBy",
                table: "MovieSelectionMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSelectionMovie_User_OwnerId",
                table: "MovieSelectionMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_User_CreatedBy",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_User_ModifiedBy",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_User_OwnerId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CreatedBy",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ModifiedBy",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_OwnerId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelectionMovie_CreatedBy",
                table: "MovieSelectionMovie");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelectionMovie_ModifiedBy",
                table: "MovieSelectionMovie");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelectionMovie_OwnerId",
                table: "MovieSelectionMovie");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelection_CreatedBy",
                table: "MovieSelection");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelection_ModifiedBy",
                table: "MovieSelection");

            migrationBuilder.DropIndex(
                name: "IX_MovieSelection_OwnerId",
                table: "MovieSelection");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CreatedBy",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ModifiedBy",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_OwnerId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Genre_CreatedBy",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_ModifiedBy",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_OwnerId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_CastAndCrews_CreatedBy",
                table: "CastAndCrews");

            migrationBuilder.DropIndex(
                name: "IX_CastAndCrews_ModifiedBy",
                table: "CastAndCrews");

            migrationBuilder.DropIndex(
                name: "IX_CastAndCrews_OwnerId",
                table: "CastAndCrews");

            migrationBuilder.UpdateData(
                table: "CastAndCrews",
                keyColumn: "Id",
                keyValue: new Guid("00c4cc97-bea5-43dc-af36-470b18ad8d23"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4542), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "CastAndCrews",
                keyColumn: "Id",
                keyValue: new Guid("3c73e32a-9d87-4d99-a181-a1d57093eee5"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4528), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0fbbacd4-b09b-43f7-9b7a-32e9a715e3db"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4294), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4297) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("16b3f007-ffb8-422d-9ff7-87f4876eba64"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4283), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("5c7aeeeb-c34a-4dc2-b337-24ece8eb3fad"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("66b3d3b6-5f34-4ddd-a956-7131f23ba629"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4271), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4274) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("953ac4a5-83e5-4193-ba2e-2e8f9e0b5c82"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4257), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("f493129b-db9a-4584-af4b-a1ce8369d027"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4306), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1a84b59c-6d47-467f-9863-7ba645b45559"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4475), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4481) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("26c48d3b-c5f9-465c-aba2-e98c105e95ef"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4204), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5bfc7b-34be-4519-9e79-142d3ac7a5aa"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4192), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e642c97-af61-458e-81ed-86f8ade9f61c"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4161), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "MovieRoles",
                keyColumn: "Id",
                keyValue: new Guid("dcfe1fce-7859-4de0-8432-08ac615a45a8"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4179), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("6cf82d0c-8765-480c-95dd-f32edde21b74"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4401), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4405) });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("c507aabe-6d4b-41be-a7c4-c9dbcad7cafe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4384), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2da93c56-0722-4772-bcb3-2cb11b694adc"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(3855), new DateTime(2024, 6, 21, 17, 0, 29, 130, DateTimeKind.Local).AddTicks(3883) });
        }
    }
}
