using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoInventti.Servicos
{
    public class GeradorPessoa
    {
        public Administrador CadastrarAdministrador()
        {
            return new Administrador(GerarPessoa());
        }
        public Sindico CadastrarSindico(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            string nome = Console.ReadLine();
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Sindico(GerarPessoa(), predio, Salario());
        }
        public Zelador CadastrarZelador(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            string nome = Console.ReadLine();
            Console.Write("Prédio: ");
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Zelador(GerarPessoa(), predio, Salario());
        }
        public Morador CadastrarMorador(List<Predio> predios)
        {
            Console.WriteLine("Escolha o prédio pelo nome: ");
            predios.ForEach(p => Console.WriteLine(p.NomePredio));
            Console.Write("Prédio: ");
            string nome = Console.ReadLine();
            Predio predio = predios.Find(f => f.NomePredio == nome);
            return new Morador(GerarPessoa(), predio);
        }
        private Pessoa GerarPessoa()
        {
            Console.WriteLine();
            Console.WriteLine("Entre com os dados abaixo: ");
            Console.Write("Nome completo: ");
            string nomeCompleto = Console.ReadLine();
            Console.Write("Data de nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Dados do carro");
            Console.Write("Placa do carro: ");
            string placaCarro = (Console.ReadLine());
            Console.Write("Modelo do carro: ");
            string modeloCarro = Console.ReadLine();
            Carro carro = new Carro(placaCarro, modeloCarro);

            Console.Write("Informe o nivel de acesso (Administrador, Sindico, Zelador, Morador): ");
            TipoNivelAcesso nivel = Enum.Parse<TipoNivelAcesso>(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Entre com os dados para login");
            Console.Write("Escolha seu usuário de acesso:");
            string user = Console.ReadLine();
            Console.Write("Escolha sua senha de acesso: ");
            string senha = Console.ReadLine();

            return new Pessoa(nomeCompleto, dataNascimento, carro, telefone, nivel, user, senha);
        }
        private double Salario()
        {
            Console.WriteLine();
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine());
            return salario;
        }
        public static void RemoverMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            ExcluirMorador(moradores, usuariosSistema);
        }
        static private void ExcluirMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            Console.WriteLine("Escolha o morador que deseja excluir: ");
            Console.WriteLine();

            for (int i = 0; i < moradores.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + moradores[i]);
            }
            Console.WriteLine();
            Console.Write("Informe uma posição: ");
            int posicaoNaLista = int.Parse(Console.ReadLine());

            moradores.RemoveAt(posicaoNaLista - 1);
            usuariosSistema.RemoveAt(posicaoNaLista - 1);
            Console.WriteLine("Morador excluído.");
            Console.WriteLine();
        }
    }
}
