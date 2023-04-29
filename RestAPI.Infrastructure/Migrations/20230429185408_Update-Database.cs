using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Categories_CategoriesDtosId",
                table: "Categories_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Products_ProductDtosId",
                table: "Categories_Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ProductDtosId",
                table: "Categories_Products",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "CategoriesDtosId",
                table: "Categories_Products",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Products_ProductDtosId",
                table: "Categories_Products",
                newName: "IX_Categories_Products_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Categories_CategoriesId",
                table: "Categories_Products",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Products_ProductsId",
                table: "Categories_Products",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Categories_CategoriesId",
                table: "Categories_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Products_ProductsId",
                table: "Categories_Products");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Categories_Products",
                newName: "ProductDtosId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Categories_Products",
                newName: "CategoriesDtosId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Products_ProductsId",
                table: "Categories_Products",
                newName: "IX_Categories_Products_ProductDtosId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Categories_CategoriesDtosId",
                table: "Categories_Products",
                column: "CategoriesDtosId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Products_ProductDtosId",
                table: "Categories_Products",
                column: "ProductDtosId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
