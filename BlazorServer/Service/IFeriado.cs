using BlazorServer.Data;
using System;
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

        double CargaHorariaDoMes(DateTime data, ref double feriado);

        void RetornaDatasInicioFim(DateTime data, ref DateTime inicio, ref DateTime fim);

    }
}
