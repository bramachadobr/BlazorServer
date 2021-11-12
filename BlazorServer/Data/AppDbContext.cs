using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorServer.Data
{
    public class AppDbContext : DbContext
    {

        //ctor - atalho para o construtor da class

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Colaborador> Colaboradors { get; set; }
        public DbSet<RegistroPonto> RegistroPontos { get; set; }
        public DbSet<Feriado> Feriado { get; set; }
        public DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Feriado>().HasData(
                new Feriado { Descricao = "Ano Novo", DataFeriado = DateTime.Parse("31/12/2021") },
                new Feriado { Descricao = "Natal", DataFeriado = DateTime.Parse("25/12/2021") },
                new Feriado { Descricao = "Proclamacao da republica", DataFeriado = DateTime.Parse("15/11/2021") },
                new Feriado { Descricao = "Finados", DataFeriado = DateTime.Parse("02/11/2021") }
                );

            modelBuilder.Entity<Email>().HasData(
                new Email { Nome = "Edivaldo", EnderecoEmail = "edivaldomachado@gmailcom" }
                );

            modelBuilder.Entity<Unidade>().HasData(
                new Unidade() { Nome = "Parauapebas", Bairro = "Bairro da Paz", Numero = 152, Cidade = "Parauapebas", CNPJ = "123123123/1234-12", Endereco = "Rua Sol Poente", RazaoSocial = "EDIVALDO MACHADO BARBALHO" },
                new Unidade { Nome = "Eldorado dos Carajas", Bairro = "Centro", Numero = 152, Cidade = "Eldorado dos Carajás", CNPJ = "123123123/1234-12", Endereco = "Rua Sol Poente", RazaoSocial = "EDIVALDO MACHADO BARBALHO" },
                new Unidade { Nome = "Canaa dos Carajas", Bairro = "Centro", Numero = 152, Cidade = "Canaa dos Carajas", CNPJ = "123123123/1234-12", Endereco = "Rua Sol Poente", RazaoSocial = "EDIVALDO MACHADO BARBALHO" }
                );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo() { NomeCargo = "Tutor" },
                new Cargo() { NomeCargo = "Secretaria" },
                new Cargo() { NomeCargo = "Comercial" },
                new Cargo() { NomeCargo = "Coordenador" },
                new Cargo() { NomeCargo = "Professor" }
                );

            modelBuilder.Entity<Colaborador>().HasData(
                    new Colaborador() { CodPonto = 39, Nome = "ALEXSANDRA KETHY DE FRANÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 22, Nome = "ALVARO RICK P. VIEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 50, Nome = "AMADEU JUNIOR FERREIRA DE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 46, Nome = "ANA ALICE DA MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 35, Nome = "ANDERSON CRISTIANO SALES SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 5, Nome = "ANDRÉ DA CONCEIÇÃO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 37, Nome = "ANDREA REGINA J. B. RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 42, Nome = "ANTONIA IVANA COSTA SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 26, Nome = "CACIELY VALERIO GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 25, Nome = "CLEUDILENE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 44, Nome = "CRISTIANE SOARES COSTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 40, Nome = "DANIEL DE ARAUJO MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 41, Nome = "DAYARA BORGES LUCENA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 36, Nome = "DENILZA  ALVES PINTO DUARTE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 28, Nome = "DEREK DILERVANDO DE O. PANTOJA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 19, Nome = "DHONAYARA DA SILVA DE CAMPOS AMORIM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 2, Nome = "EDI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 45, Nome = "ELAINE DE JESUS REZENDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 48, Nome = "ERCILIO DE CASTRO  BARBOZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 29, Nome = "FERNANDO CABRAL DA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 24, Nome = "FRANCINOLIA R A L C", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 9, Nome = "GLICIANE ESTEPHANE JACOME DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 31, Nome = "HUDLER LEITE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 33, Nome = "IRISMAR SILVA CIRINO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 34, Nome = "JAKELLYNE ALVES BRANDÃO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 10, Nome = "JHYEIVSON WALLINTER SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 43, Nome = "JORDANIA DE MACEDO MENDONÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 11, Nome = "JORGE CLESIO SILVA E SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 12, Nome = "JORGE FERNANDO CASTRO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 51, Nome = "JUCIENE IONARIA DE S. GABRIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 55, Nome = "LEILSON RODRIGUES DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 13, Nome = "LORENA MATOS SILVA PRADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 30, Nome = "LUANA MARTINS ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 53, Nome = "MARIANA LEAL OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 14, Nome = "MAYARA DE OLIVEIRA PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 27, Nome = "MONICA HELLE DE LIMA ROSA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 3, Nome = "NATANAEL SOUA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 54, Nome = "NATHALIA DA SILVA MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 38, Nome = "NILCELIA DE LIMA ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 23, Nome = "RAIANE OCAES OLIVEIRA DE SOUZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 20, Nome = "RAILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 15, Nome = "RAQUEL BRITO DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 32, Nome = "ROSILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 16, Nome = "SAMARA DE OLIVEIRA MOREIRA CABRAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 47, Nome = "SILVIO VIANA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 4, Nome = "SIRLEI VANDA ANDRADE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 56, Nome = "SUANY ISAIAS DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 17, Nome = "TOMAZ B. NERY S. CAMPOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 49, Nome = "VANESSA MOURA DE ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 18, Nome = "WALDEMIR DE SOUZA REIS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 21, Nome = "WALISON RICARDO GOES DA PASCOA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 52, Nome = "WARLY BEZERRA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 57, Nome = "RENATA CAMILY SIRQUEIRA PALHETA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 58, Nome = "YURI DO CARMO MOREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 59, Nome = "VALDEMAR JUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 60, Nome = "EDSON DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 61, Nome = "BRUNO MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 6, Nome = "CIBELLE DA SILVA CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 62, Nome = "THALYTA RODRIGUES BARBOSA GIL		 ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 64, Nome = "DHELEN SILVA ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 63, Nome = "DEUZIMAR LIMA DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 7, Nome = "DAYARA NOLETO ALVES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 65, Nome = "LORENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 66, Nome = "JOSE ROBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 67, Nome = "GABRIEL DE ARAUJO VEIGA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 68, Nome = "MIREIA SOZA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 69, Nome = "MARINA LINS DE SOUZA AMADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 70, Nome = "ALVESLENE LEMS C DAMACENO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 71, Nome = "APINAGES PIRES CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 72, Nome = "LUCAS MEDEIROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 73, Nome = "ELIANE MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 74, Nome = "DANIELLE LIMA SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 75, Nome = "TASSIO VINICIUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 78, Nome = "DANIELA LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 79, Nome = "ALAN GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 80, Nome = "KASSIO FERNANDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 81, Nome = "MARYANNE STEPHANE ROCHA G", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 76, Nome = "FERNANDO ATROCH", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 82, Nome = "PEDRO AUGUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 83, Nome = "ELAINE JULIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 84, Nome = "JOSELINO DANTAS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 85, Nome = "BRNDAO REINALDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 86, Nome = "MOISES HAMSSES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 87, Nome = "DIANA MARROCOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 88, Nome = "JOAO VICTOR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 89, Nome = "EDNA MOIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 91, Nome = "MARCIA BARRETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 94, Nome = "JESSICA MELO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 93, Nome = "TARCIA ALEXANDRE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 90, Nome = "WELLIDA AVIZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 95, Nome = "FERNANDO AMOURY", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 77, Nome = "ALLAN WERBERTT", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 96, Nome = "THAISE MORGANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 97, Nome = "CRISLANE SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 98, Nome = "YARA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 99, Nome = "LUCIANO LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 100, Nome = "FRANCYANNE CASTRO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 101, Nome = "KESIA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 102, Nome = "MAIZA NONATO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 103, Nome = "ANDERSON MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 104, Nome = "RODRIGO CESAR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 105, Nome = "JOSE DE ARIMATEIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 106, Nome = "HENRIQUE NOLETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 107, Nome = "ISABELA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 108, Nome = "IOLENE VIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 109, Nome = "WESLLEY SOARES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 110, Nome = "DIVINO SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 111, Nome = "ALINE LOPES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 112, Nome = "JOSIEL MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 113, Nome = "TATIANA RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 114, Nome = "IVANA TUTORIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 115, Nome = "CARLOS EDUARDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 116, Nome = "CASSIO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 117, Nome = "ELLEN CLEIDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 118, Nome = "MARIA MARLI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 119, Nome = "MIRIA FERREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 120, Nome = "VICTOR DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 121, Nome = "ANA TEREZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 122, Nome = "HEYGON TED", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 123, Nome = "RILDO AMARAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 124, Nome = "GERLYNNE PESSOA DE CARVALHO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 125, Nome = "MATHEUS HENRIQUE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 126, Nome = "THAMYRES SALOMAO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 127, Nome = "SAMILLY GURGEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 128, Nome = "HILLARY SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 129, Nome = "PALMEIRA JR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 130, Nome = "RONIEL MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 131, Nome = "ALINE PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 132, Nome = "RAYANE MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 133, Nome = "LIDIA SOUSA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 134, Nome = "ELZA MARIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 135, Nome = "SELMA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 136, Nome = "CAMILA LETICIA P", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 137, Nome = "THIAGO MESQUITA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 138, Nome = "IRLAINE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 139, Nome = "CARLOS ALBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 140, Nome = "ERIVELTON DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 141, Nome = "ERICK LEAO FERRAZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 142, Nome = "LARISSA CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 143, Nome = "SERGIO DE JESUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 144, Nome = "FLAVIANA DE OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 145, Nome = "AMANDA GOULART", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 146, Nome = "ADAO DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 147, Nome = "SIMONE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 148, Nome = "LUCIMARA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 149, Nome = "CARMEM NATANNA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 150, Nome = "RAIRONE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 151, Nome = "RODRIGO DRELIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 152, Nome = "KALIMY DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 153, Nome = "CYMARA FRANCO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 154, Nome = "SCARLETT MILHOMEM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 155, Nome = "KIANE SANTANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 156, Nome = "EDUARDO MENDES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 157, Nome = "JUCILENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 158, Nome = "ALMIR DALMOLIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") }
                );


        }

    }
}