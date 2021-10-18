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
            return _context.Colaboradors.FirstOrDefault(i => i.Id == id);
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
            Colaborador colabUpdate = _context.Colaboradors.Where(i => i.Id == record.Id).FirstOrDefault();

            if (colabUpdate != null)
            {
                colabUpdate.Ativo = record.Ativo;
                colabUpdate.Bairro = record.Bairro;
                colabUpdate.Cargo = record.Cargo;
                colabUpdate.Cidade = record.Cidade;
                colabUpdate.Nome = record.Nome;
                colabUpdate.Numero = record.Numero;
                colabUpdate.CodPonto = record.CodPonto;
                colabUpdate.Registros = record.Registros;
                colabUpdate.Salario = record.Salario;
                colabUpdate.Telefone = record.Telefone;
                colabUpdate.Unidade = record.Unidade;
                colabUpdate.Cpf = record.Cpf;
                colabUpdate.Email = record.Email;

                _context.Colaboradors.Update(colabUpdate);
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
