﻿using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class RegistroPontoService : IRegistroPontoService
    {

        private readonly AppDbContext _context;

        public RegistroPontoService(AppDbContext _context)
        {
            this._context = _context;
        }

        private List<RegistroPonto> registroPontos { get; set; }

        private List<Colaborador> colaboradores { get; set; }

        public void AddRecord(RegistroPonto record)
        {
            _context.RegistroPontos.Add(record);
            _context.SaveChanges();
            //registroPontos.Add(record);
        }

        public bool ValidaPontoExiste(RegistroPonto record)
        {
            RegistroPonto reg = registroPontos.FirstOrDefault(i => i.AM_ENT == record.AM_ENT && i.ColaboradorId == record.ColaboradorId);
            if (reg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            return  _context.RegistroPontos.ToList();
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
            RegistroPonto reg = registroPontos.Find(i => i.Id == record.Id);
            reg = record;
        }

        public bool ContextSaveCharges()
        {
            int value =  this._context.SaveChanges();
            return value == 0 ? true : false;
        }

        public List<RegistroPonto> GetAllRegistroPontoList()
        {
            return _context.RegistroPontos.ToList();
        }
    }
}
