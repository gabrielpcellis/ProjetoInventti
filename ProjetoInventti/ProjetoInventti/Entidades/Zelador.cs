using System;
using ProjetoInventti.Enums;

namespace ProjetoInventti.Entidades
{
    public class Zelador : Pessoa
    {
        public Predio Predio { get; set; }
        public double Salario { get; set; }

        public Zelador(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, string user, string senha, Predio predio, double salario)
            : base(nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Zelador, user, senha)
        {
            Predio = predio;
            Salario = salario;
        }
        public Zelador(Pessoa pessoa, Predio predio, double salario) : base(pessoa.NomeCompleto, pessoa.DataNascimento, pessoa.Carro, pessoa.Telefone, TipoNivelAcesso.Zelador, pessoa.UsuarioAcesso, pessoa.SenhaAcesso)
        {
            Predio = predio;
            Salario = salario;
        }
    }
}
