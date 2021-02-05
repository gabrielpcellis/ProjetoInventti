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
        public int Id { get; private set; }
        public Predio Predio { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(int id, string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, TipoNivelAcesso tipoNivelAcesso, string user, string senha)
        {
            Id = id;
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
            Console.Clear();
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

        public static int Identificador(List<Pessoa> usuarios)
        {
            int id = 0;
            for (int i = 0; i < usuarios.Count; i++)
            {
                id = usuarios[i].Id += 1;
            }
            return id;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nome: " + NomeCompleto + ". ");
            sb.AppendLine("Data de Nascimento: " + DataNascimento.ToString("dd/MM/yyyy HH:mm:ss") + ". ");
            sb.AppendLine("Modelo do carro: " + Carro.ModeloCarro + ". ");
            sb.AppendLine("Placa do carro: " + Carro.PlacaCarro + ". ");
            sb.AppendLine("Telefone: " + Telefone + ". ");
            sb.AppendLine("Usuário: " + UsuarioAcesso + ". ");
            sb.AppendLine("Senha: " + SenhaAcesso + ".");
            sb.AppendLine("Prédio: " + Predio.NomePredio + ".");
            sb.AppendLine("Apartamento: " + Predio.NumeroApartamento + ".");
            return sb.ToString();
        }
    }
}
