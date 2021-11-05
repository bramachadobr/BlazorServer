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
                    { new Guid("f09aeab6-c088-4594-bf91-13379be23826"), "Tutor" },
                    { new Guid("7c759dbe-b9d4-4403-98f6-db8ef16165dc"), "Secretaria" },
                    { new Guid("d592340e-8d1e-4c05-94bd-8919bdfa1878"), "Comercial" },
                    { new Guid("0226ba49-cb58-4162-a47a-81238785e86d"), "Coordenador" },
                    { new Guid("1b2cd8bc-9fa2-4290-8ca6-2479f64b38d8"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("2b38dbae-ab74-4ccb-9b93-e2b0831f32de"), false, null, 0.0, null, null, 104, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7932), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("b822b1be-d580-496f-bed4-95ca0462e7e2"), false, null, 0.0, null, null, 105, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7936), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("3c97ad90-b1a9-491e-a500-a7c017472e96"), false, null, 0.0, null, null, 106, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7940), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("7badb438-e6bb-4ea9-a68c-95d9765ea516"), false, null, 0.0, null, null, 107, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7945), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("08751ac2-4a7a-4ab4-b7bf-e3baa8f5669b"), false, null, 0.0, null, null, 108, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7951), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("98560e6a-5387-426e-b48b-b39b8bf65e08"), false, null, 0.0, null, null, 109, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7956), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("fdd0f770-f22c-4c2a-81d4-3a11dc115a1f"), false, null, 0.0, null, null, 110, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7960), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("f83c4c9f-f9ab-4db2-9f96-5ed1b1dfbeb2"), false, null, 0.0, null, null, 113, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7974), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("73d4e481-9f78-4afd-8d57-35e324153ca0"), false, null, 0.0, null, null, 112, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7970), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("730c74a9-2b0c-436c-b2cb-b1dc80e2e913"), false, null, 0.0, null, null, 103, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7927), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("8dfda410-19f8-4b5c-ac5b-938cc4694668"), false, null, 0.0, null, null, 114, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7979), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("7b7f3a9b-0892-4cfb-9552-7149169b5386"), false, null, 0.0, null, null, 115, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7983), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("a0b21b68-23e1-4917-9bad-69165d58d8ed"), false, null, 0.0, null, null, 116, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7990), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("09c89bfa-529f-44ea-8841-b13ed1c420bb"), false, null, 0.0, null, null, 117, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7996), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("7f644ca3-12f8-4fc6-989f-ad31b164cad6"), false, null, 0.0, null, null, 118, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8001), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("fe13eda4-1b88-4718-a1c0-5bbca7fe761a"), false, null, 0.0, null, null, 111, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7966), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("1886e179-8dff-4dc8-80e4-26a3612a5e46"), false, null, 0.0, null, null, 102, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7923), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("e545b28f-8442-4418-950f-e7567cbfc622"), false, null, 0.0, null, null, 99, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7907), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("17f6eea9-dda3-4cca-b8bd-27549889358d"), false, null, 0.0, null, null, 100, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7914), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("03b3139f-5f81-4394-8cfc-dc183b18a2ad"), false, null, 0.0, null, null, 83, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7824), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("88172cbe-1f8e-4158-b9e0-c006d6d36c73"), false, null, 0.0, null, null, 85, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7839), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("407fa180-70fa-45c7-b396-7de52e0d8aab"), false, null, 0.0, null, null, 86, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7844), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("2df2a192-c2c0-4c6e-8c75-bfdfda5111e7"), false, null, 0.0, null, null, 87, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7849), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("e45d2cb2-ec9e-4515-bff8-f9f5ef0a405c"), false, null, 0.0, null, null, 88, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7854), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("564c8693-b3b0-4538-b1ba-4d70f05e4673"), false, null, 0.0, null, null, 89, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7858), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("160cca2e-eb92-4dcc-b93c-c70e22db6e86"), false, null, 0.0, null, null, 91, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7863), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("d048d576-f4f1-42be-be9b-38f3d6887fd2"), false, null, 0.0, null, null, 101, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7919), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("791ba9b6-90c7-451c-831f-32a878d96cce"), false, null, 0.0, null, null, 94, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7868), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("42ff4303-728a-4539-a773-27afad07aed3"), false, null, 0.0, null, null, 90, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7880), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("3635a6d1-b135-4b15-b315-1ec89175eafb"), false, null, 0.0, null, null, 95, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7884), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("1eb15d52-a2df-4c9c-ba33-27972d3d2320"), false, null, 0.0, null, null, 77, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7889), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("0903a4ad-0156-4dd6-b92d-295207c103e6"), false, null, 0.0, null, null, 96, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7893), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("b5589f47-7197-40e2-8d53-3a477dd1408b"), false, null, 0.0, null, null, 97, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7898), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("a42e22f7-6375-4eb3-ac57-97c75cc77ab0"), false, null, 0.0, null, null, 98, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7903), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("df165929-6f8b-40c3-ac40-004a7e619c2b"), false, null, 0.0, null, null, 119, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8006), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("7f107128-f369-4793-a605-5a00d47ce60f"), false, null, 0.0, null, null, 93, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7875), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("19bc5e18-e271-43c0-9249-e5efe220a84f"), false, null, 0.0, null, null, 120, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8011), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("e294d77b-6630-4a94-9dbf-a84c62d0d7d2"), false, null, 0.0, null, null, 123, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8055), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("748588e7-3223-4628-970b-0903436a77bc"), false, null, 0.0, null, null, 122, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8050), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("14165700-7799-4e4a-adf4-b01ddb314f8e"), false, null, 0.0, null, null, 143, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8163), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("56da5945-d38c-41c3-8987-41fc7f618d8d"), false, null, 0.0, null, null, 144, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8167), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("adcb5635-88ec-45e5-bc0c-88f72602f429"), false, null, 0.0, null, null, 145, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8172), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("8db2cf4b-9080-4079-8fa9-1d9790ab5736"), false, null, 0.0, null, null, 146, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8176), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("802a4b55-a672-4370-96a9-91dd37ae1701"), false, null, 0.0, null, null, 147, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8181), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("0f71ac04-3ed2-4db7-b774-0b95336703e7"), false, null, 0.0, null, null, 148, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8187), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("766a6c85-2643-43b1-bf03-c605d8c6ed57"), false, null, 0.0, null, null, 149, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8191), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("d7159f89-73c0-48c8-9170-203e2d514822"), false, null, 0.0, null, null, 142, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8159), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("cae06de4-351b-4c83-899c-c49aa7889fdb"), false, null, 0.0, null, null, 150, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8196), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("569f0fd5-fd42-44ad-8a29-a6022eec50b5"), false, null, 0.0, null, null, 152, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8205), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("224831e3-df24-40fd-a839-62b420cbbcc1"), false, null, 0.0, null, null, 153, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8209), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("59677adf-94e3-4321-a0b4-88b2acd6c1ef"), false, null, 0.0, null, null, 154, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8213), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("59027098-c92d-4fff-add4-505583228037"), false, null, 0.0, null, null, 155, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8218), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("4da06036-9c91-4436-a06e-6e7c2b681ecc"), false, null, 0.0, null, null, 156, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8224), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("d9059bb1-1e41-4938-880c-c8962fb23a99"), false, null, 0.0, null, null, 157, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8229), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("6b09a37b-a749-48f1-acf2-3ce1271e244b"), false, null, 0.0, null, null, 158, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8233), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("cd29ac0f-f791-4d45-8f2e-e2c6cd6b1303"), false, null, 0.0, null, null, 151, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8200), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("021a6f9a-b97f-4fe1-b817-2715da7fa77a"), false, null, 0.0, null, null, 121, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8045), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("f95eebf2-b993-44fc-9b21-53d8da5acbde"), false, null, 0.0, null, null, 141, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8153), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("f7cb335f-a8d7-46e2-b18c-2695a9b8c457"), false, null, 0.0, null, null, 139, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8141), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("4158051f-6c01-47a3-b2a6-816df5bea900"), false, null, 0.0, null, null, 82, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7818), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("772bcc09-3426-4f24-9b4c-53766ca8ba40"), false, null, 0.0, null, null, 124, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8061), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("d255e3f8-7b60-48bd-9192-66ae70fd099a"), false, null, 0.0, null, null, 125, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8066), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("54417969-dfa3-436f-aeee-5b8a6aa2189f"), false, null, 0.0, null, null, 126, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8070), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("8af68684-d94f-48a2-a6fb-91d7abd2845a"), false, null, 0.0, null, null, 127, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8075), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("3b391c1f-69db-4e7f-95c8-e52c9c976881"), false, null, 0.0, null, null, 128, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8084), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("6c024ed1-deab-45dc-8573-faa8d3603728"), false, null, 0.0, null, null, 129, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8088), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("756b48d1-af93-45d1-9df2-5c24ce048e8e"), false, null, 0.0, null, null, 140, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8148), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("76e5488d-c839-4ab6-8e21-3194d71cb66a"), false, null, 0.0, null, null, 130, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8093), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("b4c8cfdc-bafd-4c23-8162-c1485d26e935"), false, null, 0.0, null, null, 132, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8105), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("83dcab06-4d72-481c-b886-510b16692f37"), false, null, 0.0, null, null, 133, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8110), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("1c505103-50af-49ce-b827-b2427681ef23"), false, null, 0.0, null, null, 134, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8115), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("6604b423-7396-4b97-969e-e811d349f682"), false, null, 0.0, null, null, 135, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8121), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("bb8fe909-fe84-4ac8-8267-ab064788f969"), false, null, 0.0, null, null, 136, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8128), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("9e73f0f2-b197-413d-824c-0fdb56733a91"), false, null, 0.0, null, null, 137, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8133), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("94a6f3a5-1193-4bc7-8303-d9e67d434198"), false, null, 0.0, null, null, 138, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8137), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("a9fde4f9-55d8-46cf-9996-2406f6883c5d"), false, null, 0.0, null, null, 131, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(8097), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("2d955001-924c-43a2-bbd4-9bd898bc576e"), false, null, 0.0, null, null, 76, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7783), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("6266fb74-85a4-40c1-9dec-00192767a95a"), false, null, 0.0, null, null, 84, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7831), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("94ea2156-addd-4d6e-8cf0-3f2a0c95869a"), false, null, 0.0, null, null, 80, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7774), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("21f4a960-ebf6-41d9-a805-e7df9df3a206"), false, null, 0.0, null, null, 24, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7297), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("2608020f-1c24-429d-a6ad-6f1bdf71fbd7"), false, null, 0.0, null, null, 9, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7301), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("72225316-3a61-4af8-85d4-a6e745134431"), false, null, 0.0, null, null, 31, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7306), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("c008bd4f-7980-4ace-b299-f57b8818f920"), false, null, 0.0, null, null, 33, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7311), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("fc8d8627-5f1c-4bf7-bba6-4a494b6cf288"), false, null, 0.0, null, null, 34, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7318), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("55193db7-d2aa-4a44-8fe9-608b2a2e64cb"), false, null, 0.0, null, null, 10, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7323), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("16ffd12d-629d-4e73-9b1f-10e9223b1aae"), false, null, 0.0, null, null, 43, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7327), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("eb05c655-c7fc-44fb-a7a0-5cbf0fc54950"), false, null, 0.0, null, null, 29, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7292), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("e40835c4-9aeb-4b3a-a7f7-3c2010b908f8"), false, null, 0.0, null, null, 11, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7332), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("49542d5f-f42e-404e-914d-e4bad0be9996"), false, null, 0.0, null, null, 51, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7341), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("10171d47-7d30-4768-9e18-c839125d4b4c"), false, null, 0.0, null, null, 55, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7347), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("dabf6f0f-2301-4cc0-b528-fb407e0443c4"), false, null, 0.0, null, null, 13, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7354), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("702e85b9-29a7-4a3e-921a-f06c9e003348"), false, null, 0.0, null, null, 30, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7365), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("9324886e-720e-43ba-b727-83ef9f8e9206"), false, null, 0.0, null, null, 81, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7779), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("8914fc03-29b0-44cf-b7b7-64459b14273c"), false, null, 0.0, null, null, 14, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7374), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("30e959ff-9688-49b2-8e32-11967b81c8bb"), false, null, 0.0, null, null, 27, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7379), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("81a80f2e-2f54-4b03-a55c-d159180a1e39"), false, null, 0.0, null, null, 12, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7336), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("5dc84807-6c2b-4023-93f3-90887f7979f7"), false, null, 0.0, null, null, 3, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7383), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null },
                    { new Guid("8b25b090-f527-4530-a602-e870e85bbd6c"), false, null, 0.0, null, null, 48, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7287), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("5dbc9dc6-d101-4b40-a5de-62082252c22e"), false, null, 0.0, null, null, 2, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7277), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("47d704f6-bdea-4346-93f9-878f5076d9c5"), false, null, 0.0, null, null, 39, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(1695), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("a423d95a-e3a6-4850-8ce7-d2d7532d58fb"), false, null, 0.0, null, null, 22, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7163), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("3fbe5163-00cc-410c-91fd-eff49b0f69ce"), false, null, 0.0, null, null, 50, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7188), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("39539bc4-4e56-483a-919c-aa29f7ffeb25"), false, null, 0.0, null, null, 46, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7195), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("043a642c-7ee8-4e09-9567-367e1bbfb9e8"), false, null, 0.0, null, null, 35, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7201), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("6a64fb0a-7887-40e5-aab1-da23e92f54fc"), false, null, 0.0, null, null, 5, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7206), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("df5d4b5c-8f53-4844-ae25-2b1d03e929b6"), false, null, 0.0, null, null, 37, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7211), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("4e82a4e8-0066-4aa5-8111-93f0dbd42eec"), false, null, 0.0, null, null, 45, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7283), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("b0426ce3-74b0-4082-a442-66ab958c97b8"), false, null, 0.0, null, null, 42, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7219), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("eea8b3ca-21a8-4e25-9224-4af9bd3fb842"), false, null, 0.0, null, null, 25, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7237), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("dc661ab3-9856-4a78-ba26-39299550d7a3"), false, null, 0.0, null, null, 44, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7243), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("5e9e0bb0-1f73-47a1-8175-7a91306e2a71"), false, null, 0.0, null, null, 40, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7248), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("1377162b-02ee-4943-b588-3df65bb932e4"), false, null, 0.0, null, null, 41, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7253), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("16f5e0d1-3224-41b8-bd6b-84a0be95a02a"), false, null, 0.0, null, null, 36, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7259), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("4cad8e18-09aa-467b-91fe-dc7f68296f67"), false, null, 0.0, null, null, 28, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7264), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("e3cb076d-a699-40f2-a96c-939a4d0d791c"), false, null, 0.0, null, null, 19, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7269), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("a73902f0-d744-4b71-b0d8-92466e379489"), false, null, 0.0, null, null, 26, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7231), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("5e01d3a2-a4d6-4adf-b6b8-cf22220accbc"), false, null, 0.0, null, null, 54, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7387), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("f1cc2fb9-69c6-4bff-af1e-27d5025f7a63"), false, null, 0.0, null, null, 53, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7370), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("e0d4356a-5e84-4dc3-a616-4c0b5215ab63"), false, null, 0.0, null, null, 23, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7579), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("1d48da48-3444-43be-b8a8-5f0e61d6e796"), false, null, 0.0, null, null, 63, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7696), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("e2745f9f-81d9-4db1-a64a-29bdb781d943"), false, null, 0.0, null, null, 7, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7701), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("177e37b0-221f-4aeb-b6bc-ad8336b45e6d"), false, null, 0.0, null, null, 38, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7392), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("a6d4912d-8248-4672-9eaa-90fdce7b7701"), false, null, 0.0, null, null, 66, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7710), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("58ce6271-9434-4291-a5e1-622fc8b0ee06"), false, null, 0.0, null, null, 67, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7717), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("1c085821-ebbc-4d8e-ab01-91e0870d0040"), false, null, 0.0, null, null, 68, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7722), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("24faa850-fa70-43e2-b82b-169a16113d4f"), false, null, 0.0, null, null, 69, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7727), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("a5bfde22-fb4b-4bb2-ad88-1aa1a8844d3e"), false, null, 0.0, null, null, 70, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7732), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("2af5f604-0700-40dc-9f85-d376a0ca7591"), false, null, 0.0, null, null, 71, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7737), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("c26d0f33-dada-4bce-8c34-f8b94c797b4f"), false, null, 0.0, null, null, 72, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7742), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("fc4e89b6-570b-460d-90c2-2c6e620b772a"), false, null, 0.0, null, null, 73, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7747), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("06d4cc90-03bc-40c7-a95b-6f5096504f98"), false, null, 0.0, null, null, 74, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7752), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("584c8fd4-8be3-491c-a2e5-caa8c8431cf8"), false, null, 0.0, null, null, 75, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7759), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("93bd0b80-845b-431b-b6fa-d8613850c4b3"), false, null, 0.0, null, null, 78, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7765), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("9ae7568d-16d6-47d5-a9e9-9ae8535179e7"), false, null, 0.0, null, null, 79, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7770), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("bd03435f-d75c-4688-a65d-08fd9b0beacb"), false, null, 0.0, null, null, 64, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7692), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("0f5ad397-85e9-4378-9012-8e212054c547"), false, null, 0.0, null, null, 62, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7687), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("1afd813e-af2e-42c5-bd9f-c0f74e0ecef0"), false, null, 0.0, null, null, 65, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7706), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("7a529b60-bbf2-494d-8d61-f1fda11523b4"), false, null, 0.0, null, null, 61, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7676), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("ec107df8-0139-4ec3-b5d8-707428981e81"), false, null, 0.0, null, null, 20, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7592), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("bb413565-96f4-42b0-8a2b-3157f1849e10"), false, null, 0.0, null, null, 15, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7600), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("710b302b-77d9-4376-bb0a-6ad32bd8c1da"), false, null, 0.0, null, null, 6, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7682), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("130a81f6-cfcc-4aff-bdb5-3486f3ab95a1"), false, null, 0.0, null, null, 16, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7610), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("85224dca-e82d-47ba-ad9a-05a600147372"), false, null, 0.0, null, null, 47, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7614), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("30d1ec69-6d99-4a5f-a78a-dae78318a1d1"), false, null, 0.0, null, null, 4, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7618), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("625771c4-98bb-4af3-97a9-b1339bd2e0e5"), false, null, 0.0, null, null, 56, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7623), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("30b3fb2a-2e69-4729-92a5-455bb840e2b0"), false, null, 0.0, null, null, 17, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7628), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("c4d9b4d8-6d7e-4cd9-a110-71077146366d"), false, null, 0.0, null, null, 32, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7605), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("a6656bf2-c2c0-4d41-bbaa-cac79233e185"), false, null, 0.0, null, null, 18, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7641), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("bb797137-a5ec-461d-9d3c-c87b280c19b0"), false, null, 0.0, null, null, 21, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7647), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("99cf1f3f-eb17-4d44-a366-097a67b99f87"), false, null, 0.0, null, null, 52, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7652), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6a9ed5ee-9cce-45ca-aaf6-53499c291325"), false, null, 0.0, null, null, 57, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7656), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("84534975-30fd-4ff9-b509-663f4fd83504"), false, null, 0.0, null, null, 58, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7660), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("c29f42c1-7cad-4dc8-b95a-ebf7d8e518b3"), false, null, 0.0, null, null, 59, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7665), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("f5e08147-6af2-4778-ae4e-66dbb196d587"), false, null, 0.0, null, null, 60, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7669), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("bb6ac265-b514-48cd-8371-f0acb350eed9"), false, null, 0.0, null, null, 49, new DateTime(2021, 10, 27, 19, 26, 45, 678, DateTimeKind.Local).AddTicks(7635), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("577152f1-89f3-472e-82c5-5d91214be51d"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("5d3e44db-f878-4bc6-bd93-6825f446e52c"), new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado05" },
                    { new Guid("4f28b7ee-b14d-4e17-be44-dfe65b97f59f"), new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado04" },
                    { new Guid("ad5fea47-2196-4c0a-bc4c-d195ee4a65c9"), new DateTime(2021, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado03" },
                    { new Guid("496b4448-aec0-4cf9-8bbf-999fd1257817"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("3fc3f5ee-0f74-45c2-8e44-fe39954d3c45"), new DateTime(2021, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado01" },
                    { new Guid("0a86d88f-3a96-4e2d-8d4e-3936d3e6d6a9"), new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado00" },
                    { new Guid("92bd2489-e377-4832-a489-26e582cebff2"), new DateTime(2021, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feriado02" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("f836dca4-aa44-49d7-b182-b616da2d2e0e"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("4ba1bae2-065f-487b-8d7c-d934d97f4f81"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[] { new Guid("81f644cb-0219-4d44-aba4-bf9f11cd7562"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" });

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
