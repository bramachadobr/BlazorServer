﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace BlazorServer.Data
{

    public enum EnumTipoAlerts
    {
        success,
        info,
        warning,
        danger
    }

    public class Arquivo
    {
        public Arquivo()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string EnderecoEmail { get; set; }
    }

    public class Cargo
    {
        public Cargo()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Required]
        public string? NomeCargo { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }


    public class Colaborador
    {
        public Colaborador()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        public int CodPonto { get; set; }
        [Required(ErrorMessage = "Informe um nome para o colaborador")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Informe o CPF do colaborador")]
        public string Cpf { get; set; } = string.Empty;    

        public string CpfComMascara { get => string.Format(@"{0:000\.###\.###-##}", Cpf); }
        //[Required(ErrorMessage ="Informe o Cargo do colaborador")]
        public Cargo? Cargo { get; set; }
        public Unidade Unidade { get; set; }
        [Required(ErrorMessage ="Data da contratação obrigatoria")]
        public DateTime? Contratacao { get; set; }

        public DateTime? Demissao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoraAula { get; set; }
        public double CargaHorariaSemanal { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;

        [Required]
        public string Telefone { get; set; }=string.Empty;
        public string Endereco { get; set; } = string.Empty;

        public int Numero { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public bool Ativo { get; set; }

        public List<RegistroPonto> Registros { get; set; }


    }

    public class RegistroPonto
    {
        readonly CultureInfo Cultura = new CultureInfo("pt-BR");

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        public RegistroPonto()
        {
            Id = Guid.NewGuid();
        }

        public Colaborador Colaborador { get; set; }
        public DayOfWeek DiaSemana { get => Data.DayOfWeek; }
        public string DiaSemanaPtBr { get => Cultura.DateTimeFormat.GetDayName(DiaSemana); }
        public DateTime Data { get; set; }
        public DateTime AM_ENT { get; set; }
        public DateTime AM_SAI { get; set; }
        public DateTime PM_ENT { get; set; }
        public DateTime PM_SAI { get; set; }
        public DateTime NOI_ENT { get; set; }
        public DateTime NOI_SAI { get; set; }

        public TimeSpan TotalHorasDia
        {
            get => TimeSpan.FromTicks((AM_SAI.TimeOfDay.Ticks - AM_ENT.TimeOfDay.Ticks)
                                + (PM_SAI.TimeOfDay.Ticks - PM_ENT.TimeOfDay.Ticks)
                                + (NOI_SAI.TimeOfDay.Ticks - NOI_ENT.TimeOfDay.Ticks));
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorHora { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

        public void AddHora(DateTime dataHora)
        {
            if (AM_ENT == DateTime.MinValue)
            {
                AM_ENT = dataHora;
            }
            else
            {
                if (AM_SAI == DateTime.MinValue)
                {
                    AM_SAI = dataHora;
                }
                else
                {
                    if (PM_ENT == DateTime.MinValue)
                    {
                        PM_ENT = dataHora;
                    }
                    else
                    {
                        if (PM_SAI == DateTime.MinValue)
                        {
                            PM_SAI = dataHora;
                        }
                        else
                        {
                            if (NOI_ENT == DateTime.MinValue)
                            {
                                NOI_ENT = dataHora;
                            }
                            else
                            {
                                if (NOI_SAI == DateTime.MinValue)
                                {
                                    NOI_SAI = dataHora;
                                }
                            }
                        }
                    }

                }
            }
        }

    }

    public class RegistroRelogio
    {
        public RegistroRelogio()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        public int CodColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public string Cpf { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }

    }

    public class Feriado
    {
        public Feriado()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Required]
        public DateTime? DataFeriado { get; set; }
        //public DateTime Data { get=>Convert.ToDateTime(DataFeriado.Value); }
        [Required]
        public string Descricao { get; set; }
    }


    public class Unidade
    {
        public Unidade()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }

    public class TopsDashBoard
    {
        public int Posicao { get; set; }
        private string _nome;
        public string Nome { get => _nome.Length > 30 ? _nome.Substring(0, 30) : _nome; set => _nome = value; }

        public string NomeCargo { get; set; }

        private TimeSpan _totalHoras;
        public TimeSpan TotalHoras { get => _totalHoras; set => _totalHoras = value; }
        public string TotalHorasFormatada { get => _totalHoras.TotalHorasTrabalhadas(); }
        public double ChSemanal { get; set; }

        private TimeSpan _chColabMes;
        public TimeSpan ChColabMes { get => _chColabMes; set => _chColabMes = value; }
        public string ChColabMesFormatada { get => _chColabMes.TotalHorasTrabalhadas(); }

        public string SaldoHorasTrabalhadas { get => (_totalHoras.Subtract(_chColabMes).TotalHorasTrabalhadas()); }
    }

    public class BancoDeHorasColaborador
    {
        public Guid Id { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime Mes { get; set; }
        public TimeSpan CargaHorariaMensaldoColabaorador { get; set; }
        public TimeSpan CargaHorariaTrabalhada { get; set; }
        public TimeSpan DiferencadoMes { get => CargaHorariaTrabalhada - CargaHorariaMensaldoColabaorador; }
    }

    public class ConfigureDashBoard
    {
        public int Quant { get; set; }
    }

    public class ColabTopMes
    {
        public Colaborador Colaborador { get; set; }
        public Cargo Cargo { get; set; }
        public TimeSpan Tempo { get; set; }
        public double ChSemanal { get; set; }
        public TimeSpan ChMes { get; set; }
        public DateTime data { get; set; }
    }

    public static class MetodosStaticos
    {
        public static string TotalHorasTrabalhadas(this TimeSpan totalHorasPeriodo)
        {
            TimeSpan times = new TimeSpan(0, 0, 0, 0);
            times = totalHorasPeriodo;

            string TotalHorasPeriodo = string.Format("{0}:{1}:{2}", times.Days > 0 ? ((times.Days * 24) + times.Hours) : times.Hours,
                                       times.Minutes < 10 ? ("0" + times.Minutes) : times.Minutes.ToString(),
                                       times.Seconds < 10 ? ("0" + times.Seconds) : times.Seconds.ToString());
            return TotalHorasPeriodo;
        }



        public static double TotalHorasDoColaboradorMes(this Colaborador colab, DateTime data)
        {
            double chColaboradorDia = colab.CargaHorariaSemanal / 6;

            int ano = data.Year;
            int mes = data.Month;
            int diasDoMes = DateTime.DaysInMonth(ano, mes);
            double cargaHoraria = 0;
            double diasUteis = 0;

            for (int i = 1; i <= diasDoMes; i++)
            {
                DateTime _data = new DateTime(ano, mes, i);
                if (_data.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (_data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        cargaHoraria = cargaHoraria + chColaboradorDia;
                        diasUteis += 0.5;
                    }
                    else
                    {
                        cargaHoraria = cargaHoraria + chColaboradorDia;
                        diasUteis += 1;
                    }
                }
            }
            return cargaHoraria;
        }
    }
}