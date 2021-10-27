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
                    { new Guid("efdccdef-301a-4845-ad95-de232edfdd36"), "Tutor" },
                    { new Guid("5f13f069-ab1d-4b90-b2bf-aca5536dd363"), "Secretaria" },
                    { new Guid("5ebb39c8-acaa-4349-a50b-5906ea70be30"), "Comercial" },
                    { new Guid("feab1760-c2b6-475d-a22f-3d0945391859"), "Coordenador" },
                    { new Guid("2e9e6842-87e4-4862-a4cd-aa0fa69fec9c"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("38166c99-29e9-4432-91d9-3cbf0ce8ff06"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 104, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4390), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("e5b69cf3-6b2c-4328-9238-7381669d0d57"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 105, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4394), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("abf1feaa-fac4-44f5-939c-0cc701cc203e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 106, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4399), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("b1fa0c23-e623-4fba-8a4e-e46d7270fc0d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 107, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4403), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("d0eaf827-80f6-4261-9880-9fe73bfae6f4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 108, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4408), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("bc3a1cc0-2380-44ed-b66c-8ee961e2ea85"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 109, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4415), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("b6b6283f-9dda-400f-bd6c-d534ffc44e32"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 110, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4419), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("d03d257c-90d7-45bf-be7a-f5e8e429f676"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 113, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4463), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("149de4cd-0d09-41ad-b777-c4642f8296a5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 112, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4458), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("f5ea25cd-e96f-4a30-bc81-91672bbef497"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 103, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4385), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("00249ec7-f107-46a3-a9aa-fc437d7f440c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 114, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4467), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("3b0d0314-dac3-4b8e-b655-ff9d692a10f2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 115, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4472), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("d11fe3d7-20fd-49a6-b4e1-bdaad55f26fe"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 116, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4476), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("e0f95ab1-4e8c-4786-8143-fc6259b99e3d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 117, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4483), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("f6c71463-fd03-4c0f-8625-0806b030c7df"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 118, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4487), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("5528592f-6a30-4f50-a82a-dab9f99b033d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 111, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4454), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("f2ba5b8f-585e-4e3a-8e05-9a1039bea9b8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 102, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4381), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("c9417b5c-3eaa-4593-ab06-b776cdee88ee"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 99, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4366), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("baa065e4-9bb9-4487-a913-b8009b12b01e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 100, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4370), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("688d42c6-12fc-4c14-ab82-c68627d43d0e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 83, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4285), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("b79dc3b8-2191-4c57-b87b-255a54ef9916"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 85, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4296), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("6fcc67d5-e4aa-4e32-b772-0fb3a3e4fa34"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 86, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4300), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("ad83869e-8da8-4756-b4a0-8b2183815f0a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 87, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4304), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("4ad31bd8-1b75-42c9-862d-43bf0a4baa75"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 88, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4309), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("816918f1-088d-41cd-9235-7a0f321d0c50"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 89, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4313), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("cfa2bdcf-a0db-405b-bf75-91481dd5edd0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 91, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4319), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("12982756-f77b-4832-a932-24d3491c47a6"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 101, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4377), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("4f7a5e99-1947-453c-afd1-510001dfc62e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 94, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4324), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("236e52c2-bab5-4f0a-861c-3ca2a8085fb2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 90, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4338), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("fe4fb762-7a99-4249-8304-59dcaaf7ad27"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 95, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4342), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("da1d826a-b874-4635-9027-38f49c696bde"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 77, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4347), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("6670d057-2f9c-41f2-8442-09999eabdd38"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 96, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4351), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("d7144ffb-7feb-45a7-ae0f-f39b2a884391"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 97, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4356), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("ccf2f0df-8cc2-4984-b58d-e1e6149a514b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 98, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4360), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("cfd6b176-087e-4819-b1cd-1d51d6ff3558"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 119, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4492), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("1b11be70-7364-4811-a188-b0e51b5fb0cb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 93, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4330), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("daa6671b-ef1e-4faa-9375-ab9fb4a5439e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 120, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4496), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("71c37034-8add-4b03-8ef5-bda5fe513686"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 123, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4509), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("9811aece-5ad0-4cb8-9023-7b255e51033c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 122, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4504), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("58bfee3a-70c0-4ec0-af17-a51a192c5128"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 143, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4607), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("239c0065-0564-4e6b-b3ba-440be36cd66b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 144, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4611), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("d015bacd-2f70-4474-a4ad-90b9efc98e73"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 145, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4615), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("cd865569-d058-4f61-82d4-85f2b05e2e29"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 146, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4619), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("9a1aab5d-0844-4b1b-9c76-7d9dbe4ea7d1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 147, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4623), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("c98c5318-bd3e-45f3-949a-8240045aecb7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 148, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4627), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("2e1414f0-5e66-4262-a55b-790d7816e721"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 149, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4634), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("b8d68aa0-24ed-4e9e-9b9a-34f59b6a5504"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 142, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4602), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("c80eb7e9-fda2-42d5-8039-d006093e3c0a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 150, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4638), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("e17c3f58-bd21-4603-b986-8c0425f59c6b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 152, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4677), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("cf3a288f-1c38-45ec-b891-dcb6d914df4f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 153, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4681), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("293454e4-527e-4228-a4e7-1a8b91e3a5f9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 154, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4685), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("b8faabf1-3bbc-4181-930d-2ebd72fdd18e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 155, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4689), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("e2a55901-d5f1-4e45-a0c5-c8a783a36d47"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 156, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4693), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("20168ad0-2612-47e0-8ae0-11f14cad503e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 157, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4700), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("d941101e-69c6-49a9-b6ce-46bfb6922e6b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 158, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4704), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("7cd549f9-029d-4102-91d8-c5caebec0229"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 151, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4672), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("df166039-bcc3-4451-a8c0-0704da12ea9c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 121, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4500), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("e41a4e16-435c-4167-9fbc-5511b6cbcc71"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 141, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4597), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("f02ae0f7-afcf-46b0-9355-05715bfa5f77"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 139, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4585), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("6a3f8f67-60f2-44a1-898b-d726e0e11d8a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 82, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4280), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("62d2ff6d-e24b-45b9-a9b7-a43560b6bfde"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 124, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4513), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("b82fb884-d8f0-443c-afe9-c3f92ef2c29b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 125, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4520), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("a3ad9141-42f8-4427-9cd4-91a4281f35bc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 126, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4524), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("466ea388-9e4d-4240-85fb-ac13018d4d3e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 127, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4528), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("7571ebb2-9b16-4344-9586-b24a459d497b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 128, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4533), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("644e97f5-268c-4f04-95dc-b9a1f6173824"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 129, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4537), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("928a34bd-4aeb-4324-8008-a0e2c396c93b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 140, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4590), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("069d7e36-00ac-489c-bebf-4fbac1271d54"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 130, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4541), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("4b81a838-e4bf-4eb3-a69b-fe328538efcb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 132, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4549), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("908e4dfe-6a49-445c-935a-9473896329da"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 133, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4556), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("d567a727-21d8-441b-8108-3e9ce6118534"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 134, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4561), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("3d78f9fb-30c4-429a-8bef-18c170289e2e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 135, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4566), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("0aa66eb5-f665-4eb6-a1b8-72f1747d215b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 136, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4570), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("1f4a1b36-c2b3-4c39-9afd-2823533b61f3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 137, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4575), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("087b341c-3b56-4291-8b90-0e07a81bed26"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 138, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4579), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("4f93d39f-7b94-4ac0-8314-472707365b76"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 131, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4545), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("db2cdf9d-1ea5-4349-a48f-63bb3255eaba"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 76, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4274), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("520c0ca7-21cf-424e-92b1-c58e6f7a2e33"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 84, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4289), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("f360caf1-5a18-4f5d-9f3b-96289604e3f9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 80, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4265), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("669cc44f-e353-453b-88ae-4dffca0a2b17"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 24, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3906), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("bcfd4531-8eb7-482b-bd6b-f42136f5a1e2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 9, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3911), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("2dab2b54-ae0d-4738-9cba-87bf464a803e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 31, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3917), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("7cc8ad95-48b4-4c29-9a7c-77afac638234"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 33, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3923), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("f200fe50-ad2b-49ea-9f09-feefa5f36dbc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 34, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3928), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("cfc3eed8-7a4d-4e98-9f74-a10feb621f72"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 10, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3935), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("e0c0ed0a-04b0-499a-b64e-122074cac906"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 43, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3939), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("7658d0d2-9f67-440d-b8b0-90c926aaf1b0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 29, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3901), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("8900157f-9f7f-40a8-99f5-e335a9a9af50"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 11, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3943), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("cc0925af-20b0-4aca-b2e3-2cf1f37a26d2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 51, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3993), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("f6ba59db-4d64-4592-8003-5b47e7261d8a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 55, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3999), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("654234f0-de0b-4e65-b3d5-d0877ba94e2e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 13, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4004), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("c098b32b-bb61-463c-88bb-1eb66aea6a8a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 30, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4010), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("b82de0fc-de05-4a2d-b955-da2be6c7c948"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 81, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4269), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("7c48629d-7bef-4de0-8ac6-81c413a6e8ab"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 14, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4022), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("9374d2f0-9298-43c2-a7c0-20d486df7e13"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 27, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4027), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("fc5e1de5-c50b-46c8-8bf3-533658ce49fd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 12, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3947), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("5a83534d-6346-4e3c-abac-8e6476b0c956"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 3, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4032), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null },
                    { new Guid("1eb104fe-f566-4e25-adef-1ddf7f110c65"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 48, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3897), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("f4c89203-710f-4a86-95a4-64147ff5a20b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 2, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3885), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("8f8d81a0-5099-461d-9ffa-9bc6eecf64c4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 39, new DateTime(2021, 10, 26, 20, 53, 39, 55, DateTimeKind.Local).AddTicks(9344), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("a6ab7186-8d9f-4b8b-b2ec-57d8f3562e82"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 22, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3782), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("a52110c5-16f6-4a88-ad3f-5a2832e0e734"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 50, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3804), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("33eb7aa0-06ea-4aa3-be9d-6b49dd4d31f2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 46, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3811), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("ef9e267c-d6ab-4802-a4a5-54098f77ce2e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 35, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3818), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("038c8fd5-5098-49ae-a5e0-b814d46da328"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 5, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3824), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("3dc32514-aa1c-4f8e-a1c5-46bdc5285113"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 37, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3829), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("7f450100-acd9-4be1-aff9-d87179503376"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 45, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3892), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("2a5d2f52-31d2-4088-9bbe-05f467e26b13"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 42, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3836), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("aea5fe45-7606-4a92-8ab6-2ee7c2e73981"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 25, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3850), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("b9009e78-e464-4e60-870e-e24c5f295fc9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 44, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3856), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("4281e223-e6d8-45ba-98f8-f6f2bf8707fe"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 40, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3861), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("104ac7b5-d9f9-4a2f-af3c-b3e8cff67a2d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 41, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3867), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("7e2f7fb3-be55-46a3-95f9-228b1dfb0586"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 36, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3871), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("61d6e83e-f674-476a-a963-9d8171a0b9cb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 28, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3876), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("65bb836b-f765-40ea-b006-fe51589e82a2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 19, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3880), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("3dbf523f-806d-4d93-b85e-50e66e8ae919"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 26, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(3842), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("78a6c282-fcb3-4d43-adb7-12bf23911cde"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 54, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4037), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("3db508c6-f3af-4d4e-9fc4-b9b360288ce5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 53, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4017), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("151325d3-dac0-495d-8189-616c26186390"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 23, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4047), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("9263400d-f286-4df7-bd8a-ceabb76c5e71"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 63, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4156), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("ae1ff437-d802-476e-9762-e66379fb63be"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 7, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4161), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("58c8191d-59b5-4054-8721-208abaccd9c5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 38, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4043), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("ebb9ddea-8c11-4c07-8303-24562429789c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 66, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4170), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("dce140c6-23b4-4658-a128-83762b10d844"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 67, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4175), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("0b5d75fc-07cc-4d7d-814e-c1cdfc0519df"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 68, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4183), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("a7c5a903-0e7b-4623-a13e-5a273f525d43"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 69, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4187), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("f3d5fb96-fb97-4911-9884-11d21d0deee2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 70, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4191), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("6cc674c2-5c75-42a7-ab07-126885915268"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 71, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4227), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("00f35d14-dc68-445c-b4ca-1cb726e50391"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 72, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4232), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("23db0f1d-65cd-4d13-b114-974ed9dea656"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 73, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4237), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("dfa8596d-1935-47da-9629-de4ae25b66d4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 74, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4242), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("cbf94d12-54f4-4206-8bf1-7a733c10a23c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 75, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4247), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("745048b4-0c9d-4c2b-a835-1fef7bf5c4ae"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 78, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4255), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("866bf490-06f5-4366-83e3-85336ebe83c7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 79, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4260), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("4e6f3158-5b4a-4a2e-9167-cd20729307c2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 64, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4151), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("c0275114-3c18-4334-96f3-40a0e2514cb9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 62, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4146), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("b6bd5c68-0e54-4895-ba39-469ca0bb82b7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 65, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4166), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("208129ed-dfdb-4170-aefc-20981b4a0779"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 61, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4134), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("53efc96c-c3f4-4fe4-b71a-78f328d64190"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 20, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4053), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("3ec08e0e-6ca6-42a4-8007-b1eb10906eca"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 15, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4060), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("cabbee06-6972-484e-9ef2-e7505e11ce86"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 6, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4141), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("fe5b4b88-0042-4726-9399-ee1ac3644182"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 16, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4069), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("39c5c5fc-64d9-4db5-a202-ce4cbbf4e795"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 47, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4074), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("fbba8b88-5ee7-40c0-84d9-a5e3a0ccf03c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 4, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4082), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("212d9e9a-a4b2-4c33-b1df-d3c230d66067"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 56, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4087), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("627f9588-9b53-4c4a-96c3-b4386d2d73aa"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 17, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4092), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("e3161142-addd-43c1-a34a-1af53152910b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 32, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4064), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("3caaa7e7-f3f1-4ec0-9421-51f2a8ec94d4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 18, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4103), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("daf6a0ec-bc30-4f56-98b3-324762cea9eb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 21, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4107), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("768c1995-7020-4dc8-be7d-1f3dba2f50e9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 52, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4111), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("77bb1a0e-2fb6-4c57-ae76-8a2166f7d0ba"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 57, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4116), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("34c19c43-6c08-4455-aa23-b1f2e90bf033"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 58, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4120), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("439806ca-99f3-40c7-b8f5-076e5f98cfea"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 59, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4125), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("c177dd99-54cf-4082-a911-db0f357119e5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 60, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4130), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6c188205-e65e-4165-b855-d8d50813488d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 49, new DateTime(2021, 10, 26, 20, 53, 39, 56, DateTimeKind.Local).AddTicks(4096), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("165567dd-4321-4bf5-b34b-02df776b54c7"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("deade74c-74cf-4801-990f-0d2f65f19a3c"), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado05" },
                    { new Guid("d536f28d-2041-49c7-9651-7626cc1403b6"), new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado04" },
                    { new Guid("6d4ce065-eedd-4ebf-860c-4af9d3dd8932"), new DateTime(2021, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado03" },
                    { new Guid("b23a5498-b3a1-4312-96c1-c5b7c8614082"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("bb8e3964-3e1b-45b4-b4b0-81b1eafd32cc"), new DateTime(2021, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado01" },
                    { new Guid("3d8397af-93f8-4aea-88d8-de3e8ae9d31d"), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado00" },
                    { new Guid("565121a4-5270-4b02-a16f-17f45e7f952f"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado02" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("44945691-91e7-46cc-8272-b011a63c7d1a"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("613c41c5-f70d-482f-b447-d0e7cae9438a"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("651ee52a-154e-498e-b930-07a055ab50ab"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" });

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
