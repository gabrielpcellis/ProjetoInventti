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

        //Construtor solicitações
        public Solicitacoes(DateTime dataSolicitacao, string titulo, string nome, string descricaozinha)
        {
            DataSolicitacao = dataSolicitacao;
            Titulo = titulo;
            Nome = nome;
            Descricao = descricaozinha;
            TipoSolicitacao = TipoSolicitacao.Recebido;
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
                + TipoSolicitacao;
        }
    }
}
