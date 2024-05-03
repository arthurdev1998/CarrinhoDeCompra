using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mongo.Services.CupomApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cupom",
                columns: new[] { "Id", "code", "discount", "min_amount" },
                values: new object[,]
                {
                    { 1, "50Off", 50.0, 100 },
                    { 2, "20Off", 20.0, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cupom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cupom",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
