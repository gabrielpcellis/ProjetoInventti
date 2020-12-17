using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades {
    public class Administrador : Pessoa {

        public Administrador(string nomeCompleto, DateTime dataNascimento, string numeroApartamento, Carro carro, string telefone, string user, string senha)
            : base(nomeCompleto, dataNascimento, numeroApartamento, carro, telefone, TipoNivelAcesso.Administrador, user, senha)
        {

        }
    }
}