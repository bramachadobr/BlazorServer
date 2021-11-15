using BlazorServer.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Service
{
    public class CargoService : ICargoService
    {

        private readonly AppDbContext _context;


        public CargoService(AppDbContext context)
        {
            _context = context;
        }

        public bool UpdateCargo(Cargo record)
        {
            Cargo upCargo = _context.Cargo.Where(a => a.Id == record.Id).FirstOrDefault();
            if (upCargo != null)
            {
                upCargo.NomeCargo = record.NomeCargo;
                _context.Cargo.Update(upCargo);
                _context.SaveChanges(true);
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
            return _context.Cargo.OrderBy(a => a.NomeCargo).ToList();
        }

        public List<Cargo> GetAllRecordsList()
        {
            return _context.Cargo.OrderBy(a => a.NomeCargo).AsQueryable().ToList();
        }

        public IEnumerable<Cargo> GetAllRecordsAsEnumerable()
        {
            //https://codethug.com/2016/02/19/Entity-Framework-Cache-Busting/

            return _context.Cargo.OrderBy(a => a.NomeCargo).AsNoTracking();
            //var cache = _context.ChangeTracker.Entries<Cargo>().FirstOrDefault();
            //if (cache == null)
            //{
            //    return _context.Cargo.OrderBy(a => a.NomeCargo).AsEnumerable();
            //}
            //else
            //{
            //    cache.Reload();
            //    return _context.Cargo.OrderBy(a => a.NomeCargo).AsEnumerable();
            //}
        }

        public async Task<IEnumerable<Cargo>> GetCargosAsync()
        {
            return await _context.Cargo.ToListAsync();
        }

        public async Task<Data.Cargo> GetRecordId(System.Guid id)
        {
            return _context.Cargo.FirstOrDefault(i => i.Id == id);
        }

        Task<IEnumerable<Cargo>> ICargoService.GetAllRecordsAsEnumerable()
        {
            throw new System.NotImplementedException();
        }

    }
}
