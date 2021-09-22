using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class EMailService : IEMailService
    {

        public List<Email> Email { get; set; } = new List<Email>();


        public void LoadEmail()
        {
            Email = new List<Email> {
                new Email { Id = 1, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 2, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 3, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 4, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" },
                new Email { Id = 5, Nome = "Edivlado", EnderecoEmail = "edivaldomachado@gmailcom" }
            };
        }


        private readonly AppDbContext _context;

        public EMailService(AppDbContext context)
        {
            _context = context;
        }

        public bool DeleteRecord(Email record)
        {
            _context.Email.Remove(record);
            _context.SaveChanges();
            return true;

        }

        public async Task<List<Email>> GetAllEmail()
        {
            return await _context.Email.ToListAsync();
        }

        public async Task<Email> GetEmailById(int id)
        {
            return await _context.Email.Where<Email>(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Email>> GetEmailsByName(string url)
        {
            return await _context.Email.Where<Email>(a => a.Nome.Contains(url)).ToListAsync();
        }

        public bool InserRecord(Email record)
        {
            this.Email.Add(record);
            //_context.Email.Add(record);
            //_context.SaveChanges();
            return true;
        }

        public bool UpdateRecord(Email record)
        {
            _context.Email.Update(record);
            _context.SaveChanges();
            return true;
        }
    }
}
