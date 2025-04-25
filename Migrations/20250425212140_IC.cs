using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillLinkCMS.Migrations
{
    /// <inheritdoc />
    public partial class IC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CategoryId",
                table: "Profiles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CityId",
                table: "Profiles",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Categories_CategoryId",
                table: "Profiles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Cities_CityId",
                table: "Profiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Categories_CategoryId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Cities_CityId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_CategoryId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_CityId",
                table: "Profiles");
        }
    }
}
