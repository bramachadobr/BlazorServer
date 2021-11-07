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
                    { new Guid("50914a4a-5a74-462e-be68-f0c836172db3"), "Tutor" },
                    { new Guid("9fee2148-259f-461e-b4d9-d2dfed9fb8fa"), "Secretaria" },
                    { new Guid("9232e316-b97d-418b-8aa0-9f2239a7427f"), "Comercial" },
                    { new Guid("d505d96b-13f8-4a4b-b7fd-cf9dcb4a08c4"), "Coordenador" },
                    { new Guid("e51aa5e5-7586-4548-9cbc-48751886de15"), "Professor" }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("19bace09-4601-4321-a9f6-e3bf8850b867"), false, null, 0.0, null, null, 104, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8075), null, null, null, null, null, 52.00m, "RODRIGO CESAR", 0, 5000.00m, null, null },
                    { new Guid("7bc603b5-6670-47b2-b093-719a44f13093"), false, null, 0.0, null, null, 105, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8080), null, null, null, null, null, 52.00m, "JOSE DE ARIMATEIA", 0, 5000.00m, null, null },
                    { new Guid("7003d0e0-ebb2-4fc8-a2af-d001beaa92e3"), false, null, 0.0, null, null, 106, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8085), null, null, null, null, null, 52.00m, "HENRIQUE NOLETO", 0, 5000.00m, null, null },
                    { new Guid("96906bec-97c0-424d-be63-d30d35151258"), false, null, 0.0, null, null, 107, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8089), null, null, null, null, null, 52.00m, "ISABELA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("dca45661-61fb-4056-8dc2-c803ef89b314"), false, null, 0.0, null, null, 108, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8094), null, null, null, null, null, 52.00m, "IOLENE VIANA", 0, 5000.00m, null, null },
                    { new Guid("16324c34-2f8f-4943-9419-1709a8d868b4"), false, null, 0.0, null, null, 109, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8099), null, null, null, null, null, 52.00m, "WESLLEY SOARES", 0, 5000.00m, null, null },
                    { new Guid("1d728c17-f570-412c-8939-97a0af2e55d9"), false, null, 0.0, null, null, 110, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8103), null, null, null, null, null, 52.00m, "DIVINO SANTOS", 0, 5000.00m, null, null },
                    { new Guid("59124ff7-41b0-4b11-a07d-19e7a62660c0"), false, null, 0.0, null, null, 113, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8120), null, null, null, null, null, 52.00m, "TATIANA RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("8a677bab-a1cf-4222-a42b-a1f3922cf653"), false, null, 0.0, null, null, 112, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8115), null, null, null, null, null, 52.00m, "JOSIEL MACIEL", 0, 5000.00m, null, null },
                    { new Guid("3c9962a2-3090-43a0-ba19-9f1a686bbddc"), false, null, 0.0, null, null, 103, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8070), null, null, null, null, null, 52.00m, "ANDERSON MACIEL", 0, 5000.00m, null, null },
                    { new Guid("19086b00-9e73-401d-aeb5-9c2c141bf1f4"), false, null, 0.0, null, null, 114, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8124), null, null, null, null, null, 52.00m, "IVANA TUTORIA", 0, 5000.00m, null, null },
                    { new Guid("b18960ff-24f5-4556-895d-29c53302c6f6"), false, null, 0.0, null, null, 115, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8130), null, null, null, null, null, 52.00m, "CARLOS EDUARDO", 0, 5000.00m, null, null },
                    { new Guid("d562fa4b-4103-4e2c-b4c1-dd7584b5a924"), false, null, 0.0, null, null, 116, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8135), null, null, null, null, null, 52.00m, "CASSIO", 0, 5000.00m, null, null },
                    { new Guid("b6cb6d88-c2ed-4f83-b96b-2c57e55cccc2"), false, null, 0.0, null, null, 117, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8140), null, null, null, null, null, 52.00m, "ELLEN CLEIDE", 0, 5000.00m, null, null },
                    { new Guid("ee40b8bf-8c6a-4651-a950-7c3a108a43a5"), false, null, 0.0, null, null, 118, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8144), null, null, null, null, null, 52.00m, "MARIA MARLI", 0, 5000.00m, null, null },
                    { new Guid("e6c1f629-b44f-45e1-83a0-d2afb1dfeced"), false, null, 0.0, null, null, 111, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8111), null, null, null, null, null, 52.00m, "ALINE LOPES", 0, 5000.00m, null, null },
                    { new Guid("d1aee436-bce8-4c49-ad62-aa632ae849c5"), false, null, 0.0, null, null, 102, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8063), null, null, null, null, null, 52.00m, "MAIZA NONATO", 0, 5000.00m, null, null },
                    { new Guid("567a1764-9d74-4b1b-ac21-5a937bf8d44f"), false, null, 0.0, null, null, 99, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8049), null, null, null, null, null, 52.00m, "LUCIANO LIMA", 0, 5000.00m, null, null },
                    { new Guid("c831bbef-814f-404e-beb8-271d035e9eeb"), false, null, 0.0, null, null, 100, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8054), null, null, null, null, null, 52.00m, "FRANCYANNE CASTRO", 0, 5000.00m, null, null },
                    { new Guid("55a6a8fd-6760-4940-8874-d278a1be9b01"), false, null, 0.0, null, null, 84, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7973), null, null, null, null, null, 52.00m, "JOSELINO DANTAS", 0, 5000.00m, null, null },
                    { new Guid("ebb18faf-cd4d-42a6-b9a8-0b31e30a921c"), false, null, 0.0, null, null, 85, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7978), null, null, null, null, null, 52.00m, "BRNDAO REINALDO", 0, 5000.00m, null, null },
                    { new Guid("412274fd-4570-43f9-ac06-be048a674a00"), false, null, 0.0, null, null, 86, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7983), null, null, null, null, null, 52.00m, "MOISES HAMSSES", 0, 5000.00m, null, null },
                    { new Guid("3d6e23f0-0cb3-4d67-ac28-d4e39edec38e"), false, null, 0.0, null, null, 87, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7990), null, null, null, null, null, 52.00m, "DIANA MARROCOS", 0, 5000.00m, null, null },
                    { new Guid("0d1ce075-ead0-40bf-bcf8-058704289677"), false, null, 0.0, null, null, 88, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7995), null, null, null, null, null, 52.00m, "JOAO VICTOR", 0, 5000.00m, null, null },
                    { new Guid("469ff0ca-0c8b-4e60-a694-a65cd262477e"), false, null, 0.0, null, null, 89, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7999), null, null, null, null, null, 52.00m, "EDNA MOIA", 0, 5000.00m, null, null },
                    { new Guid("a823df9a-48e2-450f-9aca-d0194c9417ec"), false, null, 0.0, null, null, 91, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8005), null, null, null, null, null, 52.00m, "MARCIA BARRETO", 0, 5000.00m, null, null },
                    { new Guid("b897a0ac-6273-437d-b8a0-66dc11725b81"), false, null, 0.0, null, null, 101, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8058), null, null, null, null, null, 52.00m, "KESIA MARTINS", 0, 5000.00m, null, null },
                    { new Guid("76b469ee-c295-43a0-8269-5c7f0ea09b7a"), false, null, 0.0, null, null, 94, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8009), null, null, null, null, null, 52.00m, "JESSICA MELO", 0, 5000.00m, null, null },
                    { new Guid("4a4051e2-08dd-47e8-97d5-a9d3ba0d7afa"), false, null, 0.0, null, null, 90, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8019), null, null, null, null, null, 52.00m, "WELLIDA AVIZ", 0, 5000.00m, null, null },
                    { new Guid("f3713c9f-f6c2-45a7-8de9-bc9d8fcd5e88"), false, null, 0.0, null, null, 95, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8023), null, null, null, null, null, 52.00m, "FERNANDO AMOURY", 0, 5000.00m, null, null },
                    { new Guid("6e22c4e9-6a72-4c5c-bb6c-4903d6de30f4"), false, null, 0.0, null, null, 77, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8031), null, null, null, null, null, 52.00m, "ALLAN WERBERTT", 0, 5000.00m, null, null },
                    { new Guid("4025845f-3f84-4538-8cfe-081528243737"), false, null, 0.0, null, null, 96, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8035), null, null, null, null, null, 52.00m, "THAISE MORGANA", 0, 5000.00m, null, null },
                    { new Guid("9ca141cf-485e-4797-ac9e-3a4268c57c14"), false, null, 0.0, null, null, 97, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8040), null, null, null, null, null, 52.00m, "CRISLANE SANTOS", 0, 5000.00m, null, null },
                    { new Guid("2adb39fe-9c4f-453a-abe3-e6cafbf3722a"), false, null, 0.0, null, null, 98, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8044), null, null, null, null, null, 52.00m, "YARA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("69df2189-8421-426d-b58b-2b85191160a0"), false, null, 0.0, null, null, 119, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8151), null, null, null, null, null, 52.00m, "MIRIA FERREIRA", 0, 5000.00m, null, null },
                    { new Guid("202b6f66-cd8b-4a74-a09c-582b4ed69d46"), false, null, 0.0, null, null, 93, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8014), null, null, null, null, null, 52.00m, "TARCIA ALEXANDRE", 0, 5000.00m, null, null },
                    { new Guid("122a5766-d400-45c8-aad6-e321eddb2875"), false, null, 0.0, null, null, 120, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8155), null, null, null, null, null, 52.00m, "VICTOR DE PAULA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("a8c53fab-8df7-48f7-a17c-93837bcb8220"), false, null, 0.0, null, null, 123, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8207), null, null, null, null, null, 52.00m, "RILDO AMARAL", 0, 5000.00m, null, null },
                    { new Guid("dfb8a7b1-5a54-4abd-b4f2-6c24e1892c9b"), false, null, 0.0, null, null, 122, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8201), null, null, null, null, null, 52.00m, "HEYGON TED", 0, 5000.00m, null, null },
                    { new Guid("2263e49d-c2c8-40f5-822a-ab912ab426ec"), false, null, 0.0, null, null, 143, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8312), null, null, null, null, null, 52.00m, "SERGIO DE JESUS", 0, 5000.00m, null, null },
                    { new Guid("f3625230-9cae-41fd-8768-b18d49d69b2b"), false, null, 0.0, null, null, 144, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8316), null, null, null, null, null, 52.00m, "FLAVIANA DE OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("ea88a8ed-3fce-46be-9a29-08efe9f2da01"), false, null, 0.0, null, null, 145, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8320), null, null, null, null, null, 52.00m, "AMANDA GOULART", 0, 5000.00m, null, null },
                    { new Guid("92699c66-d32f-4205-ba23-b74825775597"), false, null, 0.0, null, null, 146, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8325), null, null, null, null, null, 52.00m, "ADAO DE PAULA", 0, 5000.00m, null, null },
                    { new Guid("d801b77c-248d-4084-bc16-59e6e017764f"), false, null, 0.0, null, null, 147, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8329), null, null, null, null, null, 52.00m, "SIMONE SILVA", 0, 5000.00m, null, null },
                    { new Guid("bb951a00-7d15-4228-ba8a-bd168def52d0"), false, null, 0.0, null, null, 148, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8334), null, null, null, null, null, 52.00m, "LUCIMARA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("75248261-a18d-49df-bf45-487c4ac13fa0"), false, null, 0.0, null, null, 149, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8339), null, null, null, null, null, 52.00m, "CARMEM NATANNA", 0, 5000.00m, null, null },
                    { new Guid("85949380-a0c9-408f-aaeb-e6a65c436094"), false, null, 0.0, null, null, 142, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8305), null, null, null, null, null, 52.00m, "LARISSA CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("8b037819-e100-41b6-b82b-5caa5a4f178f"), false, null, 0.0, null, null, 150, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8344), null, null, null, null, null, 52.00m, "RAIRONE LIMA", 0, 5000.00m, null, null },
                    { new Guid("889103a1-7a77-4c8c-9378-7c3d8b37019a"), false, null, 0.0, null, null, 152, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8356), null, null, null, null, null, 52.00m, "KALIMY DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("106b37e7-ad7c-4f48-9e83-0b240118d2c4"), false, null, 0.0, null, null, 153, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8360), null, null, null, null, null, 52.00m, "CYMARA FRANCO", 0, 5000.00m, null, null },
                    { new Guid("0b2e547e-943e-45ed-b1c6-7b9281eac228"), false, null, 0.0, null, null, 154, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8365), null, null, null, null, null, 52.00m, "SCARLETT MILHOMEM", 0, 5000.00m, null, null },
                    { new Guid("1fef6174-5f0a-4130-b261-7f591a8d8622"), false, null, 0.0, null, null, 155, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8369), null, null, null, null, null, 52.00m, "KIANE SANTANA", 0, 5000.00m, null, null },
                    { new Guid("5815caba-fb70-43e5-b2f4-96bf62adeb6a"), false, null, 0.0, null, null, 156, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8374), null, null, null, null, null, 52.00m, "EDUARDO MENDES", 0, 5000.00m, null, null },
                    { new Guid("843740e0-3159-482d-96bc-6b6fdb98917f"), false, null, 0.0, null, null, 157, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8379), null, null, null, null, null, 52.00m, "JUCILENE SILVA", 0, 5000.00m, null, null },
                    { new Guid("eaa7a0bf-04de-4c70-9552-d20089a77833"), false, null, 0.0, null, null, 158, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8384), null, null, null, null, null, 52.00m, "ALMIR DALMOLIN", 0, 5000.00m, null, null },
                    { new Guid("17194e36-c33a-40b0-b5cf-aff613b8ce8a"), false, null, 0.0, null, null, 151, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8351), null, null, null, null, null, 52.00m, "RODRIGO DRELIN", 0, 5000.00m, null, null },
                    { new Guid("de22e14d-8456-491b-a10b-8ecef7c4b3ef"), false, null, 0.0, null, null, 121, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8196), null, null, null, null, null, 52.00m, "ANA TEREZA", 0, 5000.00m, null, null },
                    { new Guid("a18ae3c5-0ba8-401b-a236-29f89cfe8ba5"), false, null, 0.0, null, null, 141, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8300), null, null, null, null, null, 52.00m, "ERICK LEAO FERRAZ", 0, 5000.00m, null, null },
                    { new Guid("f574690e-89b2-4c56-9ab5-ce79edb6bd1c"), false, null, 0.0, null, null, 139, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8291), null, null, null, null, null, 52.00m, "CARLOS ALBERTO", 0, 5000.00m, null, null },
                    { new Guid("587030a3-a908-4f61-a42d-a253dfbf8520"), false, null, 0.0, null, null, 83, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7968), null, null, null, null, null, 52.00m, "ELAINE JULIANA", 0, 5000.00m, null, null },
                    { new Guid("057b97cb-8afd-4b69-901d-d8131e418463"), false, null, 0.0, null, null, 124, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8213), null, null, null, null, null, 52.00m, "GERLYNNE PESSOA DE CARVALHO SILVA", 0, 5000.00m, null, null },
                    { new Guid("1ee00479-92d3-4452-91f1-32bde73f369f"), false, null, 0.0, null, null, 125, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8218), null, null, null, null, null, 52.00m, "MATHEUS HENRIQUE", 0, 5000.00m, null, null },
                    { new Guid("fa13f171-e143-4bbc-8a87-a0e7868032d6"), false, null, 0.0, null, null, 126, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8223), null, null, null, null, null, 52.00m, "THAMYRES SALOMAO", 0, 5000.00m, null, null },
                    { new Guid("b60e17bb-25ee-47df-a558-a0e25e027126"), false, null, 0.0, null, null, 127, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8231), null, null, null, null, null, 52.00m, "SAMILLY GURGEL", 0, 5000.00m, null, null },
                    { new Guid("8a814563-94ea-455d-bbf8-55a9fa71a8c6"), false, null, 0.0, null, null, 128, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8236), null, null, null, null, null, 52.00m, "HILLARY SANTOS", 0, 5000.00m, null, null },
                    { new Guid("ddb62a6e-7249-4217-bc9b-076b6718351d"), false, null, 0.0, null, null, 129, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8241), null, null, null, null, null, 52.00m, "PALMEIRA JR", 0, 5000.00m, null, null },
                    { new Guid("d5363b64-6f25-4ef5-897d-5d71d44c0a87"), false, null, 0.0, null, null, 140, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8296), null, null, null, null, null, 52.00m, "ERIVELTON DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("5848ddea-4f34-484e-94b7-d56756404684"), false, null, 0.0, null, null, 130, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8246), null, null, null, null, null, 52.00m, "RONIEL MARQUES", 0, 5000.00m, null, null },
                    { new Guid("4ca8ac4b-9a11-494e-a19a-c95623e355d9"), false, null, 0.0, null, null, 132, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8256), null, null, null, null, null, 52.00m, "RAYANE MARTINS", 0, 5000.00m, null, null },
                    { new Guid("1435b512-7a04-4208-b27d-00f4fa6002a8"), false, null, 0.0, null, null, 133, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8261), null, null, null, null, null, 52.00m, "LIDIA SOUSA BARROS", 0, 5000.00m, null, null },
                    { new Guid("ae8f1e2d-203e-4f61-8623-a2173fc5bda8"), false, null, 0.0, null, null, 134, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8265), null, null, null, null, null, 52.00m, "ELZA MARIA", 0, 5000.00m, null, null },
                    { new Guid("eafe3cc7-c52d-4dd6-abcf-59090a16ac42"), false, null, 0.0, null, null, 135, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8272), null, null, null, null, null, 52.00m, "SELMA OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("5ab51dfa-45cb-420e-916a-84aec13ef8cd"), false, null, 0.0, null, null, 136, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8277), null, null, null, null, null, 52.00m, "CAMILA LETICIA P", 0, 5000.00m, null, null },
                    { new Guid("cb5c70d6-a1c6-4784-9ed1-3df953e27fd1"), false, null, 0.0, null, null, 137, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8281), null, null, null, null, null, 52.00m, "THIAGO MESQUITA", 0, 5000.00m, null, null },
                    { new Guid("1f470c13-6376-43a0-99d9-e7aff07b6d8f"), false, null, 0.0, null, null, 138, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8285), null, null, null, null, null, 52.00m, "IRLAINE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("d5280b43-4e60-4a1c-a08c-1b57e49080ae"), false, null, 0.0, null, null, 131, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(8251), null, null, null, null, null, 52.00m, "ALINE PEREIRA", 0, 5000.00m, null, null },
                    { new Guid("88817e2c-7c36-444e-b2d0-31b25eb3b98d"), false, null, 0.0, null, null, 76, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7920), null, null, null, null, null, 52.00m, "FERNANDO ATROCH", 0, 5000.00m, null, null },
                    { new Guid("fb95836f-cb7e-459a-beee-6f98799b4c10"), false, null, 0.0, null, null, 82, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7962), null, null, null, null, null, 52.00m, "PEDRO AUGUSTO", 0, 5000.00m, null, null },
                    { new Guid("235ec74e-27e9-47ae-9700-ebdd374a3b8a"), false, null, 0.0, null, null, 14, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7659), null, null, null, null, null, 52.00m, "MAYARA DE OLIVEIRA PEREIRA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("a2579f32-70ab-4f3c-b6f7-efa97f8eb45a"), false, null, 0.0, null, null, 24, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7590), null, null, null, null, null, 52.00m, "FRANCINOLIA R A L C", 0, 5000.00m, null, null },
                    { new Guid("d5900863-0271-4ded-8a83-bc295191a64c"), false, null, 0.0, null, null, 9, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7594), null, null, null, null, null, 52.00m, "GLICIANE ESTEPHANE JACOME DE SOUSA", 0, 5000.00m, null, null },
                    { new Guid("f7aeb2de-d3fa-47f0-8c39-3f9ce46a75b3"), false, null, 0.0, null, null, 31, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7599), null, null, null, null, null, 52.00m, "HUDLER LEITE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("66a89868-f2ba-42e5-9045-b5b344ce9be7"), false, null, 0.0, null, null, 33, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7605), null, null, null, null, null, 52.00m, "IRISMAR SILVA CIRINO", 0, 5000.00m, null, null },
                    { new Guid("13f63e1a-5aba-43b2-8551-29951fb8147f"), false, null, 0.0, null, null, 34, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7610), null, null, null, null, null, 52.00m, "JAKELLYNE ALVES BRANDÃO", 0, 5000.00m, null, null },
                    { new Guid("f6d46752-bd9d-441c-85d3-6aa65b58b4a6"), false, null, 0.0, null, null, 10, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7614), null, null, null, null, null, 52.00m, "JHYEIVSON WALLINTER SILVA", 0, 5000.00m, null, null },
                    { new Guid("ecf61f78-5739-4a58-a7c2-7be8ba5f9570"), false, null, 0.0, null, null, 43, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7619), null, null, null, null, null, 52.00m, "JORDANIA DE MACEDO MENDONÇA", 0, 5000.00m, null, null },
                    { new Guid("a27e02c3-3cc5-4ebb-b061-d69f47792310"), false, null, 0.0, null, null, 11, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7626), null, null, null, null, null, 52.00m, "JORGE CLESIO SILVA E SILVA", 0, 5000.00m, null, null },
                    { new Guid("ca5987a6-d3be-4e3f-bfae-9d0300328f1d"), false, null, 0.0, null, null, 12, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7632), null, null, null, null, null, 52.00m, "JORGE FERNANDO CASTRO SILVA", 0, 5000.00m, null, null },
                    { new Guid("7901de5d-a932-4102-b009-74adf9c0fcc5"), false, null, 0.0, null, null, 51, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7636), null, null, null, null, null, 52.00m, "JUCIENE IONARIA DE S. GABRIEL", 0, 5000.00m, null, null },
                    { new Guid("de1f7d6c-3b90-41c9-a62f-049f1490d8e9"), false, null, 0.0, null, null, 55, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7641), null, null, null, null, null, 52.00m, "LEILSON RODRIGUES DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("8056817f-befd-4083-8bd6-d0168c88cad9"), false, null, 0.0, null, null, 13, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7645), null, null, null, null, null, 52.00m, "LORENA MATOS SILVA PRADO", 0, 5000.00m, null, null },
                    { new Guid("ba0c0219-b4c9-4dec-878d-7e723893486e"), false, null, 0.0, null, null, 30, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7650), null, null, null, null, null, 52.00m, "LUANA MARTINS ROCHA", 0, 5000.00m, null, null },
                    { new Guid("4292f13a-83d8-42f9-8eff-055ce2868980"), false, null, 0.0, null, null, 53, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7654), null, null, null, null, null, 52.00m, "MARIANA LEAL OLIVEIRA", 0, 5000.00m, null, null },
                    { new Guid("a2a76126-637c-40b9-ab86-669361c58cb4"), false, null, 0.0, null, null, 81, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7915), null, null, null, null, null, 52.00m, "MARYANNE STEPHANE ROCHA G", 0, 5000.00m, null, null },
                    { new Guid("8d3f274d-e29a-4b83-8b5f-83c80b096479"), false, null, 0.0, null, null, 29, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7585), null, null, null, null, null, 52.00m, "FERNANDO CABRAL DA FONSECA", 0, 5000.00m, null, null },
                    { new Guid("e07a8190-a4cc-4751-9f88-8f368e5ae8df"), false, null, 0.0, null, null, 48, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7577), null, null, null, null, null, 52.00m, "ERCILIO DE CASTRO  BARBOZA", 0, 5000.00m, null, null },
                    { new Guid("d443089d-a190-42c1-b049-d85b64bc056c"), false, null, 0.0, null, null, 45, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7572), null, null, null, null, null, 52.00m, "ELAINE DE JESUS REZENDE", 0, 5000.00m, null, null },
                    { new Guid("d60bbbc3-5f51-4b74-8465-4cd447de5f50"), false, null, 0.0, null, null, 2, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7568), null, null, null, null, null, 52.00m, "EDI", 0, 5000.00m, null, null },
                    { new Guid("53943aed-da8f-4263-95e7-6d3cd2a9dc47"), false, null, 0.0, null, null, 39, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(2582), null, null, null, null, null, 52.00m, "ALEXSANDRA KETHY DE FRANÇA", 0, 5000.00m, null, null },
                    { new Guid("e581cf9e-966d-4bc4-8e6f-73c3dd14b3bd"), false, null, 0.0, null, null, 22, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7451), null, null, null, null, null, 52.00m, "ALVARO RICK P. VIEIRA", 0, 5000.00m, null, null },
                    { new Guid("11e37b45-ae0d-49cd-88af-1bf43ffe3aeb"), false, null, 0.0, null, null, 50, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7476), null, null, null, null, null, 52.00m, "AMADEU JUNIOR FERREIRA DE LIMA", 0, 5000.00m, null, null },
                    { new Guid("f9737a19-b99c-4f73-a070-e72b28b6d21c"), false, null, 0.0, null, null, 46, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7491), null, null, null, null, null, 52.00m, "ANA ALICE DA MOTA", 0, 5000.00m, null, null },
                    { new Guid("66546f95-e949-449d-a145-f26a751b1400"), false, null, 0.0, null, null, 35, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7498), null, null, null, null, null, 52.00m, "ANDERSON CRISTIANO SALES SILVA", 0, 5000.00m, null, null },
                    { new Guid("5bb111d3-7c47-4262-9139-e25bec9f560c"), false, null, 0.0, null, null, 5, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7503), null, null, null, null, null, 52.00m, "ANDRÉ DA CONCEIÇÃO SILVA", 0, 5000.00m, null, null },
                    { new Guid("089a6914-45fc-40ec-b6c9-d3540ba95418"), false, null, 0.0, null, null, 37, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7508), null, null, null, null, null, 52.00m, "ANDREA REGINA J. B. RODRIGUES", 0, 5000.00m, null, null },
                    { new Guid("59e031f2-1569-4029-b704-559ae620c1ca"), false, null, 0.0, null, null, 27, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7666), null, null, null, null, null, 52.00m, "MONICA HELLE DE LIMA ROSA SILVA", 0, 5000.00m, null, null },
                    { new Guid("36bab26f-c494-4e90-9424-451e56aa5200"), false, null, 0.0, null, null, 42, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7515), null, null, null, null, null, 52.00m, "ANTONIA IVANA COSTA SOUSA", 0, 5000.00m, null, null },
                    { new Guid("a370a7fa-d247-4fe0-93e1-3f434a17a94d"), false, null, 0.0, null, null, 25, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7528), null, null, null, null, null, 52.00m, "CLEUDILENE DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("873978ff-605d-4040-b31b-042d1e2a1580"), false, null, 0.0, null, null, 44, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7534), null, null, null, null, null, 52.00m, "CRISTIANE SOARES COSTA", 0, 5000.00m, null, null },
                    { new Guid("faa32eff-0aed-4927-ae59-bc8b75031f6e"), false, null, 0.0, null, null, 40, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7543), null, null, null, null, null, 52.00m, "DANIEL DE ARAUJO MOTA", 0, 5000.00m, null, null },
                    { new Guid("3c52510c-2c55-45d3-a476-df8ff3713892"), false, null, 0.0, null, null, 41, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7549), null, null, null, null, null, 52.00m, "DAYARA BORGES LUCENA", 0, 5000.00m, null, null },
                    { new Guid("6825f468-bb6e-4c5c-b628-3a976b5fedef"), false, null, 0.0, null, null, 36, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7554), null, null, null, null, null, 52.00m, "DENILZA  ALVES PINTO DUARTE", 0, 5000.00m, null, null },
                    { new Guid("83e5a89d-0368-42f6-bb21-453f260b5539"), false, null, 0.0, null, null, 28, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7558), null, null, null, null, null, 52.00m, "DEREK DILERVANDO DE O. PANTOJA", 0, 5000.00m, null, null },
                    { new Guid("3c171b33-9622-41f9-90a3-7970ede36ef0"), false, null, 0.0, null, null, 19, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7563), null, null, null, null, null, 52.00m, "DHONAYARA DA SILVA DE CAMPOS AMORIM", 0, 5000.00m, null, null },
                    { new Guid("a3d8cd5c-d012-400d-8a2e-b090595e6101"), false, null, 0.0, null, null, 26, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7523), null, null, null, null, null, 52.00m, "CACIELY VALERIO GOMES", 0, 5000.00m, null, null },
                    { new Guid("22e88e6f-6df2-4e6e-a1bc-e1f53c4fd4d4"), false, null, 0.0, null, null, 54, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7674), null, null, null, null, null, 52.00m, "NATHALIA DA SILVA MARQUES", 0, 5000.00m, null, null },
                    { new Guid("9347162e-de02-43dc-890b-7ed756017b0c"), false, null, 0.0, null, null, 3, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7670), null, null, null, null, null, 52.00m, "NATANAEL SOUA BARROS", 0, 5000.00m, null, null },
                    { new Guid("8f469731-997d-4768-a7bf-bb958357e37f"), false, null, 0.0, null, null, 23, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7726), null, null, null, null, null, 52.00m, "RAIANE OCAES OLIVEIRA DE SOUZA", 0, 5000.00m, null, null },
                    { new Guid("926b082a-29de-4e53-b0db-1bcd70535210"), false, null, 0.0, null, null, 63, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7832), null, null, null, null, null, 52.00m, "DEUZIMAR LIMA DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("3395f625-2acb-470d-8481-c28e3c96b376"), false, null, 0.0, null, null, 7, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7836), null, null, null, null, null, 52.00m, "DAYARA NOLETO ALVES", 0, 5000.00m, null, null },
                    { new Guid("0a4526af-fa78-49bd-b539-ad717afde2a3"), false, null, 0.0, null, null, 65, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7841), null, null, null, null, null, 52.00m, "LORENE SILVA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Colaboradors",
                columns: new[] { "Id", "Ativo", "Bairro", "CargaHorariaSemanal", "CargoId", "Cidade", "CodPonto", "Contratacao", "Cpf", "Demissao", "Email", "Endereco", "Estado", "HoraAula", "Nome", "Numero", "Salario", "Telefone", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("92063ae4-1a7a-4efc-89ed-197fa8233f36"), false, null, 0.0, null, null, 66, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7845), null, null, null, null, null, 52.00m, "JOSE ROBERTO", 0, 5000.00m, null, null },
                    { new Guid("a753ff33-04b6-4251-b8d5-8560512a6394"), false, null, 0.0, null, null, 67, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7850), null, null, null, null, null, 52.00m, "GABRIEL DE ARAUJO VEIGA", 0, 5000.00m, null, null },
                    { new Guid("3709fe4c-552c-434d-b14c-82b9142a9942"), false, null, 0.0, null, null, 68, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7855), null, null, null, null, null, 52.00m, "MIREIA SOZA BARROS", 0, 5000.00m, null, null },
                    { new Guid("98770ba0-b214-4694-8863-0ceb3d1ba1a0"), false, null, 0.0, null, null, 69, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7859), null, null, null, null, null, 52.00m, "MARINA LINS DE SOUZA AMADO", 0, 5000.00m, null, null },
                    { new Guid("b40651bf-0316-49c5-a055-5ab70d4aa8cc"), false, null, 0.0, null, null, 38, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7679), null, null, null, null, null, 52.00m, "NILCELIA DE LIMA ROCHA", 0, 5000.00m, null, null },
                    { new Guid("098ccde9-999f-41f5-8b42-06e245238f9d"), false, null, 0.0, null, null, 70, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7867), null, null, null, null, null, 52.00m, "ALVESLENE LEMS C DAMACENO", 0, 5000.00m, null, null },
                    { new Guid("5e1340ca-b937-4e25-9abe-bbad8767d31d"), false, null, 0.0, null, null, 72, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7879), null, null, null, null, null, 52.00m, "LUCAS MEDEIROS", 0, 5000.00m, null, null },
                    { new Guid("eeade45f-e89a-4f55-aee7-d67678d41f46"), false, null, 0.0, null, null, 73, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7884), null, null, null, null, null, 52.00m, "ELIANE MORAES", 0, 5000.00m, null, null },
                    { new Guid("e5e43023-c257-4e2f-b249-c7c14c09305b"), false, null, 0.0, null, null, 74, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7889), null, null, null, null, null, 52.00m, "DANIELLE LIMA SANTOS", 0, 5000.00m, null, null },
                    { new Guid("250e589f-97d0-430b-95b1-f8730c3b471a"), false, null, 0.0, null, null, 75, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7893), null, null, null, null, null, 52.00m, "TASSIO VINICIUS", 0, 5000.00m, null, null },
                    { new Guid("a9f70efb-9437-4173-9664-8a32b6a7068f"), false, null, 0.0, null, null, 78, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7898), null, null, null, null, null, 52.00m, "DANIELA LIMA", 0, 5000.00m, null, null },
                    { new Guid("dd04be8d-c7fb-44e0-8c92-0b3ec5602e61"), false, null, 0.0, null, null, 79, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7902), null, null, null, null, null, 52.00m, "ALAN GOMES", 0, 5000.00m, null, null },
                    { new Guid("cff53184-5291-4bf4-9525-67948bcc7464"), false, null, 0.0, null, null, 80, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7910), null, null, null, null, null, 52.00m, "KASSIO FERNANDO", 0, 5000.00m, null, null },
                    { new Guid("c0c859a4-3c1d-4743-b982-5ae226dc4755"), false, null, 0.0, null, null, 71, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7875), null, null, null, null, null, 52.00m, "APINAGES PIRES CARDOSO", 0, 5000.00m, null, null },
                    { new Guid("fcfe1136-f9cf-4a61-ad59-b68dbabc42f6"), false, null, 0.0, null, null, 62, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7819), null, null, null, null, null, 52.00m, "THALYTA RODRIGUES BARBOSA GIL		 ", 0, 5000.00m, null, null },
                    { new Guid("1dbd9d13-38cf-4c56-97a5-c023363fc2f7"), false, null, 0.0, null, null, 64, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7826), null, null, null, null, null, 52.00m, "DHELEN SILVA ALMEIDA", 0, 5000.00m, null, null },
                    { new Guid("f7b4ff1a-0bbe-49bb-b966-b19fcf2fe04d"), false, null, 0.0, null, null, 61, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7809), null, null, null, null, null, 52.00m, "BRUNO MORAES", 0, 5000.00m, null, null },
                    { new Guid("51a787c3-2c27-4ef0-b511-9dca4ea740ca"), false, null, 0.0, null, null, 20, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7732), null, null, null, null, null, 52.00m, "RAILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("68e8585c-e097-4cd9-8a09-cd624a25b88e"), false, null, 0.0, null, null, 15, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7737), null, null, null, null, null, 52.00m, "RAQUEL BRITO DOS SANTOS", 0, 5000.00m, null, null },
                    { new Guid("b8080992-cd8b-4fef-bcf3-1ab73b44f782"), false, null, 0.0, null, null, 32, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7741), null, null, null, null, null, 52.00m, "ROSILENE CONCEIÇÃO DE CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("34156e94-6515-4d09-9f7e-212f8105502f"), false, null, 0.0, null, null, 16, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7748), null, null, null, null, null, 52.00m, "SAMARA DE OLIVEIRA MOREIRA CABRAL", 0, 5000.00m, null, null },
                    { new Guid("5704f377-74ff-4276-b46e-21b913c6213d"), false, null, 0.0, null, null, 47, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7753), null, null, null, null, null, 52.00m, "SILVIO VIANA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("6a595ae9-44eb-4c96-8ccd-785b2cfd90fc"), false, null, 0.0, null, null, 6, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7814), null, null, null, null, null, 52.00m, "CIBELLE DA SILVA CARVALHO", 0, 5000.00m, null, null },
                    { new Guid("af52fbb6-9020-4dd0-8ad4-b8c94f90e267"), false, null, 0.0, null, null, 56, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7761), null, null, null, null, null, 52.00m, "SUANY ISAIAS DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("3febbfb4-d3fc-4fd8-9884-125bd8881428"), false, null, 0.0, null, null, 17, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7766), null, null, null, null, null, 52.00m, "TOMAZ B. NERY S. CAMPOS", 0, 5000.00m, null, null },
                    { new Guid("a89b17ac-e9fb-4c16-bc78-dea0b70bf0e6"), false, null, 0.0, null, null, 4, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7757), null, null, null, null, null, 52.00m, "SIRLEI VANDA ANDRADE", 0, 5000.00m, null, null },
                    { new Guid("af331fe2-55b3-4e5e-b16c-4a23b3444052"), false, null, 0.0, null, null, 18, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7775), null, null, null, null, null, 52.00m, "WALDEMIR DE SOUZA REIS", 0, 5000.00m, null, null },
                    { new Guid("b3bf54d1-e616-404e-96e2-c6e8e27d5f20"), false, null, 0.0, null, null, 21, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7779), null, null, null, null, null, 52.00m, "WALISON RICARDO GOES DA PASCOA", 0, 5000.00m, null, null },
                    { new Guid("f5b90d56-d10b-48a1-a3c6-0943d4826b9a"), false, null, 0.0, null, null, 52, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7787), null, null, null, null, null, 52.00m, "WARLY BEZERRA DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("2dd873e4-e152-4d8e-ac85-ed45e13f613d"), false, null, 0.0, null, null, 57, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7791), null, null, null, null, null, 52.00m, "RENATA CAMILY SIRQUEIRA PALHETA", 0, 5000.00m, null, null },
                    { new Guid("d5cfb976-3b09-4dd3-9812-4a1c1655fa80"), false, null, 0.0, null, null, 58, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7795), null, null, null, null, null, 52.00m, "YURI DO CARMO MOREIRA", 0, 5000.00m, null, null },
                    { new Guid("562a266d-26c9-43ed-9579-cc1eb9e7bfaa"), false, null, 0.0, null, null, 59, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7800), null, null, null, null, null, 52.00m, "VALDEMAR JUSTO", 0, 5000.00m, null, null },
                    { new Guid("f7c9c57f-7d34-40b0-92e2-6a08dd83e999"), false, null, 0.0, null, null, 60, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7804), null, null, null, null, null, 52.00m, "EDSON DA SILVA", 0, 5000.00m, null, null },
                    { new Guid("1e05cda4-cea3-476f-84be-3819df5d77cc"), false, null, 0.0, null, null, 49, new DateTime(2021, 11, 5, 21, 44, 10, 613, DateTimeKind.Local).AddTicks(7770), null, null, null, null, null, 52.00m, "VANESSA MOURA DE ALMEIDA", 0, 5000.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Id", "EnderecoEmail", "Nome" },
                values: new object[] { new Guid("1205b71c-4be1-4b3c-83c9-7b92947a85d5"), "edivaldomachado@gmailcom", "Edivaldo" });

            migrationBuilder.InsertData(
                table: "Feriado",
                columns: new[] { "Id", "DataFeriado", "Descricao" },
                values: new object[,]
                {
                    { new Guid("0a977562-4b40-4900-81aa-7ee534576b99"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proclamacao da republica" },
                    { new Guid("d82813ae-338f-4ef3-b2a0-9a668b80d3de"), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ano Novo" },
                    { new Guid("0a3a28b5-be2c-4b7d-9031-a2413d959e30"), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natal" },
                    { new Guid("8715cfa8-2d84-4311-abd8-3a72368a9ec9"), new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finados" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Bairro", "CNPJ", "Cidade", "Endereco", "Nome", "Numero", "RazaoSocial" },
                values: new object[,]
                {
                    { new Guid("9362932f-4fa6-46ea-bdf1-757c99da1d02"), "Centro", "123123123/1234-12", "Eldorado dos Carajás", "Rua Sol Poente", "Eldorado dos Carajas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("c14eaf77-ed96-46f0-9730-716dc864f15a"), "Bairro da Paz", "123123123/1234-12", "Parauapebas", "Rua Sol Poente", "Parauapebas", 152, "EDIVALDO MACHADO BARBALHO" },
                    { new Guid("54b672ee-1d5e-428a-a2dd-e2099d82ac0d"), "Centro", "123123123/1234-12", "Canaa dos Carajas", "Rua Sol Poente", "Canaa dos CArajas", 152, "EDIVALDO MACHADO BARBALHO" }
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
