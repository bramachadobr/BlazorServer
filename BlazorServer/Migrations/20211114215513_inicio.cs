using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BlazorServer.Migrations
{
    public partial class inicio : Migration
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
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contratacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Demissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraAula = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargaHorariaSemanal = table.Column<double>(type: "float", nullable: false),
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
                    { new Guid("5061ae51-0a73-49bb-a18d-a18d068f7cfb"), "Tutor" },
                    { new Guid("3c3f93f4-fabf-4d1d-88ac-4a12919d6f93"), "Secretaria" },
                    { new Guid("258d07d9-0576-4e73-b699-108d11eb8c21"), "Comercial" },
                    { new Guid("20727d06-e07e-4258-a065-ed9feed9b1bc"), "Coordenador" },
                    { new Guid("7ef5cacf-93f9-4c33-8956-6d96393661f8"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("0543cb06-2652-449c-af52-13f7d81ec78e"), false, null, 0.0, null, null, 110, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5841), "", null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("b060a12b-7e52-455f-889e-0ff637cc1593"), false, null, 0.0, null, null, 111, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5845), "", null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("b00c0670-2bea-4429-b151-4d1b007ad3c3"), false, null, 0.0, null, null, 112, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5850), "", null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("2db23e19-ae63-44c1-8416-38a8014185ba"), false, null, 0.0, null, null, 113, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5889), "", null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("c8355896-e3e3-4691-9467-8b908b407acd"), false, null, 0.0, null, null, 114, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5894), "", null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("1c90283a-6861-4ccd-b614-d794274331ea"), false, null, 0.0, null, null, 115, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5898), "", null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("1707f466-67ca-4dca-be71-7ed36e4001c9"), false, null, 0.0, null, null, 116, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5902), "", null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("75ba4e31-300c-4f76-9c99-da720c870f0f"), false, null, 0.0, null, null, 117, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5907), "", null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("6b02f0de-337b-46af-a729-e38bf653deee"), false, null, 0.0, null, null, 120, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5923), "", null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("dbe6eefb-7b69-430b-8634-f753deb78157"), false, null, 0.0, null, null, 119, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5918), "", null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("f8ce9151-a61a-4e26-93d6-7fb9ddd88b99"), false, null, 0.0, null, null, 109, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5834), "", null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("e5c0ea57-1591-4e92-8ec7-896e1e413773"), false, null, 0.0, null, null, 121, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5928), "", null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("bf9a8d3d-ae1b-4922-bbb0-319360b1f3f0"), false, null, 0.0, null, null, 122, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5932), "", null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("2c42a6ff-d163-4e00-975b-d5d4d85d1bf1"), false, null, 0.0, null, null, 123, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5937), "", null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("48a9c677-c90c-4c81-812e-42530d3ec1fd"), false, null, 0.0, null, null, 124, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5942), "", null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("8774a463-e65e-4917-87ce-a8b45a6c286f"), false, null, 0.0, null, null, 125, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5946), "", null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("3bcb8ee4-7c06-49d0-9b03-876073f1bd8c"), false, null, 0.0, null, null, 126, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5953), "", null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("408bda29-cb03-4171-870e-f0e0fda7589c"), false, null, 0.0, null, null, 118, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5914), "", null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("eb767200-f06c-47d8-8a27-07c8a899e899"), false, null, 0.0, null, null, 108, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5830), "", null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("e997f58f-8962-4ce7-8e15-a73261fec142"), false, null, 0.0, null, null, 106, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5822), "", null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("1fea43dd-1154-442c-9b82-8b520c65893c"), false, null, 0.0, null, null, 127, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5958), "", null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("189af262-0b3f-4f60-93a2-e714377c3fd7"), false, null, 0.0, null, null, 89, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5735), "", null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("c22d9908-9235-4139-aecf-2511a968683c"), false, null, 0.0, null, null, 91, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5740), "", null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("aa26ccb8-7bdc-494b-b831-16904027b92a"), false, null, 0.0, null, null, 94, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5745), "", null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("a8aaa387-d234-4179-8036-f2c61c2ad9cd"), false, null, 0.0, null, null, 93, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5750), "", null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("9d8f5f31-17bf-425b-892e-63d33af868a0"), false, null, 0.0, null, null, 90, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5756), "", null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("ff86a8f8-8770-4c6f-be87-e05e33ed8950"), false, null, 0.0, null, null, 95, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5763), "", null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("e6e9e8cd-bbe2-46b3-8b02-d030ea64443f"), false, null, 0.0, null, null, 77, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5768), "", null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("d671e5e6-c169-4367-a4ab-d1be93124255"), false, null, 0.0, null, null, 96, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5773), "", null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("54daa783-a5f4-418a-b2ec-94a66427a56e"), false, null, 0.0, null, null, 97, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5778), "", null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("948757e8-55a8-4734-b869-e4f91a3ea712"), false, null, 0.0, null, null, 98, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5782), "", null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("a4a38d5c-8642-49c4-ab47-df384c0bc5a7"), false, null, 0.0, null, null, 99, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5787), "", null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("84d62258-cc0b-4078-879a-3a7297639cb4"), false, null, 0.0, null, null, 100, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5791), "", null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("4fdfb2df-669c-496c-897f-e8945679ceff"), false, null, 0.0, null, null, 101, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5796), "", null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("53e8d79a-dfea-4327-a45d-b313e968b9da"), false, null, 0.0, null, null, 102, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5802), "", null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("808477e3-4436-4ff5-89f9-53ccd205072a"), false, null, 0.0, null, null, 103, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5807), "", null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("ff33b519-9979-4ce8-9142-da07a0181843"), false, null, 0.0, null, null, 104, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5812), "", null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("5c50d0ef-9cb4-4e48-9ee6-64037bc4b36c"), false, null, 0.0, null, null, 105, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5817), "", null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("0bf1e154-b23d-42c5-a72c-accf2802af1d"), false, null, 0.0, null, null, 107, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5826), "", null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("2c5fcac2-b98f-41a1-90fe-ba2048208c44"), false, null, 0.0, null, null, 128, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5963), "", null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("2be4c621-1d05-4148-b94c-d90c9c63e2e8"), false, null, 0.0, null, null, 130, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5972), "", null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("d57a9544-a97c-42ee-aede-f218d840c5ad"), false, null, 0.0, null, null, 88, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5730), "", null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("440d5158-69fd-45f0-97c9-ba49f7e1770b"), false, null, 0.0, null, null, 152, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6115), "", null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("8c0e7d57-a5e2-4fc2-b8ef-67a56792ebde"), false, null, 0.0, null, null, 153, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6119), "", null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("b9cf6bda-cbcc-4371-88b5-83e000192cf0"), false, null, 0.0, null, null, 154, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6124), "", null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("f05d6439-0220-4728-9e1f-27a306845d52"), false, null, 0.0, null, null, 155, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6129), "", null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("d94ab737-da27-4ff5-b7b8-05376d93c37b"), false, null, 0.0, null, null, 156, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6133), "", null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("00e0f333-4563-489c-bb7c-d705e45a3925"), false, null, 0.0, null, null, 157, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6138), "", null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("f8ee0774-94c7-4478-9a05-b5910fe52874"), false, null, 0.0, null, null, 158, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6145), "", null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("1d68cbbf-4670-4dca-8bf4-5028439a71ac"), false, null, 0.0, null, null, 159, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6149), "", null, null, null, null, 52.00m, "IRLEN SOUSA", 0, 5000.00m, null, null },
                    { new Guid("6ed7ee63-94cf-4b5d-b832-daea6613196f"), false, null, 0.0, null, null, 160, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6154), "", null, null, null, null, 52.00m, "PATRICIA ZEN", 0, 5000.00m, null, null },
                    { new Guid("ed646ca6-78c3-4c9f-b3a7-dad3876ef8ed"), false, null, 0.0, null, null, 161, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6158), "", null, null, null, null, 52.00m, "CAROLAINE MELO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("d8c4f7e9-38c5-4944-9b18-6b0b7bf9b016"), false, null, 0.0, null, null, 162, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6162), "", null, null, null, null, 52.00m, "DANIELLA SIQUEIRA", 0, 5000.00m, null, null },
                    { new Guid("02ae14d1-13e4-434a-85c3-b2269b52fe35"), false, null, 0.0, null, null, 163, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6167), "", null, null, null, null, 52.00m, "CLARA PAULA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("6c103fa2-9c07-4da8-a0a3-6412616b2c7a"), false, null, 0.0, null, null, 164, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6172), "", null, null, null, null, 52.00m, "JEFTE DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("46ba7899-b494-43d5-a97a-c451e7163d39"), false, null, 0.0, null, null, 165, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6177), "", null, null, null, null, 52.00m, "GISELLE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("1af13c4a-8591-4180-b3b7-2546259b9ae1"), false, null, 0.0, null, null, 166, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6184), "", null, null, null, null, 52.00m, "FREDSON LEITE", 0, 5000.00m, null, null },
                    { new Guid("c586ba70-7665-4928-9018-3a6c2a59cb0d"), false, null, 0.0, null, null, 167, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6188), "", null, null, null, null, 52.00m, "THAMIRES GOMES", 0, 5000.00m, null, null },
                    { new Guid("c14a2859-8f94-451e-9c51-d1b32e371e50"), false, null, 0.0, null, null, 168, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6193), "", null, null, null, null, 52.00m, "FERNANDA", 0, 5000.00m, null, null },
                    { new Guid("ab7c3601-9eff-40a1-9c13-0a8176f52fd0"), false, null, 0.0, null, null, 151, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6080), "", null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("018ea381-8a16-4fc3-8666-7228dba827e0"), false, null, 0.0, null, null, 129, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5967), "", null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("093c9b21-2477-4798-9e87-90950387df6c"), false, null, 0.0, null, null, 150, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6075), "", null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("3f8bc280-ddd1-467a-9c9a-2de62e8d5599"), false, null, 0.0, null, null, 148, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6062), "", null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("212be68a-18c5-4c7e-bae5-fcda46f147dd"), false, null, 0.0, null, null, 131, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5976), "", null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("db9cc57a-5a97-410d-93da-3d267bfe0cd0"), false, null, 0.0, null, null, 132, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5981), "", null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("748d60f8-e290-4aa2-8807-041ccee19c13"), false, null, 0.0, null, null, 133, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5985), "", null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("9451718b-c31c-4da7-a4ba-becaa798519a"), false, null, 0.0, null, null, 134, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5992), "", null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("128ffc11-00ad-4640-8e98-9b5f96f9e257"), false, null, 0.0, null, null, 135, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5996), "", null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("ce588f7a-ae2d-45c0-8725-b6e562511cca"), false, null, 0.0, null, null, 136, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6001), "", null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("6723e91f-de19-4a76-a30f-ac9ce726edc6"), false, null, 0.0, null, null, 137, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6006), "", null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("d4ddd087-efca-477c-8b4f-a49bc20d77f2"), false, null, 0.0, null, null, 138, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6010), "", null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("8e6eff4f-f3fc-4c18-a9c8-925cba54d5a8"), false, null, 0.0, null, null, 139, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6014), "", null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("3e041193-9a78-4fbc-8c27-017abe4824a1"), false, null, 0.0, null, null, 140, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6019), "", null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("e6f684ef-5b32-4b6b-bb02-39c6f75be1fd"), false, null, 0.0, null, null, 141, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6024), "", null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("511cf979-f71d-4c2b-a316-99a7461eecc5"), false, null, 0.0, null, null, 142, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6031), "", null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("5e183886-cea9-43ca-a4cc-77559af4d45b"), false, null, 0.0, null, null, 143, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6036), "", null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("f3850ee6-927f-4735-be72-106256a7e21b"), false, null, 0.0, null, null, 144, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6042), "", null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("616a2363-3ae3-4bdc-828d-3ad99f23cd26"), false, null, 0.0, null, null, 145, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6047), "", null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("aec431ae-2f14-489d-930b-3311e08a608e"), false, null, 0.0, null, null, 146, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6051), "", null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("42cef1eb-9025-47d4-a86e-c8176825e42d"), false, null, 0.0, null, null, 147, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6057), "", null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("50d5af64-5878-46e7-9242-006a951606fa"), false, null, 0.0, null, null, 149, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(6068), "", null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("578b8a55-0ec8-47ed-99cd-4c8324882d56"), false, null, 0.0, null, null, 86, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5719), "", null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("71e3d555-0f4a-4b74-b57c-ad71de653349"), false, null, 0.0, null, null, 87, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5724), "", null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("971ce6a0-193a-480b-b5ee-591d14660064"), false, null, 0.0, null, null, 54, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5465), "", null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("eae5dcf3-f1a2-4020-863d-34c603d66d35"), false, null, 0.0, null, null, 9, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5336), "", null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("f4e58723-71b3-4319-a9ec-09f0d586208c"), false, null, 0.0, null, null, 31, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5341), "", null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("3a74a1b1-803f-4b33-830a-a00c9841a5a2"), false, null, 0.0, null, null, 33, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5346), "", null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("339a928f-8869-4bdd-bf12-c2c035739e5f"), false, null, 0.0, null, null, 34, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5351), "", null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("3b9705f3-1234-4c26-a0b5-d499421ee814"), false, null, 0.0, null, null, 10, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5356), "", null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("8c5da62d-3ae7-48da-a270-d3f182580b7d"), false, null, 0.0, null, null, 43, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5363), "", null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("8001ea00-4d0a-41af-a442-51f69e2030f8"), false, null, 0.0, null, null, 11, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5369), "", null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("89459cef-d17b-44d4-a1d1-b8b2f464794e"), false, null, 0.0, null, null, 12, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5374), "", null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("133893ac-0d3b-4593-a90c-20c5412998b9"), false, null, 0.0, null, null, 51, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5379), "", null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("3683d4ef-047c-4b1a-8815-7782c071aa26"), false, null, 0.0, null, null, 55, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5384), "", null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("eec20026-4573-4f6d-8444-85feb3790868"), false, null, 0.0, null, null, 13, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5431), "", null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("313d83d4-a79e-4351-8d70-0f81ceac96b5"), false, null, 0.0, null, null, 30, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5436), "", null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("b4439726-cecd-4348-9964-6559fa463d4f"), false, null, 0.0, null, null, 53, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5441), "", null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("d5fded2d-9d94-4b10-b319-b451e3491596"), false, null, 0.0, null, null, 14, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5449), "", null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("023c2634-c450-4166-a34d-0fdd4ae0eaf6"), false, null, 0.0, null, null, 27, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5454), "", null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("f58ab34d-0fbe-46f4-8d2e-b24d38545c5d"), false, null, 0.0, null, null, 3, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5459), "", null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null },
                    { new Guid("a76e3f0a-eee5-44ec-85f5-a460c03b22a8"), false, null, 0.0, null, null, 85, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5712), "", null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("e0673fab-3a5c-4fdf-8c95-d183a5ede58d"), false, null, 0.0, null, null, 24, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5332), "", null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("7b614e10-6fb9-4361-a2e1-a1cbf80a5750"), false, null, 0.0, null, null, 23, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5475), "", null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("6b891a4e-4109-4f49-bca6-9fd661206954"), false, null, 0.0, null, null, 29, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5327), "", null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("f2b302ff-f9e3-4430-a12b-85cc2d5b0413"), false, null, 0.0, null, null, 45, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5315), "", null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("861eb0eb-9af9-4ef5-8167-260ef0985d44"), false, null, 0.0, null, null, 39, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(852), "", null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("4626979a-40d5-4311-8534-1f9e03404aa9"), false, null, 0.0, null, null, 22, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5199), "", null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("db992406-3cb5-4892-b31d-9915e092656b"), false, null, 0.0, null, null, 50, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5232), "", null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("eaa53c0d-5747-4165-9dc9-be981d5404df"), false, null, 0.0, null, null, 46, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5239), "", null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("5445ee49-9816-4895-bbba-21d2695d1a59"), false, null, 0.0, null, null, 35, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5244), "", null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("1e17e6d2-2e2c-4e12-8ac3-8f14e3bc192d"), false, null, 0.0, null, null, 5, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5250), "", null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("5daea54b-281c-418f-91e0-ee029cf90e5a"), false, null, 0.0, null, null, 37, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5255), "", null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("f75d942a-4a19-470d-b94e-35dbae4df6e7"), false, null, 0.0, null, null, 42, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5260), "", null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("23fd94ab-be84-4843-9598-7c54821cebb5"), false, null, 0.0, null, null, 26, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5265), "", null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("b6b02430-8c9c-4e86-a92c-28d58c95f538"), false, null, 0.0, null, null, 25, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5270), "", null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("723353ae-d33b-4100-907c-a875ac8e9e16"), false, null, 0.0, null, null, 44, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5278), "", null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("8f5a2142-49aa-4f5c-9aa1-7256ab3f80ea"), false, null, 0.0, null, null, 40, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5283), "", null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("182b338a-c893-4935-ae6a-2ea5de902e8d"), false, null, 0.0, null, null, 41, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5290), "", null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("27d90030-b6a8-4409-a13e-74945222e0ea"), false, null, 0.0, null, null, 36, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5295), "", null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("5e2d8a66-3ba0-42db-9a48-4682a2926723"), false, null, 0.0, null, null, 28, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5300), "", null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("b4e80d40-a572-4984-9b5b-ca8602f60e34"), false, null, 0.0, null, null, 19, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5305), "", null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("2040f38d-88ed-48bd-82af-551e0221cca9"), false, null, 0.0, null, null, 2, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5310), "", null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("edce1d74-04d9-41f3-8cab-bb5b703a3e5f"), false, null, 0.0, null, null, 48, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5322), "", null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("91e25fbf-38dd-40d5-abbe-9cfb612bca3b"), false, null, 0.0, null, null, 20, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5480), "", null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("1c095fd4-2e4f-409e-940d-c3ea486b00fe"), false, null, 0.0, null, null, 38, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5470), "", null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("420855c3-373d-4c60-bf9f-89a4c1744a53"), false, null, 0.0, null, null, 32, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5493), "", null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("ed2d32a3-7e9e-4018-a2fc-0cf325690c1e"), false, null, 0.0, null, null, 67, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5597), "", null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("aebcc22f-537e-4271-9ef5-6306c49a2f77"), false, null, 0.0, null, null, 68, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5602), "", null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("4734fc7e-8e2f-45dc-a652-a5c2796fe47a"), false, null, 0.0, null, null, 69, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5609), "", null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("b050fe6d-0144-4ef7-94f2-3596b35d5215"), false, null, 0.0, null, null, 70, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5613), "", null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("46d3c0dd-6a8a-4e7e-aa77-2c730335de97"), false, null, 0.0, null, null, 71, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5618), "", null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("352360d7-fbdd-49aa-b838-4f9ef3ede709"), false, null, 0.0, null, null, 72, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5622), "", null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("e63dd5cb-267a-4a8a-aeaa-0b99433610e0"), false, null, 0.0, null, null, 73, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5657), "", null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("139e2dd4-4ed0-4d9d-ac83-d281406ef899"), false, null, 0.0, null, null, 74, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5662), "", null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("063fd6d3-4b5b-4634-91ed-3c6aac3c0b1d"), false, null, 0.0, null, null, 75, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5666), "", null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("bc87aaa1-9fb8-4e5d-87fa-9ebd9d2f3108"), false, null, 0.0, null, null, 78, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5671), "", null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("f899397a-6613-4537-a77b-7b99ac8ab9f8"), false, null, 0.0, null, null, 79, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5678), "", null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("95e6ce5e-7521-4ae9-9103-e6b8bded64f0"), false, null, 0.0, null, null, 80, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5682), "", null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("d77a6afb-d349-43cf-bff0-9c6ed65b3831"), false, null, 0.0, null, null, 81, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5687), "", null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("41430e51-6f39-45f7-8c81-1d35468c1436"), false, null, 0.0, null, null, 76, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5691), "", null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("eb95e848-a280-4303-a041-b80084c4e43a"), false, null, 0.0, null, null, 82, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5697), "", null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("acddb6dd-f1d7-49c9-a8c8-4031a796864d"), false, null, 0.0, null, null, 83, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5702), "", null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("66ac8fd3-6c98-4c9b-b472-137cb9b3c329"), false, null, 0.0, null, null, 84, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5707), "", null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("8e3afb36-513f-4ae3-80cb-7c3038dd6a82"), false, null, 0.0, null, null, 15, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5485), "", null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("a73a078c-068f-471e-90a6-3a9e604d76d1"), false, null, 0.0, null, null, 65, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5589), "", null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("b8f0608b-e402-44ab-a402-2adcb518f7cb"), false, null, 0.0, null, null, 66, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5593), "", null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("b4e4ceed-4fc2-463b-96b5-54d1ec9c55ed"), false, null, 0.0, null, null, 63, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5580), "", null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("605dda51-ec5a-4913-a5c5-7e75e770df6d"), false, null, 0.0, null, null, 16, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5497), "", null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("b0154fcc-d0d0-4087-adf5-54989e9c1de7"), false, null, 0.0, null, null, 47, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5502), "", null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("a42ff6c3-4f06-4cce-9ac0-3e2e35dce671"), false, null, 0.0, null, null, 4, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5507), "", null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("6e9bc8e5-2a97-41ad-9d27-ecffc0341d83"), false, null, 0.0, null, null, 56, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5511), "", null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6d4f93de-cdb3-470f-b889-a912a9db29e5"), false, null, 0.0, null, null, 17, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5515), "", null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("730b765d-0c9c-4129-af5b-e9ab4f81e272"), false, null, 0.0, null, null, 49, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5520), "", null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("94200091-9f41-443f-868c-ab2068d74058"), false, null, 0.0, null, null, 7, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5584), "", null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("c082da70-aa14-402f-a691-3c3963474262"), false, null, 0.0, null, null, 21, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5531), "", null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("313476ce-922e-4372-a361-1b2e8b55c300"), false, null, 0.0, null, null, 18, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5524), "", null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("e4d2cbdf-37c3-45d1-8207-adc6a6d2750a"), false, null, 0.0, null, null, 57, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5540), "", null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("20a55ed6-e832-4c2b-9e01-d765863147c7"), false, null, 0.0, null, null, 58, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5545), "", null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("483e464b-d805-45c0-af5d-61fae7de04f8"), false, null, 0.0, null, null, 59, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5549), "", null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("19c9fc85-795f-47ef-94ef-b59165dec3d6"), false, null, 0.0, null, null, 60, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5554), "", null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("35338b1e-a726-44ae-9798-415ed3a2941c"), false, null, 0.0, null, null, 61, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5558), "", null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("f70d2088-ee53-4c5a-ac0d-93b170012a66"), false, null, 0.0, null, null, 6, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5563), "", null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("399ccc41-5e6d-4c40-a494-cad5ddeee0a7"), false, null, 0.0, null, null, 62, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5570), "", null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("4a11b864-eed1-4699-bd23-001674cb3bfc"), false, null, 0.0, null, null, 64, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5575), "", null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("84181e81-6bbb-4193-b42f-9fb5b56a51b4"), false, null, 0.0, null, null, 52, new DateTime(2021, 11, 14, 18, 55, 13, 138, DateTimeKind.Local).AddTicks(5535), "", null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("f2374dee-65a8-4ac3-a0b7-1aaa17573a9f"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("d1b4e769-de95-4a23-92d7-25be1418d80c"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proclamacao da republica" },
                    { new Guid("fd3b7eda-da7a-4e93-b31b-dc6e3926350f"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ano Novo" },
                    { new Guid("0b6b4c1b-5445-4534-b7ba-49d39e1397ee"), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("3afb6ea4-ad62-4843-b172-fa998893a427"), new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finados" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("b158879b-7545-43b8-b08b-2863a5201442"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("cd179d84-4a4f-4cde-a64a-5a9dc6da01d3"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("9cbea4ae-a9fd-4f68-bc32-41521627e780"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
