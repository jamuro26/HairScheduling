using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairScheduling.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CitaId",
                table: "Pagos",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCitas_CitaId",
                table: "DetallesCitas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCitas_ServicioId",
                table: "DetallesCitas",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ClienteId",
                table: "Citas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EmpleadoId",
                table: "Citas",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Clientes_ClienteId",
                table: "Citas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Empleados_EmpleadoId",
                table: "Citas",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesCitas_Citas_CitaId",
                table: "DetallesCitas",
                column: "CitaId",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesCitas_Servicios_ServicioId",
                table: "DetallesCitas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Usuarios_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Citas_CitaId",
                table: "Pagos",
                column: "CitaId",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Clientes_ClienteId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Empleados_EmpleadoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesCitas_Citas_CitaId",
                table: "DetallesCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesCitas_Servicios_ServicioId",
                table: "DetallesCitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Usuarios_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Citas_CitaId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_CitaId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCitas_CitaId",
                table: "DetallesCitas");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCitas_ServicioId",
                table: "DetallesCitas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_ClienteId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_EmpleadoId",
                table: "Citas");
        }
    }
}
