﻿using System;
using System.Collections.Generic;
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
        public Contas(DateTime dataConta, double energia, double agua, double gas, double jardineiro, double despesasGerais, double multa, double condominio, double salarioZelador, double salarioSindico)
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
    }
}
