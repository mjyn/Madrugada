using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Madrugada.Data.Migrations
{
    public partial class AddViewThumbCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverImageId",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Locations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasThumbnail",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThumbUrl",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CoverImageId",
                table: "Locations",
                column: "CoverImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Images_CoverImageId",
                table: "Locations",
                column: "CoverImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Images_CoverImageId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CoverImageId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CoverImageId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HasThumbnail",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ThumbUrl",
                table: "Images");
        }
    }
}
