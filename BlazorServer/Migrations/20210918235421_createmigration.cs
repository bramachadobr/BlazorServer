using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServer.Migrations
{
    public partial class createmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPonto = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoId = table.Column<int>(type: "int", nullable: true),
                    Contratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Demissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraAula = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradors_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: true),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AM_ENT = table.Column<TimeSpan>(type: "time", nullable: false),
                    AM_SAI = table.Column<TimeSpan>(type: "time", nullable: false),
                    PM_ENT = table.Column<TimeSpan>(type: "time", nullable: false),
                    PM_SAI = table.Column<TimeSpan>(type: "time", nullable: false),
                    NOI_ENT = table.Column<TimeSpan>(type: "time", nullable: false),
                    NOI_SAI = table.Column<TimeSpan>(type: "time", nullable: false),
                    TOTALHORAS = table.Column<TimeSpan>(type: "time", nullable: false),
                    VALORHORA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroPontos_Colaboradors_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradors_CargoId",
                table: "Colaboradors",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPontos_ColaboradorId",
                table: "RegistroPontos",
                column: "ColaboradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroPontos");

            migrationBuilder.DropTable(
                name: "Colaboradors");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
