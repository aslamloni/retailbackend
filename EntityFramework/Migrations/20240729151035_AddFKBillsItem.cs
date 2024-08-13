using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFKBillsItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Item_ItemId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Users_UserIdId",
                table: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Bill_UserIdId",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bill",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_ItemId",
                table: "Bill",
                newName: "IX_Bill_ItemID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemID",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Item_ItemID",
                table: "Bill",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Item_ItemID",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Bill",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_ItemID",
                table: "Bill",
                newName: "IX_Bill_ItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdId",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserIdId",
                table: "Bill",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Item_ItemId",
                table: "Bill",
                column: "ID",
                principalTable: "Item",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Users_UserIdId",
                table: "Bill",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
