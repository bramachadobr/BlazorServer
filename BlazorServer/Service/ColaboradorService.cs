using BlazorServer.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class ColaboradorService : ICobaloradorService
    {
        private readonly AppDbContext _context;


        public List<Data.Colaborador> Colaboradores { get; set; } = new List<Data.Colaborador>();

        public void LoadColaboradores()
        {

            Colaboradores = new List<Data.Colaborador> {
                new Colaborador {Id = 1, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 2, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 3, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 4, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 5, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 6, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 7, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 8, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" },
                new Colaborador {Id = 9, Cargo=new Cargo{ Id=1, NomeCargo="Professor"}, Contratacao=DateTime.Now, CargoId=1, CodPonto=5, HoraAula= Convert.ToDecimal("50.00"), Salario=Convert.ToDecimal("5000.00"), Nome="Edivaldo Machado Barbalho" }
            };
        }


        public ColaboradorService(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteRecord(Colaborador record)
        {
            _context.Colaboradors.Remove(record);
            int result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<List<Colaborador>> GetAllColaboradores()
        {
            //return await _context.Colaboradors.ToListAsync();
            return Colaboradores;
        }

        public async Task<Colaborador> GetColaboradorById(int id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            //return await _context.Colaboradors.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return Colaboradores.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Colaborador> GetColaboradorByIdPonto(int id)
        {
            //return await _context.Colaboradors.Where<Colaborador>(x => x.CodPonto == id).FirstOrDefaultAsync();
            return Colaboradores.FirstOrDefault(a => a.CargoId == id);
        }

        public async Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl)
        {
            //return await _context.Colaboradors.Where<Colaborador>(b => b.Cargo.NomeCargo == cargoUrl).ToListAsync();
            return Colaboradores.Where<Colaborador>(a => a.Cargo.NomeCargo == cargoUrl).ToList();
        }

        public bool InsertRecord(Colaborador record)
        {
            // _context.Colaboradors.AddAsync(record);
            //int result =  _context.SaveChanges();
            //return result > 0;

            Colaboradores.Add(record);
            return true;
        }

        public bool UpdateRecord(Colaborador record)
        {
            //_context.Colaboradors.Update(record);
            //int result =  _context.SaveChanges();
            //return result > 0;

            Colaborador c = Colaboradores.FirstOrDefault(a => a.Id == record.Id);
            c = record;

            return true;
        }

        public void SaveRecord(Colaborador record)
        {
            Colaborador cl = Colaboradores.FirstOrDefault(a => a.CargoId == record.Id);
            if (cl != null)
            {
                UpdateRecord(record);
            }
            else
            {
                InsertRecord(record);
            }
        }

    }
}
