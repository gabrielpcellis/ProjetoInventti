using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Zelador : Pessoa {

        public Zelador(string nomeCompleto, DateTime dataNascimento, string telefone, double salario, DateTime dataContratacao, Carro carro)
            : base(nomeCompleto, dataNascimento, telefone, salario, dataContratacao, carro)
        {

        }
    }
}
