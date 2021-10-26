using System;
using System.Collections;
using System.Threading.Tasks;
using BlazorServer.Data;
using System.Collections.Generic;


namespace BlazorServer.Service
{
    public interface IFeriado
    {
        List<Feriado> GetFeriadoDoMes(DateTime data);

        bool InsereFeriado(Feriado f);

        bool ExcluiFeriado(Feriado f);

        bool UpdateFeriado(Feriado f);

        Feriado GetFeriadoBuyId(Guid id);



    }
}
