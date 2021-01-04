using ProjetoInventti.Entidades;
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
        public StatusSolicitacao TipoSolicitacao { get; set; }
        public string Observacao { get; set; }
        public Predio Predio { get; set; }


        //Construtor solicitações
        public Solicitacoes(DateTime dataSolicitacao, string titulo, string nome, string descricaozinha, StatusSolicitacao tipoSolicitacao, string observacao, Predio predio)
        {
            DataSolicitacao = dataSolicitacao;
            Titulo = titulo;
            Nome = nome;
            Descricao = descricaozinha;
            TipoSolicitacao = tipoSolicitacao;
            Observacao = observacao;
            Predio = predio;
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
