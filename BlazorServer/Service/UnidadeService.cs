using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class UnidadeService: IServiceUnidade
    {



        public UnidadeService()
        {
            Unidades = new List<Unidade>();
        }

        public List<Unidade> Unidades;

        public bool AddRecord(Unidade record)
        {
            if (record.Id.Equals(Guid.Empty))
            {
                Unidades.Add(record);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool DeleteRecor(Unidade record)
        {
            throw new NotImplementedException();
        }

        public Task<List<Unidade>> GetUnidades()
        {
            throw new NotImplementedException();
        }

        public Task<List<Unidade>> GetUnidadesById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecord(Unidade record)
        {
            throw new NotImplementedException();
        }

        public void LoadUnidades() {

            Unidades = new List<Unidade> {
                new Unidade(){ Nome="Parauapebas", Bairro="Bairro da Paz", Numero=152, Cidade="Parauapebas", CNPJ="123123123/1234-12", Endereco="Rua Sol Poente", RazaoSocial="EDIVALDO MACHADO BARBALHO"},
                new Unidade{ Nome="Eldorado dos Carajas", Bairro="Centro", Numero=152, Cidade="Eldorado dos Carajás", CNPJ="123123123/1234-12", Endereco="Rua Sol Poente", RazaoSocial="EDIVALDO MACHADO BARBALHO"},
                new Unidade{ Nome="Canaa dos CArajas", Bairro="Centro", Numero=152, Cidade="Canaa dos Carajas", CNPJ="123123123/1234-12", Endereco="Rua Sol Poente", RazaoSocial="EDIVALDO MACHADO BARBALHO"}
            };
        }



    }
}

