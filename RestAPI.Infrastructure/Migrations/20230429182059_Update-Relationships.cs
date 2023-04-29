using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductDtoId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductDtoId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductDtoId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoriesDtosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDtosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.CategoriesDtosId, x.ProductDtosId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoriesDtosId",
                        column: x => x.CategoriesDtosId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductDtosId",
                        column: x => x.ProductDtosId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductDtosId",
                table: "ProductCategories",
                column: "ProductDtosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDtoId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductDtoId",
                table: "Categories",
                column: "ProductDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductDtoId",
                table: "Categories",
                column: "ProductDtoId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
