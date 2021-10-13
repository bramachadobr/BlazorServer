using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface IServiceUnidade
    {


        public bool AddRecord(Unidade record);

        public bool DeleteRecor(Unidade record);

        public Task UpdateRecord(Unidade record);

        public Task<List<Unidade>> GetUnidades();

        public Task<List<Unidade>> GetUnidadesById(Guid id);


    }
}

