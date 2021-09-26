using BlazorServer.Data;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System;

namespace BlazorServer.Service
{
    public interface ICobaloradorService
    {

        bool InsertRecord(Colaborador record);

        bool DeleteRecord(Colaborador record);

        bool UpdateRecord(Colaborador record);

        Task<List<Colaborador>> GetAllColaboradores();

        Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl);

        Task<Colaborador> GetColaboradorById(Guid id);

        Task<Colaborador> GetColaboradorByIdPonto(int id);

    }
}
