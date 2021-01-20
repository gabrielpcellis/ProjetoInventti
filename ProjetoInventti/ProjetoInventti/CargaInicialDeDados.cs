using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;

namespace ProjetoInventti
{
    public static class CargaInicialDeDados
    {
        public static List<Predio> GerarPredio()
        {
            List<Predio> predio = new List<Predio> 
            { 
                new Predio("Anemona", "Bloco A", 10, 40, new DateTime(2007, 08, 28)),
                new Predio("Alpinea Rosa", "Bloco A", 10, 40, new DateTime(2007, 08, 28)) 
            };

            return predio;
        }

        public static List<Pessoa> GerarCarga()
        {
            Carro carro = new Carro("placa 1", "modelo 1");
            var predio = GerarPredio();

            List<Pessoa> lista = new List<Pessoa>
            {
                new Morador("morador 1", DateTime.Now, carro, "telefone 1", "usuario 1", "senha 1", predio[0]),
                new Morador("morador 2", DateTime.Now, carro, "telefone 2", "usuario 2", "senha 2", predio[0]),
                new Morador("morador 3", DateTime.Now, carro, "telefone 3", "usuario 3", "senha 3", predio[0]),

                new Administrador("administrador 1", DateTime.Now, carro, "telefone 1", "usuario 4", "senha 4"),
                new Administrador("administrador 2", DateTime.Now, carro, "telefone 2", "usuario 5", "senha 5"),
                new Administrador("administrador 3", DateTime.Now, carro, "telefone 3", "usuario 6", "senha 6"),

                new Sindico("síndico 1", DateTime.Now, predio[0], carro, "telefone 1", "usuario 7", "senha 7", 1000.00),
                new Sindico("síndico 2", DateTime.Now, predio[0], carro, "telefone 2", "usuario 8", "senha 8", 1000.00),
                new Sindico("síndico 3", DateTime.Now, predio[0], carro, "telefone 3", "usuario 9", "senha 9", 1000.00),

                new Zelador("zelador 1", DateTime.Now, carro, "telefone 1", "usuario 10", "senha 10", predio[0], 1000.00),
                new Zelador("zelador 2", DateTime.Now, carro, "telefone 2", "usuario 11", "senha 11", predio[0], 1000.00),
                new Zelador("zelador 3", DateTime.Now, carro, "telefone 3", "usuario 12", "senha 12", predio[0], 1000.00)
            };

            return lista;
        }
        public static List<Contas> GerarContasAPagar()
        {
            List<Contas> contasAPagar = new List<Contas>
            {
                new Contas (DateTime.Now,Enums.TipoConta.Pagar, 2400.00m),
                new Contas (DateTime.Now, Enums.TipoConta.Receber, 10000.00m)

            };
            return contasAPagar;
        }
        public static List<Solicitacoes> GerarSolicitacoes()
        {
            var predio = GerarPredio();

            List<Solicitacoes> solicitacoes = new List<Solicitacoes>
            {
                new Solicitacoes (DateTime.Now, "Vizinho chato", "Fulano", "Vou descer a porrada nele", Enums.StatusSolicitacao.Recebido, "observação 1", predio[0]),
                new Solicitacoes (DateTime.Now, "Problema no encanamento", "Beltrano", "Cano perfurado", Enums.StatusSolicitacao.Recebido, "observação 2", predio[1])
            };
            return solicitacoes;
        }
    }
}
