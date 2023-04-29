using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "ProductCategoriesId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Categories_Products",
                newName: "CategoryProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Products_ProductsId",
                table: "Categories_Products",
                newName: "IX_Categories_Products_ProductCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Categories_ProductCategoriesId",
                table: "Categories_Products",
                column: "ProductCategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_Products_CategoryProductsId",
                table: "Categories_Products",
                column: "CategoryProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Categories_ProductCategoriesId",
                table: "Categories_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Products_CategoryProductsId",
                table: "Categories_Products");

            migrationBuilder.RenameColumn(
                name: "ProductCategoriesId",
                table: "Categories_Products",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "CategoryProductsId",
                table: "Categories_Products",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Products_ProductCategoriesId",
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
    }
}
