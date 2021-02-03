using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Excecoes.DomainExceptions;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Menus
{
    class Submenu
    {
        public static void SubMenuSindico(List<Solicitacoes> solicitacoesPendentes, List<Solicitacoes> solicitacoesDoZelador)
        {
            SubmenuSindico(solicitacoesPendentes, solicitacoesDoZelador);
        }
        public static void SubMenuZelador(List<Solicitacoes> solicitacoes)
        {
            SubmenuZelador(solicitacoes);
        }
        #region Submenus
        private static void SubmenuSindico(List<Solicitacoes> solicitacoesPendentes, List<Solicitacoes> solicitacoesDoZelador)
        {
            
            Solicitacoes.VisualizarSolicitacoes(solicitacoesPendentes);

            Console.WriteLine();
            Console.WriteLine("Para visualizar uma solicitação, escolha um número acima: ");
            int posicaoEscolhida = int.Parse(Console.ReadLine());
            int posicao = posicaoEscolhida - 1;

            Console.WriteLine(solicitacoesPendentes[posicao] + "\n");

            Console.WriteLine("Escolha uma opção: \n" +
                " 1) Alterar status da solicitação, \n" +
                " 2) Adicionar observação, \n" +
                " 3) Excluir solicitação, \n" +
                " 4) Transferir para o zelador, \n" +
                " 5) Histórico de ações, \n" +
                " 6) Sair:");

            string opt = Console.ReadLine();

            Historico historico;
            switch (opt)
            {
                case "1":
                    historico = new Historico("A solicitação '", solicitacoesPendentes[posicao].Titulo, "' teve seu status alterado na data ", DateTime.Now);
                    solicitacoesPendentes[posicao].AlterarStatus(solicitacoesPendentes, posicao);
<<<<<<< HEAD
                    //Solicitacoes.VisualizarSolicitacoesEmAnalise(solicitacoesPendentes);
=======
>>>>>>> main
                    historico.AdicionarAoHistorico(historico);
                    break;
                case "2":
                    historico = new Historico("Observação adicionada à solicitação '", solicitacoesPendentes[posicao].Titulo, "' na data ", DateTime.Now);
                    solicitacoesPendentes[posicao].AdicionarObservacao(solicitacoesPendentes, posicao);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case "3":
                    historico = new Historico("A solicitação '", solicitacoesPendentes[posicao].Titulo, "' Foi removida na data ", DateTime.Now);
                    solicitacoesPendentes[posicao].RemoverSolicitacao(solicitacoesPendentes, posicao);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case "4":
                    historico = new Historico("Solicitação '", solicitacoesPendentes[posicao].Titulo, "' transferida na data ", DateTime.Now);
                    Solicitacoes.TransferirSolicitacao(solicitacoesDoZelador, solicitacoesPendentes, posicao);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case "5":
                    Historico.VisualizarHistoricoDeAcoes();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Insira um número de acordo com o menu!");
                    break;
            }
        }
        private static void SubmenuZelador(List<Solicitacoes> solicitacoes)
        {
            Solicitacoes.VisualizarSolicitacoes(solicitacoes);

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

            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    
                    solicitacoes[posicao].AlterarStatus(solicitacoes, posicao);
                    break;
                case "2":
                    solicitacoes[posicao].AdicionarObservacao(solicitacoes, posicao);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Cancelando...");
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Insira um número de acordo com o menu!");
                    break;
            }
        }

        #endregion
    }
}
