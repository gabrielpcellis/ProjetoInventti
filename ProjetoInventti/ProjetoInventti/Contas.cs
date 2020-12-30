using ProjetoInventti.Enums;
using System;
using System.Globalization;


namespace ProjetoInventti
{
    public class Contas
    {
        public DateTime DataConta { get; set; }
        public TipoConta TipoConta { get; set; }
        public decimal Valor { get; set; }

        public Contas(DateTime dataConta, TipoConta tipoConta, decimal valor)
        {
            DataConta = dataConta;
            TipoConta = tipoConta;
            Valor = valor;
        }

        public override string ToString()
        {
            return "Data da Conta: " + DataConta.ToLocalTime() + " Tipo da Conta: " + TipoConta.ToString() + " Valor: " + Valor.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
