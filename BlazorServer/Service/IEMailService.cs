using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Data;

namespace BlazorServer.Service
{
    public interface IEMailService
    {
        
        bool InserRecord(Email record);
        
        bool UpdateRecord(Email record);
        
        bool DeleteRecord(Email record);

        Task<List<Email>> GetAllEmail();

        Task<Email> GetEmailById(int id);

        Task<List<Email>> GetEmailsByName(string url);

    }
}
