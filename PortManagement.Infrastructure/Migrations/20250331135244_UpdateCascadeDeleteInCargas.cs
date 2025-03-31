using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDeleteInCargas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Cargas_CargaId",
                table: "Operaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Cargas_CargaId",
                table: "Operaciones",
                column: "CargaId",
                principalTable: "Cargas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Cargas_CargaId",
                table: "Operaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Cargas_CargaId",
                table: "Operaciones",
                column: "CargaId",
                principalTable: "Cargas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
