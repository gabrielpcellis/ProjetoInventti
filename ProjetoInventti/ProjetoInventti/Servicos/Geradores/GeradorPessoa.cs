using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoInventti.Servicos
{
   
    //Classe interna para cadastrar 
    internal class GeradorPessoa
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
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Zelador(GerarPessoa(), predio, Salario());
        }

        //Método de cadastrar Morador
        public Morador CadastrarMorador(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            string nome = Console.ReadLine();
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Morador(GerarPessoa(), predio);
        }

        //Método para criar um objeto pessoa
        private Pessoa GerarPessoa()
        {
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

            Console.WriteLine("Informe o nivel de Acesso : ");
            var nivel = Enum.Parse<TipoNivelAcesso>(Console.ReadLine());

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
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return salario;
        }

     
    }
}
