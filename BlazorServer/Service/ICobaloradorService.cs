using BlazorServer.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface ICobaloradorService /*: Microsoft.AspNetCore.Components.IComponent*/
    {
        void SaveRecord(Colaborador record);

        bool InsertRecord(Colaborador record);

        bool DeleteRecord(Colaborador record);

        bool UpdateRecord(Colaborador record);

        Task<List<Colaborador>> GetAllColaboradores();

        Task<List<Colaborador>> GetColaboradorsByCargo(string cargoUrl);

        Task<Colaborador> GetColaboradorById(int id);

        Task<Colaborador> GetColaboradorByIdPonto(int id);

    }
}
