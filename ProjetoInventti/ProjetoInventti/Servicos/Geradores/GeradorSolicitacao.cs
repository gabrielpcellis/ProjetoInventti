using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Servicos.Geradores
{
    internal class GeradorSolicitacao
    {
        public Solicitacoes GerarNovaSolicitacao(Pessoa usuario)
        {
            Solicitacoes solicitacao = GerarSolicitacao((Morador)usuario);
            return solicitacao;
        }

        private Solicitacoes GerarSolicitacao(Morador usuario)
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

            Solicitacoes solicitacao = new Solicitacoes(data, titulo, usuario.NomeCompleto, descricao, StatusSolicitacao.Recebido, observacao, usuario.PredioDoMorador);
            Console.WriteLine();
            Console.WriteLine("Solicitação criada: \n");
            Console.WriteLine(solicitacao);
            Console.WriteLine();

            return solicitacao;
        }

    }
}
