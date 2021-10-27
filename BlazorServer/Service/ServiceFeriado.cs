using System;
using System.Data;
using System.Linq;
using Microsoft.Data.Sql;
using Microsoft.Data;
using System.Collections.Generic;
using BlazorServer.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Threading;

namespace BlazorServer.Service
{
    public class ServiceFeriado : IFeriado
    {
        private readonly AppDbContext _context;

        public ServiceFeriado(AppDbContext context)
        {
            _context = context;
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
                return _context.Feriado.Where(a => a.DataFeriado.Month.Equals(data.Month) && a.DataFeriado.Year.Equals(data.Year)).OrderBy(a => a.DataFeriado).ToList();
            }
            else
                return null;
        }

        public bool InsereFeriado(Feriado f)
        {
            if (f!=null)
            {
                _context.Feriado.Add(f);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
            
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
