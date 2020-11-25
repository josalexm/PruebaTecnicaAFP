using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTEC.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    NumeroDocumento = table.Column<string>(maxLength: 50, nullable: false),
                    FechaIngreso = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(maxLength: 50, nullable: true),
                    IdAfiliado = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefono_Afiliado_IdAfiliado",
                        column: x => x.IdAfiliado,
                        principalTable: "Afiliado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_IdAfiliado",
                table: "Telefono",
                column: "IdAfiliado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Afiliado");
        }
    }
}
