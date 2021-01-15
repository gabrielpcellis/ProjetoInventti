using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
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

        //Construtor solicitações
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
        //Excluir solicitação
        public void RemoverSolicitacao(List<Solicitacoes> solicitacao, int posicao)
        {
            solicitacao.RemoveAt(posicao);
            Console.WriteLine("A solicitação foi excluída.");
            Console.WriteLine();
        }
        //Transferir solicitação
        public void TransferirSolicitacao(List<Solicitacoes> solicitacaoZelador, List<Solicitacoes> solicitacaoSindico, int posicao)
        {
            solicitacaoZelador.Insert(0, solicitacaoSindico[posicao]);
            solicitacaoSindico.RemoveAt(posicao);
            Console.WriteLine("Solicitação transferida.");
            Console.WriteLine();
        }
        //Adicionar observação ao objeto
        public void AdicionarObservacao(List<Solicitacoes> solicitacoes, int posicao)
        {
            Console.Write("Adicionar observação: ");
            string observacao = Console.ReadLine();
            solicitacoes[posicao].Observacao = observacao;
            Console.Write("Nova observação: " + solicitacoes[posicao].Observacao);
            Console.WriteLine();
        }
        //Alterar status solicitação
        public void AlterarStatus(List<Solicitacoes> solicitacoes, int posicao)
        {
            Console.WriteLine("Digite o novo status da solicitação: 'Analise', 'Finalizado': ");
            solicitacoes[posicao].StatusSolicitacao = Enum.Parse<StatusSolicitacao>(Console.ReadLine());
        }
        //Formatação do objeto
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DATA:");
            sb.AppendLine(DataSolicitacao.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("TÍTULO: ");
            sb.AppendLine(Titulo);
            sb.AppendLine("DESCRIÇÃO: ");
            sb.AppendLine(Descricao);
            sb.Append("NOME: ");
            sb.AppendLine(Nome);
            sb.Append("STATUS: ");
            sb.AppendLine(StatusSolicitacao.ToString());
            sb.Append("OBSERVAÇÃO: ");
            sb.AppendLine(Observacao);
            return sb.ToString();
        }
    }
}
