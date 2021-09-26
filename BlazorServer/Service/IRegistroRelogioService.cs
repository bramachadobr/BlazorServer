using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface IRegistroRelogioService
    {

        void AddRegistro(RegistroRelogio record);

        void DeleteRegistro(RegistroRelogio record);

        Task<List<RegistroRelogio>> GetAllRegistroRelogio();

        RegistroRelogio GetAllRegistroRelogioById(Guid id);



    }
}
