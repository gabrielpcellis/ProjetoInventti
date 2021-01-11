﻿using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Menus
{
    class Submenu
    {
        //Chamar submenu do síndico
        public static void SubMenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
        {
            SubmenuSindico(solicitacoes, solicitacoesDoZelador);
        }
        //Chamar submenu do zelador
        public static void SubMenuZelador(List<Solicitacoes> solicitacoes)
        {
            SubmenuZelador(solicitacoes);
        }

        #region Submenus
        //Submenu do síndico para opção 5 do menu (Solicitações pendentes)
        private static void SubmenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
        {
            //Percorrerá a lista toda mostrando apenas o título dos objetos
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
                " 5) Cancelar:");

            int opt = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
                    solicitacoes[posicao].TipoSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Adicionar observação: ");
                    string observacao = Console.ReadLine();
                    solicitacoes[posicao].Observacao = observacao;
                    Console.Write("Nova observação: " + solicitacoes[posicao].Observacao);
                    Console.WriteLine();
                    break;
                case 3:
                    solicitacoes.RemoveAt(posicao);
                    Console.WriteLine("A solicitação foi excluída.");
                    Console.WriteLine();
                    break;
                case 4:
                    solicitacoesDoZelador.Insert(0, solicitacoes[posicao]);
                    solicitacoes.RemoveAt(posicao);
                    Console.WriteLine("Solicitação transferida.");
                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Cancelando...");
                    Console.WriteLine();
                    break;
            }
        }
        //Submenu do zelador
        private static void SubmenuZelador(List<Solicitacoes> solicitacoes)
        {
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
                    Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
                    solicitacoes[posicao].TipoSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
                    Console.WriteLine("Status atualizado: " + solicitacoes[posicao].TipoSolicitacao);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Write("Adicionar observação: ");
                    string observacao = Console.ReadLine();
                    solicitacoes[posicao].Observacao = observacao;
                    Console.WriteLine("Nova observação: " + solicitacoes[posicao].Observacao);
                    Console.WriteLine();
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
