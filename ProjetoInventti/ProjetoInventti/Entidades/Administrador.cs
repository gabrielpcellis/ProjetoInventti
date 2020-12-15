using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Administrador : Pessoa {

        public Administrador(string nomeCompleto, DateTime dataNascimento, int telefone, double salario, Carro carro)
            : base(nomeCompleto, dataNascimento, telefone, salario, carro)
        {

        }
    }
}