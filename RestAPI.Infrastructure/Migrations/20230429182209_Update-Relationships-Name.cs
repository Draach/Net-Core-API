using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesDtosId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductDtosId",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Categories_Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ProductDtosId",
                table: "Categories_Products",
                newName: "IX_Categories_Products_ProductDtosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories_Products",
                table: "Categories_Products",
                columns: new[] { "CategoriesDtosId", "ProductDtosId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Categories_CategoriesDtosId",
                table: "Categories_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_Products_ProductDtosId",
                table: "Categories_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories_Products",
                table: "Categories_Products");

            migrationBuilder.RenameTable(
                name: "Categories_Products",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Products_ProductDtosId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ProductDtosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                columns: new[] { "CategoriesDtosId", "ProductDtosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesDtosId",
                table: "ProductCategories",
                column: "CategoriesDtosId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductDtosId",
                table: "ProductCategories",
                column: "ProductDtosId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
