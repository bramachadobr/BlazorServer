using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class RegistroPontoService : IRegistroPontoService
    {

        private readonly AppDbContext _context;

        public RegistroPontoService(AppDbContext _context)
        {
            this._context = _context;
            RegistroPontos = _context.RegistroPontos;
            Colaboradores = _context.Colaboradors;
        }

        public IEnumerable<RegistroPonto> RegistroPontos { get; set; }
        public IEnumerable<Colaborador> Colaboradores { get; set; }

        private List<RegistroPonto> registroPontos { get; set; }

        private List<Colaborador> colaboradores { get; set; }

        public void AddRecord(RegistroPonto record)
        {
            _context.RegistroPontos.Add(record);
            _context.SaveChanges();
        }

        public bool ValidaPontoExiste(RegistroPonto record)
        {

            var obj = from n in _context.RegistroPontos
                      where n.Colaborador == record.Colaborador
                      && n.AM_ENT == record.AM_ENT
                      select n;

            if (obj.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            //RegistroPonto reg = _context.RegistroPontos.Where(i => i.AM_ENT.Equals(record.AM_ENT) && i.ColaboradorId.Equals(record.ColaboradorId)).FirstOrDefault();
            //return reg == null?true:false;
        }

        public void DeleteRecord(RegistroPonto record)
        {
            var recor = _context.RegistroPontos.Where(i => i.Id == record.Id).FirstOrDefault();
            if (recor != null)
            {
                _context.RegistroPontos.Remove(recor);
                this._context.SaveChanges();
            }
            //registroPontos.Remove(record);
        }

        public void DeleteRecord(Guid id)
        {
            var recor = _context.RegistroPontos.Where(i => i.Id == id).FirstOrDefault();
            if (recor != null)
            {
                _context.RegistroPontos.Remove(recor);
            }
            //RegistroPonto reg = registroPontos.Find(i => i.Id == id);
            //registroPontos.Remove(reg);
        }

        public virtual async Task<List<RegistroPonto>> GetAllRegistroPonto()
        {
            return _context.RegistroPontos.ToList();
            //return registroPontos;
        }

        public async Task<List<RegistroPonto>> GetAllRegistroPontoById(int id)
        {
            Guid idGuid = _context.Colaboradors.Where(i => i.CodPonto == id).FirstOrDefault().Id; /*  this.colaboradores.Find(i => i.CodPonto == id).Id;*/

            if (idGuid != null)
            {
                return _context.RegistroPontos.Where(i => i.Colaborador.Id == idGuid).ToList();
            }
            else
            {
                return null;
            }
            //return registroPontos.Where(i => i.Colaborador.Id == idGuid).ToList();
        }

        public async Task<List<RegistroPonto>> GetAllRegistroPontoByIdData(Guid id, DateTime data1, DateTime data2)
        {
            if (id == Guid.Empty && data1 == DateTime.MinValue)
            {
                return await GetAllRegistroPonto();
            }
            else
            {
                if (id != Guid.Empty)
                {
                    if (data1 != DateTime.MinValue && data2 != DateTime.MinValue)
                    {
                        return _context.RegistroPontos.Where(i => i.Colaborador.Id.Equals(id) && i.Data >= data1 && i.Data <= data2).ToList();
                        //return registroPontos.Where(i => i.Colaborador.Id.Equals(id) && i.Data >= data1 && i.Data <= data2).ToList();
                    }
                    else
                    {
                        return _context.RegistroPontos.Where(i => i.Colaborador.Id.Equals(id)).ToList();
                        //return registroPontos.Where(i => i.Colaborador.Id.Equals(id)).ToList();
                    }
                }
                else
                {
                    return _context.RegistroPontos.Where(i => i.Data >= data1 && i.Data <= data2).ToList();
                    //return registroPontos.Where(i => i.Data >= data1 && i.Data <= data2).ToList();
                }
            }
        }

        public void UpdateRecord(RegistroPonto record)
        {
            if (record != null)
            {
                RegistroPonto reg = _context.RegistroPontos.Where(i => i.Id == record.Id).FirstOrDefault();
                if (reg != null)
                {
                    reg.AM_ENT = record.AM_ENT;
                    reg.AM_SAI = record.AM_SAI;
                    reg.PM_ENT = record.PM_SAI;
                    reg.PM_SAI = record.PM_SAI;
                    reg.NOI_ENT = record.NOI_SAI;
                    reg.NOI_SAI = record.NOI_SAI;
                    _context.SaveChanges();
                }
            }
        }

        public bool ContextSaveCharges()
        {
            int value = this._context.SaveChanges();
            return value == 0 ? true : false;
        }

        public List<RegistroPonto> GetAllRegistroPontoList()
        {
            return _context.RegistroPontos.ToList();
        }

        public RegistroPonto GetRecord(Guid id)
        {
            return _context.RegistroPontos.Where(i => i.Id == id).FirstOrDefault();
        }

        public async Task<List<RegistroPonto>> GetRegistroPontoByColaborador(Colaborador colab)
        {

            return _context.RegistroPontos.Where<RegistroPonto>(i => i.Colaborador.Id.Equals(colab.Id)).ToList();

            //return await _context.RegistroPontos.Where(i => i.Colaborador.Id.Equals(colab.Id)).ToListAsync();
        }
    }
}
