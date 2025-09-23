using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerCompanyScopedUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "LegalName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId_DisplayName",
                table: "Customers",
                columns: new[] { "CompanyId", "DisplayName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId_Email",
                table: "Customers",
                columns: new[] { "CompanyId", "Email" },
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId_LegalName",
                table: "Customers",
                columns: new[] { "CompanyId", "LegalName" },
                unique: true,
                filter: "[LegalName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId_DisplayName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId_Email",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId_LegalName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LegalName",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");
        }
    }
}
