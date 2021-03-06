﻿using System;
using System.Collections.Generic;

namespace ProjetoInventti.Entidades
{
    public class Predio
    {
        public string NomePredio { get; set; }
        public string BlocoPredio { get; set; }
        public int QuantidadeAndares { get; set; }
        public int QuantidadeApartamentos { get; set; }
        public DateTime DataConstrucao { get; set; }
        public int NumeroApartamento { get; set; }

        public Predio()
        {
        }

        public Predio(string nomePredio, string blocoPredio, int quantidadeAndares, int quantidadeApartamentos, DateTime dataConstrucao)
        {
            NomePredio = nomePredio;
            BlocoPredio = blocoPredio;
            QuantidadeAndares = quantidadeAndares;
            QuantidadeApartamentos = quantidadeApartamentos;
            DataConstrucao = dataConstrucao;
        }

        public Predio(string nomePredio, string blocoPredio, int quantidadeAndares, int quantidadeApartamentos, DateTime dataConstrucao, int numeroApartamento)
            : this(nomePredio, blocoPredio, quantidadeAndares, quantidadeApartamentos, dataConstrucao)
        {
            NumeroApartamento = numeroApartamento;
        }

        public void EscolherPredio(Predio predio, List<Predio> predios)
        {
            Console.WriteLine("Escolha um dos prédios disponíveis:");
            string nome;
            do
            {
                predios.ForEach(p => Console.WriteLine(p.NomePredio));
                Console.WriteLine();
                Console.Write("Prédio: ");
                nome = Console.ReadLine();
                foreach (var item in predios)
                {
                    if (item.NomePredio == nome)
                    {
                        predio = predios.Find(f => f.NomePredio == nome);
                    }
                }

                if (predio.NomePredio != nome)
                {
                    Console.WriteLine("Prédio não existente, tente novamente: \n");
                }
            } while (predio.NomePredio != nome);
        }

        public static void EscolherPredio(List<Predio> listaDePredios, List<Pessoa> listaDeUsuarios, Morador morador)
        {
            bool retornaVerdadeiroSeOApartamentoNaoExistir = false;
            do
            {
                Console.Write("Informe o número do apartamento: ");
                int numeroApartamento = int.Parse(Console.ReadLine());
                bool retornaVerdadeiroSeOApartamentoEscolhidoNaoPossuirDono = false;
                foreach (var item in listaDePredios)
                {
                    if (numeroApartamento > 0 && numeroApartamento < morador.Predio.QuantidadeApartamentos)
                    {
                        retornaVerdadeiroSeOApartamentoEscolhidoNaoPossuirDono = listaDeUsuarios.Exists(x => x.Predio.NumeroApartamento == numeroApartamento);
                        if (!retornaVerdadeiroSeOApartamentoEscolhidoNaoPossuirDono)
                        {
                            morador.Predio.NumeroApartamento = numeroApartamento;
                        }
                        else
                        {
                            Console.WriteLine("O apartamento escolhido já possui dono.");
                        }
                    }
                    else
                    {
                        retornaVerdadeiroSeOApartamentoNaoExistir = true;
                        Console.WriteLine("Este apartamento não existe.");
                        break;
                    }
                }
            } while (retornaVerdadeiroSeOApartamentoNaoExistir);
        }

    }
}