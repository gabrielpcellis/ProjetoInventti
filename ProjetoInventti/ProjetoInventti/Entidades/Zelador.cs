﻿using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades {
    public class Zelador : Pessoa{

        public Predio PredioZelador { get; set; }
        public double Salario { get; set; }

        public Zelador(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha, Predio predio, double salario)
            : base (nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Sindico, user, senha)
        {
            PredioZelador = predio;
            Salario = salario;
        }
    }
}
