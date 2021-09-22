using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



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
        public int Id { get; set; } = 0;
        public string NomeCargo { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }


    public class Arquivo
    {
        public string NomeArquivo { get; set; }

        public string Caminho { get; set; }

        public long Tamanho { get; set; }

    }

    public class Email
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoEmail { get; set; }
    }


    public class Colaborador
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CodPonto { get; set; }
        [Required]
        public string Nome { get; set; }

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
        public int Id { get; set; }
        public Colaborador Colaborador { get; set; }
        public int ColaboradorId { get; set; }
        public string DiaSemana { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan AM_ENT { get; set; }
        public TimeSpan AM_SAI { get; set; }
        public TimeSpan PM_ENT { get; set; }
        public TimeSpan PM_SAI { get; set; }
        public TimeSpan NOI_ENT { get; set; }
        public TimeSpan NOI_SAI { get; set; }
        public TimeSpan TOTALHORAS { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VALORHORA { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VALORTOTAL { get; set; }
    }

    public class RegistroRegolgio
    {
        public int CodColaborador { get; set; }
        public DateTime? DataHoraRegistro { get; set; }
    }

    public class Feriado
    {
        public int Id { get; set; }
        public DateTime? DataFeriado { get; set; }
        public string NomeFeriado { get; set; }
    }

}