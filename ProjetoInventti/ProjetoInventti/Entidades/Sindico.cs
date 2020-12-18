using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades
{
    public class Sindico : Pessoa
    {
        public Predio PredioSindico { get; set; }
        public double Salario { get; set; }

        public Sindico(string nomeCompleto, DateTime dataNascimento, Predio predio, Carro carro, string telefone, string user, string senha, double salario)
        : base(nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Sindico, user, senha)
        {
            PredioSindico = predio;
            Salario = salario;
        }

        public Sindico (Pessoa pessoa, Predio predio, double salario) : base (pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Sindico, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
            PredioSindico = predio;
            Salario = salario;
        }
    }
}
