using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserFromItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Users_UsersId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UsersId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Item",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UsersId",
                table: "Item",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Users_UsersId",
                table: "Item",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
