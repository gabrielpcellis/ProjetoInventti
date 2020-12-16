using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Sindico : Pessoa {

        public Sindico(string nomeCompleto, DateTime dataNascimento, string telefone, double salario, DateTime dataContratacao, Carro carro, Predio predio)
            : base(nomeCompleto, dataNascimento, telefone, salario, dataContratacao, carro, predio)
        {

        }

    }
}
