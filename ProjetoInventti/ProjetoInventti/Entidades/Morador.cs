using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades {
    public class Morador : Pessoa {

        public Predio PredioDoMorador { get; set; }


        public Morador(string nomeCompleto, DateTime dataNascimento, string numeroApartamento, Carro carro, string telefone, string user, string senha, Predio predio)
            : base(nomeCompleto, dataNascimento, numeroApartamento, carro, telefone, TipoNivelAcesso.Morador, user, senha)
        {
            PredioDoMorador = predio;
        }
    }
}
