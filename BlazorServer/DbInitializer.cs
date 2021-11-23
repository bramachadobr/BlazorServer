using BlazorServer.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorServer
{
    public class DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
                {

                    foreach (var item in context.Colaboradors.Where(a=>a.Cargo.Equals(null)))
                    {
                        item.Cargo = context.Cargo.FirstOrDefault(a => a.NomeCargo.Contains("Tutor"));
                    }
                    foreach (var item in context.Colaboradors.Where(a=>a.Unidade.Equals(null)))
                    {
                        item.Unidade = context.Unidade.FirstOrDefault(a => a.Cidade.Contains("Parauapebas"));
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}