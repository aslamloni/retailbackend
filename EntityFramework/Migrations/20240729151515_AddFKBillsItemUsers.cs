using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFKBillsItemUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Item_ItemID",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_ItemID",
                table: "Bill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bill_ItemID",
                table: "Bill",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Item_ItemID",
                table: "Bill",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
