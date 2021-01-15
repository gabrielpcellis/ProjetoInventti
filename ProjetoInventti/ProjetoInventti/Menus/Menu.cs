using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Servicos;
using ProjetoInventti.Servicos.Geradores;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoInventti.Menus
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

        #region Menu do administrador
        //Método para chamar as opções do administrador 
        //Finalizado
        public void MenuAdministrador(List<Pessoa> usuariosSistema, List<Contas> contas, List<Predio> predios)
        {
            // CRIAR OPÇÕES DE ESCOLHA PARA O ADM
            Console.WriteLine("Escolha uma opção, por favor:");
            Console.WriteLine(" 1) Cadastrar novo Administrador, \n"
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
                    Console.WriteLine();
                    Console.Write("Total: ");
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
        public void MenuSindico(List<Pessoa> usuariosSistema, Pessoa usuarioAtual,ref List<Solicitacoes> solicitacoes, List<Predio> predios, List<Solicitacoes> solicitacoesDoZelador)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(" 1) Cadastrar novo Morador, \n"
                            + " 2) Cadastrar novo Zelador, \n"
                            + " 3) Alterar senha, \n"
                            + " 4) Lista de moradores, \n"
                            + " 5) Solicitações pendentes, \n"
                            + " 6) Histórico de solicitações, \n"
                            + " 7) Excluir morador: ");

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
                    Console.WriteLine();

                    //Lista filtrada
                    List<Pessoa> moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
                    foreach (var item in moradores)
                    {
                        //Mostrando os dados formatados do objeto atual
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    break;
                case 5:
                    //Solicitações pendentes
                    Sindico sindico = (Sindico)usuarioAtual;
                    //Lista filtrada
                    List<Solicitacoes> solicitacoesPendentes = solicitacoes.FindAll(x => x.Predio.NomePredio == sindico.Predio.NomePredio);
                    solicitacoes = solicitacoesPendentes;
                   
                    //Submenu do síndico
                    Submenu.SubMenuSindico(solicitacoesPendentes, solicitacoesDoZelador);
                    break;
                case 6:
                    Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
                    Console.WriteLine();
                    for (int i = 0; i < solicitacoes.Count; i++)
                    {
                        Console.WriteLine(solicitacoes[i]);
                        Console.WriteLine();
                    }
                    break;
                case 7:
                    //Lista filtrada
                    moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
                    GeradorPessoa.RemoverMorador(moradores, usuariosSistema);
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
                            Console.WriteLine(i + 1 + "- " + solicitacoes[i].Titulo);
                        }

                        //Submenu do zelador
                        Submenu.SubMenuZelador(solicitacoes);
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
                        foreach (var item in solicitacoes)
                        {
                            Console.WriteLine(item);
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
                    //Criar nova solicitação e enviá-la para a lista do síndico na primeira posição
                    solicitacoes.Insert(0, geradorSolicitacao.GerarNovaSolicitacao(usuarioAtual));
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
                        Console.WriteLine();
                    }
                    break;
                default:
                    break;
            }
        }

    }

    #endregion
}
