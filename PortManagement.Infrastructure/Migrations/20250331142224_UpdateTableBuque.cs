using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableBuque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCarga",
                table: "Buques");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoCarga",
                table: "Buques",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
