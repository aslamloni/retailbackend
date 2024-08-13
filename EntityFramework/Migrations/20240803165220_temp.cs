using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CGSTPrice",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "SGSTPrice",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BillID",
                table: "Item",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CGSTPrice",
                table: "Item",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Item",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Item",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SGSTPrice",
                table: "Item",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Item",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
