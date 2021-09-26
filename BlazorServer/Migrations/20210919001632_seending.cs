using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BlazorServer.Migrations
{
    public partial class seending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "CargoId", "CodPonto", "Contratacao", "Demissao", "HoraAula", "Nome", "Salario" },
                values: new object[] { 1, null, 0, new DateTime(2021, 9, 18, 21, 16, 31, 959, DateTimeKind.Local).AddTicks(9628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.00m, "Edivaldo", 5000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colaboradors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
