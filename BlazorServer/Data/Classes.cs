using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorServer.Service;
using Microsoft.EntityFrameworkCore;



namespace BlazorServer.Data
{

    public enum EnumTipoAlerts
    {
        success,
        info,
        warning,
        danger
    }

    public class Cargo
    {
        public Cargo()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string NomeCargo { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }


    public class Arquivo
    {
        public Arquivo()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }

        public string Caminho { get; set; }

        public long Tamanho { get; set; }

    }

    public class Email
    {
        public Email()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoEmail { get; set; }
    }


    public class Colaborador
    {
        public Colaborador()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public int CodPonto { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public Cargo Cargo { get; set; }

        public int CargoId { get; set; }

        public DateTime? Contratacao { get; set; }

        public DateTime? Demissao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoraAula { get; set; }

        public List<RegistroPonto> Registros { get; set; }

    }

    public class RegistroPonto 
    {
        public Guid Id { get; set; }

        public RegistroPonto(Guid id)
        {
            Id = id;
        }

        public Colaborador Colaborador { get; set; }
        public int ColaboradorId { get; set; }
        public string DiaSemana { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan AM_ENT { get; set; }
        public TimeSpan AM_SAI { get; set; }
        public TimeSpan PM_ENT { get; set; }
        public TimeSpan PM_SAI { get; set; }
        public TimeSpan NOI_ENT { get; set; }
        public TimeSpan NOI_SAI { get; set; }
        public TimeSpan TotalHorasDia { get => TimeSpan.FromHours( (AM_SAI.Ticks - AM_ENT.Ticks) + (PM_SAI.Ticks - PM_ENT.Ticks) + (NOI_SAI.Ticks - NOI_ENT.Ticks)); }
        [Column(TypeName ="decimal(18,2)")]
        public decimal ValorHora { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
    }

    public class RegistroRegolgio
    {
        public RegistroRegolgio()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int CodColaborador { get; set; }
        public DateTime? DataHoraRegistro { get; set; }
    }

    public class Feriado
    {
        public Feriado()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime? DataFeriado { get; set; }
        public string NomeFeriado { get; set; }
    }

}