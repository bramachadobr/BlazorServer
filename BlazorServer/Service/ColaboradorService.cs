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

        public async Task DeleteRecord(Guid id)
        {
            Colaborador c = await GetColaboradorById(id);
            _context.Colaboradors.Remove(c);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Colaborador>> GetAllColaboradores()
        {
            return await _context.Colaboradors.Include(c => c.Cargo).Include(u => u.Unidade).ToListAsync();
        }

        public List<Colaborador> GetAllColaboradoresList()
        {
            return _context.Colaboradors.ToList();

        }

        public async Task<Colaborador> GetColaboradorById(Guid id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            //return await _context.Colaboradors.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return _context.Colaboradors.Include(c => c.Cargo).Include(u => u.Unidade).FirstOrDefault(i => i.Id == id);
        }

        public async Task DesativaColaborador(Guid id)
        {
            Colaborador c = await GetColaboradorById(id);
            c.Ativo = false;
            _context.Colaboradors.Update(c);
        }

        public IEnumerable<Colaborador> GetColaboradorIEnumerable()
        {
            return _context.Colaboradors.Include(a => a.Cargo).Include(u => u.Unidade).OrderBy(i => i.Nome).AsNoTracking().AsQueryable();
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
            try
            {
                record.Unidade = _context.Unidade.Where(i => i.Id == record.Unidade.Id).FirstOrDefault();
                record.Cargo = _context.Cargo.Where(i => i.Id == record.Cargo.Id).FirstOrDefault();
                _context.Colaboradors.Add(record);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRecord(Colaborador newRecord)
        {
            Colaborador record = _context.Colaboradors.Where(i => i.Id == newRecord.Id).FirstOrDefault();
            if (record != null)
            {
                record.Ativo = newRecord.Ativo;
                record.Bairro = newRecord.Bairro;
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
                record.Cargo = _context.Cargo.Where(i => i.Id == newRecord.Cargo.Id).FirstOrDefault();
                record.Unidade = _context.Unidade.Where(i => i.Id == newRecord.Unidade.Id).FirstOrDefault();
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