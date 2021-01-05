using System;
using System.Collections.Generic;
using System.Text;
using ProjetoInventti.Enums;
using ProjetoInventti.Menus;

namespace ProjetoInventti.Menus
{
    static class Submenu
    {
        //Submenu do síndico
        public static void SubmenuSindico(List<Solicitacoes> solicitacoes, List<Solicitacoes> solicitacoesDoZelador)
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
                            Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
                            solicitacoes[i].TipoSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
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
    }
}
