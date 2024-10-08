﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface ICargoService
    {
        public bool AddRecord(Data.Cargo record);
        public bool ExluirRecord(Data.Cargo record);
        public Task<List<Data.Cargo>> GetAllRecords();
        public Task<IEnumerable<Data.Cargo>> GetAllRecordsAsEnumerable();
        public Task<Data.Cargo> GetRecordId(System.Guid id);

    }
}
