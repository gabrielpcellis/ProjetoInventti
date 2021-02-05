using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades
{
    public class Sindico : Pessoa
    {
        public double Salario { get; set; }

        public Sindico(int id, string nomeCompleto, DateTime dataNascimento, Predio predio, Carro carro, string telefone, string user, string senha, double salario)
        : base(id, nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Sindico, user, senha)
        {
            Predio = predio;
            Salario = salario;
        }

        public Sindico(Pessoa pessoa, Predio predio, double salario)
            : base(pessoa.Id, pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Sindico, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
            Predio = predio;
            Salario = salario;
        }
    }
}
