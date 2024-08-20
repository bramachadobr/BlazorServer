using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class ServiceFeriado : IFeriado
    {
        private readonly AppDbContext _context;

        public ServiceFeriado(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retorna a carga horaria do mes total dos feriados
        /// </summary>
        /// <param name="data">1º data do mes </param>
        /// <returns>retorna a quantidade de horas</returns>
        public double TotalChFeriadoMes(DateTime data)
        {
            double cargaFeriado = 0;
            List<Feriado> ListaFeriados = _context.Feriado.Where(a => a.DataFeriado.Value.Month.Equals(data.Month) && a.DataFeriado.Value.Year.Equals(data.Year)).ToList();

            foreach (var item in ListaFeriados)
            {
                if (item.DataFeriado.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    cargaFeriado = cargaFeriado + 4;
                }
                else
                {
                    cargaFeriado = cargaFeriado + 8;
                }
            }

            return cargaFeriado;
        }

        public double CargaHorariaMesColaborador(DateTime data, Guid idColaborador)
        {
            double cargaHoraria = 0;
            double cargaFeriado = 0;
            double cargaColaborador = 0;
            int diasDoMes = DateTime.DaysInMonth(data.Year, data.Month);

            double chColaborador = _context.Colaboradors.Where(a => a.Id.Equals(idColaborador)).FirstOrDefault().CargaHorariaSemanal;
            cargaColaborador = chColaborador / 6;


            double feriados = TotalChFeriadoMes(data);

            int ano = data.Year;
            int mes = data.Month;
            int diasUteis = 0;

            for (int i = 1; i <= diasDoMes; i++)
            {
                DateTime _data = new DateTime(ano, mes, i);
                if (_data.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (_data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        cargaHoraria += 4;
                        diasUteis++;
                    }
                    else
                    {
                        cargaHoraria += 8;
                        diasUteis++;
                    }
                }
            }

            double cargaColaboradorMes = cargaColaborador * diasUteis;
            cargaColaborador = Math.Round(cargaColaboradorMes, 0);
            return cargaHoraria - cargaFeriado;
        }

        /// <summary>
        /// Ratorna a carga horaria do mês menos os feriados cadastrados, apenas os dias úteis
        /// Utiliza 44 horas semanais para todos
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Data do mês que se quer</returns>
        public double CargaHorariaDoMes(DateTime data, ref double feriados)
        {
            double cargaHoraria = 0;
            double cargaFeriado = 0;
            double cargaColaborador = 0;
            int diasDoMes = DateTime.DaysInMonth(data.Year, data.Month);
            double valor = 44;
            cargaColaborador = valor / 6;


            feriados = TotalChFeriadoMes(data);

            int ano = data.Year;
            int mes = data.Month;
            int diasUteis = 0;

            for (int i = 1; i <= diasDoMes; i++)
            {
                DateTime _data = new DateTime(ano, mes, i);
                if (_data.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (_data.DayOfWeek == DayOfWeek.Saturday)
                    {
                        cargaHoraria += 4;
                        diasUteis++;
                    }
                    else
                    {
                        cargaHoraria += 8;
                        diasUteis++;
                    }
                }
            }

            double cargaColaboradorMes = cargaColaborador * diasUteis;
            cargaColaborador = Math.Round(cargaColaboradorMes, 0);
            return cargaHoraria - cargaFeriado;

        }

        public bool ExcluiFeriado(Feriado f)
        {
            bool result = false;
            Feriado f1 = GetFeriadoBuyId(f.Id);
            if (f1 != null)
            {
                _context.Feriado.Remove(f1);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public Feriado GetFeriadoBuyId(Guid id)
        {
            return _context.Feriado.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Feriado> GetFeriadoDoMes(DateTime data)
        {
            if (data != DateTime.MinValue)
            {
                return _context.Feriado.Where(a => a.DataFeriado.Value.Month.Equals(data.Month) && a.DataFeriado.Value.Year.Equals(data.Year)).OrderBy(a => a.DataFeriado).ToList();
            }
            else
                return null;
        }

        public async Task<List<Feriado>> GetFeriadoAll()
        {
            return _context.Feriado.OrderByDescending(a => a.DataFeriado).AsQueryable().ToList();
        }

        public IEnumerable<Feriado> GetFeriadoAllEnumerable()
        {
            return _context.Feriado.OrderByDescending(a => a.DataFeriado).AsNoTracking().AsQueryable();
        }

        public bool InsereFeriado(Feriado f)
        {
            if (f != null)
            {
                _context.Feriado.Add(f);
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public void RetornaDatasInicioFim(DateTime data, ref DateTime inicio, ref DateTime fim)
        {
            int diasDoMes = DateTime.DaysInMonth(data.Year, data.Month);
            DateTime d1 = new DateTime(data.Year, data.Month, 1);
            inicio = d1;
            DateTime d2 = new DateTime(data.Year, data.Month, diasDoMes);
            fim = d2;
        }

        public bool UpdateFeriado(Feriado f)
        {
            if (f != null)
            {
                Feriado fUpdate = _context.Feriado.Where(a => a.Id == f.Id).FirstOrDefault();
                if (fUpdate == null)
                {
                    InsereFeriado(f);
                    return true;
                }
                else
                {
                    fUpdate.Descricao = f.Descricao;
                    fUpdate.DataFeriado = f.DataFeriado;
                    _context.Feriado.Update(fUpdate);
                    _context.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }


    }
}
