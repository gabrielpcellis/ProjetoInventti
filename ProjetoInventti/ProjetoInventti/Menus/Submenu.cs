using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Menus
{
    class Submenu
    {
        public static void SubMenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador, List<Historico> historico)
        {
            SubmenuSindico(solicitacoes, solicitacoesDoZelador, historico);
        }
        public static void SubMenuZelador(List<Solicitacoes> solicitacoes)
        {
            SubmenuZelador(solicitacoes);
        }
        #region Submenus
        private static void SubmenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador, List<Historico> historicoDeAcoes)
        {
            Console.WriteLine("Solicitações pendentes: ");
            Console.WriteLine();
            if (solicitacoes.Count > 0)
            {
                try
                {
                    for (int i = 0; i < solicitacoes.Count; i++)
                    {
                        Console.WriteLine(i + 1 + "- " + solicitacoes[i].Titulo);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Para visualizar uma solicitação, escolha um número acima: ");
                    int posicaoEscolhida = int.Parse(Console.ReadLine());
                    int posicao = posicaoEscolhida - 1;
                    Console.WriteLine();

                    Console.WriteLine(solicitacoes[posicao]);
                    Console.WriteLine();

                    Console.WriteLine("Escolha uma opção: \n" +
                        " 1) Alterar status da solicitação, \n" +
                        " 2) Adicionar observação, \n" +
                        " 3) Excluir solicitação, \n" +
                        " 4) Transferir para o zelador, \n" +
                        " 5) Histórico de ações, \n" +
                        " 6) Cancelar e sair:");

                    int opt = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Historico historico;

                    switch (opt)
                    {
                        case 1:
                            solicitacoes[posicao].AlterarStatus(solicitacoes, posicao);
                            historico = new Historico("A solicitação '", solicitacoes[posicao].Titulo, "' teve seu status alterado na data ", DateTime.Now);
                            historicoDeAcoes.Add(historico);
                            break;
                        case 2:
                            solicitacoes[posicao].AdicionarObservacao(solicitacoes, posicao);
                            historico = new Historico("Observação adicionada à solicitação '", solicitacoes[posicao].Titulo, "' na data ", DateTime.Now);
                            historicoDeAcoes.Add(historico);
                            break;
                        case 3:
                            solicitacoes[posicao].RemoverSolicitacao(solicitacoes, posicao);
                            historico = new Historico("A solicitação '", solicitacoes[posicao].Titulo, "' Foi removida na data ", DateTime.Now);
                            historicoDeAcoes.Add(historico);
                            break;
                        case 4:
                            solicitacoes[posicao].TransferirSolicitacao(solicitacoesDoZelador, solicitacoes, posicao);
                            historico = new Historico("Solicitação '", solicitacoes[posicao].Titulo, "' transferida na data ", DateTime.Now);
                            historicoDeAcoes.Add(historico);
                            break;
                        case 5:
                            historico = null;
                            Console.WriteLine("Histórico de ações: ");
                            foreach (var item in historicoDeAcoes)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 6:
                            Console.WriteLine("Saindo...");
                            break;
                    }
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de texto inválido!");
                    Console.WriteLine();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("O argumento fornecido não corresponde à nenhuma solicitação existente!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Não há solicitações pendentes no momento.");
                Console.WriteLine();
            }
        }
        private static void SubmenuZelador(List<Solicitacoes> solicitacoes)
        {
            try
            {
                Console.WriteLine("Solicitações pendentes: ");
                Console.WriteLine();

                for (int i = 0; i < solicitacoes.Count; i++)
                {
                    Console.WriteLine(i + 1 + "- " + solicitacoes[i].Titulo);
                }

                Console.WriteLine();
                Console.WriteLine("Para visualizar uma solicitação, escolha um número acima: ");
                int posicaoEscolhida = int.Parse(Console.ReadLine());
                int posicao = posicaoEscolhida - 1;
                Console.WriteLine();

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
                        solicitacoes[posicao].AlterarStatus(solicitacoes, posicao);
                        break;
                    case 2:
                        solicitacoes[posicao].AdicionarObservacao(solicitacoes, posicao);
                        break;
                    case 3:
                        Console.WriteLine("Cancelando...");
                        Console.WriteLine();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de texto inválido!");
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("O argumento fornecido não corresponde à nenhuma solicitação existente!");
                Console.WriteLine();
            }
        }
        #endregion
    }
}
