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
            return "Data da solicitação : "
                + DataSolicitacao + "\n"
                + "Título: "
                + Titulo + "\n"
                + "Descrição: "
                + Descricao + "\n"
                + "Nome: "
                + Nome + "\n"
                + "STATUS: " 
                + TipoSolicitacao;
        }
    }
}
