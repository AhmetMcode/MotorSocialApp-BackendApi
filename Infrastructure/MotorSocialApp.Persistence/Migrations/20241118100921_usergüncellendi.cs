using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorSocialApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class usergüncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 10, 9, 21, 435, DateTimeKind.Utc).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 10, 9, 21, 435, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 10, 9, 21, 435, DateTimeKind.Utc).AddTicks(8633));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 8, 59, 48, 139, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 8, 59, 48, 139, DateTimeKind.Utc).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 8, 59, 48, 139, DateTimeKind.Utc).AddTicks(3989));
        }
    }
}
