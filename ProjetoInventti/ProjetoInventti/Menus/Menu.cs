using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Servicos;
using ProjetoInventti.Servicos.Geradores;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoInventti.Menus
{
    public class Menu
    {
        GeradorPessoa geradorPessoa = new GeradorPessoa();
        GeradorConta geradorConta = new GeradorConta();
        GeradorSolicitacao geradorSolicitacao = new GeradorSolicitacao();

        #region Menu do administrador
        public void MenuAdministrador(List<Pessoa> usuariosSistema, List<Contas> contas, List<Predio> predios, ref bool opcaoSair, ref Pessoa usuarioConectado)
        {
            Console.WriteLine("Escolha uma opção, por favor:");
            Console.WriteLine(" 1) Cadastrar novo Administrador, \n"
                            + " 2) Cadastrar novo Síndico, \n"
                            + " 3) Contas a pagar, \n"
                            + " 4) Contas a receber, \n"
                            + " 5) Histórico de gastos, \n"
                            + " 6) Nova conta a pagar, \n"
                            + " 7) Trocar usuário, \n"
                            + " 8) Sair: ");
            try
            {
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        usuariosSistema.Add(geradorPessoa.CadastrarAdministrador());
                        break;
                    case 2:
                        usuariosSistema.Add(geradorPessoa.CadastrarSindico(predios));
                        break;
                    case 3:
                        Console.WriteLine("CONTAS A PAGAR:");
                        foreach (var obj in contas)
                        {
                            if (obj.TipoConta == TipoConta.Pagar)
                                Console.WriteLine(obj);
                        }
                        break;
                    case 4:
                        Console.WriteLine("CONTAS A RECEBER:");
                        foreach (var obj in contas)
                        {
                            if (obj.TipoConta == TipoConta.Receber)
                                Console.WriteLine(obj);
                        }
                        break;
                    case 5:
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
                        contas.AddRange(geradorConta.GerarConta());
                        break;
                    case 7:
                        Deslogar(ref usuarioConectado);
                        break;
                    case 8:
                        Sair(ref opcaoSair);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de texto inválido!");
            }

        }
        #endregion

        #region Menu do síndico
        public void MenuSindico(List<Pessoa> usuariosSistema, Pessoa usuarioAtual, ref List<Solicitacoes> solicitacoes, List<Predio> predios,
            List<Solicitacoes> solicitacoesDoZelador, List<Historico> historico, ref bool opcaoSair, ref Pessoa usuarioConectado)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(" 1) Cadastrar novo Morador, \n"
                            + " 2) Cadastrar novo Zelador, \n"
                            + " 3) Alterar senha, \n"
                            + " 4) Lista de moradores, \n"
                            + " 5) Solicitações pendentes, \n"
                            + " 6) Histórico de solicitações, \n"
                            + " 7) Excluir morador, \n" 
                            + " 8) Trocar usuário, \n" 
                            + " 9) Sair: ");
            try
            {
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
                        Console.WriteLine("Lista de moradores: \n");

                        Console.WriteLine("Nome completo,  Data de nascimento,  Modelo,  Placa,    Telefone,  Usuário,  Senha");
                        List<Pessoa> moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
                        foreach (var item in moradores)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        Sindico sindico = (Sindico)usuarioAtual;
                        List<Solicitacoes> solicitacoesPendentes = solicitacoes.FindAll(x => x.Predio.NomePredio == sindico.Predio.NomePredio);
                        solicitacoes = solicitacoesPendentes;

                        Submenu.SubMenuSindico(solicitacoesPendentes, solicitacoesDoZelador, historico);
                        break;
                    case 6:
                        Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES: \n");

                        sindico = (Sindico)usuarioAtual;
                        solicitacoesPendentes = solicitacoes.FindAll(x => x.Predio.NomePredio == sindico.Predio.NomePredio);

                        if (solicitacoesPendentes.Count > 0)
                        {
                            for (int i = 0; i < solicitacoesPendentes.Count; i++)
                            {
                                Console.WriteLine(solicitacoesPendentes[i] + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Histórico vazio. \n");
                        }
                        break;
                    case 7:
                        moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
                        GeradorPessoa.RemoverMorador(moradores, usuariosSistema);
                        break;
                    case 8:
                        Deslogar(ref usuarioConectado);
                        break;
                    case 9:
                        Sair(ref opcaoSair);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de texto inválido! \n");
            }
        }
        #endregion

        #region Menu do zelador
        public void MenuZelador(Pessoa usuarioAtual, List<Solicitacoes> solicitacoes, ref bool opcaoSair, ref Pessoa UsuarioConectado)
        {
            Console.WriteLine("Escolha uma opção, por favor: ");
            Console.WriteLine(
                            " 1) Alterar senha, \n"
                            + " 2) Solicitações pendentes, \n"
                            + " 3) Histórico de solicitações \n"
                            + " 4) Trocar usuário, \n"
                            + " 5) Sair: ");

            try
            {
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
                            Submenu.SubMenuZelador(solicitacoes);
                        }
                        else
                        {
                            Console.WriteLine("Não há solicitações pendentes.");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
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
                    case 4:
                        Deslogar(ref usuarioAtual);
                        break;
                    case 5:
                        Sair(ref opcaoSair);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de texto inválido!");
            }
        }
        #endregion

        #region Menu do morador
        public void MenuMorador(List<Solicitacoes> solicitacoes,ref Pessoa usuarioAtual, List<Solicitacoes> solicitacoesSindico, ref bool opcaoSair)
        {
            try
            {
                Console.WriteLine("Escolha uma opção, por favor: ");
                Console.WriteLine();
                Console.WriteLine(" 1) Alterar senha, \n"
                                + " 2) Abrir nova solicitação, \n"
                                + " 3) Histórico de solicitações, \n"
                                + " 4) Trocar usuário, \n"
                                + " 5) Sair: ");

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
                        solicitacoesSindico.Insert(0, geradorSolicitacao.GerarNovaSolicitacao(usuarioAtual));
                        solicitacoes.Insert(0, solicitacoesSindico[0]);
                        break;
                    case 3:
                        Solicitacoes.VisualizarHistoricoDeSolicitacoes(solicitacoes);
                        break;
                    case 4:
                        Deslogar(ref usuarioAtual);
                        break;
                    case 5:
                        Sair(ref opcaoSair);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de texto inválido!");
            }
        }

        #endregion

        public void Deslogar(ref Pessoa usuarioConectado)
        {
            Console.WriteLine("Tem certeza que deseja trocar de usuário (S ou N)?");
            char confirmacao = char.Parse(Console.ReadLine());
            if (confirmacao == 'S' || confirmacao == 's')
            {
                usuarioConectado = null;
            }
        }
        public void Sair(ref bool opcaoSair)
        {
            Console.Write("Tem certeza que deseja sair (S ou N)? ");
            char confirmacao = char.Parse(Console.ReadLine());
            if (confirmacao == 'S' || confirmacao == 's')
            {
                opcaoSair = true;
                Console.WriteLine("Saindo...");
            }
        }

    }
}
