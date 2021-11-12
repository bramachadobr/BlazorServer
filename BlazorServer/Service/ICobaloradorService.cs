using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface ICobaloradorService
    {

        bool InsertRecord(Colaborador record);

        bool DeleteRecord(Colaborador record);

        bool UpdateRecord(Colaborador record);

        Task<IEnumerable<Colaborador>> GetAllColaboradores();

        Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl);

        Task<Colaborador> GetColaboradorById(Guid id);

        Task<Colaborador> GetColaboradorByIdPonto(int id);

    }
}