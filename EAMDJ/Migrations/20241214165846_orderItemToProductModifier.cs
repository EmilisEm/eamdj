using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
    /// <inheritdoc />
    public partial class orderItemToProductModifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItemProductModifier",
                columns: table => new
                {
                    OrderItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductModifiersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemProductModifier", x => new { x.OrderItemsId, x.ProductModifiersId });
                    table.ForeignKey(
                        name: "FK_OrderItemProductModifier_OrderItem_OrderItemsId",
                        column: x => x.OrderItemsId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemProductModifier_ProductModifier_ProductModifiersId",
                        column: x => x.ProductModifiersId,
                        principalTable: "ProductModifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemProductModifier_ProductModifiersId",
                table: "OrderItemProductModifier",
                column: "ProductModifiersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemProductModifier");
        }
    }
}
