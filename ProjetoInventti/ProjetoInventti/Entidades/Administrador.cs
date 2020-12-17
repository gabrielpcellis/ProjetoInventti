using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades
{
    public class Administrador : Pessoa
    {

        public Administrador(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha)
            : base(nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Administrador, user, senha)
        {

        }

        //construtor referente ao cadastro manual pela classe "Menu"
        public Administrador(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, TipoNivelAcesso tipoNivelAcesso, string user, string senha)
     : base(nomeCompleto, dataNascimento, carro, telefone, tipoNivelAcesso, user, senha)
        {

        }


    }
}