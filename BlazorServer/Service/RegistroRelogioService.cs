using BlazorServer.Data;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class RegistroRelogioService : IRegistroRelogioService
    {

        public ColaboradorService colaboradorService { get; set; }

        public List<RegistroRelogio> registroRelogios { get; set; }

        public RegistroRelogioService()
        {
            colaboradorService = new ColaboradorService(new Data.AppDbContext());
            registroRelogios = new List<RegistroRelogio>();
        }

        public bool ValidaArquivo(InputFileChangeEventArgs e)
        {
            var entidade = e.GetMultipleFiles();
            var file = entidade.FirstOrDefault();
            string extensao = string.Empty;
            extensao = file.Name.Substring(file.Name.IndexOf("."), file.Name.Length - file.Name.IndexOf("."));

            if (!extensao.Equals(".txt"))
            {
                return false;
            }
            else
            {
                return true;
                //listAlert.Add($"Nome: {file.Name} - Tamanho: {file.Size}");
            }
        }

        public async Task<RegistroRelogio> CriaRegistroObjAsync(string item)
        {
            if (item == null)
            {
                return null;
            }
            string cod = item.Substring(0, 5);
            string cpf = item.Substring(5, 17);
            string dia = item.Substring(17, 2);
            string mes = item.Substring(19, 2);
            string ano = item.Substring(21, 4);
            string hh = item.Substring(25, 2);
            string mm = item.Substring(27, 2);

            string sData = $"{dia}/{mes}/{ano} {hh}:{mm}";

            RegistroRelogio reg = new RegistroRelogio();

            reg.CodColaborador = Convert.ToInt32(cod);
            reg.Colaborador = await colaboradorService.GetColaboradorByIdPonto(Convert.ToInt32(cod));
            reg.Cpf = cpf;
            reg.Data = Convert.ToDateTime(sData, new System.Globalization.CultureInfo("pt-BR"));
            //reg.Hora = new TimeSpan(Convert.ToInt32(hh), Convert.ToInt32(mm), 0);

            return reg;
        }

        public async Task<List<string>> ConvertFileInList(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();
            var file = files.FirstOrDefault();

            var ms = new MemoryStream();

            await file.OpenReadStream().CopyToAsync(ms);

            StreamReader sr = new StreamReader(ms);

            List<string> linhas = new List<string>();

            ms.Position = 0;

            string linha = "";

            while (!(linha is null))
            {
                linha = sr.ReadLine();
                if (linha != null)
                {
                    linhas.Add(linha);
                }
            }
            //string lin = sr.ReadToEnd();
            //string Arquivo = Encoding.ASCII.GetString(ms.ToArray());
            List<string> lista = new List<string>();

            ms.Position = 0;

            string sline = "";

            while (sline != null)
            {
                sline = sr.ReadLine();
                if (sline != "")
                {
                    lista.Add(sline);
                }
            }
            return lista;
        }

        public void AddRegistro(RegistroRelogio record)
        {
            registroRelogios.Add(record);
        }

        public void DeleteRegistro(RegistroRelogio record)
        {
            registroRelogios.Remove(record);
        }

        public async Task<List<RegistroRelogio>> GetAllRegistroRelogio()
        {
            return registroRelogios;
        }

        public RegistroRelogio GetAllRegistroRelogioById(Guid id)
        {
            return registroRelogios.Find(i => i.Id == id);
        }
    }
}
