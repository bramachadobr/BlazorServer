using Microsoft.EntityFrameworkCore.Migrations;
using System;

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
                    { new Guid("496869c3-4f5f-4bc2-9c9a-ae8b34d2fabc"), "Tutor" },
                    { new Guid("eba2cf54-ecfc-4f7d-a81d-811ce6e68830"), "Secretaria" },
                    { new Guid("32fd915b-063f-4e8f-b239-3ce50b9230e3"), "Comercial" },
                    { new Guid("1677b133-384e-401f-9630-ec7d9fc60a59"), "Coordenador" },
                    { new Guid("9f8f33d1-94c9-49c9-a35f-440bce9a87c5"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("cb2f0839-b9b5-4fb3-8f6b-9afc5d88b7f8"), false, null, null, null, 104, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8903), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("6b08d06d-f270-4b0c-b34e-19dac6e09cb2"), false, null, null, null, 105, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8907), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("41cf0b64-4769-4f2d-9025-b2e4eb0f0c39"), false, null, null, null, 106, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8912), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("d8ce8bf3-44e9-4584-a267-89c4b45485df"), false, null, null, null, 107, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8916), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("b772a677-c8ab-4b02-b326-55bb221fb107"), false, null, null, null, 108, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8924), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("78239da9-8a51-4f5f-86f1-178ed7021bd7"), false, null, null, null, 109, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8929), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("d19aa01f-eb5d-4b55-bd22-7ba0f5f434dc"), false, null, null, null, 110, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8934), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("17feb1e5-8b6b-492b-8794-25791bcb3da4"), false, null, null, null, 113, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8947), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("6974312d-09bb-470b-b97c-9ccd5e5df49b"), false, null, null, null, 112, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8943), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("51d11f6f-2fc8-4a76-816e-abe40ea22e40"), false, null, null, null, 103, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8898), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("d409636d-3c47-4853-8d73-ee0506e9810c"), false, null, null, null, 114, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8952), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("3d4920b8-9a5f-46c3-b052-39aeacc2821d"), false, null, null, null, 115, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8956), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("fe53f049-0dda-4a7d-bc1c-b86b7ae6afc2"), false, null, null, null, 116, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8994), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("6fbf841e-8970-4ce5-88b3-eda8396d0037"), false, null, null, null, 117, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9000), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("579a488b-9984-4ab6-bf00-d736d85636ae"), false, null, null, null, 118, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9005), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("ae2d2e4f-7e9d-4b93-b2eb-cd77fbe72935"), false, null, null, null, 111, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8938), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("4d1f33e9-ef0a-4be1-b55b-77c1b7eb371c"), false, null, null, null, 102, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8893), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("d3b4f040-e09d-4b78-a2e2-788b9503c274"), false, null, null, null, 99, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8876), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("adee6549-804a-4820-939e-e1b7eeb0565d"), false, null, null, null, 100, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8884), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("2ff438dd-207c-4d18-9e73-3a3df133a852"), false, null, null, null, 84, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8801), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("8e78b276-7a28-42f4-b5b0-5712ef786bd4"), false, null, null, null, 85, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8807), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("5ef05dc9-2c8c-40b9-8093-3f2ddaafea93"), false, null, null, null, 86, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8813), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("8fb60c73-00ce-446f-a8b5-276c7e31e0e6"), false, null, null, null, 87, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8818), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("5e0ada3e-e45d-4653-85aa-1bae7ed94ff2"), false, null, null, null, 88, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8823), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("677bd6fb-f0db-4bc9-9736-07287e6d0139"), false, null, null, null, 89, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8828), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("4cd58bc1-e51c-4185-ba86-ada154f87a5c"), false, null, null, null, 91, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8832), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("d95175bb-8518-4be5-9aa4-9fd45f60ed11"), false, null, null, null, 101, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8889), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("63842210-2055-47ef-a70c-f302ae19268c"), false, null, null, null, 94, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8837), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("1e1e6eb0-702c-4933-86ef-c228412fd363"), false, null, null, null, 90, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8849), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("afcfde8f-c285-457b-84a8-80f8c194cc4e"), false, null, null, null, 95, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8853), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("d2dc555e-d0e8-4154-b4d7-151ba7f8d57d"), false, null, null, null, 77, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8858), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("35f964b9-e422-4c9e-a166-260ec0b0bc64"), false, null, null, null, 96, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8862), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("a8f05b31-84dd-4465-812a-1b0383046993"), false, null, null, null, 97, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8867), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("a32b76b1-9035-46b2-9d9a-fe4db729e119"), false, null, null, null, 98, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8872), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("9b549916-e79a-43fa-99d5-0b9643ffbf55"), false, null, null, null, 119, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9009), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("3fad560a-a7aa-4491-897f-9c0388a960f2"), false, null, null, null, 93, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8844), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("e86cb9c7-85ca-4ef5-9157-d858137296f6"), false, null, null, null, 120, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9014), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("52261f3e-e18b-4567-a167-29021d890fa7"), false, null, null, null, 123, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9028), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("d622c959-4a3c-4c15-a7ca-8f7346a8f37d"), false, null, null, null, 122, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9023), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("b375c925-6b38-4933-9c64-bd032c2c4b35"), false, null, null, null, 143, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9132), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("c62aacb1-da32-4368-86e5-393081eb31c0"), false, null, null, null, 144, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9137), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("3f3ec614-6090-4607-a340-cbc7906dab8c"), false, null, null, null, 145, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9142), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("769e07f0-b8a6-4d0b-a69b-8b2f12ed3383"), false, null, null, null, 146, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9147), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("ff89dabd-9a49-4633-b1de-279c4b512c4b"), false, null, null, null, 147, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9152), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("28f79feb-e148-4fa6-bb97-c1c1d37ad1ad"), false, null, null, null, 148, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9160), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("ca63ee31-d211-4473-887a-f62b847f7aca"), false, null, null, null, 149, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9165), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("335ae038-cf85-40b8-8f12-51931979df0a"), false, null, null, null, 142, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9126), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("3f6ba8cf-1543-419f-ad60-d13cb06b408e"), false, null, null, null, 150, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9169), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("a24d198f-efc7-4194-8a02-3ec8c178127e"), false, null, null, null, 152, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9178), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("fa637094-8776-415a-b811-4aa37751ba16"), false, null, null, null, 153, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9183), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("6200f935-8974-4817-9221-23346894e9bc"), false, null, null, null, 154, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9187), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("a3e7e575-a9f0-4d84-bb65-47f1c7585a17"), false, null, null, null, 155, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9192), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("b2c7cdae-cfcf-4f7f-ad7d-c52bf85d512e"), false, null, null, null, 156, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9199), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("6d5d2b11-e247-43fe-9ec1-1d9da215cb05"), false, null, null, null, 157, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9234), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("28e4a120-0485-4a85-bf81-a8ffd2cf46ef"), false, null, null, null, 158, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9239), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("c7e75968-808f-4093-8ffa-b3d8136a35c9"), false, null, null, null, 151, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9174), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("481ac085-27e6-4de6-bf11-067528d033ab"), false, null, null, null, 121, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9019), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("16a9da81-cb5f-4348-94e0-2ad6795bc1a3"), false, null, null, null, 141, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9121), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("ae71c842-7b20-4b4c-9652-de5df14c2b99"), false, null, null, null, 139, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9109), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("eb356426-a9ea-4860-963b-b26f9476acb7"), false, null, null, null, 83, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8794), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("19fe23bf-98bf-4c3f-91a1-b35834a0fd12"), false, null, null, null, 124, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9035), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("4cda752e-bba8-49a3-bed3-175ebb7e0be3"), false, null, null, null, 125, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9040), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("f3e7ef6e-6d07-45f6-8540-f82b1248987f"), false, null, null, null, 126, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9044), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("491ef176-ae1c-464c-8b12-a8c4cd8dc9a5"), false, null, null, null, 127, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9049), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("eaead136-b29b-4cd1-9abd-32ecea8583d3"), false, null, null, null, 128, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9054), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("a80425ae-9c87-4a18-b216-a355360da4b2"), false, null, null, null, 129, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9058), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("4dc6567f-bee9-4500-b4f0-095ed6486e1d"), false, null, null, null, 140, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9117), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("dd8f1296-cdd7-4682-a58a-8c25084f7139"), false, null, null, null, 130, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9063), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("5f30dcbb-0283-4090-8f2e-40dd357a7b14"), false, null, null, null, 132, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9075), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("f4cdffa1-d3b4-471b-970f-343a4a0a0bd9"), false, null, null, null, 133, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9080), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("6a5c280b-3ec4-40db-9c23-4d3e4393d04d"), false, null, null, null, 134, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9084), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("6ee63c73-aa6d-4ead-b1c8-a7354c62f1c2"), false, null, null, null, 135, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9089), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("1e450daa-d71c-4757-bfac-6a7bc751df65"), false, null, null, null, 136, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9094), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("5be8556f-42ae-4591-a57e-9d7dd0c66cf3"), false, null, null, null, 137, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9098), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("474ed4e9-415e-4d80-81a2-b94367ca5e66"), false, null, null, null, 138, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9104), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("4feb08b7-efa4-482f-bbdd-95d8ccee3dca"), false, null, null, null, 131, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(9068), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("67041274-0fdf-43ce-8c7d-6db602670378"), false, null, null, null, 82, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8789), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("8249c209-d67e-4439-82c8-a54d1bf4f8b6"), false, null, null, null, 81, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8779), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("478ede76-5a84-4225-841f-74ade11233b2"), false, null, null, null, 3, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8542), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("20c6b6e0-f06b-4590-964a-37c7e1df10c5"), false, null, null, null, 9, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8400), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("6abc60e0-7bdb-4917-854c-c8b639afeae6"), false, null, null, null, 31, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8406), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("3099706e-64f4-4ed6-bf11-1aedba2b3e2a"), false, null, null, null, 33, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8411), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("886c92b0-cc3b-4a45-b5e8-089e15723f80"), false, null, null, null, 34, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8419), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("b193f695-d90b-4b67-9234-0cd695337633"), false, null, null, null, 10, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8425), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("a1ee3dcd-4832-4bd7-a8bd-38caf4095852"), false, null, null, null, 43, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8430), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("cb36a9ba-98f0-4991-bb95-eb56f4484a95"), false, null, null, null, 11, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8435), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("4b6e7d3e-faee-4cc6-aff4-d8c871b406f0"), false, null, null, null, 12, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8440), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("298b1cf0-dceb-4978-9a64-a02f2249f7e9"), false, null, null, null, 51, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8444), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("3384d4c4-3144-46eb-bb5a-7d7d32079fb4"), false, null, null, null, 55, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8448), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("65690e1a-249c-494f-a7b6-d28f7e85b3ac"), false, null, null, null, 13, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8514), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("983687fa-324d-4740-be1a-e1c667ff5d2e"), false, null, null, null, 30, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8522), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("efbae2ec-df98-417d-ac51-ae617fc7575f"), false, null, null, null, 53, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8527), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("56d170b1-6b09-49ec-b569-e1d7c544ea53"), false, null, null, null, 14, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8532), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("c7cc16be-5278-4f84-a945-d274582837f2"), false, null, null, null, 27, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8537), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("ec4ae8b1-c134-4240-b919-c8b31ecfbcba"), false, null, null, null, 24, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8395), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("f6b16a1a-02b9-4841-92a8-bef949f55c2d"), false, null, null, null, 29, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8390), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("dcde7e29-842e-4da6-aaa2-ce4e600c0b48"), false, null, null, null, 48, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8386), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("11c0b584-b024-4819-a199-a1bd126b7d54"), false, null, null, null, 45, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8381), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("494b34a7-25e0-4254-9525-ba07a54367d7"), false, null, null, null, 22, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8153), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("64e6655f-6cbb-4041-b802-c3a3789f2ec3"), false, null, null, null, 50, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8280), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("26f02b31-deea-4300-9896-5337a2044dee"), false, null, null, null, 46, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8287), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("b262b620-a3d8-442b-b3ee-81d44a519a26"), false, null, null, null, 35, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8293), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("911825ef-4473-4055-b0f6-407ccd7ea77b"), false, null, null, null, 5, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8299), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("c6828a4c-dd91-47dd-9be2-faa0ba4317ad"), false, null, null, null, 37, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8305), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("84335af1-3b57-4dea-af1d-f7dcb6b275e9"), false, null, null, null, 42, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8310), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("f53b9827-9a91-496a-85d5-d511f93cec2a"), false, null, null, null, 76, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8784), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("95513b5a-3366-4fa6-a9db-81e2c5c19c55"), false, null, null, null, 26, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8330), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("2c84cfce-cc97-4863-81b6-5f3a154de80e"), false, null, null, null, 44, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8340), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("16f37c72-746b-49d2-b15c-4d7363e2b2fb"), false, null, null, null, 40, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8345), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("a1c40dad-73f5-44ca-bc49-1b18d0724db9"), false, null, null, null, 41, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8351), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("33d30ac6-d264-4916-8dbb-bc25a1ea626d"), false, null, null, null, 36, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8356), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("0430df7c-b52c-4398-bc00-ac651d014094"), false, null, null, null, 28, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8361), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("abf66ca5-41c7-487e-ad91-8e82e1abebe3"), false, null, null, null, 19, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8367), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("c4e1d5f6-3863-4e64-b295-b33d27587fe1"), false, null, null, null, 2, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8375), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("610c832b-1bdc-43d0-8d85-b9a9b132605e"), false, null, null, null, 25, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8335), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6a2413b3-5f00-4aa0-bff5-9a303251f4c0"), false, null, null, null, 54, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8547), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("1cef62f4-6205-49a4-b76e-719fe9e404b2"), false, null, null, null, 38, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8553), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("cf0f0f3d-5511-4ba4-8630-9ed8cd88c339"), false, null, null, null, 23, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8558), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("271a8f6b-291f-48cb-90a1-9a8d530c5144"), false, null, null, null, 63, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8666), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("58415de7-4fcc-4277-b29e-eb2cba823533"), false, null, null, null, 7, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8671), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("c645463d-86e6-431f-9b65-850affb7c88c"), false, null, null, null, 65, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8675), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("3a8914af-ce35-4ba7-99fb-42fe821b277a"), false, null, null, null, 66, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8680), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("06841848-09b8-41f8-b341-80fc20bb881a"), false, null, null, null, 67, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8687), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("dbf8ffe1-44cb-4c60-a152-975a10a830d7"), false, null, null, null, 68, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8692), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("53835cab-4bfd-45e8-9444-28ba7c923a62"), false, null, null, null, 69, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8697), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("2f32ba63-8243-47c5-89bf-08a804e07732"), false, null, null, null, 64, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8662), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("09385b3e-448c-42f0-b2dc-f381c4ee31bb"), false, null, null, null, 70, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8701), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("f1238f6a-21f1-457f-812c-8beee7c29110"), false, null, null, null, 72, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8710), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("f206e275-c629-4719-9f9f-fcada7bb9c42"), false, null, null, null, 73, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8714), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("8693cd38-c7af-41b0-b4e0-fccfd181e42f"), false, null, null, null, 74, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8751), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("85c07e39-f035-44d1-bd5d-06d4f99aac35"), false, null, null, null, 75, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8759), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("af973e9e-8072-4cd5-bff0-782df3c1b656"), false, null, null, null, 78, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8765), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("7733d054-9b53-4b99-9fa5-027f5032620a"), false, null, null, null, 79, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8769), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("bc0e9aa9-3dfe-4d05-8e69-8722eac8fe08"), false, null, null, null, 80, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8774), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("491dc553-3695-4037-9ab2-90572d6ac0a8"), false, null, null, null, 71, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8705), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("d69a83fc-b88d-4e38-a2d1-13499c9ea7b1"), false, null, null, null, 39, new DateTime(2021, 10, 20, 21, 38, 30, 385, DateTimeKind.Local).AddTicks(151), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("8614a2ff-71fb-480e-8f6e-1100d84dbb55"), false, null, null, null, 62, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8657), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("243f10c6-37a7-4791-8519-9f7007b4844e"), false, null, null, null, 61, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8647), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("14ffbca7-d2a0-4acc-a23e-cf29f33d52c9"), false, null, null, null, 20, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8566), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("563e99b3-ce69-496c-9e63-9c27ff11348f"), false, null, null, null, 15, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8571), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("8fad249b-d6b0-4d38-aa2b-179fc8d28eb6"), false, null, null, null, 32, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8577), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("28263b1d-332d-4ddf-ad2d-57a174775d39"), false, null, null, null, 16, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8582), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("7a3deba9-9e4f-4b42-a0fd-07c0561ec8cf"), false, null, null, null, 47, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8587), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("36db8abb-e12d-46ed-97ce-9a27738926b6"), false, null, null, null, 4, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8591), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("6086736c-d497-4c64-a358-85ca6c5992c2"), false, null, null, null, 56, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8596), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("bf928419-4a88-4f8a-b782-6c0fff65e263"), false, null, null, null, 6, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8653), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("f557edb4-2255-404d-9dea-ecfba17762a5"), false, null, null, null, 17, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8601), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("867785db-f060-4f30-afd7-8e546feb614e"), false, null, null, null, 18, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8613), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("3fa4bde4-5489-4ed7-84ad-690d0c078a7d"), false, null, null, null, 21, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8618), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("2681b1ad-5e76-4664-aae9-04575ff21ac8"), false, null, null, null, 52, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8623), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("7b035088-f42c-4469-8cce-a796a4f8f130"), false, null, null, null, 57, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8627), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("45473d9d-7a27-4a56-9f64-edb7f890ad1a"), false, null, null, null, 58, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8631), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("fd6087d4-f2f9-4a7f-9db5-3f52c9786081"), false, null, null, null, 59, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8635), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("13eb0df2-0900-4081-b77b-a85e418917e1"), false, null, null, null, 60, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8640), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("855229da-8062-4bc5-a80a-6a2b9718ebd3"), false, null, null, null, 49, new DateTime(2021, 10, 20, 21, 38, 30, 386, DateTimeKind.Local).AddTicks(8608), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("3aa1abb7-be38-4a5d-952e-5e2d72663d31"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("a542f40c-8e41-4b0d-9db2-61b881433d26"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("e765e564-7df0-417c-a171-1ccef5c761a8"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("07c2dffd-568b-4dfd-a65c-ec39246708bc"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
