using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class RegistroPontoService : IRegistroPontoService
    {
        public RegistroPontoService()
        {
            registroPontos = new List<RegistroPonto>();
        }

        public List<RegistroPonto> registroPontos { get; set; }

        public List<Colaborador> colaboradores { get; set; }


        public void AddRecord(RegistroPonto record)
        {
            registroPontos.Add(record);
        }
        /// <summary>
        /// Retorna True caso haja um registro e false caso não exista
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
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
            Guid idGuid = this.colaboradores.Find(i => i.CodPonto == id).Id;
            return registroPontos.Where(i => i.Colaborador.Id == idGuid).ToList();
        }

        public async Task<List<RegistroPonto>> GetAllRegistroPontoByIdData(int id, DateTime data1, DateTime data2)
        {
            Guid idGuid = this.colaboradores.Find(i => i.CodPonto == id).Id;
            return registroPontos.Where(i => i.Colaborador.Id == idGuid && i.Data >= data1 && i.Data <= data2).ToList();
        }

        public void UpdateRecord(RegistroPonto record)
        {
            RegistroPonto reg = registroPontos.Find(i => i.Id == record.Id);
            reg = record;
        }
    }
}
