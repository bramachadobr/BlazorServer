using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorServer.Service;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

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

        Task<List<RegistroPonto>> GetAllGeristroPontoByIdData(int id, DateTime data1, DateTime data2);



    }
}
