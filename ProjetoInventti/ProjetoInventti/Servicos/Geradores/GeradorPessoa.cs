using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Servicos
{
    //Classe para cadastrar 
    public class GeradorPessoa
    {
        //Método de cadastrar administrador
        //É criado um objeto "pessoa" que recebe o cadastro realizado na chamada do método "GerarPessoa()"
        //Quando o cadastro é realizado, o método retorna um novo administrador com esses dados
        public Administrador CadastrarAdministrador()
        {
            return new Administrador(GerarPessoa());
        }

        //Método de cadastrar síndico
        public Sindico CadastrarSindico(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            string nome = Console.ReadLine();
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Sindico(GerarPessoa(), predio, Salario());
        }

        //Método de cadastrar Zelador
        public Zelador CadastrarZelador(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            string nome = Console.ReadLine();
            Console.Write("Prédio: ");
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Zelador(GerarPessoa(), predio, Salario());
        }

        //Método de cadastrar Morador
        public Morador CadastrarMorador(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            Console.Write("Prédio: ");
            string nome = Console.ReadLine();
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Morador(GerarPessoa(), predio);
        }

        //Método para criar um objeto pessoa
        private Pessoa GerarPessoa()
        {
            Console.WriteLine();
            Console.WriteLine("Entre com os dados abaixo: ");
            Console.Write("Nome completo: ");
            string nomeCompleto = Console.ReadLine();
            Console.Write("Data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Dados do carro");
            Console.Write("Placa do carro: ");
            string placaCarro = (Console.ReadLine());
            Console.Write("Modelo do carro: ");
            string modeloCarro = Console.ReadLine();
            Carro carro = new Carro(placaCarro, modeloCarro);

            Console.Write("Informe o nivel de acesso (Administrador, Sindico, Zelador, Morador): ");
            TipoNivelAcesso nivel = Enum.Parse<TipoNivelAcesso>(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Entre com os dados para login");
            Console.Write("Escolha seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Pessoa(nomeCompleto, dataNascimento, carro, telefone, nivel, user, senha);
        }

        //Método para criar criar um objeto salário
        private double Salario()
        {
            Console.WriteLine();
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return salario;
        }
        //Chamada do método ExcluirMorador
        public static void RemoverMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            ExcluirMorador(moradores, usuariosSistema);
        }

        //Método para excluir um morador
        static private void ExcluirMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            Console.WriteLine("Escolha o morador que deseja excluir: ");
            Console.WriteLine();

            //Mostrar a lista
            for (int i = 0; i < moradores.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + moradores[i]);
            }
            Console.WriteLine();
            Console.Write("Informe uma posição: ");
            int posicaoNaLista = int.Parse(Console.ReadLine());

            moradores.RemoveAt(posicaoNaLista - 1);
            //Encontrar solução para a lista de usuários
            usuariosSistema.RemoveAt(posicaoNaLista - 1);
            Console.WriteLine("Morador excluído.");
            Console.WriteLine();
        }
    }
}
