using ProjetoInventti.Entidades;
using ProjetoInventti.Serviços;
using System;
using System.Collections.Generic;

namespace ProjetoInventti {
    public class Program {
        static void Main(string[] args)
        {
            //Criar tela de login com usuário e senha (validar com if + ToUpper)
            //Criar um switch case para definir que tipo de pessoa cadastrar
            //Criar um for para definir a quantidade de pessoas a serem cadastradas
            //Criar e instanciar uma lista para cada tipo de pessoa a ser cadastrada

            #region Populando carga Inicial

            //Objetos predio
            Predio predio = new Predio("PREDIO XPTO 1", "BLOCO-01");
            Predio predio1 = new Predio("PREDIO XPTO 2", "BLOCO-02");

            //Objetos carro
            Carro carro = new Carro("PLACA XPTO 1", "FIAT XPTO");
            Carro carro1 = new Carro("PLACA XPTO 2", "UNO XPTO");

            List<Administrador> administradores = new List<Administrador>();
            List<Sindico> sindicos = new List<Sindico>();
            List<Zelador> zeladores = new List<Zelador>();
            List<Morador> moradores = new List<Morador>();

            //injeção de valores lista administrador
            administradores.Add(new Administrador("Gabriel",DateTime.Parse("20/05/1993"),"1111-1111", 1000.00, carro1));
            administradores.Add(new Administrador("Alexandre",DateTime.Parse("28/01/1996"),"9198-4021", 1500.00, carro));

            //injeção de valores lista síndico
            sindicos.Add(new Sindico("Dilso",DateTime.Parse("12/07/2000"), "2222-3333", 150.00, DateTime.Parse("10/04/2015"), carro, predio1));

            //injeção de valores lista zelador
            zeladores.Add(new Zelador("Mateus",DateTime.Parse("03/10/1990"), "2222-2222", 5000.00, DateTime.Parse("06/10/2013"), carro));

            //injeção de valores lista morador
            moradores.Add(new Morador("Tiago", DateTime.Parse("03/10/1990"), "2222-5555", predio, carro1));

            #endregion



            //Nível de acesso
            //Console.Write("Digite seu nível de acesso (1- Administrador, 2- Síndico, 3- Zelador, 4- Morador): ");
            //int nivelDeAcesso = int.Parse(Console.ReadLine());

            //switch (nivelDeAcesso)
            //{
            //    case 1:
            //        Console.WriteLine("Administrador:");
            //        Console.Write("Digite a quantidade desejada de novos cadastros: ");
            //        int quantidadeDeCadastrosASeremFeitos = int.Parse(Console.ReadLine());
            //        for (int i = 0; i < quantidadeDeCadastrosASeremFeitos; i++)
            //        {
            //            Console.Write("Digite a opção correspondente ao tipo de cadastro que você deseja realizar (1- Administrador, 2- Síndico): ");
            //            int opcao1 = int.Parse(Console.ReadLine());
            //            switch (opcao1)
            //            {
            //                case 1:
            //                    Console.WriteLine("Opção escolhida: 1- Administrador: ");
            //                    administradores.Add(Cadastro.CadastrarAdministrador());
            //                    break;
            //                case 2:
            //                    Console.WriteLine("Opção escolhida: 2- Síndico: ");
            //                    sindicos.Add(Cadastro.CadastrarSindico());
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //        break;
            //    case 2:
            //        Console.WriteLine("Síndico:");
            //        Console.Write("Digite a quantidade desejada de novos cadastros: ");
            //        quantidadeDeCadastrosASeremFeitos = int.Parse(Console.ReadLine());
            //        for (int i = 0; i < quantidadeDeCadastrosASeremFeitos; i++)
            //        {
            //            Console.Write("Digite a opção correspondente ao tipo de cadastro que você deseja realizar (1- Zelador, 2- Morador): ");
            //            int opcao2 = int.Parse(Console.ReadLine());
            //            switch (opcao2)
            //            {
            //                case 1:
            //                    Console.WriteLine("Opção escolhida: 1- Zelador:");
            //                    zeladores.Add(Cadastro.CadastrarZelador());
            //                    break;
            //                case 2:
            //                    Console.WriteLine("Opção escolhida: 2- Morador: ");
            //                    moradores.Add(Cadastro.CadastrarMorador());
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //        break;
            //    case 3:
            //        Console.WriteLine("Zelador:");
            //        Console.Write("Digite uma opção: 1- Alterar senha, 2- Solicitações pendentes, 3- Histórico de solicitações, 4- Sair");
            //            Console.Write("Digite a opção correspondente ao tipo de cadastro que você deseja realizar (1- Zelador, 2- Morador): ");
            //            int opcao = int.Parse(Console.ReadLine());
            //            switch (opcao)
            //            {
            //                case 1:
            //                    zeladores.Add(Cadastro.CadastrarZelador());
            //                    break;
            //                case 2:
            //                    moradores.Add(Cadastro.CadastrarMorador());
            //                    break;
            //                default:
            //                    break;
            //            }
            //        break;
            //    case 4:
            //        //moradores.Add(Cadastro.CadastrarMorador());
            //        break;
            //    default:
            //        break;
            //}


        }
    }
}
