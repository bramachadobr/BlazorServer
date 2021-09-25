using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public DbSet<Colaborador> Colaboradors { get; set; }

        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<Feriado> Feriado { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<RegistroPonto> RegistroPontos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Colaborador>().HasData(
                new Colaborador {  Nome="Edivaldo", Contratacao=DateTime.Now, HoraAula=Convert.ToDecimal("52,00"), Salario=Convert.ToDecimal("5000,00")},
                new Colaborador {  Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador {  Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador {  Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador {  Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador {  Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") }

                );

            modelBuilder.Entity<Email>().HasData(
                new Email { Nome ="Edivlado", EnderecoEmail = "edivaldomachado@gmailcom"},
                new Email { Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" }

                );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo { NomeCargo = "Professor"},
                new Cargo { NomeCargo = "Secretaria" },
                new Cargo { NomeCargo = "Comercial" }
                );
        }

    }
}
