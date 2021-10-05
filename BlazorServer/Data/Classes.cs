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

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }

        public bool Ativo { get; set; }

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
        public DateTime AM_ENT { get; set; }
        public DateTime AM_SAI { get; set; }
        public DateTime PM_ENT { get; set; }
        public DateTime PM_SAI { get; set; }
        public DateTime NOI_ENT { get; set; }
        public DateTime NOI_SAI { get; set; }
        //public string AM_ENT_bind { get => AM_ENT.ToString(); set => TimeSpan.Parse(value); }
        //public string AM_SAI_bind { get => AM_SAI.ToString(); set => TimeSpan.Parse(value); }
        //public string PM_ENT_bind { get => PM_ENT.ToString(); set => TimeSpan.Parse(value); }
        //public string PM_SAI_bind { get => PM_SAI.ToString(); set => TimeSpan.Parse(value); }
        //public string NOI_ENT_bind { get => NOI_ENT.ToString(); set => TimeSpan.Parse(value); }
        //public string NOI_SAI_bind { get => NOI_SAI.ToString(); set => TimeSpan.Parse(value); }
        public TimeSpan TotalHorasDia { get => TimeSpan.FromTicks((AM_SAI.TimeOfDay.Ticks - AM_ENT.TimeOfDay.Ticks) + (PM_SAI.TimeOfDay.Ticks - PM_ENT.TimeOfDay.Ticks) + (NOI_SAI.TimeOfDay.Ticks - NOI_ENT.TimeOfDay.Ticks)); }
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