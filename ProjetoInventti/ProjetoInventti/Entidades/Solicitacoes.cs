using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Excecoes.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti
{
    public class Solicitacoes
    {
        public DateTime DataSolicitacao { get; set; }
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusSolicitacao StatusSolicitacao { get; set; }
        public string Observacao { get; set; }
        public Predio Predio { get; set; }

        public Solicitacoes(DateTime dataSolicitacao, string titulo, string nome, string descricaozinha, StatusSolicitacao tipoSolicitacao, string observacao, Predio predio)
        {
            DataSolicitacao = dataSolicitacao;
            Titulo = titulo;
            Nome = nome;
            Descricao = descricaozinha;
            StatusSolicitacao = tipoSolicitacao;
            Observacao = observacao;
            Predio = predio;
        }
        public void RemoverSolicitacao(List<Solicitacoes> solicitacao, int posicao)
        {
            solicitacao.RemoveAt(posicao);
            Console.WriteLine("A solicitação foi excluída. \n");
        }
        public void TransferirSolicitacao(List<Solicitacoes> solicitacaoZelador, List<Solicitacoes> solicitacaoSindico, int posicao)
        {
            solicitacaoZelador.Insert(0, solicitacaoSindico[posicao]);
            solicitacaoSindico.RemoveAt(posicao);
            Console.WriteLine("Solicitação transferida. \n");
        }
        public void AdicionarObservacao(List<Solicitacoes> solicitacoes, int posicao)
        {
            Console.Write("Adicionar observação: ");
            string observacao = Console.ReadLine();
            solicitacoes[posicao].Observacao = observacao;
            Console.Write("Nova observação: " + solicitacoes[posicao].Observacao + "\n");
        }
        public void AlterarStatus(List<Solicitacoes> solicitacoes, int posicao)
        {
            Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
            solicitacoes[posicao].StatusSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
        }
        public static void VisualizarHistoricoDeSolicitacoes(List<Solicitacoes> solicitacoes)
        {
            if (solicitacoes.Count <= 0)
            {
                throw new DomainExceptions("O histórico está vazio! \n");
            }
            Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
            Console.WriteLine();
            foreach (var item in solicitacoes)
            {
                Console.WriteLine(item + "\n");
            }
        }
        public static void VisualizarSolicitacoesPendentes(List<Solicitacoes> solicitacoes)
        {
            if (solicitacoes.Count <= 0)
            {
                throw new DomainExceptions("Não há solicitações pendentes no momento. \n");
            }

            Console.WriteLine("Solicitações pendentes: \n");
            for (int i = 0; i < solicitacoes.Count; i++)
            {
                Console.WriteLine(i + 1 + "- " + solicitacoes[i].Titulo);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DATA:" + DataSolicitacao.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("TÍTULO: " + Titulo);
            sb.AppendLine("DESCRIÇÃO: " + Descricao);
            sb.AppendLine("NOME: " + Nome);
            sb.AppendLine("STATUS: " + StatusSolicitacao.ToString());
            sb.AppendLine("OBSERVAÇÃO: " + Observacao);
            return sb.ToString();
        }
    }
}
