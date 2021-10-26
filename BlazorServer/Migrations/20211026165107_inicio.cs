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
                    { new Guid("13ff71b0-076a-40f9-a2e5-7aa215fb104c"), "Tutor" },
                    { new Guid("4bdcc184-848a-41f0-8862-2161122cd40a"), "Secretaria" },
                    { new Guid("bdfb2330-634b-4581-bed2-4d2a096ccf18"), "Comercial" },
                    { new Guid("6f963393-49e6-425e-a90a-0f0ac03fee13"), "Coordenador" },
                    { new Guid("d6f1e005-ab56-463f-bb6f-1da0a107136f"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("02c3d488-49ac-4823-a475-3c16b17d5600"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 104, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9497), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("49ea7681-eab6-4e3b-a56a-345aaed8ec06"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 105, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9502), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("86d2ae0d-89cd-4d2d-8f2d-cad7ec70a0e9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 106, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9506), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("59e3e905-614b-4638-841a-cdb0aa0ef2a9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 107, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9511), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("86cfa125-1bf6-4c30-a498-32c5824a48fe"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 108, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9518), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("28011921-e5ca-424e-ac7d-919ad6c99d72"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 109, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9522), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("157d4830-fd56-43b4-b369-07b6a44d0ebb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 110, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9527), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("87961018-5118-41e8-9ef2-9fe8b7054063"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 113, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9540), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("f5046b63-7a16-4f3a-94fd-09b6d7229657"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 112, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9536), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("9c5f94a4-b616-4d55-99ed-57960c739855"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 103, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9491), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("6ea278fe-ccb2-472d-971b-22067422d7b0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 114, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9545), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("7a3861a5-61d7-4b69-a767-dc1559601a47"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 115, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9550), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("2d87d27b-581a-425e-af16-d0ba5980cf5b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 116, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9557), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("74b6d2cf-f866-4851-9180-1624f55f2fa6"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 117, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9562), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("0803c5b9-6e7b-4d31-9e58-19da79a09ae2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 118, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9566), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("60ebd343-1f76-4d1a-8fbe-1b4b553cc31d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 111, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9531), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("d46cb72d-bce5-48ef-893e-5904c5f6acf2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 102, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9486), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("db9e2708-b244-4177-a04a-f95790750c6f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 99, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9467), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("17cd4eb4-8101-4be9-9c2b-f8e6a446310e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 100, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9475), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("45d9e076-c5b5-44d0-bfda-3f7ef62fae0d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 84, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9358), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("6c54cb86-8edb-4978-aec4-e8c205e3a593"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 85, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9363), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("11220ee0-0884-47d5-8c24-10cce0500ad7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 86, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9368), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("8e684ee5-802a-4747-b7c0-76dd10685dc1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 87, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9374), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("44bdddb3-0a39-4edb-82b1-1b7526313a10"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 88, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9378), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("cc2894ae-7e43-4b66-a2eb-c876ffbec09c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 89, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9383), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("62488d4d-bc5c-41ed-86a6-14988377e99e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 91, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9387), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("aae856e6-2e92-4a5e-9777-c4db9257204b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 101, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9481), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("1bf44d0a-3c3c-4bb6-af45-b4e0d0445c7f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 94, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9391), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("378eee10-6365-41ca-b7a6-711241a8c81a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 90, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9404), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("364c62f0-726e-4207-a9c4-09363df46898"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 95, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9442), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("057d44ca-9282-414f-b6b1-f3726fe04516"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 77, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9447), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("80a4672a-1cb0-4905-8efc-37c86e794637"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 96, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9452), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("77a1fa44-8ef2-442e-a54d-3244fff8f9a2"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 97, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9457), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("b9db93bf-4f75-4116-9383-5fe1482f21f3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 98, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9462), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("9e1f6654-39f5-4d96-944c-edd979612a40"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 119, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9570), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("d7efa4ce-1237-4695-bbeb-37843c122836"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 93, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9399), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("a5bd1742-3dce-447c-ab23-bb1d17349a41"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 120, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9575), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("8fc71085-d50b-4211-b552-9977f3b007d5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 123, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9590), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("60d7ea82-1e54-4267-afaf-cc84a4f33109"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 122, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9585), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("cdc6fab9-d889-4c33-9fb4-bf617cd3cd49"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 143, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9729), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("afc39ed5-9551-4fb0-98ed-feabba30b99e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 144, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9733), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("25bc8c6c-1b63-47ed-80e0-0404f91af939"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 145, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9738), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("fcc4a9f5-58d3-4970-a649-9481ddc76c02"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 146, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9742), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("14d902e3-05dc-42c4-b76d-16099c0635bf"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 147, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9747), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("9c4cc7f4-9648-4a3c-b5e7-4fdb07095e75"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 148, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9753), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("0223c902-66f3-4969-b550-69912746a17b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 149, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9758), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("95e6cfbd-3795-4d57-b6d1-dc642c945b21"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 142, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9724), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("bf72d0e7-7f7f-449d-9115-1207f6328708"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 150, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9763), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("604328a5-6fed-4f1f-8122-052f50f15b6e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 152, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9773), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("a79787d6-2d88-4a9c-9f14-27e3006cf9dc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 153, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9777), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("b07cab46-fe70-4046-93d8-1a64292d6e49"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 154, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9782), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("8f3615ae-db94-4f1c-994f-42d1d45b8aec"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 155, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9787), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("96b67306-4023-48bf-8acb-4c899c481c12"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 156, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9794), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("9f68899f-91b2-4dd2-9f10-5f60c61d7779"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 157, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9799), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("97c46125-a633-40b0-b77d-6cfb6ea755c9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 158, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9804), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("5868b8c9-7c9e-43dc-a3f1-30d2700ab486"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 151, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9768), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("815f1290-cc3e-42e7-bd13-ec0585b163ee"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 121, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9581), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("7452be88-0c4d-4282-80fd-6df1fd51e6f6"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 141, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9720), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("ea839794-e661-4841-914b-48a62833909c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 139, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9709), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("1678d3c4-37c9-4531-bb0a-ff8eef877f91"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 83, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9352), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("e5fb9ed9-59c7-42fd-9aef-9ff8818a18db"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 124, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9596), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("7c52201a-def5-4318-9d86-dd60d358c38d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 125, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9601), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("40deb0e4-ff39-40f9-8548-4539ead74224"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 126, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9605), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("fdf32ef8-6b2b-42f5-983b-7fec1afef5b1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 127, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9610), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("d032c954-cbb1-4cfc-a65b-529e9cc02853"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 128, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9615), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("d65dda6f-bb01-4efc-b48b-99d0cf927b4f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 129, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9620), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("56ee6731-809d-4365-8ac1-5d420a31f235"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 140, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9716), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("31b328d8-b1cb-4a96-b6ee-3e7860d00f7f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 130, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9624), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("cec0278d-f570-48e8-b7c6-9a053020a4dc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 132, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9636), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("80a946b4-2e05-4110-b6f0-25bf587490d8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 133, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9678), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("ca83d7a7-74ae-43cd-b6da-530a1f646a88"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 134, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9684), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("300b1caa-c50c-4db1-a309-60035d321c4c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 135, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9689), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("fdab9da3-d69f-4482-8241-103a5bc4b131"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 136, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9693), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("c44e461d-2b9f-40aa-9dd5-7198dc2119cb"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 137, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9698), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("6a84d00a-3b94-440a-9de1-8df28ed09854"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 138, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9704), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("0d63d5e7-404a-4e70-8b88-3a625f09e25d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 131, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9629), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("dbf02fd4-41d8-4476-906f-41d999182eab"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 82, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9347), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("500cad61-9d40-4ea2-b0fc-fc70938b5211"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 81, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9337), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("6a462f2f-9ec6-4a93-abf3-8452b13c1a66"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 3, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9091), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("79876892-6589-4d6f-848c-0642167b5745"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 9, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9010), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("40e5d42a-dfa3-404a-948c-4240f9a304dd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 31, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9017), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("046d3d9c-af00-425b-b5f6-78f486462bfd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 33, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9021), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("3c69aac3-2f04-4115-a863-55755b2b3935"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 34, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9028), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("f9742e48-3833-45b2-8315-7c45a49d3962"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 10, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9033), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("ea467af9-2d71-45ad-b29d-ed3e029218fd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 43, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9039), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("02c46090-eb59-4e57-9a8c-7cc1623a3341"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 11, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9043), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("554a56cb-8add-42a5-b45e-d04fbe473db1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 12, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9048), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("1fa0ca87-4087-4338-90aa-85b8fe6ba91d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 51, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9053), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("23850c83-40f9-4e67-a586-6abbeee2a46d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 55, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9057), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("c4daa869-5a9a-4e2c-aae7-f90cde820274"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 13, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9061), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("f195502a-024c-470c-9e92-a4e150beae6d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 30, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9070), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("82301ea6-4958-4cdc-a271-0f5a66a34b6e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 53, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9075), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("b5fa3301-c7a5-42c7-a652-1712a9b8119a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 14, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9080), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("5e0ce959-38bc-4870-8742-59cd72246867"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 27, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9086), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("ad57f0f2-9f32-4440-b412-b69f43306e96"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 24, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9005), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("c213b73b-1273-4ee9-ae5b-616cd8b966c1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 29, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8999), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("2038015b-8851-4841-990e-dba917e4210c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 48, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8994), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("3ab3eaca-10f2-463d-8a7c-1db56027f96f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 45, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8988), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("0c11b6d8-d27a-48a1-a9ed-d759384cc0ae"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 22, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8617), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("710f521c-298e-4e7f-a1b7-443030010818"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 50, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8798), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("bb80e433-c509-4456-87d0-a62666837ec0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 46, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8810), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("2f10ceea-4cc7-4257-8958-99c61093bf90"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 35, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8815), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("856d7698-c045-4786-893c-2dcc679097ed"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 5, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8821), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("7f78d365-8038-4ef0-a4b1-586b62aa4c23"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 37, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8826), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("302cca92-6227-4b8d-a00a-16bb824dbb07"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 42, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8831), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("8d5a2167-5ec4-4f13-9b50-f39d5c84cef4"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 76, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9342), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("54666957-b7e7-4561-93f6-8716f6b2ae05"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 26, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8855), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("d1c1db6e-1392-4a98-ac1a-9e3366d9ffde"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 44, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8866), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("f6daf380-11e5-476f-8dd7-cef898a5d4fc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 40, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8951), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("8e2c8644-5db0-4b4f-98f7-91b9cc4e43b5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 41, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8957), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("f626d37a-63d4-41cb-a82a-d12cf2df5aa3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 36, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8963), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("53032ca9-8fdc-434b-9363-59e8f8798857"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 28, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8968), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("c82fbda4-4200-48b8-96a7-b1acc93e934c"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 19, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8973), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("16aa73a5-8ae3-41b2-bbf3-085d9e76d6d3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 2, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8982), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("8268cd59-7711-4a0b-a0ff-debbca74f09f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 25, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(8861), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("8ff17f88-03e9-468d-af1c-54de03a96b10"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 54, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9096), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("2d93d951-d176-4198-8c21-7d03bb920e6b"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 38, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9102), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("3525b8a2-14d6-4306-a198-f2ac86ab20f3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 23, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9106), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("3d39dffb-d6c1-4b2c-8a77-7d2da0170538"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 63, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9256), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("ed4fa369-12d2-487f-aa3e-4d4c5b6adaf9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 7, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9260), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("fb4fc54b-6567-437c-b76e-34dd18047cbd"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 65, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9265), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("2914c530-40d8-43c9-9178-c7de36fc7e73"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 66, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9269), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("d8cfa472-862f-4bda-afc8-70400d7e40c1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 67, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9277), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("52096073-806e-45c3-ad8b-3e031c2900d7"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 68, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9281), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("ece38f11-5fb2-4496-a98a-6bd8c297a550"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 69, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9286), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("a88dd076-dd3d-41f7-b26a-0e102a39880f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 64, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9251), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("f00b30e1-1187-4278-871b-54313d75e518"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 70, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9293), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("c5f78f0f-f504-4595-8712-b11a12672463"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 72, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9302), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("a27e3990-49cb-44ef-b94f-9d01fb2eecf1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 73, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9306), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("11fe4df9-7bab-49da-83c0-fd50ab42862f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 74, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9311), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("0e2a2332-c9df-4cc9-b0e4-4754c31055a3"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 75, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9320), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("dfd09d9e-58d7-400a-a66b-5936cf8cd76d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 78, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9324), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("7fcfffd2-7dbd-488a-b34a-d1208d42729f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 79, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9329), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("e70361fa-918e-402f-935e-1790d64a6926"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 80, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9333), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("0591853c-fd7f-4ef4-9ad3-4a370ff573f9"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 71, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9298), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("29d651cc-9be3-41ee-9ec0-ebda4b1d7bde"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 39, new DateTime(2021, 10, 26, 13, 51, 6, 304, DateTimeKind.Local).AddTicks(9506), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("820b3c2c-e513-4f37-b0f0-7312e8d6fed5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 62, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9246), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("a75e189f-6c2b-42bf-a08a-db6c3ccdb297"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 61, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9236), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("99b25e78-2ab4-4ce8-a455-212b32c95fa1"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 20, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9113), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("9408bde3-8b14-4f53-86a1-f3872aca3b25"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 15, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9119), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("eb3ddc6b-f03d-46fc-8fbb-06967b38aa5a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 32, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9124), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("c4a6fdba-733c-403f-897e-59963eb29e28"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 16, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9129), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("6bf1bae5-cd1f-4378-830f-a65b361f16f8"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 47, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9135), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("62fd1be3-3266-4660-a76d-d891aba3a056"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 4, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9139), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("d6b451ed-0e00-4cbd-bdb6-e1aba8012bfa"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 56, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9145), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("3c8f77c5-ce6b-457c-a812-17f4d4ad947f"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 6, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9241), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("10f030ea-c2b9-4ed3-bf06-3170beba9d1d"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 17, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9150), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("f29f4cf3-170d-4b4e-bb73-24522f3000fc"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 18, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9161), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("c6a7de89-3b37-4a03-b60a-4b6cbcf452e5"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 21, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9166), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("b135121d-1572-4318-8838-5c85f2f0bd4a"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 52, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9207), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6fbd1426-7639-413c-83ad-24850c58d5e0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 57, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9213), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("4814b65b-32d7-4cfc-80b4-d6a72e3b31a0"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 58, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9218), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("3cc76099-ec5b-4e02-9fea-b740de88ad45"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 59, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9223), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("5652e2b6-ee6f-49bd-9b6a-9a39a2aec200"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 60, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9228), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("f40a476d-272f-4e4a-b73d-37d7210b8a9e"), false, null, new TimeSpan(0, 0, 0, 0, 0), null, null, 49, new DateTime(2021, 10, 26, 13, 51, 6, 306, DateTimeKind.Local).AddTicks(9157), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("ffaa2574-4f33-439f-8712-350881941aa6"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("14d9f157-fd94-48b4-a848-375279f3a792"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("895ef900-2c36-4c6e-af7e-cc5eb665ca5d"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("88af7f81-cae1-450c-8563-7dcee42f3f9b"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
