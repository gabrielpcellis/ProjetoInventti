using ProjetoInventti.Enums;
using ProjetoInventti.Excecoes.DomainExceptions;
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
        public void AlterarSenha()
        {
            Console.WriteLine();
            Console.WriteLine("Para alterar sua senha, informe os dados abaixo: ");
            Console.Write("Digite a nova senha: ");

            string novaSenha = Console.ReadLine();
            SenhaAcesso = novaSenha;
            Console.WriteLine("Nova senha: " + SenhaAcesso + "\n");
        }
        public static string[] CadastrarUsuarioESenha(List<Pessoa> usuarios)
        {
            Console.WriteLine();
            Console.WriteLine("Entre com os dados para login");
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            bool find = true;
            string[] usuarioSenha = new string[2];
            do
            {
                find = usuarios.Exists(f => f.UsuarioAcesso == usuario);
                if (find)
                {
                    Console.WriteLine("Usuário já existente, tente novamente. \n");
                    Console.Write("Usuário: ");
                    usuario = Console.ReadLine();
                    Console.Write("Senha: ");
                    senha = Console.ReadLine();
                }
            } while (find);

            usuarioSenha[0] = usuario;
            usuarioSenha[1] = senha;

            return usuarioSenha;
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
