using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catteria.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdProduct",
                table: "OrderItems",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_IdProduct",
                table: "OrderItems",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_IdProduct",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_IdProduct",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
