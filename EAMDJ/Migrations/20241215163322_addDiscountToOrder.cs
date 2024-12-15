using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
    /// <inheritdoc />
    public partial class addDiscountToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DiscountId",
                table: "Order",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DiscountId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Order");
        }
    }
}
