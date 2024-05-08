using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActividadesPorHacer",
                columns: table => new
                {
                    ActividadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Realizada = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activida__981483F074BDC49B", x => x.ActividadID);
                });

            migrationBuilder.CreateTable(
                name: "Lugares",
                columns: table => new
                {
                    LugarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Calificacion = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lugares__1BDE0D80D0D0F7AC", x => x.LugarID);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSerie",
                columns: table => new
                {
                    PeliculaSerieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Imagen = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    FechaEstreno = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSerie", x => x.PeliculaSerieID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    RestauranteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Calificacion = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.RestauranteID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__1788CCACC3AB795C", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosLugares",
                columns: table => new
                {
                    ComentarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LugarID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    FechaComentario = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__F1844958B399EC7F", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK__Comentari__Lugar__2E1BDC42",
                        column: x => x.LugarID,
                        principalTable: "Lugares",
                        principalColumn: "LugarID");
                    table.ForeignKey(
                        name: "FK__Comentari__UserI__2F10007B",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ComentariosRestaurantes",
                columns: table => new
                {
                    ComentarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauranteID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    FechaComentario = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__F1844958D3EFAD3E", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK__Comentari__Resta__286302EC",
                        column: x => x.RestauranteID,
                        principalTable: "Restaurantes",
                        principalColumn: "RestauranteID");
                    table.ForeignKey(
                        name: "FK__Comentari__UserI__29572725",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosActividades",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ActividadID = table.Column<int>(type: "int", nullable: true),
                    FechaRealizacion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__UsuariosA__Activ__33D4B598",
                        column: x => x.ActividadID,
                        principalTable: "ActividadesPorHacer",
                        principalColumn: "ActividadID");
                    table.ForeignKey(
                        name: "FK__UsuariosA__UserI__32E0915F",
                        column: x => x.UserID,
                        principalTable: "Usuarios",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosLugares_LugarID",
                table: "ComentariosLugares",
                column: "LugarID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosLugares_UserID",
                table: "ComentariosLugares",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosRestaurantes_RestauranteID",
                table: "ComentariosRestaurantes",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosRestaurantes_UserID",
                table: "ComentariosRestaurantes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosActividades_ActividadID",
                table: "UsuariosActividades",
                column: "ActividadID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosActividades_UserID",
                table: "UsuariosActividades",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosLugares");

            migrationBuilder.DropTable(
                name: "ComentariosRestaurantes");

            migrationBuilder.DropTable(
                name: "PeliculaSerie");

            migrationBuilder.DropTable(
                name: "UsuariosActividades");

            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "ActividadesPorHacer");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
