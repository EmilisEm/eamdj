using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAMDJ.Migrations
{
	/// <inheritdoc />
	public partial class BaseEntities_again : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Flat",
				table: "Discount");

			migrationBuilder.DropColumn(
				name: "Percentage",
				table: "Discount");

			migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "User",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Password",
				table: "User",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "LastName",
				table: "User",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "FirstName",
				table: "User",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Tax",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Product",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AddColumn<decimal>(
				name: "Amount",
				table: "Discount",
				type: "numeric",
				nullable: false,
				defaultValue: 0m);

			migrationBuilder.AddColumn<bool>(
				name: "IsFlat",
				table: "Discount",
				type: "boolean",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Business",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Business",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Address",
				table: "Business",
				type: "text",
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "text",
				oldNullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_ProductCategory_BusinessId",
				table: "ProductCategory",
				column: "BusinessId");

			migrationBuilder.AddForeignKey(
				name: "FK_ProductCategory_Business_BusinessId",
				table: "ProductCategory",
				column: "BusinessId",
				principalTable: "Business",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ProductCategory_Business_BusinessId",
				table: "ProductCategory");

			migrationBuilder.DropIndex(
				name: "IX_ProductCategory_BusinessId",
				table: "ProductCategory");

			migrationBuilder.DropColumn(
				name: "Amount",
				table: "Discount");

			migrationBuilder.DropColumn(
				name: "IsFlat",
				table: "Discount");

			migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "User",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "Password",
				table: "User",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "LastName",
				table: "User",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "FirstName",
				table: "User",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Tax",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "Description",
				table: "Product",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AddColumn<decimal>(
				name: "Flat",
				table: "Discount",
				type: "numeric",
				nullable: true);

			migrationBuilder.AddColumn<decimal>(
				name: "Percentage",
				table: "Discount",
				type: "numeric",
				nullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Business",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Business",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");

			migrationBuilder.AlterColumn<string>(
				name: "Address",
				table: "Business",
				type: "text",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "text");
		}
	}
}
