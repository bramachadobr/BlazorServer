using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class UnidadeService : IServiceUnidade
    {
        private readonly AppDbContext _context;


        public UnidadeService(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }

        public bool AddRecord(Unidade record)
        {
            if (record.Id.Equals(Guid.Empty))
            {
                _context.Unidade.Add(record);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteRecor(Unidade record)
        {
            _context.Unidade.Remove(record);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Unidade>> GetUnidades()
        {
            return _context.Unidade.ToList();
        }

        public List<Unidade> GetUnidadesList()
        {
            return _context.Unidade.ToList();
        }

        public Task<Unidade> GetUnidadesById(Guid id)
        {
            return _context.Unidade.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool UpdateRecord(Unidade record)
        {
            Unidade uni = _context.Unidade.FirstOrDefault(i => i.Id == record.Id);
            if (uni != null)
            {
                uni.Nome = record.Nome;
                uni.RazaoSocial = record.RazaoSocial;
                uni.CNPJ = record.CNPJ;
                uni.Endereco = record.Endereco;
                uni.Cidade = record.Cidade;
                uni.Numero = record.Numero;
                uni.Bairro = record.Bairro;
                _context.Unidade.Update(uni);
                _context.SaveChanges();
                return true;
            }
            else
            {
                AddRecord(record);
                return true;
            }
        }

        Unidade IServiceUnidade.GetUnidadesById(Guid id)
        {
            return _context.Unidade.FirstOrDefault(i => i.Id == id);
        }
    }
}

