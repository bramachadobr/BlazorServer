using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Data;

namespace BlazorServer.Service
{
    public interface ICobaloradorService
    {

        bool InsertRecord(Colaborador record);

        bool DeleteRecord(Colaborador record);

        bool UpdateRecord(Colaborador record);

        Task<List<Colaborador>> GetAllColaboradores();

        Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl);

        Task<Colaborador> GetColaboradorById(int id);

        Task<Colaborador> GetColaboradorByIdPonto(int id);

    }
}
