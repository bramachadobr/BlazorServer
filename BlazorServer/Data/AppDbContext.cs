using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


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
            //Fazer Update em Colaborador.Cargos apos os inserts
            //Implementar as validações nos add de cada objeto

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

            #region Colaboradores


            modelBuilder.Entity<Colaborador>().HasData(
                    new Colaborador() { CodPonto = 39, Cpf = "", Nome = "ALEXSANDRA KETHY DE FRANÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 22, Cpf = "", Nome = "ALVARO RICK P. VIEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 50, Cpf = "", Nome = "AMADEU JUNIOR FERREIRA DE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 46, Cpf = "", Nome = "ANA ALICE DA MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 35, Cpf = "", Nome = "ANDERSON CRISTIANO SALES SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 5, Cpf = "", Nome = "ANDRÉ DA CONCEIÇÃO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 37, Cpf = "", Nome = "ANDREA REGINA J. B. RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 42, Cpf = "", Nome = "ANTONIA IVANA COSTA SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 26, Cpf = "", Nome = "CACIELY VALERIO GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 25, Cpf = "", Nome = "CLEUDILENE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 44, Cpf = "", Nome = "CRISTIANE SOARES COSTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 40, Cpf = "", Nome = "DANIEL DE ARAUJO MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 41, Cpf = "", Nome = "DAYARA BORGES LUCENA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 36, Cpf = "", Nome = "DENILZA  ALVES PINTO DUARTE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 28, Cpf = "", Nome = "DEREK DILERVANDO DE O. PANTOJA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 19, Cpf = "", Nome = "DHONAYARA DA SILVA DE CAMPOS AMORIM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 2, Cpf = "", Nome = "EDI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 45, Cpf = "", Nome = "ELAINE DE JESUS REZENDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 48, Cpf = "", Nome = "ERCILIO DE CASTRO  BARBOZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 29, Cpf = "", Nome = "FERNANDO CABRAL DA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 24, Cpf = "", Nome = "FRANCINOLIA R A L C", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 9, Cpf = "", Nome = "GLICIANE ESTEPHANE JACOME DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 31, Cpf = "", Nome = "HUDLER LEITE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 33, Cpf = "", Nome = "IRISMAR SILVA CIRINO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 34, Cpf = "", Nome = "JAKELLYNE ALVES BRANDÃO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 10, Cpf = "", Nome = "JHYEIVSON WALLINTER SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 43, Cpf = "", Nome = "JORDANIA DE MACEDO MENDONÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 11, Cpf = "", Nome = "JORGE CLESIO SILVA E SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 12, Cpf = "", Nome = "JORGE FERNANDO CASTRO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 51, Cpf = "", Nome = "JUCIENE IONARIA DE S. GABRIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 55, Cpf = "", Nome = "LEILSON RODRIGUES DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 13, Cpf = "", Nome = "LORENA MATOS SILVA PRADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 30, Cpf = "", Nome = "LUANA MARTINS ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 53, Cpf = "", Nome = "MARIANA LEAL OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 14, Cpf = "", Nome = "MAYARA DE OLIVEIRA PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 27, Cpf = "", Nome = "MONICA HELLE DE LIMA ROSA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 3, Cpf = "", Nome = "NATANAEL SOUA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 54, Cpf = "", Nome = "NATHALIA DA SILVA MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 38, Cpf = "", Nome = "NILCELIA DE LIMA ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 23, Cpf = "", Nome = "RAIANE OCAES OLIVEIRA DE SOUZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 20, Cpf = "", Nome = "RAILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 15, Cpf = "", Nome = "RAQUEL BRITO DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 32, Cpf = "", Nome = "ROSILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 16, Cpf = "", Nome = "SAMARA DE OLIVEIRA MOREIRA CABRAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 47, Cpf = "", Nome = "SILVIO VIANA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 4, Cpf = "", Nome = "SIRLEI VANDA ANDRADE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 56, Cpf = "", Nome = "SUANY ISAIAS DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 17, Cpf = "", Nome = "TOMAZ B. NERY S. CAMPOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 49, Cpf = "", Nome = "VANESSA MOURA DE ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 18, Cpf = "", Nome = "WALDEMIR DE SOUZA REIS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 21, Cpf = "", Nome = "WALISON RICARDO GOES DA PASCOA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 52, Cpf = "", Nome = "WARLY BEZERRA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 57, Cpf = "", Nome = "RENATA CAMILY SIRQUEIRA PALHETA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 58, Cpf = "", Nome = "YURI DO CARMO MOREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 59, Cpf = "", Nome = "VALDEMAR JUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 60, Cpf = "", Nome = "EDSON DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 61, Cpf = "", Nome = "BRUNO MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 6, Cpf = "", Nome = "CIBELLE DA SILVA CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 62, Cpf = "", Nome = "THALYTA RODRIGUES BARBOSA GIL		 ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 64, Cpf = "", Nome = "DHELEN SILVA ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 63, Cpf = "", Nome = "DEUZIMAR LIMA DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 7, Cpf = "", Nome = "DAYARA NOLETO ALVES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 65, Cpf = "", Nome = "LORENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 66, Cpf = "", Nome = "JOSE ROBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 67, Cpf = "", Nome = "GABRIEL DE ARAUJO VEIGA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 68, Cpf = "", Nome = "MIREIA SOZA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 69, Cpf = "", Nome = "MARINA LINS DE SOUZA AMADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 70, Cpf = "", Nome = "ALVESLENE LEMS C DAMACENO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 71, Cpf = "", Nome = "APINAGES PIRES CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 72, Cpf = "", Nome = "LUCAS MEDEIROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 73, Cpf = "", Nome = "ELIANE MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 74, Cpf = "", Nome = "DANIELLE LIMA SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 75, Cpf = "", Nome = "TASSIO VINICIUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 78, Cpf = "", Nome = "DANIELA LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 79, Cpf = "", Nome = "ALAN GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 80, Cpf = "", Nome = "KASSIO FERNANDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 81, Cpf = "", Nome = "MARYANNE STEPHANE ROCHA G", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 76, Cpf = "", Nome = "FERNANDO ATROCH", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 82, Cpf = "", Nome = "PEDRO AUGUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 83, Cpf = "", Nome = "ELAINE JULIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 84, Cpf = "", Nome = "JOSELINO DANTAS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 85, Cpf = "", Nome = "BRNDAO REINALDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 86, Cpf = "", Nome = "MOISES HAMSSES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 87, Cpf = "", Nome = "DIANA MARROCOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 88, Cpf = "", Nome = "JOAO VICTOR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 89, Cpf = "", Nome = "EDNA MOIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 91, Cpf = "", Nome = "MARCIA BARRETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 94, Cpf = "", Nome = "JESSICA MELO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 93, Cpf = "", Nome = "TARCIA ALEXANDRE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 90, Cpf = "", Nome = "WELLIDA AVIZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 95, Cpf = "", Nome = "FERNANDO AMOURY", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 77, Cpf = "", Nome = "ALLAN WERBERTT", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 96, Cpf = "", Nome = "THAISE MORGANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 97, Cpf = "", Nome = "CRISLANE SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 98, Cpf = "", Nome = "YARA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 99, Cpf = "", Nome = "LUCIANO LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 100, Cpf = "", Nome = "FRANCYANNE CASTRO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 101, Cpf = "", Nome = "KESIA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 102, Cpf = "", Nome = "MAIZA NONATO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 103, Cpf = "", Nome = "ANDERSON MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 104, Cpf = "", Nome = "RODRIGO CESAR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 105, Cpf = "", Nome = "JOSE DE ARIMATEIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 106, Cpf = "", Nome = "HENRIQUE NOLETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 107, Cpf = "", Nome = "ISABELA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 108, Cpf = "", Nome = "IOLENE VIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 109, Cpf = "", Nome = "WESLLEY SOARES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 110, Cpf = "", Nome = "DIVINO SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 111, Cpf = "", Nome = "ALINE LOPES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 112, Cpf = "", Nome = "JOSIEL MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 113, Cpf = "", Nome = "TATIANA RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 114, Cpf = "", Nome = "IVANA TUTORIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 115, Cpf = "", Nome = "CARLOS EDUARDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 116, Cpf = "", Nome = "CASSIO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 117, Cpf = "", Nome = "ELLEN CLEIDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 118, Cpf = "", Nome = "MARIA MARLI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 119, Cpf = "", Nome = "MIRIA FERREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 120, Cpf = "", Nome = "VICTOR DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 121, Cpf = "", Nome = "ANA TEREZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 122, Cpf = "", Nome = "HEYGON TED", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 123, Cpf = "", Nome = "RILDO AMARAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 124, Cpf = "", Nome = "GERLYNNE PESSOA DE CARVALHO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 125, Cpf = "", Nome = "MATHEUS HENRIQUE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 126, Cpf = "", Nome = "THAMYRES SALOMAO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 127, Cpf = "", Nome = "SAMILLY GURGEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 128, Cpf = "", Nome = "HILLARY SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 129, Cpf = "", Nome = "PALMEIRA JR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 130, Cpf = "", Nome = "RONIEL MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 131, Cpf = "", Nome = "ALINE PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 132, Cpf = "", Nome = "RAYANE MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 133, Cpf = "", Nome = "LIDIA SOUSA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 134, Cpf = "", Nome = "ELZA MARIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 135, Cpf = "", Nome = "SELMA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 136, Cpf = "", Nome = "CAMILA LETICIA P", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 137, Cpf = "", Nome = "THIAGO MESQUITA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 138, Cpf = "", Nome = "IRLAINE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 139, Cpf = "", Nome = "CARLOS ALBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 140, Cpf = "", Nome = "ERIVELTON DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 141, Cpf = "", Nome = "ERICK LEAO FERRAZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 142, Cpf = "", Nome = "LARISSA CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 143, Cpf = "", Nome = "SERGIO DE JESUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 144, Cpf = "", Nome = "FLAVIANA DE OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 145, Cpf = "", Nome = "AMANDA GOULART", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 146, Cpf = "", Nome = "ADAO DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 147, Cpf = "", Nome = "SIMONE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 148, Cpf = "", Nome = "LUCIMARA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 149, Cpf = "", Nome = "CARMEM NATANNA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 150, Cpf = "", Nome = "RAIRONE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 151, Cpf = "", Nome = "RODRIGO DRELIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 152, Cpf = "", Nome = "KALIMY DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 153, Cpf = "", Nome = "CYMARA FRANCO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 154, Cpf = "", Nome = "SCARLETT MILHOMEM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 155, Cpf = "", Nome = "KIANE SANTANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 156, Cpf = "", Nome = "EDUARDO MENDES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 157, Cpf = "", Nome = "JUCILENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 158, Cpf = "", Nome = "ALMIR DALMOLIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 159, Cpf = "", Nome = "IRLEN SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 160, Cpf = "", Nome = "PATRICIA ZEN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 161, Cpf = "", Nome = "CAROLAINE MELO MOREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 162, Cpf = "", Nome = "DANIELLA SIQUEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 163, Cpf = "", Nome = "CLARA PAULA SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 164, Cpf = "", Nome = "JEFTE DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 165, Cpf = "", Nome = "GISELLE SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 166, Cpf = "", Nome = "FREDSON LEITE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 167, Cpf = "", Nome = "THAMIRES GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 168, Cpf = "", Nome = "FERNANDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") }
                );

            #endregion



        }

        void AtualizaDados()
        {
            //List<Colaborador> lista = new List<Colaborador>();
            IEnumerable<Colaborador> lista;

            using (var ctx = new AppDbContext())
            {
                lista = ctx.Colaboradors.Where(a => a.Cargo == null);
                if (lista.Count() <= 0)
                {
                    return;
                }
                foreach (var item in lista)
                {
                    item.Cargo = ctx.Cargo.Where(a => a.NomeCargo.Contains("Tutor")).FirstOrDefault();
                    ctx.Entry(item).State = EntityState.Modified;
                }

                ctx.SaveChanges();
            }
        }


    }
}