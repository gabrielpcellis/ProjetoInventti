﻿using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

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

        #region Menu do administrador
        //Método para chamar as opções do administrador
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
                    //REVISAR
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
        #endregion

        #region Menu do síndico
        //Método para a chamada das opções do síndico
        public void MenuSindico(List<Pessoa> usuariosSistema, Pessoa usuarioAtual, List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(
                            " 1) Cadastrar novo Morador, \n"
                            + " 2) Cadastrar novo Zelador, \n"
                            + " 3) Alterar senha, \n"
                            + " 4) Lista de moradores, \n"
                            + " 5) Solicitações pendentes, \n"
                            + " 6) Histórico de solicitações: ");

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
                    Console.WriteLine("Solicitações pendentes: ");
                    Console.WriteLine();

                    if (solicitacoes.Count > 0)
                    {
                        //Percorrerá a lista toda mostrando apenas o título dela
                        for (int i = 0; i < solicitacoes.Count; i++)
                        {
                            Console.WriteLine(i + 1 + " - " + solicitacoes[i].Titulo);
                        }

                        //Procurar uma forma de mostrar este bloco apenas quando as solicitações forem do síndico
                        Console.WriteLine();
                        Console.WriteLine("Para visualizar uma solicitação, escolha um número acima: ");
                        int posicaoEscolhida = int.Parse(Console.ReadLine());
                        int posicao = posicaoEscolhida - 1;
                        Console.WriteLine();

                        for (int i = 0; i < solicitacoes.Count; i++)
                        {
                            //Percorrerá a lista, mostrando apenas a posição escolhida
                            if (solicitacoes[i] == solicitacoes[posicao])
                            {
                                Console.WriteLine(solicitacoes[i]);
                                Console.WriteLine();
                                //Se o tipo de solicitação for Recebida ou AnaliseSindico, faça

                                Console.WriteLine("Escolha uma opção: \n" +
                                    " 1) Alterar status da solicitação, \n" +
                                    " 2) Adicionar observação, \n" +
                                    " 3) Excluir solicitação, \n" +
                                    " 4) Transferir para o zelador, \n" +
                                    " 5) Cancelar:");

                                int opt = int.Parse(Console.ReadLine());
                                Console.WriteLine();

                                switch (opt)
                                {
                                    case 1:
                                        Console.WriteLine("Digite o novo status da solicitação: 'AnaliseSindico', 'Finalizado', 'Zelador', AnaliseZelador: ");
                                        solicitacoes[i].TipoSolicitacao = Enum.Parse<TipoSolicitacao>(Console.ReadLine());
                                        break;
                                    case 2:
                                        Console.Write("Adicionar observação: ");
                                        string observacao = Console.ReadLine();
                                        solicitacoes[i].Observacao = observacao;
                                        Console.WriteLine("Nova observação: " + solicitacoes[i].Observacao);
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        solicitacoes.RemoveAt(i);
                                        Console.WriteLine("A solicitação foi excluída.");
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        solicitacoesDoZelador.Add(solicitacoes[i]);
                                        solicitacoes.RemoveAt(i);
                                        Console.WriteLine("Solicitação transferida.");
                                        Console.WriteLine();
                                        break;
                                    case 5:
                                        Console.WriteLine("Cancelando...");
                                        Console.WriteLine();
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não solicitações pendentes");
                    }
                    break;
                case 6:
                    //Filtrar histórico por tipoNivelAcesso
                    Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
                    Console.WriteLine();
                    for (int i = 0; i < solicitacoes.Count; i++)
                    {
                        Console.WriteLine(solicitacoes[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Menu do zelador
        //Método para a chamada das opções do zelador
        public void MenuZelador(Pessoa usuarioAtual, List<Solicitacoes> solicitacoes)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(
                            " 1) Alterar senha, \n"
                            + " 2) Solicitações pendentes, \n"
                            + " 3) Histórico de solicitações: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Para alterar sua senha, informe os dados abaixo: ");
                    Console.Write("Digite a nova senha: ");
                    string novaSenha = Console.ReadLine();
                    usuarioAtual.AlterarSenha(novaSenha);
                    break;
                case 2:
                    if (solicitacoes.Count > 0)
                    {
                        Console.WriteLine("Solicitações pendentes: ");
                        Console.WriteLine();

                        for (int i = 0; i < solicitacoes.Count; i++)
                        {
                            //Percorrerá a lista toda mostrando apenas o título dela caso a solicitação respeite a condicional
                            Console.WriteLine(i + 1 + " - " + solicitacoes[i].Titulo);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Para visualizar uma solicitação, escolha um número acima: ");
                        int posicaoEscolhida = int.Parse(Console.ReadLine());
                        int posicao = posicaoEscolhida - 1;
                        Console.WriteLine();

                        //A execução somente acabará quando percorrer toda a lista.

                        for (int j = 0; j < solicitacoes.Count; j++)
                        {
                            if (solicitacoes[j] == solicitacoes[posicao])
                            {
                                Console.WriteLine("Solicitação escolhida: \n" + solicitacoes[posicao]);
                                Console.WriteLine();
                                Console.WriteLine("Escolha uma opção: \n" +
                                   " 1) Alterar status da solicitação, \n" +
                                   " 2) Adicionar observação, \n" +
                                   " 3) Cancelar:");

                                int opt = int.Parse(Console.ReadLine());
                                Console.WriteLine();

                                switch (opt)
                                {
                                    case 1:
                                        Console.WriteLine("Digite o novo status da solicitação: 'AnaliseZelador: ");
                                        solicitacoes[posicao].TipoSolicitacao = Enum.Parse<TipoSolicitacao>(Console.ReadLine());
                                        Console.WriteLine("Status atualizado: " + solicitacoes[posicao].TipoSolicitacao);
                                        Console.WriteLine();
                                        break;
                                    case 2:
                                        Console.Write("Adicionar observação: ");
                                        string observacao = Console.ReadLine();
                                        solicitacoes[j].Observacao = observacao;
                                        Console.WriteLine("Nova observação: " + solicitacoes[j].Observacao);
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("Cancelando...");
                                        Console.WriteLine();
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há solicitações pendentes.");
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    //Histórico de solicitações
                    if (solicitacoes.Count > 0)
                    {
                        Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
                        Console.WriteLine();
                        for (int i = 0; i < solicitacoes.Count; i++)
                        {
                            Console.WriteLine(solicitacoes[i]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há nenhuma solicitação.");
                    }
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Menu do morador
        //Método para a chamada das opções do morador
        public void MenuMorador(List<Solicitacoes> solicitacoes, Pessoa usuarioAtual, List<Solicitacoes> solicitacoesSindico)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine();
            Console.WriteLine(" 1) Alterar senha, \n"
                            + " 2) Abrir nova solicitação, \n"
                            + " 3) Histórico de solicitações: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Para alterar sua senha, informe os dados abaixo: ");
                    Console.Write("Digite a nova senha: ");
                    string novaSenha = Console.ReadLine();
                    usuarioAtual.AlterarSenha(novaSenha);
                    break;
                case 2:
                    //Criar nova solicitação e enviá-la para a lista do síndico
                    solicitacoes.Add(cadastro.GerarNovaSolicitacao(usuarioAtual));
                    for (int i = 0; i < solicitacoes.Count; i++)
                    {
                        solicitacoesSindico.Add(solicitacoes[i]);
                    }
                    break;
                case 3:
                    //Se a lista for somente inicializada, não entrará no IF
                    if (solicitacoes.Count > 0)
                    {
                        Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
                        Console.WriteLine();
                        for (int i = 0; i < solicitacoes.Count; i++)
                        {
                            Console.WriteLine(solicitacoes[i]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há nenhuma solicitação no histórico");
                    }
                    break;
                default:
                    break;
            }
        }

    }
    #endregion


    //Classe interna para cadastrar 
    internal class Cadastro
    {
        //Método de cadastrar administrador
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
        public Solicitacoes GerarNovaSolicitacao(Pessoa nome)
        {
            Solicitacoes solicitacao = GerarSolicitacao(nome);
            return solicitacao;
        }

        //Método gerar solicitação recebendo o nome do usuário logado como nome do solicitante
        private Solicitacoes GerarSolicitacao(Pessoa nome)
        {
            Console.WriteLine("Criando nova solicitação...");
            DateTime data = DateTime.Now;
            Console.Write("Informe o título da solicitação: ");
            string titulo = Console.ReadLine();
            Console.Write("Informe a descriçao do problema, meu chapa: ");
            string descricao = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Deseja adicionar uma observação? 1- Sim, 2- Não");
            int opt = int.Parse(Console.ReadLine());

            string observacao = null;
            if (opt == 1)
            {
                Console.Write("Observação: ");
                observacao = Console.ReadLine();
            }

            Solicitacoes solicitacao = new Solicitacoes(data, titulo, nome.NomeCompleto, descricao, TipoSolicitacao.Recebido, observacao);
            Console.WriteLine();
            Console.WriteLine("Solicitação criada: ");
            Console.WriteLine();
            Console.WriteLine(solicitacao);
            Console.WriteLine();

            return solicitacao;
        }
    }
}
