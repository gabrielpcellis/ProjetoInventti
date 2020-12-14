using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Predio {

        public string NomePredio { get; set; }
        public int BlocoPredio { get; set; }
        public int QuantidadeAndares { get; set; }
        public int QuantidadeApartamentos { get; set; }
        public DateTime DataConstrucao { get; set; }
        public int Andares { get; set; }

        public Predio(string nomePredio, int blocoPredio, int quantidadeAndares, int quantidadeApartamentos, DateTime dataConstrucao, int andares)
        {
            NomePredio = nomePredio;
            BlocoPredio = blocoPredio;
            QuantidadeAndares = quantidadeAndares;
            QuantidadeApartamentos = quantidadeApartamentos;
            DataConstrucao = dataConstrucao;
            Andares = andares;
        }
    }
}