using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class CargoService : ICargoService
    {

        public List<Cargo> Cargos { get; set; }

        public CargoService()
        {

        }

        public bool AddRecord(Cargo record)
        {
            this.Cargos.Add(record);
            return true;
        }

        public bool ExluirRecord(Cargo record)
        {
            this.Cargos.Remove(record);
            return true;
        }

        public async Task<List<Cargo>> GetAllRecords()
        {
            return this.Cargos;
        }

        public async Task<Data.Cargo> GetRecords(Guid id)
        {
            Data.Cargo cargo = Cargos.FirstOrDefault(i => i.Id == id);
            return cargo;
        }

        public void LoadCargos()
        {
            Cargos = new List<Cargo> {
                new Cargo(){  NomeCargo ="Tutor"},
                new Cargo(){  NomeCargo ="Secretaria"},
                new Cargo(){  NomeCargo ="Comercial"},
                new Cargo(){  NomeCargo ="Coordenador"},
                new Cargo(){  NomeCargo ="Professor"},
            };
        }

    }
}
