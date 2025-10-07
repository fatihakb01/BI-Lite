using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionLineItemPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionLineItems",
                table: "TransactionLineItems");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TransactionLineItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionLineItems",
                table: "TransactionLineItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLineItems_TransactionId_ProductId",
                table: "TransactionLineItems",
                columns: new[] { "TransactionId", "ProductId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionLineItems",
                table: "TransactionLineItems");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLineItems_TransactionId_ProductId",
                table: "TransactionLineItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TransactionLineItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionLineItems",
                table: "TransactionLineItems",
                columns: new[] { "TransactionId", "ProductId" });
        }
    }
}
