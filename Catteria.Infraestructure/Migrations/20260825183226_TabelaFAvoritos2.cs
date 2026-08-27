using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catteria.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class TabelaFAvoritos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CupomCodigo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CupomId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.DropColumn(
                  name: "OrderId",
                  table: "CupomUsos");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CupomUsos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CupomCodigo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CupomUsos");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CupomUsos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
