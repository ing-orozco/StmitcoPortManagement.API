using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargas_Buques_BuqueId",
                table: "Cargas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Usuarios",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargas_Buques_BuqueId",
                table: "Cargas",
                column: "BuqueId",
                principalTable: "Buques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargas_Buques_BuqueId",
                table: "Cargas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Usuarios",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Clave");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargas_Buques_BuqueId",
                table: "Cargas",
                column: "BuqueId",
                principalTable: "Buques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
