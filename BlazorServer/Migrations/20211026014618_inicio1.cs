using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServer.Migrations
{
    public partial class inicio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanho = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feriado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataFeriado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feriado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodPonto = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contratacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Demissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraAula = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargaHorariaSemanal = table.Column<TimeSpan>(type: "time", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UnidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Colaboradors_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPontos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AM_ENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AM_SAI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PM_ENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PM_SAI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOI_ENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOI_SAI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "NomeCargo" },
                values: new object[,]
                {
                    { new Guid("ede1dac0-cbf9-4cc8-a1b6-3fe990171264"), "Tutor" },
                    { new Guid("1ab3999a-49d1-4169-ae78-8b6c9e180232"), "Secretaria" },
                    { new Guid("19be5985-cb48-40ee-b9ae-5697ee870155"), "Comercial" },
                    { new Guid("cd85d77e-971b-4e2d-a36c-bca02b9c36a5"), "Coordenador" },
                    { new Guid("380b83d4-a949-41b2-af73-620ba848f741"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("5ddfb425-f50f-4dbb-b1cd-88f40c6ac1a3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 104, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2129), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("ba607804-7835-4839-840d-69d9033071de"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 105, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2166), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("e6c1f6b3-a06a-4891-963f-d140dfcddb1d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 106, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2172), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("d91b80b1-3524-4afd-86a3-1f3e2fcfc46a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 107, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2176), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("edda2638-26b0-4c80-8cb5-b983f76cd38b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 108, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2180), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("5d600a15-d208-453c-a0ce-3ab84ba18faa"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 109, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2185), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("db89996c-0d2c-45bb-8095-c9782f9746c4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 110, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2189), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("d0a250d4-09a0-45aa-a381-ddae7a815bf8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 113, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2205), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("66b45346-3d2e-4522-a964-cdba0efb369a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 112, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2198), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("2bd64f02-cec4-45a8-8814-127fdc6899a8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 103, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2124), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("3a0f339d-d442-4220-8181-0624401ea4f7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 114, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2209), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("844e9893-9225-4be5-ae58-a1a9490b1839"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 115, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2214), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("affcd4e1-8b9b-4066-a590-d26e9d5c4879"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 116, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2218), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("6403987e-c016-4525-a615-f8282ccdfecb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 117, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2222), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("8f4783c9-c800-44a7-8180-95ef6373c280"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 118, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2227), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("d480b0f7-6abd-4d09-b3e3-cec530c739b4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 111, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2194), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("b736e47e-bf4b-47ac-9d5d-238b7f7a14eb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 102, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2120), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("ca7a24d8-0db6-4af3-8694-fa07ee1cfd33"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 99, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2107), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("31a76ca6-5aee-4aeb-9962-563a26e17eed"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 100, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2111), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("a53f6dd5-65d9-4d60-8f54-ef830c102075"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 84, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2036), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("cccd5571-0aa6-48db-8828-b933b8473e49"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 85, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2041), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("f4dd22ba-d90f-4631-b006-7eacbaec8b59"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 86, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2046), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("7304a7e9-08a8-4c13-a006-21588a92f151"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 87, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2050), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("c8a39ad3-3f19-472d-83b0-ffeb6611a8ea"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 88, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2055), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("1303f4c6-1278-4bfa-b0da-13aa593483ac"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 89, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2061), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("74e47cb6-054a-4af1-9bf7-903bd611baca"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 91, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2066), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("afebabbc-a5f7-4009-8f9f-719ddbf87006"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 101, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2116), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("4071aeb0-916e-4e1a-8997-8b2fb85e47ea"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 94, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2070), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("6c81e523-aff6-467d-bcdc-62f0f0638c4a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 90, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2079), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("06fa5075-0dad-43b2-85cf-2e910634ddbf"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 95, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2083), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("a1b29121-152a-4eba-99ff-c1b63d7a6bb2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 77, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2087), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("110e59b3-9b01-4ba2-a416-62581015b277"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 96, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2092), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("447d97a7-f280-4e34-8a8b-47103fb15664"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 97, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2099), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("2c9657b2-ed66-4bba-8d0e-bda54acc4453"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 98, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2103), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("28a6f970-1d2b-4519-97c6-bc333387d083"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 119, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2231), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("6d2eaa29-a7da-47c7-8cee-385ce8a7c5be"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 93, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2074), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("ab0171ff-12a4-493c-9d91-a8b3dbd40acd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 120, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2235), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("faa43619-d8f8-4410-b79e-bb44a5510210"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 123, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2250), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("7caf270f-0a46-4b47-ab4f-1fccc1c8cd1d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 122, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2246), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("ec1e7417-fbd8-44ad-9da3-aac4476d6f05"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 143, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2349), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("d482df16-3427-4034-b6e7-0a8b1dd13e1f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 144, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2353), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("9fb455d7-bc07-421c-a3dd-0e0ba66418c9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 145, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2390), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("0bbaf183-1c16-4fae-a867-9cbc787ef086"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 146, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2395), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("134fa098-ca75-4542-ac14-d41a2f801f1c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 147, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2400), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("93c64f2f-21fe-4e4f-949a-993280cbe914"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 148, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2404), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("f8e84bb8-2e43-4baf-b632-5117ae3079e3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 149, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2409), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("26a9a5ea-52ab-4a0b-9a78-2b4088278e5b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 142, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2344), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("75c1340f-abdd-403e-bf11-a996434738f8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 150, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2413), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("a4deb30e-d85b-4858-a778-041046d9e3d7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 152, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2422), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("bc6b753e-7ad7-42ff-b926-8ad22d0eb222"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 153, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2428), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("680bd942-c712-4068-a3b9-d13d71d1240a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 154, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2433), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("599516e2-0c84-4a0b-8b29-2b4d90a95e7b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 155, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2438), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("283a9f59-5315-4eba-a404-d1f891c61626"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 156, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2442), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("4bac04fd-eb0e-45c1-b5a9-4b255e9cd78b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 157, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2446), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("94add223-1bda-49bc-b93c-2a87d6d77b05"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 158, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2451), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("7c61233d-9d18-4b30-9e31-9291b515d89a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 151, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2417), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("0933fa2b-3e64-4521-85fe-116677e2b348"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 121, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2242), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("2c071f1c-588a-45f3-a616-faff87906e11"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 141, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2340), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("35dc2248-fb9f-42d8-ba11-a32a83877f69"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 139, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2330), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("a6709309-72b5-45db-a43a-75c44e46a352"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 83, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2032), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("c879e099-c3de-40d3-a21a-1e718bc242f7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 124, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2255), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("15a42307-8d01-4c68-b627-e53a3c290446"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 125, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2260), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("0d408243-2fe1-4cb4-acde-e189f01ca623"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 126, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2264), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("25cf951b-b2b2-47b0-a85f-d621412f3d7c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 127, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2269), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("2e504a0e-4827-428d-a4db-449be3dc684f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 128, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2274), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("1527ebe2-5aeb-40b2-904a-37eae1604d35"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 129, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2280), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("802d9cb6-ede3-405b-80c5-73b2c45fea38"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 140, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2334), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("d0cf8efc-41c4-4b23-b83c-5dbc67a0aec5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 130, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2285), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("c7642161-71ae-40ba-ab52-24b03f01bac2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 132, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2297), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("31582751-334e-401f-ae7e-642bfe3408d6"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 133, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2302), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("b5d3706c-b3cc-4058-bf8d-ec406030247f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 134, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2306), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("86831d56-805a-4a1f-af25-194520247f7a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 135, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2310), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("506bfa9a-f8ea-4e71-ac8e-3c4e8e5b1e60"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 136, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2315), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("d92d9ebf-d7f2-4d6c-955c-da963d14d897"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 137, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2322), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("ad438c56-dae5-4943-8848-4ed6f370282d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 138, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2326), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("757f8a3a-763b-4976-b854-ee0232056642"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 131, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2290), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("71209d28-7d57-4e9f-9bab-1504bd210e66"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 82, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2028), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("ad14d122-868f-499a-96e2-ac2d15f50db7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 81, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2017), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("80ee199b-de80-421e-a4fe-cbf1817e749e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 3, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1741), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("edbb9116-1c22-453e-940e-0088d5239aa2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 9, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1626), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("5d27591a-f2db-4904-acbf-f2eb76aa7fb3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 31, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1631), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("77027884-3a11-4ded-aa17-493cf8f0c68e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 33, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1678), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("7d743d8e-7728-4d41-8af7-7bd0c70584ee"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 34, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1684), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("3d612fea-91e6-4b09-a1e2-1f1672c02f76"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 10, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1689), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("284100e2-a2ec-4386-9c9a-d3a981633983"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 43, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1693), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("52a19f51-3ba5-44a6-aba7-96de17c78157"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 11, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1697), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("ad3f5645-cc90-4d2d-a4f4-6811ad7c7b7d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 12, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1702), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("6857e0a1-2947-45f0-a589-a585ac01034b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 51, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1709), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("7d8f471c-4982-4844-9ca3-ccd4db1e165f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 55, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1713), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("01296031-dccf-4beb-afe2-dbfbd312ccf7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 13, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1718), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("bc204636-5c0d-4abd-b8a6-22e7a62710fc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 30, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1722), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("29837354-81c5-4bd6-8713-93eb2aee329f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 53, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1727), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("7c2fe2cd-cac5-4bac-9745-3d7ed8d02b26"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 14, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1731), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("3d9e8fd2-c631-40b5-b79d-d043bcb66e68"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 27, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1736), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("c0c15900-f60a-4726-9b32-c2a9ff5f6fb9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 24, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1620), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("a4a33a11-fef4-4fbd-8145-53c75bf9b346"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 29, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1615), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("d1743fbf-a1cc-4fcf-b198-2392fd36f4c7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 48, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1611), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("685b2d75-5a93-402c-a1b1-fda16698cb2a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 45, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1607), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("8e8b8cbd-8732-475d-95f9-80b40b76a204"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 22, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1501), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("086b6ae8-a187-42c6-becd-3e4d41636a5a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 50, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1524), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("c704c9e2-c16e-4c36-bdcf-05da12c5d434"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 46, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1531), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("4512d04d-9e0b-46d4-96bb-a93068e2d247"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 35, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1537), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("8bb38e8e-b62a-4a1f-a427-b673131b5fdb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 5, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1548), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("26adbc72-6625-4068-b7af-81aee48fd950"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 37, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1553), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("3993ee12-6db7-4e6c-ba1e-bc9ca66f7a22"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 42, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1558), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("73e2c1f0-6a41-4017-80e1-6e7d57173184"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 76, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2024), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("ec045f8e-f166-448d-ab1a-a1911d70131d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 26, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1562), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("5150b5aa-f08a-4181-9563-1d9fc72c478b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 44, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1572), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("0c437cea-6e3c-4e93-9796-c1dd93ad16b1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 40, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1577), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("80ee5ec7-d527-4109-9372-12262583412e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 41, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1581), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("b83a4ebb-0b3f-4713-8d75-d8d6a0c626a9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 36, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1588), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("bf328d74-3e7d-4a09-a201-e6fc1a3a0ea5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 28, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1593), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("286a4958-f2a4-4bf7-a215-7ba796f9a109"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 19, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1598), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("15df854b-fa4b-4ca6-b1ca-bfe77885407a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 2, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1602), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("396dfb2c-972b-4cdd-8166-97cea681a7ac"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 25, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1568), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6e1295a7-459c-401b-8fc4-5d6895d036a3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 54, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1750), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("cfad93f5-06d2-4473-844d-c0b5c54c3eb1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 38, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1755), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("c005267c-5600-488b-a0c6-4a5c2200c72c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 23, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1760), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("1845d2ae-390b-49cf-ba60-347b2b110dc5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 63, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1856), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("1eb53933-6504-4497-99ec-b0e1d20b9f22"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 7, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1863), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("4497f37b-8a39-4c8c-bd35-52413f69beb9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 65, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1927), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("ca5ddd8a-3f73-4ad4-abbc-1f337bb723c0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 66, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1932), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("127f56dc-bb71-4364-95f2-f4f2b438c04c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 67, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1936), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("391c3b5c-7296-44de-8aa7-6b258df2e79d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 68, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1941), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("e9a7744f-2256-4ed9-83c1-6c90d3fa68bc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 69, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1946), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("9105e82f-8679-4597-bd7e-743cacd8f6fe"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 64, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1852), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("7d6c1a95-4530-401d-95e8-06d498ddac68"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 70, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1950), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("d6992abb-595c-4060-a6cc-a358c3e23a20"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 72, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1961), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("0e7c5088-9688-4a68-a7ef-e19be751ae0d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 73, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1965), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("f6f62a56-c302-4da1-ad69-c9b63c5dea82"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 74, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1970), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("8d9f1a05-cf18-4c03-86ea-21eaa7bcc555"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 75, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1974), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("60a79b14-ddbb-430c-9e7b-5ebfca68d24d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 78, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1980), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("ef05ba2a-eb1e-4bc1-b273-f6cf1205b35a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 79, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1984), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("f9459403-d47e-4378-9213-d608c4156a20"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 80, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(2013), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("c3c0465c-53b7-44a2-8ce9-2cdd302f956a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 71, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1954), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("27c84e5e-232e-46be-8c8a-5ef7ffa2af3e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 39, new DateTime(2021, 10, 25, 22, 46, 17, 676, DateTimeKind.Local).AddTicks(6282), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("ce0a7cb4-4d6f-4a00-950e-af983a3259b9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 62, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1848), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("f9bf16a1-848f-4c6b-8f4c-71d15ed54bdb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 61, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1839), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("6419027b-0100-41cf-9466-1adaecc737c3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 20, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1764), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("440892ae-d794-4bb0-85b0-0564b284c3d0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 15, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1769), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("2566e4c4-0ed6-4ad6-be09-c55feaa7489e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 32, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1773), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("d901d6de-7471-4f3c-92ec-e2dd93ccc8ee"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 16, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1778), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("d2c385d7-5676-4f64-8835-eb4bb8c003a8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 47, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1782), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("3717f484-c70d-4522-acdc-307daa1b8d40"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 4, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1789), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("22ec7c44-2bcf-48f3-91f8-940a1af98e7f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 56, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1793), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("e8fd7601-71b3-4ca2-b2a9-f08d9e9294f2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 6, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1844), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("fcf61269-265b-4130-9f49-be62eae0ba46"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 17, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1798), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("5e799867-5c9b-4b81-9ce4-ca3cc598a843"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 18, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1807), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("1c0f5a00-ab2a-4523-8c3d-665168968091"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 21, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1811), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("127374f9-6fb5-49f8-aa80-dad5246e8b8a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 52, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1815), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("809cbb48-f4e7-43f2-b347-5da5f0836533"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 57, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1819), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("28f80b09-ff72-4de2-8e04-c489c8af1615"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 58, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1826), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("bbfdeaa5-14fc-4c1e-bf61-894eaac54e3d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 59, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1831), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("9756e2de-fdd7-40d8-becb-a2207b71c051"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 60, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1835), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("631f314c-db57-4d98-9635-52f401ded713"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 49, new DateTime(2021, 10, 25, 22, 46, 17, 678, DateTimeKind.Local).AddTicks(1802), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("7b0b2b2b-3a2d-49b5-a5a6-50a9c08b1d4f"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("f713077e-1fec-495a-9350-45fc7238338a"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("424950f5-6c52-44af-a02f-e684594c1ba9"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("6c2bcb78-fef5-4ec3-923c-f022bb07369f"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradors_CargoId",
                table: "Colaboradors",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradors_UnidadeId",
                table: "Colaboradors",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPontos_ColaboradorId",
                table: "RegistroPontos",
                column: "ColaboradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Feriado");

            migrationBuilder.DropTable(
                name: "RegistroPontos");

            migrationBuilder.DropTable(
                name: "Colaboradors");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
