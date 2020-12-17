using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Servicos
{
    public class Menu
    {
        //Menus
        public static void Administrador(List<Pessoa> usuariosSistema)
        {
            usuariosSistema.Add(Cadastro.CadastrarAdministrador());
            usuariosSistema.Add(Cadastro.CadastrarSindico());

            Cadastro.CadastrarSindico();
        }
        
        public static void Sindico()
        {
            Cadastro.CadastrarSindico();
            Cadastro.CadastrarZelador();
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
        public static Pessoa CadastrarAdministrador()
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

            Console.WriteLine("Entre com os dados para login: ");
            Console.Write("Escolhe seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Administrador(nomeCompleto, dataNascimento, carro, telefone, TipoNivelAcesso.Administrador, user, senha);
        }

        //Método de cadastrar síndico
        public static Pessoa CadastrarSindico()
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
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Dados do carro: ");
            Console.Write("Placa do carro: ");
            string placaCarro = (Console.ReadLine());
            Console.Write("Modelo do carro: ");
            string modeloCarro = Console.ReadLine();
            Carro carro = new Carro(placaCarro, modeloCarro);

            Console.WriteLine("Dados do prédio: ");
            Console.Write("Nome do prédio: ");
            string nomePredio = Console.ReadLine();
            Console.Write("Bloco: ");
            string bloco = Console.ReadLine();
            Console.Write("Apartamento: ");
            int apartamento = int.Parse(Console.ReadLine());
            Predio predio = new Predio(nomePredio, bloco, apartamento);

            Console.WriteLine("Entre com os dados para login: ");
            Console.Write("Escolhe seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Sindico(nomeCompleto, dataNascimento, predio, carro, telefone, user, senha, salario);
        }

        //Método de cadastrar Zelador
        public static Pessoa CadastrarZelador()
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
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Dados do carro: ");
            Console.Write("Placa do carro: ");
            string placaCarro = (Console.ReadLine());
            Console.Write("Modelo do carro: ");
            string modeloCarro = Console.ReadLine();
            Carro carro = new Carro(placaCarro, modeloCarro);

            Console.WriteLine("Dados do prédio: ");
            Console.Write("Nome do prédio: ");
            string nomePredio = Console.ReadLine();
            Console.Write("Bloco: ");
            string bloco = Console.ReadLine();
            Console.Write("Apartamento: ");
            int apartamento = int.Parse(Console.ReadLine());
            Predio predio = new Predio(nomePredio, bloco, apartamento);

            Console.WriteLine("Entre com os dados para login: ");
            Console.Write("Escolhe seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Zelador(nomeCompleto, dataNascimento, carro, telefone, user, senha, predio, salario);
        }

        //Método de cadastrar Morador
        public static Pessoa CadastrarMorador()
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

            Console.WriteLine("Dados do prédio: ");
            Console.Write("Nome do prédio: ");
            string nomePredio = Console.ReadLine();
            Console.Write("Bloco: ");
            string bloco = Console.ReadLine();
            Console.Write("Apartamento: ");
            int apartamento = int.Parse(Console.ReadLine());
            Predio predio = new Predio(nomePredio, bloco, apartamento);

            Console.WriteLine("Entre com os dados para login: ");
            Console.Write("Escolhe seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Morador(nomeCompleto, dataNascimento, carro, telefone, user, senha, predio);
        }
    }
}
