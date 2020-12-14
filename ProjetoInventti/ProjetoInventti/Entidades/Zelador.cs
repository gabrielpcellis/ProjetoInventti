using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Zelador : Pessoa {

        public Zelador(string nomeCompleto, DateTime dataNascimento, int telefone, double salario, Predio predio, Carro carro)
            : base(nomeCompleto, dataNascimento, telefone, salario, predio, carro)
        {

        }
    }
}
