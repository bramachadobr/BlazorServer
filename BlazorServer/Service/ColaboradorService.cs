using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class ColaboradorService : ICobaloradorService
    {

        private readonly AppDbContext _context;
        public ColaboradorService(AppDbContext context)
        {
            _context = context;
            Colaboradores = GetAllColaboradoresList();
        }

        public List<Colaborador> Colaboradores { get; set; }

        public bool DeleteRecord(Colaborador record)
        {
            _context.Colaboradors.Remove(record);
            int result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<List<Colaborador>> GetAllColaboradores()
        {
            return await _context.Colaboradors.ToListAsync();
        }

        public List<Colaborador> GetAllColaboradoresList()
        {
            this.Colaboradores = _context.Colaboradors.ToList();
            return this.Colaboradores;
        }

        public async Task<Colaborador> GetColaboradorById(Guid id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            //return await _context.Colaboradors.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return  _context.Colaboradors.FirstOrDefault(i => i.Id == id);
        }

        public async Task<Colaborador> GetColaboradorByIdPonto(int id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(x => x.CodPonto == id).FirstOrDefaultAsync();
            return await _context.Colaboradors.FirstOrDefaultAsync(i => i.CodPonto == id);
        }

        public async Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl)
        {
            return await _context.Colaboradors.Where<Colaborador>(b => b.Cargo.NomeCargo == cargoUrl).ToListAsync();
        }

        public bool InsertRecord(Colaborador record)
        {
            //_context.Colaboradors.AddAsync(record);
            //int result = _context.SaveChanges();
            //return result > 0;
            _context.Colaboradors.Add(record);
            _context.SaveChanges();
            //this.Colaboradores.Add(record);
            return true;
        }

        public bool UpdateRecord(Colaborador record)
        {
            Colaborador colab = _context.Colaboradors.Single(i => i.Id.Equals(record.Id));

            if (colab != null)
            {
                colab = record;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return InsertRecord(record);
            }
        }
    }
}
