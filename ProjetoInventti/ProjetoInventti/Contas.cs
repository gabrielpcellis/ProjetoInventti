using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjetoInventti
{
    public class Contas
    {
        public DateTime DataConta { get; set; }
        public double Energia { get; set; }
        public double Agua { get; set; }
        public double Gas { get; set; }
        public double Jardineiro { get; set; }
        public double DespesasGerais { get; set; }
        public double Multa { get; set; }
        public double Condominio { get; set; }
        public double SalarioZelador { get; set; }
        public double SalarioSindico { get; set; }

        //Construtor Contas a pagar
        public Contas(DateTime dataConta, double energia, double agua, double gas, double jardineiro, double despesasGerais, double multa, double condominio,
            double salarioZelador, double salarioSindico)
        {
            DataConta = dataConta;
            Energia = energia;
            Agua = agua;
            Gas = gas;
            Jardineiro = jardineiro;
            DespesasGerais = despesasGerais;
            Multa = multa;
            Condominio = condominio;
            SalarioZelador = salarioZelador;
            SalarioSindico = salarioSindico;
        }

        //Contrutor Contas a receber
        public Contas(DateTime dataConta, double energia, double agua, double gas, double multa, double condominio)
        {
            DataConta = dataConta;
            Energia = energia;
            Agua = agua;
            Gas = gas;
            Multa = multa;
            Condominio = condominio;
        }

        public override string ToString()
        {
            if (SalarioSindico == 0)
            {
                return "Data: " + DataConta
                + "\n"
                + "Energia: R$" + Energia.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Água: R$" + Agua.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Gás: R$" + Gas.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Multa: R$" + Multa.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Condomio: R$" + Condominio.ToString("F2", CultureInfo.InvariantCulture);
            }
            else
            {
                return "Data: " + DataConta
                + "\n"
                + "Energia: R$" + Energia.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Água: R$" + Agua.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Gás: R$" + Gas.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Jardineiro: R$" + Jardineiro.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Despesas gerais: R$" + DespesasGerais.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Multa: R$" + Multa.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Condomio: R$" + Condominio.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Salário do zelador: R$" + SalarioZelador.ToString("F2", CultureInfo.InvariantCulture)
                + "\n"
                + "Salário do síndico: R$" + SalarioSindico.ToString("F2", CultureInfo.InvariantCulture)
                + "\n";
            }
            
        }
    }
}
