using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Excecoes.DomainExceptions;
using ProjetoInventti.Servicos.Geradores;
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
        public void AlterarStatus(List<Solicitacoes> solicitacoesPendentes, int posicao)
        {
            string status;
            do
            {
                Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
                status = Console.ReadLine();
                if (status != "Analise" && status != "Finalizado")
                {
                    Console.WriteLine("Informe um status válido e tente novamente. \n");
                }
                else
                {
                    solicitacoesPendentes[posicao].StatusSolicitacao = Enum.Parse<StatusSolicitacao>(status);
                    solicitacoesPendentes.RemoveAt(posicao);
                }
            } while (status != "Analise" && status != "Finalizado");
        }
        public static void VisualizarHistoricoDeSolicitacoes(List<Solicitacoes> solicitacoes)
        {
            if (solicitacoes.Count <= 0)
            {
                throw new DomainExceptions("O histórico está vazio! \n");
            }
            Console.WriteLine("HISTÓRICO DE SOLICITAÇÕES:");
            Console.WriteLine();
            solicitacoes.ForEach(p => Console.WriteLine(p));
        }
        public static void VisualizarSolicitacoesPendentes(List<Solicitacoes> solicitacoes)
        {
            if (solicitacoes.Count <= 0)
            {
                throw new DomainExceptions("Não há solicitações pendentes no momento. \n");
            }
            List<Solicitacoes> solicitacoesPendentesApenasRecebidos = new List<Solicitacoes>();
            solicitacoesPendentesApenasRecebidos = solicitacoes.FindAll(x => x.StatusSolicitacao == StatusSolicitacao.Recebido);
            Console.WriteLine("Solicitações pendentes: \n");
            //solicitacoes.ForEach(p => Console.WriteLine(p.Titulo));
            for (int i = 0; i < solicitacoesPendentesApenasRecebidos.Count; i++)
            {
                Console.WriteLine(i + 1 + "- " + solicitacoesPendentesApenasRecebidos[i].Titulo);
            }
        }
        public static void AbrirNovaSolicitacao(List<Solicitacoes> solicitacoesSindico, List<Solicitacoes> solicitacoesMorador, Pessoa usuarioAtual)
        {
            GeradorSolicitacao gerador = new GeradorSolicitacao();
            solicitacoesSindico.Insert(0, gerador.GerarNovaSolicitacao(usuarioAtual));
            solicitacoesMorador.Insert(0, solicitacoesSindico[0]);
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
