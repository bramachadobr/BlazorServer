using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BlazorServer.Migrations
{
    public partial class start : Migration
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
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
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
                    NomeFeriado = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        principalColumn: "CargoId",
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
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "CargoId", "NomeCargo" },
                values: new object[,]
                {
                    { new Guid("7b0550b3-d76b-4fe7-8585-b19ce620ccab"), "Tutor" },
                    { new Guid("0f1ae776-0094-4c85-9a6e-80ac99d6e808"), "Secretaria" },
                    { new Guid("a0847cc0-ad29-4d52-abfa-3ff6e4178045"), "Comercial" },
                    { new Guid("a3f6551a-e3e0-42fd-b3fc-c62af5f386e3"), "Coordenador" },
                    { new Guid("94834a19-9021-494e-af0b-086900298969"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("9ec35927-0f4c-4f09-a877-ce838381a87e"), false, null, null, null, 104, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5244), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("5fe79161-acf4-43f9-b89e-4b3142ca7089"), false, null, null, null, 105, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5279), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("3174ac99-4073-4fa8-ba3e-db38cf4f15b8"), false, null, null, null, 106, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5284), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("452bdd15-aeea-430e-8cd2-219c3bd2377f"), false, null, null, null, 107, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5289), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("bea7445c-571d-401b-a415-96958e229b9d"), false, null, null, null, 108, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5294), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("63d811d4-66e7-446e-9adb-b12957c33ca4"), false, null, null, null, 109, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5298), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("ac14ec82-3f6e-4bbd-a112-8457fab258ca"), false, null, null, null, 110, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5304), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("03f39b64-c2df-4da1-b51e-d7cd0303d971"), false, null, null, null, 113, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5320), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("5043bc1f-7028-4f8b-a9f0-16146e5cac21"), false, null, null, null, 112, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5315), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("24227a79-7f7c-43c2-82cb-9699ccb9c877"), false, null, null, null, 103, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5237), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("d57d4b43-a5d9-401c-bfba-0d1d3d5e131b"), false, null, null, null, 114, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5325), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("0e50ee7c-08e4-48c3-89a6-8b4ecf8e7200"), false, null, null, null, 115, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5330), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("d7031db3-70b4-4b74-ba2a-82e1740dfb22"), false, null, null, null, 116, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5334), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("c79c24dc-78fc-4354-82da-e7f6a2f0447a"), false, null, null, null, 117, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5339), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("9ec2371b-9f56-4640-a7ed-ed90d4d18dc7"), false, null, null, null, 118, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5344), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("2015cca8-eda0-45eb-a362-5458aebec528"), false, null, null, null, 111, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5308), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("956dcfbd-72fb-4033-b73a-61b5aaf1840d"), false, null, null, null, 102, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5232), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("d46c0718-8aeb-400d-a7f7-642acf86c503"), false, null, null, null, 99, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5217), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("ae51755c-b7a2-4d63-89a2-268d4e756065"), false, null, null, null, 100, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5223), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("d52de0e5-fe61-4cae-a173-8e8367cfa063"), false, null, null, null, 84, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5140), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("187c260e-e666-45f8-af53-da3fd39c0f88"), false, null, null, null, 85, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5145), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("7cc6575d-5fb6-41a1-9898-bb9923e0b1f4"), false, null, null, null, 86, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5150), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("93ccd682-52a5-4252-9957-7c0fc0b78674"), false, null, null, null, 87, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5154), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("25e834fd-1de1-4821-ba93-3ba5ec166f5e"), false, null, null, null, 88, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5161), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("6d455397-f9a5-4279-a0bb-edbff64d0a37"), false, null, null, null, 89, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5166), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("759ef78c-daa0-4ca8-84a4-90e6a4675757"), false, null, null, null, 91, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5171), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("96096f68-65ce-446c-bcfb-429572036d6c"), false, null, null, null, 101, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5227), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("b07cc473-b7ad-4f00-8f71-3d31a5bd6033"), false, null, null, null, 94, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5176), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("2c825bb1-d8ee-4b2f-942a-533f63e721ec"), false, null, null, null, 90, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5185), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("60ceb10f-5aa3-4f79-847a-f2a746bb11e6"), false, null, null, null, 95, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5190), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("bd5e1902-6be9-438a-8bce-d86e941d4056"), false, null, null, null, 77, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5194), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("49a44040-944d-4f97-8748-0a622cf45cf9"), false, null, null, null, 96, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5202), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("8b5e1ed6-37d6-42ea-a639-a38e3d8ba02e"), false, null, null, null, 97, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5206), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("e111f4a1-9589-48f2-a167-84069370ab50"), false, null, null, null, 98, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5211), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("61fc6da3-0d17-48f6-8770-137fcb117ecd"), false, null, null, null, 119, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5348), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("4418c1e4-c3af-42d3-bd42-b63acdca8571"), false, null, null, null, 93, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5181), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("0032bb0a-6110-43e0-919f-dcbf9cec1447"), false, null, null, null, 120, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5355), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("4d74b9a2-7368-4a4e-bc9d-3addb6ffb03e"), false, null, null, null, 123, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5370), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("7d75d2f4-77f6-42a5-8124-a439553b7f12"), false, null, null, null, 122, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5365), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("e9e27857-4a41-4ea6-8e6a-a3cac2ae1fa9"), false, null, null, null, 143, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5476), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("2ccdf7be-3e6e-4da3-8bc8-64c5d2d8fd43"), false, null, null, null, 144, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5483), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("544c90cb-bb5b-496a-ab23-53c0a5a1ac79"), false, null, null, null, 145, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5488), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("c02675a9-d686-40cc-b707-cb39d95b891c"), false, null, null, null, 146, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5526), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("407ac359-c13e-44c9-845d-0ea92a47f950"), false, null, null, null, 147, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5532), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("f81ea21e-4336-4dcd-96b0-60fe27e1cff5"), false, null, null, null, 148, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5537), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("4cd69df7-cc87-47dd-b0a6-2688d9eb2610"), false, null, null, null, 149, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5541), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("882177ab-8f21-43d7-8275-2ff7facafd3b"), false, null, null, null, 142, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5471), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("c91faccd-abaa-4bf7-9660-1dfaa7f0b39b"), false, null, null, null, 150, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5550), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("9771390f-7d6e-4c70-a435-233613ce8e68"), false, null, null, null, 152, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5562), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("3b9fb735-5a43-4730-a142-45fe5484144c"), false, null, null, null, 153, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5567), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("30f4bfa9-87c4-4aae-8704-d9cbb353b263"), false, null, null, null, 154, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5572), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("351d561b-bf8e-4b4b-ad80-0d8bfa0febb6"), false, null, null, null, 155, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5576), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("261008c7-62e4-4fab-b0e5-8b5bd0177ce9"), false, null, null, null, 156, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5581), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("0229e1fe-0e23-4b07-9bdd-0738b2740e7d"), false, null, null, null, 157, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5586), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("43dce4db-3e3a-41e4-be43-d80d4e0b13ca"), false, null, null, null, 158, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5590), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("d2f0ce15-12bc-4f49-854b-a6a27f7e71de"), false, null, null, null, 151, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5555), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("228ac6ca-036c-4ee4-a92b-bf5c01f02952"), false, null, null, null, 121, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5361), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("691b8ac6-c0c2-4ce3-87fa-b50f51bcba2b"), false, null, null, null, 141, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5464), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("483f3173-67a4-48d7-aa25-8ea84e448431"), false, null, null, null, 139, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5453), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("37b647c6-18e2-41f8-a348-4ebf33e70eb0"), false, null, null, null, 83, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5135), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("f9776ef5-9afe-4eab-8f2d-31df604607b8"), false, null, null, null, 124, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5375), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("9dc1989c-9773-46ab-ac6c-873d862013c8"), false, null, null, null, 125, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5379), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("2d556766-97df-46fe-ab57-6ee55e22319f"), false, null, null, null, 126, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5384), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("005aed0b-914e-41c7-baa0-bcff79ede8d1"), false, null, null, null, 127, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5388), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("c1d2a46c-3905-48f1-981c-89d3b84bc698"), false, null, null, null, 128, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5395), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("b2f09482-2617-4ce8-8124-c02f54d2bb01"), false, null, null, null, 129, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5400), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("0ba970bf-61e3-416e-9ef6-d858fd389a47"), false, null, null, null, 140, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5459), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("c1b42e3e-781f-4e30-a1e6-b8697ba58bbc"), false, null, null, null, 130, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5405), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("d04612aa-dc89-4e93-bde9-3ed98ea004a4"), false, null, null, null, 132, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5414), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("eb11772f-2ef7-4b46-8284-bdb36128491f"), false, null, null, null, 133, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5419), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("cb381a71-27f4-47df-80fe-b018dc2e0cb3"), false, null, null, null, 134, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5424), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("b141df9b-96d0-45f8-8ce8-ba39d0f9c89e"), false, null, null, null, 135, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5429), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("c6ac368e-6c51-4497-b60a-c022159c8ebe"), false, null, null, null, 136, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5437), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("2fb62d67-5f38-4890-90f0-43b92aa845fb"), false, null, null, null, 137, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5442), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("9df54a97-fbf1-44e6-b4f6-1844decbdedf"), false, null, null, null, 138, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5447), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("1b502316-2954-4840-ad98-d7d1e39e9e5a"), false, null, null, null, 131, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5409), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("8ce97934-47c5-41f7-9cf8-d143e81c71fd"), false, null, null, null, 82, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5129), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("4f4e931b-de12-4f29-8076-a1f4d89122f5"), false, null, null, null, 81, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5119), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("298aaf31-5873-44cc-a8b9-5d1cefb24880"), false, null, null, null, 3, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4884), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("f193eaa0-091a-4e7b-8997-2db1ce9acab1"), false, null, null, null, 9, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4803), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("954caf10-40a5-454a-b438-32cc1b9e10e1"), false, null, null, null, 31, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4808), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("358a92cc-028e-41af-8332-72e5c52b7db9"), false, null, null, null, 33, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4814), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("214e015e-3ede-41fe-97a9-e22925e00756"), false, null, null, null, 34, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4819), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("9436cdcc-7a93-4571-9303-a0cd1f255954"), false, null, null, null, 10, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4824), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("303904be-089b-407c-999b-c8be4383a406"), false, null, null, null, 43, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4829), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("f3f8e193-7b2e-484a-91c8-538e1b0a7390"), false, null, null, null, 11, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4834), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("2d9b2bd8-e918-45a4-be4d-263189037a56"), false, null, null, null, 12, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4842), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("b37fa7a5-95e4-41cf-8ed9-2a7e61d68f32"), false, null, null, null, 51, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4848), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("50b6a36f-99a3-4a76-965a-7c996644aa98"), false, null, null, null, 55, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4853), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("030712fb-8807-47eb-9dfa-87c031c7ab45"), false, null, null, null, 13, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4858), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("1e8ad998-2d1f-4caf-ae2a-1b1c15bd1c85"), false, null, null, null, 30, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4863), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("b478cb73-3f1e-4383-a4a8-6b72499d327e"), false, null, null, null, 53, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4867), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("f53a397e-1b4a-4924-8da8-046555376855"), false, null, null, null, 14, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4872), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("3571f896-497d-4f54-ba6f-956c383238c6"), false, null, null, null, 27, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4877), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("9d664384-6da6-4d70-a82c-c61be7bc1a26"), false, null, null, null, 24, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4796), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("5774af66-ba17-4da5-8af2-d4d6d1222d48"), false, null, null, null, 29, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4712), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("a0732dc9-dc59-4a06-adda-522679d8a0b2"), false, null, null, null, 48, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4706), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("887b401f-11ba-4af2-ac19-3cf82673f406"), false, null, null, null, 45, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4701), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("4acece27-deef-435b-a760-057f4b9f5f6b"), false, null, null, null, 22, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4553), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("687dc936-6ce2-4e23-b534-ac7d83a11eaf"), false, null, null, null, 50, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4604), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("47657922-aa83-400c-81b4-c2ca55b0f9cd"), false, null, null, null, 46, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4613), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("467fb42b-a7d8-4c97-aaf2-fd8fee3c41dd"), false, null, null, null, 35, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4629), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("96fec84b-9771-49fa-8883-ba1eae351585"), false, null, null, null, 5, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4634), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("8c847145-4d46-4baf-b374-663e1598daf4"), false, null, null, null, 37, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4640), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("7f4de793-ea69-4b1b-b0ae-9c942034d732"), false, null, null, null, 42, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4645), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("48ba4bb7-864e-41f8-b4c6-59c342e073ed"), false, null, null, null, 76, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5124), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("7b9f1c88-f8fc-4d4b-879e-2483b027e963"), false, null, null, null, 26, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4651), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("1de028d1-f15d-47a3-bb8c-53d0f1f13ced"), false, null, null, null, 44, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4661), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("931a52ae-85d3-4337-858f-7583ac8384e2"), false, null, null, null, 40, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4666), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("cd48aa6c-aed8-48f2-9455-1b8241a04edf"), false, null, null, null, 41, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4675), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("466e82b7-f3a0-4dd6-a6af-875a0e543f7b"), false, null, null, null, 36, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4680), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("53782617-315d-4beb-858c-dba6d92a3c4d"), false, null, null, null, 28, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4685), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("dfe99170-dd2d-43f6-8ee1-55b8709e5e0c"), false, null, null, null, 19, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4691), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("6874a8fd-7aaa-4037-8a85-cf5afba50d56"), false, null, null, null, 2, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4696), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("91df3a4d-bc4b-4ebf-a12e-17a045673c21"), false, null, null, null, 25, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4656), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("7f1e2e0c-172f-47d9-ae2b-1dd9a79b4ce1"), false, null, null, null, 54, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4889), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("d18d414b-0520-4c0a-99e7-22fb8e0f46e3"), false, null, null, null, 38, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4893), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("68821a39-ba61-45d6-830b-f374f86a9495"), false, null, null, null, 23, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4899), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("65d92418-6f53-463b-8edc-45c1383e7096"), false, null, null, null, 63, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5004), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("6e8cc103-65f9-4062-b848-c97d4adcc867"), false, null, null, null, 7, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5040), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("e8887d61-abec-4ae0-9cf1-f84bad681e53"), false, null, null, null, 65, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5045), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("2ff8eef0-d5b5-4433-badd-c411748b3e2a"), false, null, null, null, 66, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5050), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("1387ceab-f16b-42b0-b21d-5d4c94e9e307"), false, null, null, null, 67, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5055), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("9f3e36d6-d1dd-4fa9-a8d6-b06ec80729c8"), false, null, null, null, 68, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5060), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("ec71bdb0-2656-4330-95a4-b6014419c7c6"), false, null, null, null, 69, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5065), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("d22eb047-2879-470d-99dd-ad7a2ab72d70"), false, null, null, null, 64, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4997), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("6581d353-5bb7-4c89-b2c7-5bbeeda311a5"), false, null, null, null, 70, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5069), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("fd4bb908-9c34-4f8a-abc3-c40c6a588998"), false, null, null, null, 72, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5081), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("8ad37739-8b0d-4b84-8a0d-3f321a78ee2c"), false, null, null, null, 73, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5086), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("dec8a62d-ec98-4540-8d03-21c546a6818d"), false, null, null, null, 74, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5091), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("3aedc916-4b1a-4f98-acda-343a1dccfd81"), false, null, null, null, 75, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5096), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("c9f33ec5-0876-4670-811c-af7fa83bd5e3"), false, null, null, null, 78, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5101), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("1043533f-4271-4f4e-92e6-10e183e51e5c"), false, null, null, null, 79, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5106), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("84acfd06-c7cc-4ad2-a29c-0bbe84356463"), false, null, null, null, 80, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5112), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("052d2080-09b8-44f6-9004-cdd8f03a5ab5"), false, null, null, null, 71, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(5077), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("598f1b88-0b46-4bea-ac60-858502539d05"), false, null, null, null, 39, new DateTime(2021, 10, 15, 16, 51, 35, 144, DateTimeKind.Local).AddTicks(41), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("e634cb92-cf90-4298-86e4-f44c1ef8bf30"), false, null, null, null, 62, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4993), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("d9281b9b-58b9-4fe3-8fc4-eb274793bec3"), false, null, null, null, 61, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4983), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("a349a734-a8cc-4199-9fd5-764ac9549cfa"), false, null, null, null, 20, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4903), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("7c331f34-ab22-4fa9-8e69-f45f75346f09"), false, null, null, null, 15, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4908), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("fb3978f3-25fd-46f0-a608-c99964b416d1"), false, null, null, null, 32, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4913), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("68723160-5470-41f6-a7b4-82cda790509c"), false, null, null, null, 16, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4917), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("268af7b2-79b8-47dc-8a6d-be5bde083195"), false, null, null, null, 47, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4924), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("217f2c12-0f40-48e6-b02e-ce40b39f1de9"), false, null, null, null, 4, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4929), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("2274c9d8-e0e4-4754-bd06-3a6930bf7e9c"), false, null, null, null, 56, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4934), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("8c2b71ef-b097-45a5-8137-c86a19d42938"), false, null, null, null, 6, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4988), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("4c9a5bea-b8ac-458d-a3f4-da19a33e4236"), false, null, null, null, 17, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4939), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("3cac08da-b6db-46f6-b573-b27902d4ffe4"), false, null, null, null, 18, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4948), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("d8cf5c09-bc5f-4aa0-8089-0a57bb847067"), false, null, null, null, 21, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4952), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("328a07eb-b21a-48fc-891d-e2b2568302a8"), false, null, null, null, 52, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4957), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("0f2b5d29-51ee-4508-85e9-502381c46192"), false, null, null, null, 57, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4965), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("597b4013-cc24-4020-8644-f40ffba07a0b"), false, null, null, null, 58, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4969), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("94d4559f-224b-4a37-b60a-fdfaad2138a5"), false, null, null, null, 59, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4974), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("94312824-cf78-42fe-976f-344fdf536e9c"), false, null, null, null, 60, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4979), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("ba54784b-52aa-4610-afa1-99fbe86b50f3"), false, null, null, null, 49, new DateTime(2021, 10, 15, 16, 51, 35, 145, DateTimeKind.Local).AddTicks(4943), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("83c58185-8745-40d8-adb2-0ff484130aba"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("1b468c55-97bd-4e72-b604-6e08aa5aeb4c"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("c8ad5b4b-4b37-4a7f-b46b-e0eccacaaf53"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("220b46cb-d2d1-4657-96f9-b58b81bf80a4"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
