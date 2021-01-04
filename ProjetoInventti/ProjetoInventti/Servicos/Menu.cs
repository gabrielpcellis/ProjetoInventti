using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Servicos.Geradores;
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
        GeradorPessoa geradorPessoa = new GeradorPessoa();
        GeradorConta geradorConta = new GeradorConta();
        GeradorSolicitacao geradorSolicitacao = new GeradorSolicitacao();


        //Menus
        //Método para a chamada das opções do administrador
        //O argumento do método é uma lista que adiciona os dados do método chamado pelo objeto "cadastro"

        #region Menu do administrador
        //Método para chamar as opções do administrador
        public void MenuAdministrador(List<Pessoa> usuariosSistema, List<Contas> contas, List<Predio> predios)
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
                    usuariosSistema.Add(geradorPessoa.CadastrarAdministrador());
                    break;
                case 2:
                    //Cadastrar Síndico
                    usuariosSistema.Add(geradorPessoa.CadastrarSindico(predios));
                    break;
                case 3:
                    //Contas a pagar
                    Console.WriteLine("CONTAS A PAGAR:");
                    foreach (var obj in contas)
                    {
                        if (obj.TipoConta == TipoConta.Pagar)
                            Console.WriteLine(obj);
                    }
                    break;
                case 4:
                    //Contas a receber
                    Console.WriteLine("CONTAS A RECEBER:");
                    foreach (var obj in contas)
                    {
                        if (obj.TipoConta == TipoConta.Receber)
                            Console.WriteLine(obj);
                    }
                    break;
                case 5:
                    //Historico Total de Gastos
                    Console.WriteLine("HISTÓRICO DE GASTOS:");
                    decimal totalGasto = 0.0m;
                    foreach (var obj in contas)
                    {
                        totalGasto += obj.Valor;
                    }
                    Console.WriteLine(totalGasto.ToString("F2", CultureInfo.InvariantCulture));
                    break;
                case 6:
                    //Gerar conta a pagar
                    Console.WriteLine("NOVA CONTA A PAGAR: ");
                    contas.AddRange(geradorConta.GerarConta());
                    break;
                default:
                    break;
            }

        }
        #endregion

        #region Menu do síndico
        //Método para a chamada das opções do síndico
        public void MenuSindico(List<Pessoa> usuariosSistema, Pessoa usuarioAtual, List<Solicitacoes> solicitacoes, List<Predio> predios)
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
                    usuariosSistema.Add(geradorPessoa.CadastrarMorador(predios));
                    break;
                case 2:
                    usuariosSistema.Add(geradorPessoa.CadastrarZelador(predios));
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
                    Console.WriteLine("Solicitações Recebidas: ");
                    Sindico sindico = (Sindico)usuarioAtual; 
                    List<Solicitacoes> solicitacoesRecebidas = solicitacoes.FindAll(x => x.Predio.NomePredio == sindico.PredioSindico.NomePredio);
                    foreach(var obj in solicitacoesRecebidas)
                    {
                        Console.WriteLine(obj.ToString());
                        Console.WriteLine();
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
                                        solicitacoes[posicao].TipoSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
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
                    solicitacoes.Add(geradorSolicitacao.GerarNovaSolicitacao(usuarioAtual));
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
}
