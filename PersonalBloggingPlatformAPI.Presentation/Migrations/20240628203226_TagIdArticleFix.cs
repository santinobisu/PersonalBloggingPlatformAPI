using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBloggingPlatformAPI.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class TagIdArticleFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Tags_TagId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TagId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TagId",
                table: "Articles",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Tags_TagId",
                table: "Articles",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }
    }
}
