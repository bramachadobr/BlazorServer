using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorServer.Migrations
{
    public partial class initial : Migration
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
                    NomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DataFeriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contratacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Demissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraAula = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargaHorariaSemanal = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("38bc88f4-99af-4954-a7f0-2ffd72875d8d"), "Tutor" },
                    { new Guid("6b67c15f-29da-4058-80f2-95ded2336858"), "Secretaria" },
                    { new Guid("03a640d1-50d3-488b-a987-b958303e518f"), "Comercial" },
                    { new Guid("c567e874-ec64-4da7-95bd-8a1632a14290"), "Coordenador" },
                    { new Guid("4f710d58-ce2d-41af-a465-f2c7cacd24ff"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("f6244fad-d98d-4fe2-b4d7-743d282bc6ba"), false, null, 0.0, null, null, 110, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1731), "", null, "asd@asd.com", null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("2ad7eeff-a536-439d-8f5e-ee12ba1f979b"), false, null, 0.0, null, null, 111, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1734), "", null, "asd@asd.com", null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, "99999999", null },
                    { new Guid("27cfec7e-07c4-4fc5-b6b3-a660b56f92cb"), false, null, 0.0, null, null, 112, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1784), "", null, "asd@asd.com", null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, "99999999", null },
                    { new Guid("de0c5ac3-69d0-488e-b035-9c6d0f728302"), false, null, 0.0, null, null, 113, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1787), "", null, "asd@asd.com", null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, "99999999", null },
                    { new Guid("70fdcae7-75b2-4f4c-bdef-ee1cc494d6c9"), false, null, 0.0, null, null, 114, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1790), "", null, "asd@asd.com", null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, "99999999", null },
                    { new Guid("8a1c7991-cb13-4bf8-b6be-920109346274"), false, null, 0.0, null, null, 115, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1795), "", null, "asd@asd.com", null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, "99999999", null },
                    { new Guid("afffd55a-245b-41f0-8f22-6e50c4789e41"), false, null, 0.0, null, null, 116, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1798), "", null, "asd@asd.com", null, null, 52.00m, "CASSIO", 0, 5000.00m, "99999999", null },
                    { new Guid("11e2b1f0-8e9d-4775-862f-fcb5fe7ae3ef"), false, null, 0.0, null, null, 117, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1801), "", null, "asd@asd.com", null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, "99999999", null },
                    { new Guid("f2c26357-4c78-4eaa-a1a4-73247b563d14"), false, null, 0.0, null, null, 120, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1819), "", null, "asd@asd.com", null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, "99999999", null },
                    { new Guid("a990296a-9603-4157-918b-ba101f5e949d"), false, null, 0.0, null, null, 119, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1816), "", null, "asd@asd.com", null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("9ac9afea-911f-4abe-9196-a3c58133524f"), false, null, 0.0, null, null, 109, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1728), "", null, "asd@asd.com", null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, "99999999", null },
                    { new Guid("12629b28-451b-4eb4-8cc2-f83f3233bcc7"), false, null, 0.0, null, null, 121, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1822), "", null, "asd@asd.com", null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, "99999999", null },
                    { new Guid("24e62b5c-a8fc-4c27-a8cb-c179f872467c"), false, null, 0.0, null, null, 122, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1825), "", null, "asd@asd.com", null, null, 52.00m, "HEYGON TED", 0, 5000.00m, "99999999", null },
                    { new Guid("5175e051-e944-4a3b-933d-762c1786aa2d"), false, null, 0.0, null, null, 123, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1829), "", null, "asd@asd.com", null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, "99999999", null },
                    { new Guid("126475ef-053d-4b26-afa9-94d7f7a780c0"), false, null, 0.0, null, null, 124, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1832), "", null, "asd@asd.com", null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("de2dd5a8-1aea-4af5-a5a6-124c098dcd1b"), false, null, 0.0, null, null, 125, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1835), "", null, "asd@asd.com", null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, "99999999", null },
                    { new Guid("5393175b-5445-494c-bae2-e099ca67cacb"), false, null, 0.0, null, null, 126, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1838), "", null, "asd@asd.com", null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, "99999999", null },
                    { new Guid("2af194b1-295a-491f-bfa2-ea04b2ed5292"), false, null, 0.0, null, null, 118, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1813), "", null, "asd@asd.com", null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, "99999999", null },
                    { new Guid("15401362-ed03-49da-b7bc-b3ee92e70c70"), false, null, 0.0, null, null, 108, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1703), "", null, "asd@asd.com", null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, "99999999", null },
                    { new Guid("5c174ff2-337a-45ab-b51c-bf063136035f"), false, null, 0.0, null, null, 106, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1691), "", null, "asd@asd.com", null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, "99999999", null },
                    { new Guid("9c049cad-23aa-47b9-af96-4e5f4f627eef"), false, null, 0.0, null, null, 127, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1851), "", null, "asd@asd.com", null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, "99999999", null },
                    { new Guid("dddbaf82-887f-4416-96ef-ee57d302ff79"), false, null, 0.0, null, null, 89, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1596), "", null, "asd@asd.com", null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, "99999999", null },
                    { new Guid("4affc864-a981-44f3-979d-5e276d7a1c5c"), false, null, 0.0, null, null, 91, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1621), "", null, "asd@asd.com", null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, "99999999", null },
                    { new Guid("2fb047f7-1e6d-4a30-ad32-09d2da4b67a6"), false, null, 0.0, null, null, 94, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1626), "", null, "asd@asd.com", null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, "99999999", null },
                    { new Guid("672e46e7-68ec-4375-b4f0-91962f38279c"), false, null, 0.0, null, null, 93, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1629), "", null, "asd@asd.com", null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, "99999999", null },
                    { new Guid("833b9ab6-2b2c-4df3-81af-18206382cb42"), false, null, 0.0, null, null, 90, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1632), "", null, "asd@asd.com", null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, "99999999", null },
                    { new Guid("d0804831-208b-4fe8-aff8-d28f1de4df7a"), false, null, 0.0, null, null, 95, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1635), "", null, "asd@asd.com", null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, "99999999", null },
                    { new Guid("918453ea-c3a6-4e77-a692-857d246ca6b7"), false, null, 0.0, null, null, 77, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1638), "", null, "asd@asd.com", null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, "99999999", null },
                    { new Guid("9e4cea8c-18d0-4ebc-bbdd-70ac52f7a02d"), false, null, 0.0, null, null, 96, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1643), "", null, "asd@asd.com", null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, "99999999", null },
                    { new Guid("3dac134f-a501-4558-af88-69e236ee98c7"), false, null, 0.0, null, null, 97, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1645), "", null, "asd@asd.com", null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("01e7bbef-173a-42f6-a782-2a181028eb03"), false, null, 0.0, null, null, 98, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1648), "", null, "asd@asd.com", null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("e53e933b-556a-4099-b99d-c1e1b523861c"), false, null, 0.0, null, null, 99, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1652), "", null, "asd@asd.com", null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, "99999999", null },
                    { new Guid("7e7bb167-c67f-46a9-8b73-22f00f653918"), false, null, 0.0, null, null, 100, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1674), "", null, "asd@asd.com", null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, "99999999", null },
                    { new Guid("2b1a428c-613a-42c6-8735-a306e9919fe0"), false, null, 0.0, null, null, 101, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1677), "", null, "asd@asd.com", null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, "99999999", null },
                    { new Guid("6292d183-0c89-4199-8d45-26bf7b3fa4cb"), false, null, 0.0, null, null, 102, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1680), "", null, "asd@asd.com", null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, "99999999", null },
                    { new Guid("e7803017-c150-4413-8027-0f9d1ac076d4"), false, null, 0.0, null, null, 103, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1683), "", null, "asd@asd.com", null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, "99999999", null },
                    { new Guid("5c9a9b2d-4ff5-4895-88cc-6626e5d72ba4"), false, null, 0.0, null, null, 104, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1686), "", null, "asd@asd.com", null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, "99999999", null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("b8d11f2c-3d56-4439-b69e-5d249aaa81f1"), false, null, 0.0, null, null, 105, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1688), "", null, "asd@asd.com", null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, "99999999", null },
                    { new Guid("e9cf5149-9724-494a-b715-11857b1c1197"), false, null, 0.0, null, null, 107, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1700), "", null, "asd@asd.com", null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, "99999999", null },
                    { new Guid("b8532029-02d5-43c7-99e4-c0f2bf6d0431"), false, null, 0.0, null, null, 128, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1854), "", null, "asd@asd.com", null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("9d1e1dbf-7646-4a1f-bec1-fe5508d6be81"), false, null, 0.0, null, null, 130, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1860), "", null, "asd@asd.com", null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, "99999999", null },
                    { new Guid("c57d9a80-b553-4002-91ad-408b1af51b65"), false, null, 0.0, null, null, 88, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1589), "", null, "asd@asd.com", null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, "99999999", null },
                    { new Guid("85aa0688-f956-4cde-86f3-0c6e1dfdb7bd"), false, null, 0.0, null, null, 152, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1981), "", null, "asd@asd.com", null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("564289f5-185c-4faa-9a54-c726a2e8acfc"), false, null, 0.0, null, null, 153, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1984), "", null, "asd@asd.com", null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, "99999999", null },
                    { new Guid("ffe7df15-bb5c-4a4f-b27b-90d98272d296"), false, null, 0.0, null, null, 154, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1987), "", null, "asd@asd.com", null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, "99999999", null },
                    { new Guid("f80a0139-d357-4f60-9d43-11f97afed070"), false, null, 0.0, null, null, 155, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2001), "", null, "asd@asd.com", null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, "99999999", null },
                    { new Guid("2d2020be-6a23-4b22-9e5d-d5a6ec3b005a"), false, null, 0.0, null, null, 156, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2004), "", null, "asd@asd.com", null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, "99999999", null },
                    { new Guid("5d2f8bfe-5909-4146-8c1c-1068f4a7c91d"), false, null, 0.0, null, null, 157, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2007), "", null, "asd@asd.com", null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("88f9fc4b-ca1d-4ad6-8759-a156a3f01fb2"), false, null, 0.0, null, null, 158, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2010), "", null, "asd@asd.com", null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, "99999999", null },
                    { new Guid("09f1eb7a-55ec-4a8c-adce-bc9835a13352"), false, null, 0.0, null, null, 159, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2013), "", null, "asd@asd.com", null, null, 52.00m, "IRLEN SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("5ddd7869-29dc-43c7-88a0-70cc7c46fa10"), false, null, 0.0, null, null, 160, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2016), "", null, "asd@asd.com", null, null, 52.00m, "PATRICIA ZEN", 0, 5000.00m, "99999999", null },
                    { new Guid("f44eaff2-701e-4d96-b624-fb8c3c65cfea"), false, null, 0.0, null, null, 161, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2018), "", null, "asd@asd.com", null, null, 52.00m, "CAROLAINE MELO MOREIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("5360aa19-7beb-43af-be15-faf4eaa9c71d"), false, null, 0.0, null, null, 162, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2021), "", null, "asd@asd.com", null, null, 52.00m, "DANIELLA SIQUEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("606f057a-fbb3-4710-b080-bf663e695a50"), false, null, 0.0, null, null, 163, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2025), "", null, "asd@asd.com", null, null, 52.00m, "CLARA PAULA SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("f7c951aa-de92-4211-a041-9e78777db1a4"), false, null, 0.0, null, null, 164, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2028), "", null, "asd@asd.com", null, null, 52.00m, "JEFTE DE SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("87d595e2-b864-4895-beb9-cf8174661c66"), false, null, 0.0, null, null, 165, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2031), "", null, "asd@asd.com", null, null, 52.00m, "GISELLE SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("2973ba18-65ad-41f6-a164-bdb2bf33b394"), false, null, 0.0, null, null, 166, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2034), "", null, "asd@asd.com", null, null, 52.00m, "FREDSON LEITE", 0, 5000.00m, "99999999", null },
                    { new Guid("7f56511c-ae55-4a7e-8f05-e1df58e38a1c"), false, null, 0.0, null, null, 167, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2037), "", null, "asd@asd.com", null, null, 52.00m, "THAMIRES GOMES", 0, 5000.00m, "99999999", null },
                    { new Guid("ff781ae8-1e32-4e5f-a9ce-4da00ec47164"), false, null, 0.0, null, null, 168, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(2040), "", null, "asd@asd.com", null, null, 52.00m, "FERNANDA", 0, 5000.00m, "99999999", null },
                    { new Guid("a5876e06-04ad-4fe3-9a83-fb1f8607d442"), false, null, 0.0, null, null, 151, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1977), "", null, "asd@asd.com", null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, "99999999", null },
                    { new Guid("1ba79661-cce4-4f34-b49c-80aa8c857ee7"), false, null, 0.0, null, null, 129, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1857), "", null, "asd@asd.com", null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, "99999999", null },
                    { new Guid("8e2ef234-ac8d-4241-8559-b917ae22390a"), false, null, 0.0, null, null, 150, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1942), "", null, "asd@asd.com", null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, "99999999", null },
                    { new Guid("d28c8a42-bce8-4e2f-b71b-4162c98ac43d"), false, null, 0.0, null, null, 148, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1937), "", null, "asd@asd.com", null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, "99999999", null },
                    { new Guid("46efb30e-8d2b-4e2b-8a5f-3e6dab76ff99"), false, null, 0.0, null, null, 131, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1864), "", null, "asd@asd.com", null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("02568ba2-6e81-4a31-beb7-8686ad0fcb3a"), false, null, 0.0, null, null, 132, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1867), "", null, "asd@asd.com", null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, "99999999", null },
                    { new Guid("a8bef87e-b83a-4240-9999-67f839e2ad7d"), false, null, 0.0, null, null, 133, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1871), "", null, "asd@asd.com", null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, "99999999", null },
                    { new Guid("a7225bb8-75af-455e-b2f5-47a31611abbb"), false, null, 0.0, null, null, 134, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1874), "", null, "asd@asd.com", null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, "99999999", null },
                    { new Guid("60eb32db-7a50-46df-b990-23c8472a2663"), false, null, 0.0, null, null, 135, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1876), "", null, "asd@asd.com", null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("e661448d-87fb-4ee3-a3d3-e5db365632fb"), false, null, 0.0, null, null, 136, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1879), "", null, "asd@asd.com", null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, "99999999", null },
                    { new Guid("1805443e-c884-4633-96d7-134321006f86"), false, null, 0.0, null, null, 137, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1894), "", null, "asd@asd.com", null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, "99999999", null },
                    { new Guid("eb283ee8-d7fd-4886-841d-dc9278dbfc9e"), false, null, 0.0, null, null, 138, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1897), "", null, "asd@asd.com", null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("64c4da50-37e0-4a56-8adf-00a9c34a2d2d"), false, null, 0.0, null, null, 139, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1901), "", null, "asd@asd.com", null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, "99999999", null },
                    { new Guid("5d82349e-e1aa-4ef3-a547-8598a01a10a4"), false, null, 0.0, null, null, 140, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1904), "", null, "asd@asd.com", null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("e7c19930-9dd0-4ad6-b21a-b68dfdc8e2fa"), false, null, 0.0, null, null, 141, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1907), "", null, "asd@asd.com", null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, "99999999", null },
                    { new Guid("6240a0ca-7205-46d2-aa7f-16adb99c672e"), false, null, 0.0, null, null, 142, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1909), "", null, "asd@asd.com", null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, "99999999", null },
                    { new Guid("c1be4da1-dab5-4875-be97-c4157fe572c3"), false, null, 0.0, null, null, 143, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1912), "", null, "asd@asd.com", null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, "99999999", null },
                    { new Guid("70a053ee-1f13-4d2b-ad28-2248f2f2a86f"), false, null, 0.0, null, null, 144, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1915), "", null, "asd@asd.com", null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("2fed8cf6-541f-4b74-8258-f1d4bf3d252b"), false, null, 0.0, null, null, 145, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1918), "", null, "asd@asd.com", null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, "99999999", null },
                    { new Guid("a3486d64-c07c-4c79-b21f-62b41c830a3f"), false, null, 0.0, null, null, 146, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1929), "", null, "asd@asd.com", null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, "99999999", null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("d008b8fd-b368-45a5-bf5c-cad7a993f825"), false, null, 0.0, null, null, 147, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1934), "", null, "asd@asd.com", null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("67273f41-d451-4da1-a47f-ada79135b92c"), false, null, 0.0, null, null, 149, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1940), "", null, "asd@asd.com", null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, "99999999", null },
                    { new Guid("74ed0e6c-3ea5-43cd-b763-468081afbbca"), false, null, 0.0, null, null, 86, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1584), "", null, "asd@asd.com", null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, "99999999", null },
                    { new Guid("dcf684ed-fb45-4cf9-a498-69db6cfaa7aa"), false, null, 0.0, null, null, 87, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1587), "", null, "asd@asd.com", null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, "99999999", null },
                    { new Guid("1bb2b549-86e2-45a6-aa10-9a7eca625de8"), false, null, 0.0, null, null, 54, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1336), "", null, "asd@asd.com", null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, "99999999", null },
                    { new Guid("20bdba50-bbbb-4312-a367-8fe81923a49a"), false, null, 0.0, null, null, 9, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1227), "", null, "asd@asd.com", null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("ba9f16a5-f690-4506-b119-f6c65bf282e5"), false, null, 0.0, null, null, 31, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1241), "", null, "asd@asd.com", null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("f40e5625-6531-440a-b4cd-fe6ea10762ac"), false, null, 0.0, null, null, 33, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1245), "", null, "asd@asd.com", null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, "99999999", null },
                    { new Guid("1f72c379-8a11-480c-ae05-013b6a72f71e"), false, null, 0.0, null, null, 34, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1248), "", null, "asd@asd.com", null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, "99999999", null },
                    { new Guid("02058db9-47bb-45f0-91a3-cd7ae32cee3f"), false, null, 0.0, null, null, 10, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1250), "", null, "asd@asd.com", null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("1e8bb3ae-97bb-4661-96db-92d9be5504e7"), false, null, 0.0, null, null, 43, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1253), "", null, "asd@asd.com", null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, "99999999", null },
                    { new Guid("7074507d-4f42-4583-b36c-451ad74c5504"), false, null, 0.0, null, null, 11, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1256), "", null, "asd@asd.com", null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("e868252b-7e03-45d6-b0f8-c4d282e12a51"), false, null, 0.0, null, null, 12, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1259), "", null, "asd@asd.com", null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("ffb26ca1-718e-45db-9f0a-a6ae08ecb5c1"), false, null, 0.0, null, null, 51, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1262), "", null, "asd@asd.com", null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, "99999999", null },
                    { new Guid("5e743549-7f3b-4422-8f0b-0de9133c6d86"), false, null, 0.0, null, null, 55, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1302), "", null, "asd@asd.com", null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("8386ebe2-5a99-48c7-ac96-42c6e9ceec72"), false, null, 0.0, null, null, 13, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1318), "", null, "asd@asd.com", null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, "99999999", null },
                    { new Guid("2ac17bb0-ea93-4c7f-8c27-e066c57f6916"), false, null, 0.0, null, null, 30, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1321), "", null, "asd@asd.com", null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, "99999999", null },
                    { new Guid("77a012c9-3eb9-4557-9062-2fe8455d9119"), false, null, 0.0, null, null, 53, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1324), "", null, "asd@asd.com", null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("22c4f206-24a4-4292-a56b-ec32967e2f48"), false, null, 0.0, null, null, 14, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1327), "", null, "asd@asd.com", null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("7b59d119-efcc-4d24-b6a3-f80c1b4cb5cf"), false, null, 0.0, null, null, 27, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1330), "", null, "asd@asd.com", null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("1b08ba01-561d-471d-8f0c-fd1ed07fe74d"), false, null, 0.0, null, null, 3, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1333), "", null, "asd@asd.com", null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, "99999999", null },
                    { new Guid("4170d1f6-421c-49b0-8172-9971945f227f"), false, null, 0.0, null, null, 85, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1581), "", null, "asd@asd.com", null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, "99999999", null },
                    { new Guid("140ba84c-7747-419b-9cfb-b17fb83dbecf"), false, null, 0.0, null, null, 24, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1224), "", null, "asd@asd.com", null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, "99999999", null },
                    { new Guid("ebda66b8-9f21-445d-9691-56c883886ba6"), false, null, 0.0, null, null, 23, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1343), "", null, "asd@asd.com", null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, "99999999", null },
                    { new Guid("289c30e3-5d7e-4a61-9268-4b3b161c24fe"), false, null, 0.0, null, null, 29, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1222), "", null, "asd@asd.com", null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, "99999999", null },
                    { new Guid("7d87dad8-4a4f-4b9f-9f90-5806dd798275"), false, null, 0.0, null, null, 45, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1216), "", null, "asd@asd.com", null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, "99999999", null },
                    { new Guid("c5c46eeb-8a12-46b9-b94e-5c53eba7c656"), false, null, 0.0, null, null, 39, new DateTime(2023, 4, 26, 21, 34, 22, 58, DateTimeKind.Local).AddTicks(2030), "", null, "asd@asd.com", null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, "99999999", null },
                    { new Guid("61d320f2-8832-4da0-b55d-de0e832d46af"), false, null, 0.0, null, null, 22, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1110), "", null, "asd@asd.com", null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("4962cdb9-ab6c-465a-b1a1-ec333fc32b9d"), false, null, 0.0, null, null, 50, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1125), "", null, "asd@asd.com", null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, "99999999", null },
                    { new Guid("f651ab39-c2ca-43db-9a9e-7570cf1b5bad"), false, null, 0.0, null, null, 46, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1150), "", null, "asd@asd.com", null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, "99999999", null },
                    { new Guid("2c7a9ade-e61d-42b3-bb31-8579f253ddf0"), false, null, 0.0, null, null, 35, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1155), "", null, "asd@asd.com", null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("a001e2e9-451b-49f1-a293-57498d6d0195"), false, null, 0.0, null, null, 5, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1159), "", null, "asd@asd.com", null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("72302b86-460a-4322-bb1d-f20f9633eeae"), false, null, 0.0, null, null, 37, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1163), "", null, "asd@asd.com", null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, "99999999", null },
                    { new Guid("85a6ce20-9390-4c61-bcc8-17ade00bb9ed"), false, null, 0.0, null, null, 42, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1171), "", null, "asd@asd.com", null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, "99999999", null },
                    { new Guid("2accb953-ad62-420e-a6b2-029c3e15e3e1"), false, null, 0.0, null, null, 26, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1174), "", null, "asd@asd.com", null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, "99999999", null },
                    { new Guid("b2bbceff-0582-4dba-87c8-27a7840d06b1"), false, null, 0.0, null, null, 25, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1177), "", null, "asd@asd.com", null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("f522275a-a631-46a6-9c29-43d884a946c1"), false, null, 0.0, null, null, 44, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1180), "", null, "asd@asd.com", null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, "99999999", null },
                    { new Guid("7c2e1cd1-46fc-47c4-8322-839c8457f484"), false, null, 0.0, null, null, 40, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1184), "", null, "asd@asd.com", null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, "99999999", null },
                    { new Guid("ab858e86-6950-4872-ba57-ed7c056e9ae5"), false, null, 0.0, null, null, 41, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1187), "", null, "asd@asd.com", null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, "99999999", null },
                    { new Guid("3022c1d6-ae47-4c4a-b43e-758da31b4f56"), false, null, 0.0, null, null, 36, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1202), "", null, "asd@asd.com", null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, "99999999", null },
                    { new Guid("bf84b542-4856-429e-ab75-ba5de8164fb8"), false, null, 0.0, null, null, 28, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1205), "", null, "asd@asd.com", null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, "99999999", null },
                    { new Guid("4748d508-08c1-4eb3-bb1e-d6a1402e6446"), false, null, 0.0, null, null, 19, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1210), "", null, "asd@asd.com", null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, "99999999", null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("1638ceef-9f52-4488-b2a3-ee6386a4561e"), false, null, 0.0, null, null, 2, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1213), "", null, "asd@asd.com", null, null, 52.00m, "EDI", 0, 5000.00m, "99999999", null },
                    { new Guid("8ef347e2-49bc-470c-b097-fafce3d285c3"), false, null, 0.0, null, null, 48, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1219), "", null, "asd@asd.com", null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, "99999999", null },
                    { new Guid("8037dc0e-94a5-4ab9-9214-7d7ff69b3879"), false, null, 0.0, null, null, 20, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1355), "", null, "asd@asd.com", null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, "99999999", null },
                    { new Guid("7490fa1f-b035-4224-a8d5-d31fe55dcdef"), false, null, 0.0, null, null, 38, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1339), "", null, "asd@asd.com", null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, "99999999", null },
                    { new Guid("c9c46bdc-54f4-4b2b-914b-a5925389bebf"), false, null, 0.0, null, null, 32, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1362), "", null, "asd@asd.com", null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, "99999999", null },
                    { new Guid("a9bf27c3-e48f-40c1-8c1d-686c53c57670"), false, null, 0.0, null, null, 67, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1450), "", null, "asd@asd.com", null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, "99999999", null },
                    { new Guid("d820606c-314a-48f1-924d-e7649321305b"), false, null, 0.0, null, null, 68, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1453), "", null, "asd@asd.com", null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, "99999999", null },
                    { new Guid("b1b942dd-3eae-411d-a663-4dc48a1dad11"), false, null, 0.0, null, null, 69, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1456), "", null, "asd@asd.com", null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, "99999999", null },
                    { new Guid("60d5fc70-7811-44ac-89a1-e8ea2ab5e45e"), false, null, 0.0, null, null, 70, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1459), "", null, "asd@asd.com", null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, "99999999", null },
                    { new Guid("ba9a3abc-72b9-4169-a1be-1ad475731c27"), false, null, 0.0, null, null, 71, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1471), "", null, "asd@asd.com", null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, "99999999", null },
                    { new Guid("ffdaa1d7-04a1-495a-a25e-ccdb424b20fd"), false, null, 0.0, null, null, 72, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1531), "", null, "asd@asd.com", null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, "99999999", null },
                    { new Guid("40dea320-2d2f-4488-9582-fe161b381ce3"), false, null, 0.0, null, null, 73, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1535), "", null, "asd@asd.com", null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, "99999999", null },
                    { new Guid("1b77456e-09b7-4c70-9476-92c1f8fdc069"), false, null, 0.0, null, null, 74, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1539), "", null, "asd@asd.com", null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("f271ec58-0f10-485e-b73d-8d7803baa06b"), false, null, 0.0, null, null, 75, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1542), "", null, "asd@asd.com", null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, "99999999", null },
                    { new Guid("84cf3914-3132-47f8-beb4-d349e1f81be0"), false, null, 0.0, null, null, 78, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1545), "", null, "asd@asd.com", null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, "99999999", null },
                    { new Guid("2e67f3e9-f98e-45d7-a99a-729de0ca75fd"), false, null, 0.0, null, null, 79, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1548), "", null, "asd@asd.com", null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, "99999999", null },
                    { new Guid("c795a78d-d58d-477b-990b-ea9b8ea352ba"), false, null, 0.0, null, null, 80, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1551), "", null, "asd@asd.com", null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, "99999999", null },
                    { new Guid("68f7f6fe-900c-4c04-8084-5da33ba18517"), false, null, 0.0, null, null, 81, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1553), "", null, "asd@asd.com", null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, "99999999", null },
                    { new Guid("5b9e88e7-406e-4843-9971-93175d31d2e9"), false, null, 0.0, null, null, 76, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1567), "", null, "asd@asd.com", null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, "99999999", null },
                    { new Guid("f270dea5-65c4-4e90-82c8-2d654ee87fe0"), false, null, 0.0, null, null, 82, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1571), "", null, "asd@asd.com", null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, "99999999", null },
                    { new Guid("32ab4e10-b536-4dc1-81e5-fb748e596f76"), false, null, 0.0, null, null, 83, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1575), "", null, "asd@asd.com", null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, "99999999", null },
                    { new Guid("e49a2fb8-7f7b-46bd-b919-82d8c278f621"), false, null, 0.0, null, null, 84, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1578), "", null, "asd@asd.com", null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, "99999999", null },
                    { new Guid("acc2787c-a8ae-4b06-bbb0-f7311d0de93a"), false, null, 0.0, null, null, 15, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1359), "", null, "asd@asd.com", null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("337692e9-5f0f-4106-825e-1321ceccdb26"), false, null, 0.0, null, null, 65, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1443), "", null, "asd@asd.com", null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("f958f993-a802-46de-8732-1fa4ec7efd51"), false, null, 0.0, null, null, 66, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1447), "", null, "asd@asd.com", null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, "99999999", null },
                    { new Guid("4d022a75-c89c-4b23-9813-270beecfe78b"), false, null, 0.0, null, null, 63, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1437), "", null, "asd@asd.com", null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, "99999999", null },
                    { new Guid("7b0c149c-e7fd-4e08-9bfe-97ad613a57e5"), false, null, 0.0, null, null, 16, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1365), "", null, "asd@asd.com", null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, "99999999", null },
                    { new Guid("3707e3c5-8526-4532-9766-d7fcba2d830b"), false, null, 0.0, null, null, 47, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1367), "", null, "asd@asd.com", null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("56781599-81b9-4c30-a774-f1c24065edb4"), false, null, 0.0, null, null, 4, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1370), "", null, "asd@asd.com", null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, "99999999", null },
                    { new Guid("1030964f-b1b7-46b3-9761-633189c4c059"), false, null, 0.0, null, null, 56, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1373), "", null, "asd@asd.com", null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("d5e76d29-840d-4333-8694-62f4f6cd57a8"), false, null, 0.0, null, null, 17, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1377), "", null, "asd@asd.com", null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, "99999999", null },
                    { new Guid("e71a1d08-a2a4-4370-9978-ba1a44f5eed2"), false, null, 0.0, null, null, 49, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1380), "", null, "asd@asd.com", null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, "99999999", null },
                    { new Guid("155bc299-a9de-4a58-a1e9-fc658f82e9cb"), false, null, 0.0, null, null, 7, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1440), "", null, "asd@asd.com", null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, "99999999", null },
                    { new Guid("5584eba0-3132-46b8-aece-7aa2dff93f8f"), false, null, 0.0, null, null, 21, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1397), "", null, "asd@asd.com", null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, "99999999", null },
                    { new Guid("337cb427-3b5c-4651-81d0-295343007029"), false, null, 0.0, null, null, 18, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1383), "", null, "asd@asd.com", null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, "99999999", null },
                    { new Guid("f11b80b9-11ec-4c50-824c-b84fbe71a742"), false, null, 0.0, null, null, 57, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1402), "", null, "asd@asd.com", null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, "99999999", null },
                    { new Guid("4aa51b4d-1443-42ff-88fe-3cf28a62025e"), false, null, 0.0, null, null, 58, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1406), "", null, "asd@asd.com", null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, "99999999", null },
                    { new Guid("d47f604e-9050-40d8-83ba-fb640bf36118"), false, null, 0.0, null, null, 59, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1409), "", null, "asd@asd.com", null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, "99999999", null },
                    { new Guid("0f137964-b331-4c09-ba2f-9ed069a000d5"), false, null, 0.0, null, null, 60, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1413), "", null, "asd@asd.com", null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, "99999999", null },
                    { new Guid("26ddfae7-984b-4fb2-b31a-a13e4c7d238b"), false, null, 0.0, null, null, 61, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1416), "", null, "asd@asd.com", null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, "99999999", null },
                    { new Guid("3425c642-916d-4da2-98e7-297bfecdeaae"), false, null, 0.0, null, null, 6, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1419), "", null, "asd@asd.com", null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, "99999999", null },
                    { new Guid("a0621936-b8b4-4a90-a772-cfcd0a8c8b13"), false, null, 0.0, null, null, 62, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1422), "", null, "asd@asd.com", null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, "99999999", null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("88873d9b-3586-43cc-9242-27a9155b4a96"), false, null, 0.0, null, null, 64, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1434), "", null, "asd@asd.com", null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, "99999999", null },
                    { new Guid("618f495f-78e8-4cf6-8d2f-bd7b14588bdd"), false, null, 0.0, null, null, 52, new DateTime(2023, 4, 26, 21, 34, 22, 59, DateTimeKind.Local).AddTicks(1399), "", null, "asd@asd.com", null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, "99999999", null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("4c3e8902-acd3-441d-8620-716a70b0f3c8"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("06d6f1ed-7b73-420c-9aa8-0d008a792357"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proclamacao da republica" },
                    { new Guid("6a462591-3e86-4751-b60b-2e2cf79f8c83"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ano Novo" },
                    { new Guid("bbcdb56f-9bde-46e1-9062-e9bddbbc25c2"), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("14cfa117-02a1-494e-823f-350a021c1006"), new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finados" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("a29848a8-1c90-4dd0-84b2-2583e4820b71"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("80631538-f162-4226-b719-1a6763a08a23"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("49bd0b0f-2dc1-43b1-92c0-dbf418ad578a"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
