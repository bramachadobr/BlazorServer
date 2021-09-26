using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface IRegistroPontoService
    {

        void AddRecord(RegistroPonto record);

        void UpdateRecord(RegistroPonto record);

        void DeleteRecord(RegistroPonto record);

        void DeleteRecord(Guid id);

        Task<List<RegistroPonto>> GetAllGeristroPonto();

        Task<List<RegistroPonto>> GetAllGeristroPontoById(int id);

        Task<List<RegistroPonto>> GetAllRegistroPontoByIdData(int id, DateTime data1, DateTime data2);



    }
}
