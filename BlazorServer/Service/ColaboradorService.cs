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
            Colaboradores = _context.Colaboradors;
        }

        public IQueryable<Colaborador> Colaboradores { get; set; }

        public bool DeleteRecord(Colaborador record)
        {
            _context.Colaboradors.Remove(record);
            int result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradores()
        {
            return await _context.Colaboradors.Include(c=>c.Cargo).ToListAsync();
        }

        public List<Colaborador> GetAllColaboradoresList()
        {
            return _context.Colaboradors.ToList();

        }

        public async Task<Colaborador> GetColaboradorById(Guid id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            //return await _context.Colaboradors.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return _context.Colaboradors.FirstOrDefault(i => i.Id == id);
        }

        public async Task<Colaborador> GetColaboradorByIdPonto(int id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(x => x.CodPonto == id).FirstOrDefaultAsync();
            return await _context.Colaboradors.FirstOrDefaultAsync(i => i.CodPonto == id);
        }

        public async Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl)
        {
            return await _context.Colaboradors.Where<Colaborador>(b => b.Cargo.NomeCargo == cargoUrl).OrderBy(a => a.Nome).ToListAsync();
        }

        public bool InsertRecord(Colaborador record)
        {
            _context.Colaboradors.Add(record);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateRecord(Colaborador newRecord)
        {
            Colaborador record = _context.Colaboradors.Where(i => i.Id == newRecord.Id).FirstOrDefault();

            if (record != null)
            {
                record.Ativo = newRecord.Ativo;
                record.Bairro = newRecord.Bairro;
                record.Cargo = newRecord.Cargo;
                record.Cidade = newRecord.Cidade;
                record.Nome = newRecord.Nome;
                record.Numero = newRecord.Numero;
                record.CodPonto = newRecord.CodPonto;
                record.Registros = newRecord.Registros;
                record.Salario = newRecord.Salario;
                record.Telefone = newRecord.Telefone;
                record.Unidade = newRecord.Unidade;
                record.Cpf = newRecord.Cpf;
                record.Email = newRecord.Email;
                record.Unidade = newRecord.Unidade;

                _context.Colaboradors.Update(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return InsertRecord(newRecord);
            }
        }
    }
}
