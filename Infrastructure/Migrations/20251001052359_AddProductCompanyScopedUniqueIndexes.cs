using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCompanyScopedUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId_Name",
                table: "Products",
                columns: new[] { "CompanyId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId_SKU",
                table: "Products",
                columns: new[] { "CompanyId", "SKU" },
                unique: true,
                filter: "[SKU] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId_SKU",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");
        }
    }
}
