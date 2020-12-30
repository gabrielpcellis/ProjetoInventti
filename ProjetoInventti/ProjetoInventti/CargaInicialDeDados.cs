﻿using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;

namespace ProjetoInventti
{
    public static class CargaInicialDeDados
    {
        public static List<Pessoa> GerarCarga()
        {
            //São apenas 2 objetos para todos os usuários (Possível alteração)
            Carro carro = new Carro("placa 1", "modelo 1");
            Predio predio = new Predio("nome predio", "bloco predio", 12);

            //Carga inicial de pessoas (incluindo todas as entidades)
            List<Pessoa> lista = new List<Pessoa>
            {
                new Morador("morador 1", DateTime.Now, carro, "telefone 1", "usuario 1", "senha 1", predio),
                new Morador("morador 2", DateTime.Now, carro, "telefone 2", "usuario 2", "senha 2", predio),
                new Morador("morador 3", DateTime.Now, carro, "telefone 3", "usuario 3", "senha 3", predio),

                new Administrador("administrador 1", DateTime.Now, carro, "telefone 1", "usuario 4", "senha 4"),
                new Administrador("administrador 2", DateTime.Now, carro, "telefone 2", "usuario 5", "senha 5"),
                new Administrador("administrador 3", DateTime.Now, carro, "telefone 3", "usuario 6", "senha 6"),

                new Sindico("síndico 1", DateTime.Now, predio, carro, "telefone 1", "usuario 7", "senha 7", 1000.00),
                new Sindico("síndico 2", DateTime.Now, predio, carro, "telefone 2", "usuario 8", "senha 8", 1000.00),
                new Sindico("síndico 3", DateTime.Now, predio, carro, "telefone 3", "usuario 9", "senha 9", 1000.00),

                new Zelador("zelador 1", DateTime.Now, carro, "telefone 1", "usuario 10", "senha 10", predio, 1000.00),
                new Zelador("zelador 2", DateTime.Now, carro, "telefone 2", "usuario 11", "senha 11", predio, 1000.00),
                new Zelador("zelador 3", DateTime.Now, carro, "telefone 3", "usuario 12", "senha 12", predio, 1000.00)
            };

            return lista;
        }
        //Carga inicial de contas a pagar
        public static List<Contas> GerarContasAPagar()
        {
            List<Contas> contasAPagar = new List<Contas>
            {
                new Contas (DateTime.Now, 100, 100, 100, 100, 100, 100, 100, 100, 100)
            };
            return contasAPagar;
        }

        //Carga inicial de contas a receber
        public static List<Contas> GerarContasAReceber()
        {
            List<Contas> contasAPagar = new List<Contas>
            {
                new Contas (DateTime.Now, 260, 150, 60, 500, 110)
            };
            return contasAPagar;
        }

        public static List<Solicitacoes> GerarSolicitacoes()
        {
            List<Solicitacoes> solicitacoes = new List<Solicitacoes>
            {
                new Solicitacoes (DateTime.Now, "Vizinho chato", "Fulano", "Vou descer a porrada nele", "observação 1"),
                new Solicitacoes (DateTime.Now, "Problema no encanamento", "Beltrano", "Cano perfurado", "observação 2")
            };
            return solicitacoes;
        }
    }
}
