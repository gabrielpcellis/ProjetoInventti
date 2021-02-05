using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades
{
    public class Administrador : Pessoa
    {
        public Administrador(int id,string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha, Predio predio)
                    : base(id, nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Administrador, user, senha)
        {
            Predio = predio;
        }

        public Administrador(Pessoa pessoa, Predio predio)
            : base(pessoa.Id, pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Administrador, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
            Predio = predio;
        }

    }
}