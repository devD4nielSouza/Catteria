using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catteria.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class cupomErros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "Orders");
        }
    }
}
