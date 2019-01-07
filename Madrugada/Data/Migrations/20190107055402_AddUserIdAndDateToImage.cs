using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Madrugada.Data.Migrations
{
    public partial class AddUserIdAndDateToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");
        }
    }
}
