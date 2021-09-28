using System;
using System.Collections.Generic;
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

        public string CpfComMascara { get => string.Format(@"{0:000\.###\.###-##}", Cpf); }

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
        CultureInfo Cultura = new CultureInfo("pt-BR");
        public Guid Id { get; set; }

        public RegistroPonto()
        {
            Id = Guid.NewGuid();
        }

        public Colaborador Colaborador { get; set; }
        public Guid ColaboradorId { get; set; }
        public DayOfWeek DiaSemana { get => Data.DayOfWeek; }

        public string DiaSemanaPtBr { get => Cultura.DateTimeFormat.GetDayName(DiaSemana); }
        public DateTime Data { get; set; }
        public TimeSpan AM_ENT { get; set; }
        public TimeSpan AM_SAI { get; set; }
        public TimeSpan PM_ENT { get; set; }
        public TimeSpan PM_SAI { get; set; }
        public TimeSpan NOI_ENT { get; set; }
        public TimeSpan NOI_SAI { get; set; }
        public string AM_ENT_bind { get=>AM_ENT.ToString(); set=>TimeSpan.Parse(value); }
        public string AM_SAI_bind { get => AM_SAI.ToString(); set => TimeSpan.Parse(value); }
        public string PM_ENT_bind { get => PM_ENT.ToString(); set => TimeSpan.Parse(value); }
        public string PM_SAI_bind { get => PM_SAI.ToString(); set => TimeSpan.Parse(value); }
        public string NOI_ENT_bind { get => NOI_ENT.ToString(); set => TimeSpan.Parse(value); }
        public string NOI_SAI_bind { get => NOI_SAI.ToString(); set => TimeSpan.Parse(value); }
        public TimeSpan TotalHorasDia { get => TimeSpan.FromTicks((AM_SAI.Ticks - AM_ENT.Ticks) + (PM_SAI.Ticks - PM_ENT.Ticks) + (NOI_SAI.Ticks - NOI_ENT.Ticks)); }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorHora { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

        public void AddHora(TimeSpan hora)
        {
            if (AM_ENT == TimeSpan.Zero)
            {
                AM_ENT = hora;
            }
            else
            {
                if (AM_SAI == TimeSpan.Zero)
                {
                    AM_SAI = hora;
                }
                else
                {
                    if (PM_ENT == TimeSpan.Zero)
                    {
                        PM_ENT = hora;
                    }
                    else
                    {
                        if (PM_SAI == TimeSpan.Zero)
                        {
                            PM_SAI = hora;
                        }
                        else
                        {
                            if (NOI_ENT == TimeSpan.Zero)
                            {
                                NOI_ENT = hora;
                            }
                            else
                            {
                                if (NOI_SAI == TimeSpan.Zero)
                                {
                                    NOI_SAI = hora;
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

        public Guid Id { get; set; }
        public DateTime? DataFeriado { get; set; }
        public string NomeFeriado { get; set; }
    }

}