using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Data;
using BlazorServer.Service;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Service
{
    public class ColaboradorService : ICobaloradorService
    {
        private readonly AppDbContext _context;

        public ColaboradorService(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteRecord(Colaborador record)
        {
            _context.Colaboradors.Remove(record);
            int result =  _context.SaveChanges();
            return result > 0;
        }

        public async Task<List<Colaborador>> GetAllColaboradores()
        {
            return await _context.Colaboradors.ToListAsync();
        }

        public async Task<Colaborador> GetColaboradorById(int id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            return await _context.Colaboradors.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<Colaborador> GetColaboradorByIdPonto(int id)
        {
            return await _context.Colaboradors.Where<Colaborador>(x => x.CodPonto == id).FirstOrDefaultAsync();
        }

        public async Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl)
        {
            return await _context.Colaboradors.Where<Colaborador>(b => b.Cargo.NomeCargo == cargoUrl).ToListAsync();
        }

        public bool InsertRecord(Colaborador record)
        {
             _context.Colaboradors.AddAsync(record);
            int result =  _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateRecord(Colaborador record)
        {
            _context.Colaboradors.Update(record);
            int result =  _context.SaveChanges();
            return result > 0;
        }
    }
}
