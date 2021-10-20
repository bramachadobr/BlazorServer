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

        Task<List<RegistroPonto>> GetAllRegistroPonto();

        List<RegistroPonto> GetAllRegistroPontoList();

        Task<List<RegistroPonto>> GetAllRegistroPontoById(int id);

        Task<List<RegistroPonto>> GetAllRegistroPontoByIdData(Guid id, DateTime data1, DateTime data2);

        bool ContextSaveCharges();

        RegistroPonto GetRecord(Guid id);



    }
}
