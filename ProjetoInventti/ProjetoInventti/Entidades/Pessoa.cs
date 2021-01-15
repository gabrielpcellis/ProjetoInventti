using ProjetoInventti.Enums;
using ProjetoInventti.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades
{
    public class Pessoa
    {
        public string NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Carro Carro { get; private set; }
        public string Telefone { get; private set; }
        public TipoNivelAcesso TipoNivelAcesso { get; private set; }
        public string UsuarioAcesso { get; private set; }
        public string SenhaAcesso { get; private set; }

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
        //public Pessoa(string nome)
        //{
        //    NomeCompleto = nome;
        //}

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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(NomeCompleto);
            sb.AppendLine(DataNascimento.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(Carro.ModeloCarro);
            sb.AppendLine(Carro.PlacaCarro);
            sb.AppendLine(Telefone);
            sb.AppendLine(UsuarioAcesso);
            sb.AppendLine(SenhaAcesso);
            return sb.ToString();
        }
    }
}
