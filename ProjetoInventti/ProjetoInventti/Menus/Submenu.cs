using ProjetoInventti.Entidades;
using ProjetoInventti.Excecoes.DomainExceptions;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Menus
{
    class Submenu
    {
        public static void SubMenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
        {
            SubmenuSindico(solicitacoes, solicitacoesDoZelador);
        }
        public static void SubMenuZelador(List<Solicitacoes> solicitacoes)
        {
            SubmenuZelador(solicitacoes);
        }
        #region Submenus
        private static void SubmenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
        {
            Solicitacoes.VisualizarSolicitacoesPendentes(solicitacoes);

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
                " 6) Sair:");

            int opt = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Historico historico;
            switch (opt)
            {
                case 1:
                    solicitacoes[posicao].AlterarStatus(solicitacoes, posicao);
                    historico = new Historico("A solicitação '", solicitacoes[posicao].Titulo, "' teve seu status alterado na data ", DateTime.Now);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case 2:
                    solicitacoes[posicao].AdicionarObservacao(solicitacoes, posicao);
                    historico = new Historico("Observação adicionada à solicitação '", solicitacoes[posicao].Titulo, "' na data ", DateTime.Now);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case 3:
                    historico = new Historico("A solicitação '", solicitacoes[posicao].Titulo, "' Foi removida na data ", DateTime.Now);
                    solicitacoes[posicao].RemoverSolicitacao(solicitacoes, posicao);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case 4:
                    solicitacoes[posicao].TransferirSolicitacao(solicitacoesDoZelador, solicitacoes, posicao);
                    historico = new Historico("Solicitação '", solicitacoes[posicao].Titulo, "' transferida na data ", DateTime.Now);
                    historico.AdicionarAoHistorico(historico);
                    break;
                case 5:
                    Historico.VisualizarHistoricoDeAcoes();
                    break;
                case 6:
                    Console.WriteLine("Saindo...");
                    break;
            }
        }
        private static void SubmenuZelador(List<Solicitacoes> solicitacoes)
        {
            Solicitacoes.VisualizarSolicitacoesPendentes(solicitacoes);

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

            int opt = int.Parse(Console.ReadLine() + "\n");

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

        #endregion
    }
}
