using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Data;
using BlazorServer.Service;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Service
{
    public class RegistroPontoService : IRegistroPontoService
    {
        public RegistroPontoService()
        {
            registroPontos = new List<RegistroPonto>();
        }

        public List<RegistroPonto> registroPontos { get; set; }



        public void AddRecord(RegistroPonto record)
        {
            registroPontos.Add(record);
        }

        public void DeleteRecord(RegistroPonto record)
        {
            registroPontos.Remove(record);
        }

        public void DeleteRecord(Guid id)
        {
            RegistroPonto reg = registroPontos.Find(i => i.Id == id);
            registroPontos.Remove(reg);
        }

        public async Task<List<RegistroPonto>> GetAllGeristroPonto()
        {
            return registroPontos;
        }

        public async Task<List<RegistroPonto>> GetAllGeristroPontoById(int id)
        {
            return registroPontos.Where(i => i.ColaboradorId == id).ToList();
        }

        public async Task<List<RegistroPonto>> GetAllGeristroPontoByIdData(int id, DateTime data1, DateTime data2)
        {
            return registroPontos.Where(i => i.ColaboradorId == id && i.Data >= data1 && i.Data <= data2).ToList();
        }

        public void UpdateRecord(RegistroPonto record)
        {
            RegistroPonto reg = registroPontos.Find(i => i.Id == record.Id);
            reg = record;
        }
    }
}
