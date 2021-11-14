using System;

namespace BlazorServer.Service
{
    public class AppData
    {
        private DateTime dataSelecionada;

        public DateTime DataSelecionada
        {
            get { return dataSelecionada; }
            set
            {
                dataSelecionada = value;
                NotifyDataChanged();
            }
        }

        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();


    }
}
