//using ProjetoInventti.Entidades;
//using System;
//using System.Collections.Generic;
//using ProjetoInventti.Serviços;
//using ProjetoInventti.Enums;

//namespace ProjetoInventti {
//    public class Program_old {

//        static void Main(string[] args)
//        {
//            //Criar tela de login com usuário e senha (validar com if + ToUpper)
//            //Criar um switch case para definir que tipo de pessoa cadastrar
//            //Criar um for para definir a quantidade de pessoas a serem cadastradas
//            //Criar e instanciar uma lista para cada tipo de pessoa a ser cadastrada

//            #region Carga inicial listas

//            //Objetos predio
//            Predio predio = new Predio("PREDIO XPTO 1", "BLOCO-01", 12);
//            Predio predio1 = new Predio("PREDIO XPTO 2", "BLOCO-02", 20);

//            //Objetos carro
//            Carro carro = new Carro("PLACA XPTO 1", "FIAT XPTO");
//            Carro carro1 = new Carro("PLACA XPTO 2", "UNO XPTO");

//            //Listas criada e instanciadas
//            List<Administrador> administradores = new List<Administrador>();
//            List<Sindico> sindicos = new List<Sindico>();
//            List<Zelador> zeladores = new List<Zelador>();
//            List<Morador> moradores = new List<Morador>();
            

//            //injeção de valores lista administrador
//            administradores.Add(new Administrador("Gabriel", DateTime.Parse("20/05/1993"), "1111-1111", 1000.00, carro1));
//            administradores.Add(new Administrador("Alexandre", DateTime.Parse("28/01/1996"), "9198-4021", 1500.00, carro));

//            //injeção de valores lista síndico
//            sindicos.Add(new Sindico("Dilso", DateTime.Parse("12/07/2000"), "2222-3333", 150.00, DateTime.Parse("10/04/2015"), carro, predio1));

//            //injeção de valores lista zelador
//            zeladores.Add(new Zelador("Mateus", DateTime.Parse("03/10/1990"), "2222-2222", 5000.00, DateTime.Parse("06/10/2013"), carro));

//            //injeção de valores lista morador
//            moradores.Add(new Morador("Thiago", DateTime.Parse("03/10/1990"), "2222-5555", predio, carro1));

//            #endregion

//            var zelador = zeladores[0];


//            switch (zelador.TipoNivelAcesso)
//            {
//                case TipoNivelAcesso.Administrador:
//                    break;
//                case TipoNivelAcesso.Sindico:
//                    Menu.Sindico();
//                    break;
//                case TipoNivelAcesso.Zelador:
//                    Menu.Zelador();
//                    break;
//                case TipoNivelAcesso.Morador:
//                    break;
//                default:
//                    break;
//            }

//            #region Login e verificação

//            //Coletando dados do usuário

//            Console.WriteLine("Bem vindo(a) ao sistema!");
//            Console.Write("Login: ");
//            string usuario = Console.ReadLine();
//            Console.Write("Senha: ");
//            string senha = Console.ReadLine();

//            //Declaração e instanciação do objeto login
//            Usuario login = new Usuario(usuario, senha);

//            #endregion



//            //Cadastro cadastro = new Cadastro();

//            //    switch (NivelAcesso())
//            //    {
//            //        case 1:
//            //            Console.WriteLine("Você está logado como Administrador: ");
//            //            Console.WriteLine("Qual ação deseja executar? "
//            //                + " 1) Cadastrar novo Administrador,"
//            //                + " 2) Cadastrar novo Síndico,"
//            //                + " 3) Contas a pagar,"
//            //                + " 4) Contas a receber,"
//            //                + " 5) Histórico de gastos");

//            //            int opcao = int.Parse(Console.ReadLine());

//            //            switch (opcao)
//            //            {
//            //                case 1:
//            //                    administradores = new List<Administrador>();

//            //                    Console.WriteLine("Cadastro de administradores: ");
//            //                    Console.Write("Digite a quantidade de cadastros desejados: ");
//            //                    int quantidadeDeCadastros = int.Parse(Console.ReadLine());
//            //                    for (int i = 0; i < quantidadeDeCadastros; i++)
//            //                    {
//            //                        cadastro.CadastrarAdministrador();
//            //                    }
//            //                    break;
//            //                case 2:
//            //                    sindicos = new List<Sindico>();

//            //                    Console.WriteLine("Cadastro de síndicos: ");
//            //                    Console.Write("Digite a quantidade de cadastros desejados: ");
//            //                    quantidadeDeCadastros = int.Parse(Console.ReadLine());
//            //                    for (int i = 0; i < quantidadeDeCadastros; i++)
//            //                    {
//            //                        cadastro.CadastrarSindico();
//            //                    }
//            //                    break;
//            //                case 3:
//            //                    //contas a pagar
//            //                    break;
//            //                case 4:
//            //                    //contas a receber
//            //                    break;
//            //                case 5:
//            //                    //histórico de gastos
//            //                    break;
//            //                default:
//            //                    break;
//            //            }
//            //            break;
//            //        case 2:
//            //            Console.WriteLine("Você está logado como Síndico: ");
//            //            Console.WriteLine("Qual ação deseja executar? "
//            //                + " 1) Alterar senha,"
//            //                + " 2) Cadastrar novo morador,"
//            //                + " 3) Cadastrar novo zelador,"
//            //                + " 4) Solicitações pendentes,"
//            //                + " 5) Histórico de solicitações");

//            //            opcao = int.Parse(Console.ReadLine());

//            //            switch (opcao)
//            //            {
//            //                case 1:
//            //                    //Alterar senha
//            //                    break;
//            //                case 2:
//            //                    Console.WriteLine("Cadastro de morador: ");
//            //                    Console.Write("Digite a quantidade desejada: ");
//            //                    int quantidadeDeCadastros = int.Parse(Console.ReadLine());
//            //                    for (int i = 0; i < quantidadeDeCadastros; i++)
//            //                    {

//            //                    }
//            //                    break;
//            //                default:
//            //                    break;
//            //            }

//            //            break;
//            //        default:
//            //            break;
//            //    }
//            //}


            

//        }
//    }
//}
