using ProjetoInventti.Excecoes.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti
{
    public class Historico
    {
        public string Texto { get; set; }
        public string Texto2 { get; set; }
        public string Solicitacao { get; set; }
        public DateTime Momento { get; set; }
        public static List<Historico> HistoricoDeAcoes { get; set; } = new List<Historico>();
        public Historico()
        {
        }
        public Historico(string texto, string solicitacao, string texto1, DateTime momento)
        {
            Texto = texto;
            Solicitacao = solicitacao;
            Momento = momento;
            Texto2 = texto1;
        }
        public void AdicionarAoHistorico(Historico historico)
        {
            Console.Clear();
            HistoricoDeAcoes.Insert(0, historico);
        }
        public static void VisualizarHistoricoDeAcoes()
        {
            Console.Clear();
            if (HistoricoDeAcoes.Count <= 0)
            {
                throw new DomainExceptions("Histórico de ações vazio!");
            }
            Console.WriteLine("Histórico de ações: ");
            foreach (var item in HistoricoDeAcoes)
            {
                Console.WriteLine(item);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Texto + " " + Solicitacao + " " + Texto2 + " " + Momento);
            return sb.ToString();
        }
    }
}
