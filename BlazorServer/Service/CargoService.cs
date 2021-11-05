using BlazorServer.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class CargoService : ICargoService
    {

        private readonly AppDbContext _context;


        public List<Cargo> Cargos { get; set; }

        public CargoService(AppDbContext context)
        {
            _context = context;
            Cargos = GetAllRecordsList();
        }

        public bool UpdateCargo(Cargo record)
        {
            Cargo upCargo = _context.Cargo.Where(a => a.Id == record.Id).FirstOrDefault();
            if (upCargo != null)
            {
                upCargo.NomeCargo = record.NomeCargo;
                _context.Cargo.Update(upCargo);
                _context.SaveChanges();
                return true;
            }
            else
            { 
                AddRecord(record);
                return true;
            }
        }

        public bool AddRecord(Cargo record)
        {
            this._context.Cargo.Add(record);
            _context.SaveChanges();
            return true;
        }

        public bool ExluirRecord(Cargo record)
        {
            this._context.Cargo.Remove(record);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Cargo>> GetAllRecords()
        {
            return  _context.Cargo.AsQueryable().ToList();
        }

        public List<Cargo> GetAllRecordsList()
        {
            return _context.Cargo.AsQueryable().ToList();
        }

        public IEnumerable<Cargo> GetAllRecordsAsEnumerable()
        {
            return _context.Cargo.AsEnumerable();
        }

        public async Task<Data.Cargo> GetRecordId(System.Guid id)
        {
            return _context.Cargo.FirstOrDefault(i => i.Id == id);
        }

        //public void LoadCargos()
        //{
        //    Cargos = new List<Cargo> {
        //        new Cargo(){  NomeCargo ="Tutor"},
        //        new Cargo(){  NomeCargo ="Secretaria"},
        //        new Cargo(){  NomeCargo ="Comercial"},
        //        new Cargo(){  NomeCargo ="Coordenador"},
        //        new Cargo(){  NomeCargo ="Professor"},
        //    };
        //}
    }
}
