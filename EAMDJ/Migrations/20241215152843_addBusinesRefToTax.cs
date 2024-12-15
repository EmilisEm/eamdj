using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
    /// <inheritdoc />
    public partial class addBusinesRefToTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Tax",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tax_BusinessId",
                table: "Tax",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tax_Business_BusinessId",
                table: "Tax",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tax_Business_BusinessId",
                table: "Tax");

            migrationBuilder.DropIndex(
                name: "IX_Tax_BusinessId",
                table: "Tax");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Tax");
        }
    }
}
