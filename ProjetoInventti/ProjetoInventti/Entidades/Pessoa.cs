using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades
{
    public class Pessoa
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public Carro Carro { get; set; }
        public string Telefone { get; set; }
        public TipoNivelAcesso TipoNivelAcesso { get; set; }
        public string UsuarioAcesso { get; set; }
        public string SenhaAcesso { get; set; }

        //Construtor geral
        public Pessoa(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, TipoNivelAcesso tipoNivelAcesso, string user, string senha)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Carro = carro;
            Telefone = telefone;
            TipoNivelAcesso = tipoNivelAcesso;
            UsuarioAcesso = user;
            SenhaAcesso = senha;
        }
        //Construtor para o método gerar solicitação
        public Pessoa(string nome)
        {
            NomeCompleto = nome;
        }

        //Método verificador de acesso
        public bool VerificarDadosDeAcesso(string usuario, string senha)
        {
            //bool informacoesConferem = false;
            //if (usuario == UsuarioAcesso && senha == SenhaAcesso)
            //    informacoesConferem = true;
            //return informacoesConferem;

            return usuario == UsuarioAcesso && senha == SenhaAcesso;
        }

        //Método para alterar a senha
        public void AlterarSenha(string senha)
        {
            SenhaAcesso = senha;
            Console.WriteLine("Nova senha: " + SenhaAcesso);
            Console.WriteLine();
        }

        //Formatação do objeto para mostrar em tela
        public override string ToString()
        {
            return NomeCompleto + ", "
                + DataNascimento + ", "
                + Carro.ModeloCarro + ", "
                + Carro.PlacaCarro + ", "
                + Telefone + ", "
                + UsuarioAcesso + ", "
                + SenhaAcesso;
        }
    }
}
