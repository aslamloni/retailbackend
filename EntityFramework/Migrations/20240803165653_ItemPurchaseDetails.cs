using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ItemPurchaseDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemPurchaseDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CGST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SGST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SGSTPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CGSTPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchaseDetails", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPurchaseDetails");
        }
    }
}
