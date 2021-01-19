using ProjetoInventti.Enums;
using System;
using System.Globalization;
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data da conta: " + DataConta.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Tipo da conta: " + TipoConta.ToString());
            sb.AppendLine("Valor: " + Valor.ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
