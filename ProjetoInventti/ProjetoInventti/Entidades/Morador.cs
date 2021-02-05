using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades
{
    public class Morador : Pessoa
    {
        public Morador(int id, string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha, Predio predio)
            : base(id, nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Morador, user, senha)
        {
            Predio = predio;
        }

        public Morador(Pessoa pessoa, Predio predio)
            : base(pessoa.Id, pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Morador, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
            Predio = predio;
        }
    }

}
