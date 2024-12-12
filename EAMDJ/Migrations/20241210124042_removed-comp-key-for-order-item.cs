using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
	/// <inheritdoc />
	public partial class removedcompkeyfororderitem : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_OrderItem",
				table: "OrderItem");

			migrationBuilder.AddPrimaryKey(
				name: "PK_OrderItem",
				table: "OrderItem",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_OrderItem_OrderId",
				table: "OrderItem",
				column: "OrderId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_OrderItem",
				table: "OrderItem");

			migrationBuilder.DropIndex(
				name: "IX_OrderItem_OrderId",
				table: "OrderItem");

			migrationBuilder.AddPrimaryKey(
				name: "PK_OrderItem",
				table: "OrderItem",
				columns: new[] { "OrderId", "ProductId" });
		}
	}
}
