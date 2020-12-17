//using System;
//using System.Collections.Generic;
//using System.Text;
//using ProjetoInventti.Entidades;

//namespace ProjetoInventti.Serviços {
//    public static class Cadastro {

//        //Método de cadastro Administrador
//        public static Administrador CadastrarAdministrador()
//        {
//            Console.WriteLine("Entre com os dados abaixo: ");
//            Console.Write("Nome completo: ");
//            string nomeCompleto = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Data de nascimento: ");
//            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Telefone: ");
//            string telefone = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Salário: ");
//            double salario = double.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.WriteLine("Dados do carro: ");
//            Console.Write("Placa do carro: ");
//            string placaCarro = (Console.ReadLine());
//            Console.Write("Modelo do carro: ");
//            string modeloCarro = Console.ReadLine();
//            Carro carro = new Carro(placaCarro, modeloCarro);

//            return new Administrador(nomeCompleto, dataNascimento, telefone, salario, carro);
//        }
//        // Método de cadastro Síndico
//        public static Sindico CadastrarSindico()
//        {
//            Console.WriteLine("Entre com os dados abaixo: ");
//            Console.Write("Nome completo: ");
//            string nomeCompleto = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Data de nascimento: ");
//            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Telefone: ");
//            string telefone = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Salário: ");
//            double salario = double.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Data de contratação: ");
//            DateTime dataContratacao = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.WriteLine("Dados do carro: ");
//            Console.Write("Placa do carro: ");
//            string placaCarro = (Console.ReadLine());
//            Console.Write("Modelo do carro: ");
//            string modeloCarro = Console.ReadLine();
//            Carro carro = new Carro(placaCarro, modeloCarro);
//            Console.WriteLine();
//            Console.WriteLine("Dados do prédio: ");
//            Console.Write("Nome do prédio: ");
//            string nomePredio = Console.ReadLine();
//            Console.Write("Bloco");
//            string blocoPredio = Console.ReadLine();
//            Console.Write("Numero do apartamento: ");
//            int apartamento = int.Parse(Console.ReadLine());
//            Predio predio = new Predio(nomePredio, blocoPredio, apartamento);

//            return new Sindico(nomeCompleto, dataNascimento, telefone, salario, dataContratacao, carro, predio);
//        }
//        //Método de cadastro Zelador
//        public static Zelador CadastrarZelador()
//        {
//            Console.WriteLine("Entre com os dados abaixo: ");
//            Console.Write("Nome completo: ");
//            string nomeCompleto = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Data de nascimento: ");
//            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Telefone: ");
//            string telefone = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Salário: ");
//            double salario = double.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Data de contratação: ");
//            DateTime dataContratacao = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.WriteLine("Dados do carro: ");
//            Console.Write("Placa do carro: ");
//            string placaCarro = (Console.ReadLine());
//            Console.Write("Modelo do carro: ");
//            string modeloCarro = Console.ReadLine();
//            Carro carro = new Carro(placaCarro, modeloCarro);
//            Console.WriteLine();

//            return new Zelador(nomeCompleto, dataNascimento, telefone, salario, dataContratacao, carro);
//        }
//        //Método de cadastro Morador
//        public static Morador CadastrarMorador()
//        {
//            Console.WriteLine("Entre com os dados abaixo: ");
//            Console.Write("Nome completo: ");
//            string nomeCompleto = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Data de nascimento: ");
//            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Telefone: ");
//            string telefone = Console.ReadLine();
//            Console.WriteLine();
//            Console.Write("Salário: ");
//            double salario = double.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.Write("Data de contratação: ");
//            DateTime dataContratacao = DateTime.Parse(Console.ReadLine());
//            Console.WriteLine();
//            Console.WriteLine("Dados do carro: ");
//            Console.Write("Placa do carro: ");
//            string placaCarro = (Console.ReadLine());
//            Console.Write("Modelo do carro: ");
//            string modeloCarro = Console.ReadLine();
//            Carro carro = new Carro(placaCarro, modeloCarro);
//            Console.WriteLine();
//            Console.WriteLine("Entre com os dados do prédio: ");
//            Console.Write("Nome do prédio: ");
//            string nomePredio = Console.ReadLine();
//            Console.Write("Bloco: ");
//            string blocoPredio = Console.ReadLine();
//            Console.Write("Numero do apartamento: ");
//            int apartamento = int.Parse(Console.ReadLine());
//            Predio predio = new Predio(nomePredio, blocoPredio, apartamento);
//            return new Morador(nomeCompleto, dataNascimento, telefone, predio, carro);
//        }

//    }
//}
