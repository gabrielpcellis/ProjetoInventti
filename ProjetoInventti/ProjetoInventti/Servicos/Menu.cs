using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace ProjetoInventti.Servicos
{

    /* Descrição da classe Menu:
     * Esta classe contém os métodos necessários para fazer a chamada das opções de menu de cada tipo de pessoa 
     * Os métodos desta classe serão usados para chamar os métodos da classe cadastro e demais classes + métodos
    */

    public class Menu
    {
        Cadastro cadastro = new Cadastro();

        //Menus
        //Método para a chamada das opções do administrador
        //O argumento do método é uma lista que adiciona os dados do método chamado pelo objeto "cadastro"
        public void MenuAdministrador(List<Pessoa> usuariosSistema, List<Contas> contasAPagar, List<Contas> contasAReceber)
        {
            // CRIAR OPÇÕES DE ESCOLHA PARA O ADM
            Console.WriteLine("Escolha uma opção, por favor:");
            Console.WriteLine(
                            " 1) Cadastrar novo Administrador, \n"
                            + " 2) Cadastrar novo Síndico, \n"
                            + " 3) Contas a pagar, \n"
                            + " 4) Contas a receber, \n"
                            + " 5) Histórico de gastos, \n"
                            + " 6) Nova conta a pagar: ");

            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    //Cadastrar administrador
                    usuariosSistema.Add(cadastro.CadastrarAdministrador());
                    break;
                case 2:
                    //Cadastrar Síndico
                    usuariosSistema.Add(cadastro.CadastrarSindico());
                    break;
                case 3:
                    //Contas a pagar
                    Console.WriteLine("CONTAS A PAGAR:");
                    Console.WriteLine();
                    for (int i = 0; i < contasAPagar.Count; i++)
                    {
                        Console.WriteLine(contasAPagar[i]);
                    }
                    break;
                case 4:
                    //Contas a receber
                    Console.WriteLine("CONTAS A RECEBER:");
                    Console.WriteLine();
                    for (int i = 0; i < contasAReceber.Count; i++)
                    {
                        Console.WriteLine(contasAReceber[i]);
                    }
                    break;
                case 5:
                    //Historico de gastos
                    Console.WriteLine("HISTÓRICO DE GASTOS");
                    for (int i = 0; i < contasAPagar.Count; i++)
                    {
                        Console.WriteLine(contasAPagar[i]);
                    }
                    break;
                case 6:
                    //Gerar conta a pagar
                    Console.WriteLine("NOVA CONTA A PAGAR: ");
                    contasAPagar.Add(cadastro.GerarConta());
                    break;
                default:
                    break;
            }

        }
        //Método para a chamada das opções do síndico
        public void MenuSindico(List<Pessoa> usuariosSistema, Pessoa usuarioAtual)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(
                            " 1) Cadastrar novo Morador, \n"
                            + " 2) Cadastrar novo Zelador, \n"
                            + " 3) Alterar senha, \n"
                            + " 4) Lista de moradores, \n"
                            + " 5) Solicitações pendentes, \n"
                            + " 6) Sair: ");

            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    usuariosSistema.Add(cadastro.CadastrarMorador());
                    break;
                case 2:
                    usuariosSistema.Add(cadastro.CadastrarZelador());
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Para alterar sua senha, informe os dados abaixo: ");
                    Console.Write("Digite a nova senha: ");
                    string novaSenha = Console.ReadLine();
                    usuarioAtual.AlterarSenha(novaSenha);
                    break;
                case 4:
                    //Mostrar a lista com as alterações feitas
                    Console.WriteLine("Lista de moradores: ");
                    for (int i = 0; i < usuariosSistema.Count; i++)
                    {
                        //Condicional para mostrar apenas moradores
                        //Verifica se o tipo de nível de acesso do objeto atual é igual ao tipo de nível de acesso de morador
                        if (usuariosSistema[i].TipoNivelAcesso == TipoNivelAcesso.Morador)
                        {
                            //Mostrando os dados formatados do objeto atual
                            Console.WriteLine(usuariosSistema[i]);
                        }
                    }
                    break;
                case 5:
                    //Solicitações pendentes
                    Console.WriteLine("nada ainda");
                    break;
                default:
                    break;
            }

        }
        //Método para a chamada das opções do zelador
        public void MenuZelador()
        {

        }
        //Método para a chamada das opções do morador

        public void MenuMorador(List<Solicitacoes> solicitacoes)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(
                            " 1) Alterar senha, \n"
                            + " 2) Abrir nova solicitação, \n"
                            + " 3) Histórico de solicitações, \n"
                            + " 4) Sair: ");

            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:

                    break;
                case 2:
                    Console.WriteLine();
                    solicitacoes.Add(cadastro.GerarNovaSolicitacao());
                    break;
                case 3:
                    Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
                    Console.WriteLine();
                    for (int i = 0; i < solicitacoes.Count; i++)
                    {
                        Console.WriteLine(solicitacoes[i]);
                    }
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

    }

    //Classe interna para cadastrar 
    internal class Cadastro
    {
        //Método de cadastrar administrador
        //Neste método, observa-se o seguinte: 
        //É criado um objeto "pessoa" que recebe o cadastro realizado na chamada do método "GerarPessoa()"
        //Quando o cadastro é realizado, o método retorna um novo administrador com esses dados
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

        // Método para criar um objeto prédio
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

        //Método para criar criar um objeto salário
        private double Salario()
        {
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return salario;
        }

        //Método para gerar nova conta a pagar
        public Contas GerarConta()
        {
            Contas conta = null;

            Console.Write("Digite a quantidade de novas contas a pagar: ");
            int quantidade = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantidade; i++)
            {
                conta = GerarContaAPagar();
            }
            return conta;
        }

        private Contas GerarContaAPagar()
        {
            Console.WriteLine("Contas a pagar: ");
            Console.Write("Data da conta: ");
            DateTime dataConta = DateTime.Parse(Console.ReadLine());
            Console.Write("Valor da energia: ");
            double energia = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valor da luz: ");
            double luz = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valor do gás: ");
            double gas = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valor do jardineiro: ");
            double jardineiro = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valo das despesar gerais: ");
            double despesas = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valor da multa: ");
            double multa = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Valor do condomínio: ");
            double condominio = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Salário do zelador: ");
            double zelador = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);
            Console.Write("Salário do síndico: ");
            double sindico = double.Parse(Console.ReadLine().ToString(), CultureInfo.InvariantCulture);

            Contas contaAPagar = new Contas(dataConta, energia, luz, gas, jardineiro, despesas, multa, condominio, zelador, sindico);
            return contaAPagar;
        }

        //Criar método público para chamar o GerarSolicitacao()
        public Solicitacoes GerarNovaSolicitacao()
        {
            Solicitacoes solicitacao = GerarSolicitacao();
            return solicitacao;
        }

        //Método gerar solicitação
        private Solicitacoes GerarSolicitacao()
        {
            Console.WriteLine("Gerar solicitação: ");
            DateTime data = DateTime.Now;
            Console.Write("Informe o título da solicitação: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe seu nome, seu jaguara: ");
            string nome = Console.ReadLine();
            Pessoa nomePessoa = new Pessoa(nome);
            Console.WriteLine("Informe a descriçao do problema, meu chapa: ");
            string descricao = Console.ReadLine();

            Solicitacoes solicitacao = new Solicitacoes(data, titulo, nomePessoa, descricao);
            return solicitacao;
        }
    }
}
