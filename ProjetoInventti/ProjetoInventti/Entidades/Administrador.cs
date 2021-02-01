﻿using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades
{
    public class Administrador : Pessoa
    {
        public Administrador(int id,string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha)
                    : base(id, nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Administrador, user, senha)
        {

        }

        public Administrador(Pessoa pessoa)
            : base(pessoa.Id, pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Administrador, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
           
        }

    }
}