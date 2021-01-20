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
        public bool VerificarDadosDeAcesso(string usuario, string senha)
        {
            return usuario == UsuarioAcesso && senha == SenhaAcesso;
        }
        public void AlterarSenha(string senha)
        {
            SenhaAcesso = senha;
            Console.WriteLine("Nova senha: " + SenhaAcesso);
            Console.WriteLine();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(NomeCompleto + ", ");
            sb.Append(DataNascimento.ToString("dd/MM/yyyy HH:mm:ss") + ", ");
            sb.Append(Carro.ModeloCarro + ", ");
            sb.Append(Carro.PlacaCarro + ", ");
            sb.Append(Telefone + ", ");
            sb.Append(UsuarioAcesso + ", ");
            sb.Append(SenhaAcesso);
            return sb.ToString();
        }
    }
}
