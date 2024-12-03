using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbPostCategoryToAddPostCategoryFormFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCategories2");

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PostCategories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "IconPath",
                table: "PostCategories",
                newName: "PhotoPath");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedDate",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedDate",
                table: "PostCategories");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "PostCategories",
                newName: "IconPath");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "PostCategories",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "PostCategories2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories2", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "Id", "CreatedDate", "IconPath", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 2, 12, 9, 13, 809, DateTimeKind.Utc).AddTicks(5111), "assets/svg/volleyball.svg", false, "Voleybol" },
                    { 2, new DateTime(2024, 12, 2, 12, 9, 13, 809, DateTimeKind.Utc).AddTicks(5113), "assets/svg/paw.svg", false, "Patiler" },
                    { 3, new DateTime(2024, 12, 2, 12, 9, 13, 809, DateTimeKind.Utc).AddTicks(5114), "assets/svg/megaphone.svg", false, "Duyuru" }
                });
        }
    }
}
