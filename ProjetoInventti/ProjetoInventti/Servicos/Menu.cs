using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetoInventti.Servicos
{
    public class Menu
    {
        Cadastro cadastro = new Cadastro();

        //Menus
        public void Administrador(List<Pessoa> usuariosSistema)
        {
            usuariosSistema.Add(cadastro.CadastrarAdministrador());
            usuariosSistema.Add(cadastro.CadastrarSindico());

        }
        
        public static void Sindico()
        {
        }

        public static void Zelador()
        {

        }

        public static void Morador()
        {

        }
    }

    internal class Cadastro
    {
        //Método de cadastrar administrador
        public Administrador CadastrarAdministrador()
        {
            Pessoa pessoa = GerarPessoa();

            return new Administrador(pessoa);
        }

        //Método de cadastrar síndico
        public Sindico CadastrarSindico()
        {
            Pessoa pessoa = GerarPessoa();

            double salario = Salario();
         
            Predio predio = GerarPredio();

            return new Sindico(pessoa, predio, salario);
        }

        //Método de cadastrar Zelador
        public Zelador CadastrarZelador()
        {
            Pessoa pessoa = GerarPessoa();

            double salario = Salario();

            Predio predio = GerarPredio();

            return new Zelador(pessoa, predio, salario);
        }

        //Método de cadastrar Morador
        public Morador CadastrarMorador()
        {
            Pessoa pessoa = GerarPessoa();

            Predio predio = GerarPredio();

            return new Morador(pessoa, predio);
        }

        private Pessoa GerarPessoa()
        {
            Console.WriteLine("Entre com os dados abaixo: ");
            Console.Write("Nome completo: ");
            string nomeCompleto = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Dados do carro: ");
            Console.Write("Placa do carro: ");
            string placaCarro = (Console.ReadLine());
            Console.Write("Modelo do carro: ");
            string modeloCarro = Console.ReadLine();
            Carro carro = new Carro(placaCarro, modeloCarro);

            Console.WriteLine("Nivel de Acesso : ");
            var nivel = Enum.Parse<TipoNivelAcesso>(Console.ReadLine());

            Console.WriteLine("Entre com os dados para login: ");
            Console.Write("Escolhe seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Pessoa(nomeCompleto, dataNascimento, carro, telefone, nivel, user, senha);
        }

        private Predio GerarPredio()
        {
            Console.WriteLine("Dados do prédio: ");
            Console.Write("Nome do prédio: ");
            string nomePredio = Console.ReadLine();
            Console.Write("Bloco: ");
            string bloco = Console.ReadLine();
            Console.Write("Apartamento: ");
            int apartamento = int.Parse(Console.ReadLine());
            Predio predio = new Predio(nomePredio, bloco, apartamento);
            return predio;
        }

        private double Salario()
        {
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return salario;
        }

    }
}
