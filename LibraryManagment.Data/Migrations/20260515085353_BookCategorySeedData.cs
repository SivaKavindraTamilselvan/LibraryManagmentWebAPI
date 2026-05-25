using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookCategorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookCategoryId", "BookCategoryName" },
                values: new object[,]
                {
                    { 1, "Science" },
                    { 2, "Fiction" },
                    { 3, "Non Fiction" },
                    { 4, "Horror" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "BookCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "BookCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "BookCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "BookCategoryId",
                keyValue: 4);
        }
    }
}
