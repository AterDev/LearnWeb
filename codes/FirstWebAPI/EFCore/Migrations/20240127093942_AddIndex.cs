using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Tags",
                table: "Blogs",
                column: "Tags");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title",
                table: "Blogs",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Tags",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Title",
                table: "Blogs");
        }
    }
}
