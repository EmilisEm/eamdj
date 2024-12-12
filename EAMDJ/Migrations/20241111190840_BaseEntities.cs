using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
	/// <inheritdoc />
	public partial class BaseEntities : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Email",
				table: "Business",
				type: "text",
				nullable: true);

			migrationBuilder.CreateTable(
				name: "Order",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
					CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Order", x => x.Id);
					table.ForeignKey(
						name: "FK_Order_Business_BusinessId",
						column: x => x.BusinessId,
						principalTable: "Business",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductCategory",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: true),
					BusinessId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductCategory", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "User",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Username = table.Column<string>(type: "text", nullable: true),
					Password = table.Column<string>(type: "text", nullable: true),
					FirstName = table.Column<string>(type: "text", nullable: true),
					LastName = table.Column<string>(type: "text", nullable: true),
					UserType = table.Column<int>(type: "integer", nullable: false),
					BusinessId = table.Column<Guid>(type: "uuid", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_User", x => x.Id);
					table.ForeignKey(
						name: "FK_User_Business_BusinessId",
						column: x => x.BusinessId,
						principalTable: "Business",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Product",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Price = table.Column<decimal>(type: "numeric", nullable: false),
					Name = table.Column<string>(type: "text", nullable: false),
					CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
					Description = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Product", x => x.Id);
					table.ForeignKey(
						name: "FK_Product_ProductCategory_CategoryId",
						column: x => x.CategoryId,
						principalTable: "ProductCategory",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tax",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: true),
					Percentage = table.Column<decimal>(type: "numeric", nullable: false),
					ProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tax", x => x.Id);
					table.ForeignKey(
						name: "FK_Tax_ProductCategory_ProductCategoryId",
						column: x => x.ProductCategoryId,
						principalTable: "ProductCategory",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Discount",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					ProductId = table.Column<Guid>(type: "uuid", nullable: false),
					Percentage = table.Column<decimal>(type: "numeric", nullable: true),
					Flat = table.Column<decimal>(type: "numeric", nullable: true),
					Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Discount", x => x.Id);
					table.ForeignKey(
						name: "FK_Discount_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "OrderItem",
				columns: table => new
				{
					ProductId = table.Column<Guid>(type: "uuid", nullable: false),
					OrderId = table.Column<Guid>(type: "uuid", nullable: false),
					Quantity = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.ProductId });
					table.ForeignKey(
						name: "FK_OrderItem_Order_OrderId",
						column: x => x.OrderId,
						principalTable: "Order",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OrderItem_Product_ProductId",
						column: x => x.ProductId,
						principalTable: "Product",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Discount_ProductId",
				table: "Discount",
				column: "ProductId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Order_BusinessId",
				table: "Order",
				column: "BusinessId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderItem_ProductId",
				table: "OrderItem",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_Product_CategoryId",
				table: "Product",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Tax_ProductCategoryId",
				table: "Tax",
				column: "ProductCategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_User_BusinessId",
				table: "User",
				column: "BusinessId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Discount");

			migrationBuilder.DropTable(
				name: "OrderItem");

			migrationBuilder.DropTable(
				name: "Tax");

			migrationBuilder.DropTable(
				name: "User");

			migrationBuilder.DropTable(
				name: "Order");

			migrationBuilder.DropTable(
				name: "Product");

			migrationBuilder.DropTable(
				name: "ProductCategory");

			migrationBuilder.DropColumn(
				name: "Email",
				table: "Business");
		}
	}
}
