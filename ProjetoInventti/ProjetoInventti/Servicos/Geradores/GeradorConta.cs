using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjetoInventti.Servicos.Geradores
{
    internal class GeradorConta
    {

        //Método para gerar nova conta a pagar
        public List<Contas> GerarConta()
        {
            List<Contas> conta = new List<Contas>();

            Console.Write("Digite a quantidade de novas contas a pagar: ");
            int quantidade = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine("Contas a pagar: ");
                Console.Write("Data da conta: ");
                DateTime dataConta = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Tipo de Conta: Pagar ou Receber");
                TipoConta tipo = Enum.Parse<TipoConta>(Console.ReadLine());
                Console.WriteLine("Valor da Conta: ");
                decimal valor = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                conta.Add(new Contas(dataConta, tipo, valor));

            }
            return conta;
        }

    }
}
