using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    Id_Hotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Latitud = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Longitud = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad_Habitaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.Id_Hotel);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Id_Habitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Hotel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id_Habitacion);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Hoteles_Id_Hotel",
                        column: x => x.Id_Hotel,
                        principalTable: "Hoteles",
                        principalColumn: "Id_Hotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id_Reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Entrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Salida = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fecha_Reserva = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Habitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id_Reserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Habitaciones_Id_Habitacion",
                        column: x => x.Id_Habitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "Id_Hotel", "Cantidad_Habitaciones", "Descripcion", "Estado", "Latitud", "Longitud", "Nombre", "Pais" },
                values: new object[,]
                {
                    { 1, 5, "Hermoso hotel ubicado en la ciudad de bogotá", true, "4.640845", "-74.098481", "Hotel Bogotá", "Colombia" },
                    { 2, 5, "Hermoso hotel ubicado en la ciudad de madrid", true, "40.405885", "-3.674803", "Hotel Madrid", "España" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id_Usuario", "Apellidos", "Direccion", "Mail", "Nombres" },
                values: new object[,]
                {
                    { 1, "Perez", "Calle 123", "luis.perez@tudominio.com", "Luis" },
                    { 2, "Perez", "Calle 456", "juan.perez@tudominio.com", "Juan" },
                    { 3, "Perez", "Calle 789", "maria.perez@tudominio.com", "Maria" },
                    { 4, "Perez", "Calle 987", "monica.perez@tudominio.com", "Monica" },
                    { 5, "Perez", "Calle 654", "luisa.perez@tudominio.com", "Luisa" },
                    { 6, "Perez", "Calle 321", "pedro.perez@tudominio.com", "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "Id_Habitacion", "Descripcion", "Estado", "Id_Hotel", "Nombre" },
                values: new object[,]
                {
                    { 1, "Habitación sencilla", true, 1, "Habitación 101" },
                    { 2, "Habitación sencilla", true, 1, "Habitación 102" },
                    { 3, "Habitación doble", true, 1, "Habitación 201" },
                    { 4, "Habitación doble", true, 1, "Habitación 202" },
                    { 5, "Habitación vip", true, 1, "Habitación 301" },
                    { 6, "Habitación sencilla", true, 2, "Habitación 101" },
                    { 7, "Habitación sencilla", true, 2, "Habitación 102" },
                    { 8, "Habitación doble", true, 2, "Habitación 201" },
                    { 9, "Habitación doble", true, 2, "Habitación 202" },
                    { 10, "Habitación vip", true, 2, "Habitación 301" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id_Reserva", "Estado", "Fecha_Entrada", "Fecha_Reserva", "Fecha_Salida", "Id_Habitacion", "Id_Usuario" },
                values: new object[] { 1, true, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id_Reserva", "Estado", "Fecha_Entrada", "Fecha_Reserva", "Fecha_Salida", "Id_Habitacion", "Id_Usuario" },
                values: new object[] { 2, true, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_Id_Hotel",
                table: "Habitaciones",
                column: "Id_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Id_Habitacion",
                table: "Reservas",
                column: "Id_Habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Id_Usuario",
                table: "Reservas",
                column: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Hoteles");
        }
    }
}
