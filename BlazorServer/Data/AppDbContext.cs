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
                    new Colaborador() { CodPonto = 39, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALEXSANDRA KETHY DE FRANÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 22, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALVARO RICK P. VIEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 50, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "AMADEU JUNIOR FERREIRA DE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 46, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANA ALICE DA MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 35, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANDERSON CRISTIANO SALES SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 5,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "ANDRÉ DA CONCEIÇÃO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 37, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANDREA REGINA J. B. RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 42, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANTONIA IVANA COSTA SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 26, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CACIELY VALERIO GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 25, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CLEUDILENE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 44, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CRISTIANE SOARES COSTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 40, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DANIEL DE ARAUJO MOTA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 41, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DAYARA BORGES LUCENA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 36, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DENILZA  ALVES PINTO DUARTE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 28, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DEREK DILERVANDO DE O. PANTOJA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 19, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DHONAYARA DA SILVA DE CAMPOS AMORIM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 2,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "EDI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 45, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ELAINE DE JESUS REZENDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 48, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ERCILIO DE CASTRO  BARBOZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 29, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FERNANDO CABRAL DA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 24, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FRANCINOLIA R A L C", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 9,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "GLICIANE ESTEPHANE JACOME DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 31, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "HUDLER LEITE DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 33, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "IRISMAR SILVA CIRINO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 34, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JAKELLYNE ALVES BRANDÃO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 10, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JHYEIVSON WALLINTER SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 43, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JORDANIA DE MACEDO MENDONÇA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 11, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JORGE CLESIO SILVA E SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 12, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JORGE FERNANDO CASTRO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 51, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JUCIENE IONARIA DE S. GABRIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 55, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LEILSON RODRIGUES DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 13, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LORENA MATOS SILVA PRADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 30, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LUANA MARTINS ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 53, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MARIANA LEAL OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 14, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MAYARA DE OLIVEIRA PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 27, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MONICA HELLE DE LIMA ROSA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 3,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "NATANAEL SOUA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 54, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "NATHALIA DA SILVA MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 38, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "NILCELIA DE LIMA ROCHA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 23, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RAIANE OCAES OLIVEIRA DE SOUZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 20, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RAILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 15, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RAQUEL BRITO DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 32, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ROSILENE CONCEIÇÃO DE CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 16, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SAMARA DE OLIVEIRA MOREIRA CABRAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 47, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SILVIO VIANA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 4,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "SIRLEI VANDA ANDRADE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 56, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SUANY ISAIAS DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 17, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "TOMAZ B. NERY S. CAMPOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 49, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "VANESSA MOURA DE ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 18, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "WALDEMIR DE SOUZA REIS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 21, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "WALISON RICARDO GOES DA PASCOA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 52, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "WARLY BEZERRA DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 57, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RENATA CAMILY SIRQUEIRA PALHETA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 58, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "YURI DO CARMO MOREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 59, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "VALDEMAR JUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 60, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "EDSON DA SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 61, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "BRUNO MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 6,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "CIBELLE DA SILVA CARVALHO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 62, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "THALYTA RODRIGUES BARBOSA GIL		 ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 64, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DHELEN SILVA ALMEIDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 63, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DEUZIMAR LIMA DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 7,  Telefone="99999999", Email="asd@asd.com",Cpf = "", Nome = "DAYARA NOLETO ALVES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 65, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LORENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 66, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JOSE ROBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 67, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "GABRIEL DE ARAUJO VEIGA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 68, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MIREIA SOZA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 69, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MARINA LINS DE SOUZA AMADO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 70, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALVESLENE LEMS C DAMACENO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 71, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "APINAGES PIRES CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 72, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LUCAS MEDEIROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 73, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ELIANE MORAES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 74, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DANIELLE LIMA SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 75, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "TASSIO VINICIUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 78, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DANIELA LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 79, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALAN GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 80, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "KASSIO FERNANDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 81, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MARYANNE STEPHANE ROCHA G", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 76, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FERNANDO ATROCH", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 82, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "PEDRO AUGUSTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 83, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ELAINE JULIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 84, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JOSELINO DANTAS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 85, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "BRNDAO REINALDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 86, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MOISES HAMSSES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 87, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DIANA MARROCOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 88, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JOAO VICTOR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 89, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "EDNA MOIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 91, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MARCIA BARRETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 94, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JESSICA MELO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 93, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "TARCIA ALEXANDRE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 90, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "WELLIDA AVIZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 95, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FERNANDO AMOURY", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 77, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALLAN WERBERTT", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 96, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "THAISE MORGANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 97, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CRISLANE SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 98, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "YARA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 99, Telefone = "99999999", Email = "asd@asd.com", Cpf = "", Nome = "LUCIANO LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 100, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FRANCYANNE CASTRO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 101, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "KESIA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 102, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MAIZA NONATO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 103, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANDERSON MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 104, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RODRIGO CESAR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 105, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JOSE DE ARIMATEIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 106, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "HENRIQUE NOLETO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 107, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ISABELA MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 108, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "IOLENE VIANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 109, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "WESLLEY SOARES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 110, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DIVINO SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 111, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALINE LOPES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 112, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JOSIEL MACIEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 113, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "TATIANA RODRIGUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 114, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "IVANA TUTORIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 115, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CARLOS EDUARDO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 116, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CASSIO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 117, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ELLEN CLEIDE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 118, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MARIA MARLI", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 119, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MIRIA FERREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 120, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "VICTOR DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 121, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ANA TEREZA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 122, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "HEYGON TED", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 123, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RILDO AMARAL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 124, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "GERLYNNE PESSOA DE CARVALHO SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 125, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "MATHEUS HENRIQUE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 126, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "THAMYRES SALOMAO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 127, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SAMILLY GURGEL", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 128, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "HILLARY SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 129, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "PALMEIRA JR", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 130, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RONIEL MARQUES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 131, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALINE PEREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 132, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RAYANE MARTINS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 133, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LIDIA SOUSA BARROS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 134, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ELZA MARIA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 135, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SELMA OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 136, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CAMILA LETICIA P", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 137, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "THIAGO MESQUITA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 138, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "IRLAINE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 139, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CARLOS ALBERTO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 140, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ERIVELTON DOS SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 141, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ERICK LEAO FERRAZ", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 142, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LARISSA CARDOSO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 143, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SERGIO DE JESUS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 144, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FLAVIANA DE OLIVEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 145, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "AMANDA GOULART", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 146, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ADAO DE PAULA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 147, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SIMONE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 148, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "LUCIMARA FONSECA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 149, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CARMEM NATANNA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 150, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RAIRONE LIMA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 151, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "RODRIGO DRELIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 152, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "KALIMY DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 153, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CYMARA FRANCO", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 154, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "SCARLETT MILHOMEM", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 155, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "KIANE SANTANA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 156, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "EDUARDO MENDES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 157, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JUCILENE SILVA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 158, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "ALMIR DALMOLIN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 159, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "IRLEN SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 160, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "PATRICIA ZEN", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 161, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CAROLAINE MELO MOREIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 162, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "DANIELLA SIQUEIRA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 163, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "CLARA PAULA SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 164, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "JEFTE DE SOUSA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 165, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "GISELLE SANTOS", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 166, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "FREDSON LEITE", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 167, Telefone="99999999", Email="asd@asd.com", Cpf = "", Nome = "THAMIRES GOMES", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                    new Colaborador { CodPonto = 168, Telefone = "99999999", Email = "asd@asd.com", Cpf = "", Nome = "FERNANDA", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") }
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