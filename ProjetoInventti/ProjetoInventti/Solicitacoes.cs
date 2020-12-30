using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti
{
    public class Solicitacoes
    {
        public DateTime DataSolicitacao { get; set; }
        public string Titulo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoSolicitacao TipoSolicitacao { get; set; }
        public string Observacao { get; set; }

        //Construtor solicitações
        public Solicitacoes(DateTime dataSolicitacao, string titulo, string nome, string descricaozinha, string observacao)
        {
            DataSolicitacao = dataSolicitacao;
            Titulo = titulo;
            Nome = nome;
            Descricao = descricaozinha;
            TipoSolicitacao = TipoSolicitacao.Zelador;
            Observacao = observacao;
        }

        //Formatação do objeto
        public override string ToString()
        {
            return "DATA: "
                + DataSolicitacao + "\n"
                + "TÍTULO: "
                + Titulo + "\n"
                + "DESCRIÇÃO: "
                + Descricao + "\n"
                + "NOME: "
                + Nome + "\n"
                + "STATUS: "
                + TipoSolicitacao + "\n"
                + "OBSERVAÇÃO: "
                + Observacao;
        }
    }
}
