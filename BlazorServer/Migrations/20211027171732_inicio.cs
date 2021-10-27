using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    DataFeriado = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { new Guid("d4193e17-89f9-4bd6-92ef-1d4de933a9a0"), "Tutor" },
                    { new Guid("c2225bce-cf17-4851-81aa-a3e255098f79"), "Secretaria" },
                    { new Guid("8558f444-4bdb-44ca-b9b9-d068c6c35c6f"), "Comercial" },
                    { new Guid("992c8d78-7c4d-44ab-9d4c-bbad9c214dcb"), "Coordenador" },
                    { new Guid("dff3d0ae-0866-4c55-9dcb-80a556a26451"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("7c454249-0e21-44fa-b65d-c99b0fcdf095"), false, null, 0.0, null, null, 104, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8379), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("1e1cbdd5-ab84-44c0-91b1-c9674bf8ce4e"), false, null, 0.0, null, null, 105, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8384), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("6e10f977-4c44-4b02-b1fc-0a87cc26d99f"), false, null, 0.0, null, null, 106, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8389), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("69e0f3f4-d066-4386-bfd8-d6d332169102"), false, null, 0.0, null, null, 107, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8394), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("519d0a15-70d8-47b8-a7f8-c7cd03cbee10"), false, null, 0.0, null, null, 108, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8398), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("d1b263da-9c3f-409a-b05b-9fa6ced0eafd"), false, null, 0.0, null, null, 109, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8439), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("473adcfb-4f83-4487-b197-78b2a1fdc0ec"), false, null, 0.0, null, null, 110, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8444), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("c93b2993-ddde-49db-80e6-127be0f1e773"), false, null, 0.0, null, null, 113, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8461), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("ed823c9a-aa8b-4f48-a9bb-03e4f6265d4c"), false, null, 0.0, null, null, 112, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8456), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("97b2d4cf-3169-49bf-bc4c-fa799a5c9a88"), false, null, 0.0, null, null, 103, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8371), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("2e9e7d97-f99d-4e53-a664-300ba579fde2"), false, null, 0.0, null, null, 114, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8465), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("5e5b3ae5-aa76-4f3d-bb46-cc0e89223c01"), false, null, 0.0, null, null, 115, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8471), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("41226fe3-fb23-4075-ae36-da8d8c132d5a"), false, null, 0.0, null, null, 116, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8475), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("9b9a13a7-1bed-4dc6-9882-6eff56e9beb3"), false, null, 0.0, null, null, 117, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8479), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("91caa01f-ccca-4aaf-885a-e5d1cce40ac1"), false, null, 0.0, null, null, 118, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8484), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("dacc5f27-6348-424e-a65c-4f7099d1799f"), false, null, 0.0, null, null, 111, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8449), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("3f524168-3460-46b9-9fb2-21556553f017"), false, null, 0.0, null, null, 102, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8366), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("62f27f43-5321-4496-80cb-d8fb5db3fd07"), false, null, 0.0, null, null, 99, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8352), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("1c75ce93-a837-42b1-85c5-efb662bb90a0"), false, null, 0.0, null, null, 100, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8356), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("d486c332-c625-4eea-8610-97ab93356982"), false, null, 0.0, null, null, 83, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8267), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("026a8e5e-8ecf-441e-aac1-fe4615a6ce6e"), false, null, 0.0, null, null, 85, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8277), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("7b5022bb-285d-4a1a-878f-9e8e9a0f7549"), false, null, 0.0, null, null, 86, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8281), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("a62c5fc9-6b24-451e-b900-087ea6756c4f"), false, null, 0.0, null, null, 87, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8286), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("99ce9beb-83f2-4c12-9dd1-9aba28d9f100"), false, null, 0.0, null, null, 88, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8294), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("7b15fc4b-02ce-4a7f-80cf-4bf4b9a5d528"), false, null, 0.0, null, null, 89, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8300), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("11b65c05-4c48-4f6a-82b0-891b34deb3ff"), false, null, 0.0, null, null, 91, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8306), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("389302a2-18da-46c6-a4ef-654009e6af42"), false, null, 0.0, null, null, 101, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8361), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("b8ed7c90-b4e3-4aeb-802b-f18dde96d42f"), false, null, 0.0, null, null, 94, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8312), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("9979541b-e9d6-4b3a-9ad6-5eb78a5b9868"), false, null, 0.0, null, null, 90, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8322), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("fba6d2fb-1b66-47f2-81fb-f9e6748bb28e"), false, null, 0.0, null, null, 95, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8327), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("f243fb22-7074-4b27-9353-08241f1cf51b"), false, null, 0.0, null, null, 77, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8332), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("967a024d-98b1-4a26-9add-13af311bd1e9"), false, null, 0.0, null, null, 96, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8338), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("c126bda6-1b69-4815-9d32-32099186940c"), false, null, 0.0, null, null, 97, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8343), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("7f623f3f-b5ed-4814-b21e-ab5f10854b30"), false, null, 0.0, null, null, 98, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8348), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("01012a8f-ce7f-468b-8ddb-3048c64851ce"), false, null, 0.0, null, null, 119, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8488), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("f5915757-7432-464e-9baa-88bdd448ddaf"), false, null, 0.0, null, null, 93, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8317), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("ebe5a8d5-5c1c-44af-a43d-3378f2660a2e"), false, null, 0.0, null, null, 120, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8496), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("abfb87e6-36cc-4275-984d-aa75294431ca"), false, null, 0.0, null, null, 123, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8510), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("7e3a1c20-f089-4e08-a0e9-7706b14401e0"), false, null, 0.0, null, null, 122, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8506), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("a8cf1280-8a85-4ad8-b6c4-6073e1c7eda8"), false, null, 0.0, null, null, 143, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8604), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("4be069c0-49dc-4c50-b539-99f0600c75b9"), false, null, 0.0, null, null, 144, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8610), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("179473ab-a8fc-4c46-9b87-87ddf1819cc9"), false, null, 0.0, null, null, 145, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8615), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("f3841320-9f03-4ecf-88c2-11039ac71429"), false, null, 0.0, null, null, 146, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8620), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("79c2c9ec-f4e6-4f33-8f1f-8723faa98b0a"), false, null, 0.0, null, null, 147, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8624), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("e4541d66-8f10-4030-99b0-75f4039100f6"), false, null, 0.0, null, null, 148, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8664), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("2b9d3bcb-2371-449b-8819-9aadc5fcc55b"), false, null, 0.0, null, null, 149, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8670), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("6d540c70-7f6a-4507-b685-534fece0c608"), false, null, 0.0, null, null, 142, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8599), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("3fbb5350-bbb8-469e-8363-c487d5be7a5e"), false, null, 0.0, null, null, 150, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8675), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("2054fc9c-c621-4795-9cca-574ceb2a4ef1"), false, null, 0.0, null, null, 152, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8686), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("46e5601f-9b04-43b5-883c-976849f840dd"), false, null, 0.0, null, null, 153, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8691), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("bd831940-ed2e-4db9-9b7a-17afe8f69607"), false, null, 0.0, null, null, 154, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8696), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("e0b73490-3dea-4f2b-9823-fced257cd0e3"), false, null, 0.0, null, null, 155, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8700), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("3dc34744-ffe1-47be-b29e-2957495b139c"), false, null, 0.0, null, null, 156, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8704), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("8fffcf57-2d99-4366-a997-6605be9ab9c2"), false, null, 0.0, null, null, 157, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8709), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("4c44530a-d114-42e4-8d80-ba39d68e1324"), false, null, 0.0, null, null, 158, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8713), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("c14c517b-c4b7-42f8-b76d-6b9effea4e36"), false, null, 0.0, null, null, 151, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8679), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("37b27f2a-214a-4cc7-a0f7-07a4a6ffe83e"), false, null, 0.0, null, null, 121, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8501), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("2633557c-f5c6-4468-aa41-a50229880fe0"), false, null, 0.0, null, null, 141, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8594), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("6647caef-7804-4d19-8e93-1a17bd0a9317"), false, null, 0.0, null, null, 139, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8586), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("86512a60-986d-4990-bb1e-444894a42397"), false, null, 0.0, null, null, 82, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8263), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("b67d85ad-7b68-4697-a2b6-32dc18326078"), false, null, 0.0, null, null, 124, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8515), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("8819fb36-38e0-43f2-89d3-a44658d996e7"), false, null, 0.0, null, null, 125, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8519), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("ea0d456e-2084-41b1-b881-b3637c909855"), false, null, 0.0, null, null, 126, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8524), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("1aaa686b-331f-44f2-9d7a-765f1487b49e"), false, null, 0.0, null, null, 127, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8528), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("ca657cf4-ac92-4d79-9bb4-ec902f9749c6"), false, null, 0.0, null, null, 128, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8534), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("25e74293-e597-4999-a388-987dede0b60e"), false, null, 0.0, null, null, 129, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8539), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("4a809fc2-e165-467d-b761-3b7377af35be"), false, null, 0.0, null, null, 140, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8590), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("90fa81d1-0329-499c-bd69-75184701a8a7"), false, null, 0.0, null, null, 130, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8544), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("5afaff9f-e9e4-4555-947c-cafbd57e8627"), false, null, 0.0, null, null, 132, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8552), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("776bf637-aeb1-4e00-8f2f-171e2d7d7cca"), false, null, 0.0, null, null, 133, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8556), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("dbd89227-bdc5-452a-bedc-8453cc4c6ab1"), false, null, 0.0, null, null, 134, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8561), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("334da8c4-f56d-4493-afb6-e5ffc6ff98ae"), false, null, 0.0, null, null, 135, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8565), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("7fce9c88-395b-4385-8c2c-a04e250b34ed"), false, null, 0.0, null, null, 136, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8572), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("f9e0a1ef-1a0e-4b08-b201-bc6a08441231"), false, null, 0.0, null, null, 137, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8577), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("db084b5a-5464-4933-abed-18fc7fcd8dc9"), false, null, 0.0, null, null, 138, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8582), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("1616bf47-259e-48ca-93bd-edc0ab23e68a"), false, null, 0.0, null, null, 131, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8548), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("763cdd54-51de-471b-899b-ece14ee7e82c"), false, null, 0.0, null, null, 76, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8258), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("8080e974-2833-4672-96e3-da8b4bbce3ce"), false, null, 0.0, null, null, 84, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8272), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("d3b9b7ec-f108-41c5-aad5-c44f4739b575"), false, null, 0.0, null, null, 80, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8246), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("dc11fe99-2e18-44e0-b257-732f6817f6d9"), false, null, 0.0, null, null, 24, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7778), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("be89a286-3dda-44cf-b070-3b2cdacd7746"), false, null, 0.0, null, null, 9, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7786), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("13739e3b-7c74-478c-a49a-a705851763f9"), false, null, 0.0, null, null, 31, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7793), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("89b9725f-46e3-46ce-a10c-4b2863db5002"), false, null, 0.0, null, null, 33, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7799), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("47b40643-af97-460e-bcf5-0c2fca3d8af5"), false, null, 0.0, null, null, 34, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7804), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("d1ec4fba-0cbe-45d1-b5cc-c0f7a72d7ad7"), false, null, 0.0, null, null, 10, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7810), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("25ee5bd9-cbe7-4dde-a830-de5057f8f675"), false, null, 0.0, null, null, 43, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7877), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("53e07664-fe93-4b9b-965f-9c8fad2af839"), false, null, 0.0, null, null, 29, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7765), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("d4b84509-e7b1-40be-867a-dea635cf4990"), false, null, 0.0, null, null, 11, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7884), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("0d59fa6a-ed7c-44f2-8cea-2d257e695dee"), false, null, 0.0, null, null, 51, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7898), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("97c7f780-18c1-4116-ba06-e3702a868a47"), false, null, 0.0, null, null, 55, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7902), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("5d968c24-c4dc-4a54-bde6-5f62b6b7bb87"), false, null, 0.0, null, null, 13, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7907), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("69335573-d6fa-46f0-aeac-a8bed267dd47"), false, null, 0.0, null, null, 30, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7914), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("b1e35257-cc43-423c-b2be-c8a551eb74cf"), false, null, 0.0, null, null, 81, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8253), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("2bf7558c-e155-4e99-bb05-f7e76ddbd2e3"), false, null, 0.0, null, null, 14, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7925), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("fe859e7b-f98a-48a2-8b53-fa5b6335c8fb"), false, null, 0.0, null, null, 27, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7930), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("81884748-5084-4040-9a97-501fdbeb4488"), false, null, 0.0, null, null, 12, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7892), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("2fee4293-7dc1-4ac6-8a9e-a019d1c5bef8"), false, null, 0.0, null, null, 3, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7939), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null },
                    { new Guid("bb0bc194-859d-4519-8eb7-3b068df523c9"), false, null, 0.0, null, null, 48, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7758), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("ad075a8e-70bc-4286-bbb3-1c7cc7938d4d"), false, null, 0.0, null, null, 2, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7746), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("33bae683-7c4d-4ff5-8037-64ad5935c08d"), false, null, 0.0, null, null, 39, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(1574), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("6dd95163-0e09-4c73-a12f-5d28a9a5219a"), false, null, 0.0, null, null, 22, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7597), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("c9c76583-013a-40ca-9f59-c405846e5768"), false, null, 0.0, null, null, 50, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7637), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("12a3c659-1a7d-450f-b970-40b23b63144f"), false, null, 0.0, null, null, 46, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7645), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("81a04e23-4f8d-432f-81fd-4b77abe2f180"), false, null, 0.0, null, null, 35, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7663), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("52f23e7b-44ad-44bc-97ef-5220e92895ab"), false, null, 0.0, null, null, 5, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7670), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("9e04b114-4f7b-4949-bed3-f95203d347fb"), false, null, 0.0, null, null, 37, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7677), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("21a17e6b-76a8-4aaf-846b-2c65adcdc8ea"), false, null, 0.0, null, null, 45, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7751), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("bf1d10d6-29bd-4ff7-849f-6a3911b6ac5c"), false, null, 0.0, null, null, 42, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7684), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("d3d59321-5ad0-49d8-a136-2adf83687e1d"), false, null, 0.0, null, null, 25, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7697), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("bcc6fa2a-a0e5-4263-b6c1-9eee5644f84f"), false, null, 0.0, null, null, 44, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7706), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("2adfcdb6-96f6-4188-9968-4119c53a27a5"), false, null, 0.0, null, null, 40, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7713), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("37c8b4b5-1b8d-4e83-8eff-50ad0a1897a1"), false, null, 0.0, null, null, 41, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7723), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("3a80731c-5202-4075-b581-955fb534773d"), false, null, 0.0, null, null, 36, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7730), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("7f5752ff-2007-40a0-8966-7ae395e707da"), false, null, 0.0, null, null, 28, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7736), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("6b81c13b-068a-4a53-aaae-6677ed316ad3"), false, null, 0.0, null, null, 19, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7741), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("9ce66072-8794-40f4-9613-b8ff186aa299"), false, null, 0.0, null, null, 26, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7691), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("ae426d2f-117d-4708-95d3-6315252f83a8"), false, null, 0.0, null, null, 54, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7945), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("49be3214-463b-4995-9e7f-05fc6f5aefa5"), false, null, 0.0, null, null, 53, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7919), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("93ea57a8-bd69-47b8-975a-b06bf2954422"), false, null, 0.0, null, null, 23, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7956), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("9c14f839-ab5b-4adf-af3a-73919598df82"), false, null, 0.0, null, null, 63, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8084), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("b5fc2c9a-319c-4230-bd78-3f2203b92d98"), false, null, 0.0, null, null, 7, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8089), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("91521ce3-989c-42b6-af78-36d02d445eb0"), false, null, 0.0, null, null, 38, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7950), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("7e4e8b78-f015-4105-9dbc-b8a5a1f70953"), false, null, 0.0, null, null, 66, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8098), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("35d66e6a-444b-43c5-b7ad-efa7affccf1c"), false, null, 0.0, null, null, 67, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8103), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("9105b649-2afe-4922-a145-14fc4769c181"), false, null, 0.0, null, null, 68, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8190), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("2fdc1ab4-8a83-4236-86fe-44e34cfd255e"), false, null, 0.0, null, null, 69, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8199), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("e652e8e2-77ed-4807-8c7f-81250fa151e5"), false, null, 0.0, null, null, 70, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8204), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("88a7b9da-945b-468d-bf2c-bf6d6542bbe7"), false, null, 0.0, null, null, 71, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8212), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("8015ecc9-6248-4ae2-854f-819c4171927a"), false, null, 0.0, null, null, 72, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8218), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("c4da338c-8800-4392-b894-41d0e88e0c73"), false, null, 0.0, null, null, 73, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8223), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("0e5437d8-bcbf-442c-a11d-99a842964c87"), false, null, 0.0, null, null, 74, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8228), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("348afa95-a7b5-41f5-b316-c6da5b407e05"), false, null, 0.0, null, null, 75, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8233), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("574e9a31-92bf-421e-8033-1ca0d1740c28"), false, null, 0.0, null, null, 78, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8237), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("39e6f2b7-a450-4f6a-819e-a662bc007416"), false, null, 0.0, null, null, 79, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8242), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("87eb69a1-b017-4e8e-99b0-cf5db9df9ab9"), false, null, 0.0, null, null, 64, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8077), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("56a7fa72-d7d0-4722-95f9-879e2af10e92"), false, null, 0.0, null, null, 62, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8073), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("1da89a64-5c91-40c4-aee0-bcd0fffbe116"), false, null, 0.0, null, null, 65, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8093), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("364d9fce-467c-4666-bd0b-615fc1398df3"), false, null, 0.0, null, null, 61, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8060), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("a75b888c-75a6-4e1f-9a15-8c17e7583390"), false, null, 0.0, null, null, 20, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7961), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("aa0bac48-353b-4385-abdb-a78fc9e28b2e"), false, null, 0.0, null, null, 15, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7967), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("cb9511e2-50c6-4822-a3b2-1439fe618375"), false, null, 0.0, null, null, 6, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8064), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("c7cac34e-e6a6-42d7-9f8d-a7ea90fdfd98"), false, null, 0.0, null, null, 16, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7980), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("e10b4efe-bfbf-454f-936d-fdefa291947e"), false, null, 0.0, null, null, 47, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7989), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("7261d745-903e-4d5f-8f1a-da78d1526b56"), false, null, 0.0, null, null, 4, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7994), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("7f1c230c-e795-46fa-9a3f-237c4b2645bf"), false, null, 0.0, null, null, 56, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7999), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("e1712b86-072a-47d9-86e4-7fadf5bfc4c4"), false, null, 0.0, null, null, 17, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8006), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("c1197a40-ec8c-4abd-89f5-c176ae30a788"), false, null, 0.0, null, null, 32, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(7973), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("5c2d01d7-538d-453f-9a9c-c7651741a8ed"), false, null, 0.0, null, null, 18, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8018), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("9003c034-af38-4ad7-8a7c-bbae427adb18"), false, null, 0.0, null, null, 21, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8024), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("dcb027ee-e328-479c-a659-52ae8f59f03a"), false, null, 0.0, null, null, 52, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8029), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("4d2e0042-7963-46be-9cbf-a0dac44dd1c6"), false, null, 0.0, null, null, 57, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8037), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("e4052b0e-3bef-450a-a8b1-fc74f2e8ced3"), false, null, 0.0, null, null, 58, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8043), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("b5a0eb19-7f54-4fcb-8228-f916e6b24872"), false, null, 0.0, null, null, 59, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8048), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("b1904d9e-c1b3-4445-b21f-0a3a2ed9be5b"), false, null, 0.0, null, null, 60, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8054), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("4dd85052-c3e8-4ec4-b67a-e370d7f65897"), false, null, 0.0, null, null, 49, new DateTime(2021, 10, 27, 14, 17, 31, 507, DateTimeKind.Local).AddTicks(8012), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("9f0e9b0b-c7dd-453c-9aa1-6cc76ede18e3"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("4f89d54a-460b-463d-8636-18f1536e7781"), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado05" },
                    { new Guid("2b497c97-6d4f-4a2c-9b10-00afbc8685fe"), new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado04" },
                    { new Guid("0470b36a-8f90-4196-accd-f4f64e5e1631"), new DateTime(2021, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado03" },
                    { new Guid("60b810a3-30f5-4aee-9296-2fc0aed18777"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("984d8680-49b3-4142-b09b-e3c3df25bb7c"), new DateTime(2021, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado01" },
                    { new Guid("304ebf26-2b55-457d-9412-70e7a700dda4"), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado00" },
                    { new Guid("a658cacd-c9db-4801-a307-e7c93605c3e2"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado02" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("321badd9-5c39-42f9-838e-0b6bacd3a0fb"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("70f28054-9755-4e0d-9fd6-d974175044b1"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("b5a4189e-fd98-4d12-88b9-271397280744"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" });

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
