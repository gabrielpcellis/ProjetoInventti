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
                new Predio("Alpinea Rosa", "Bloco B", 5, 20, new DateTime(2007, 08, 28)),
                new Predio("Fox", "Bloco C", 15, 50, new DateTime(2007, 08, 28))
            };

            return predio;
        }
        public static List<Pessoa> GerarCarga()
        {
            List<Carro> carros = new List<Carro> 
            {
                new Carro("FHC12", "Fiat Uno"),
                new Carro("ABC55", "Ferrari"),
                new Carro("VHSSD23", "Porsche")
            };
            List<Predio> predio = GerarPredio();

            List<Pessoa> lista = new List<Pessoa>
            {
                new Morador(0,"morador 1", DateTime.Now, carros[0], "telefone 1", "usuario1", "senha1", predio[0]),
                new Morador(1,"morador 2", DateTime.Now, carros[1], "telefone 2", "usuario2", "senha2", predio[1]),
                new Morador(2,"morador 3", DateTime.Now, carros[2], "telefone 3", "usuario3", "senha3", predio[2]),

                new Administrador(3,"administrador 1", DateTime.Now, carros[0], "telefone 1", "usuario4", "senha4"),
                new Administrador(4,"administrador 2", DateTime.Now, carros[1], "telefone 2", "usuario5", "senha5"),
                new Administrador(5,"administrador 3", DateTime.Now, carros[2], "telefone 3", "usuario6", "senha6"),
                new Morador(6,"morador 7", DateTime.Now, carros[0], "telefone 7", "morador 7", "morador 7", predio[1]),

                new Sindico(7,"síndico 1", DateTime.Now, predio[0], carros[0], "telefone 1", "usuario7", "senha7", 1000.00),
                new Sindico(8,"síndico 2", DateTime.Now, predio[1], carros[1], "telefone 2", "usuario8", "senha8", 1000.00),
                new Sindico(9,"síndico 3", DateTime.Now, predio[2], carros[2], "telefone 3", "usuario9", "senha9", 1000.00),
                new Sindico(10,"Gabriel", DateTime.Now, predio[2], carros[1], "47 992466629", "user", "user", 1000000.00),

                new Zelador(11,"zelador 1", DateTime.Now, carros[0], "telefone 1", "usuario10", "senha10", predio[0], 1000.00),
                new Zelador(12,"zelador 2", DateTime.Now, carros[1], "telefone 2", "usuario11", "senha11", predio[1], 1000.00),
                new Zelador(13,"zelador 3", DateTime.Now, carros[2], "telefone 3", "usuario12", "senha12", predio[2], 1000.00)
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
                new Solicitacoes (DateTime.Now, "Problema no encanamento", "Beltrano", "Cano perfurado", Enums.StatusSolicitacao.Recebido, "observação 2", predio[1]),
                new Solicitacoes (DateTime.Now, "Tem um pinguim na geladeira", "Gabriel", "Me ajuda", Enums.StatusSolicitacao.Recebido, "observação 3", predio[0]),
                new Solicitacoes (DateTime.Now, "Godzilla ou King Kong?", "Zé ruela", "Decidam pls", Enums.StatusSolicitacao.Recebido, "Sério mesmo", predio[2])
            };
            return solicitacoes;
        }
    }
}
