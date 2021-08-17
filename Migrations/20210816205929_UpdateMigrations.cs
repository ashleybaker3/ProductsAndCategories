using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAndCategories.Migrations
{
    public partial class UpdateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Associations_CategoryID",
                table: "Associations",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ProductID",
                table: "Associations",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Categories_CategoryID",
                table: "Associations",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductID",
                table: "Associations",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Categories_CategoryID",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductID",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_CategoryID",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_ProductID",
                table: "Associations");
        }
    }
}
