using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Morador : Pessoa {

        public Morador(string nomeCompleto, DateTime dataNascimento, int telefone, Predio predio, Carro carro)
            : base (nomeCompleto, dataNascimento, telefone, predio, carro)
        {

        }
    }
}
