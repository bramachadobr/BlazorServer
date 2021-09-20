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
                new Colaborador { Id=1, Nome="Edivaldo", Contratacao=DateTime.Now, HoraAula=Convert.ToDecimal("52,00"), Salario=Convert.ToDecimal("5000,00")},
                new Colaborador { Id = 2, Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador { Id = 3, Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador { Id = 4, Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador { Id = 5, Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") },
                new Colaborador { Id = 6, Nome = "Edivaldo", Contratacao = DateTime.Now, HoraAula = Convert.ToDecimal("52,00"), Salario = Convert.ToDecimal("5000,00") }

                );

            modelBuilder.Entity<Email>().HasData(
                new Email { Id = 1, Nome ="Edivlado", EnderecoEmail = "edivaldomachado@gmailcom"},
                new Email { Id = 2, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 3, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 4, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 5, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" }

                );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo { Id = 1, NomeCargo = "Professor"},
                new Cargo { Id = 2, NomeCargo = "Secretaria" },
                new Cargo { Id = 3, NomeCargo = "Comercial" }
                );
        }

    }
}
