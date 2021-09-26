using BlazorServer.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public interface IEMailService
    {

        bool InserRecord(Email record);

        bool UpdateRecord(Email record);

        bool DeleteRecord(Email record);

        Task<List<Email>> GetAllEmail();

        Task<Email> GetEmailById(Guid id);

        Task<List<Email>> GetEmailsByName(string url);

    }
}
