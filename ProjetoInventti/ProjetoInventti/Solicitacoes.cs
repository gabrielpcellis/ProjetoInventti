using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti
{
    public class Solicitacoes
    {
        public DateTime DataSolicitacao { get; set; }
        public string Titulo { get; set; }
        public Pessoa Nome{ get; set; }
        public string Descricao { get; set; }

        public Solicitacoes(DateTime dataSolicitacao, string titulo, Pessoa nome, string descricaozinha)
        {
            DataSolicitacao = dataSolicitacao;
            Titulo = titulo;
            Nome = nome;
            Descricao = descricaozinha;
        }

        //Formatação do objeto
        public override string ToString()
        {
            return "Data da solicitação : "
                + DataSolicitacao + "\n"
                + "Título: "
                + Titulo + "\n"
                + "Descrição: "
                + Descricao
        }
    }
}
