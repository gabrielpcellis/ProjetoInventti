using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Excecoes.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoInventti.Servicos
{
    public class GeradorPessoa
    {
        public Administrador CadastrarAdministrador(List<Pessoa> usuarios)
        {
            TipoNivelAcesso nivel = TipoNivelAcesso.Administrador;
            return new Administrador(GerarPessoa(nivel, usuarios));
        }
        public Sindico CadastrarSindico(List<Predio> predios, List<Pessoa> usuarios)
        {
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            TipoNivelAcesso nivel = TipoNivelAcesso.Sindico;
            return new Sindico(GerarPessoa(nivel, usuarios), predio, Salario());
        }
        public Zelador CadastrarZelador(List<Predio> predios, List<Pessoa> usuarios)
        {
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            TipoNivelAcesso nivel = TipoNivelAcesso.Zelador;
            return new Zelador(GerarPessoa(nivel, usuarios), predio, Salario());
        }
        public Morador CadastrarMorador(List<Predio> predios, List<Pessoa> usuarios)
        {
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            TipoNivelAcesso nivel = TipoNivelAcesso.Morador;
            return new Morador(GerarPessoa(nivel, usuarios), predio);
        }
        private Pessoa GerarPessoa(TipoNivelAcesso nivel, List<Pessoa> usuariosDoSistema)
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

            string[] usuarioSenha = Pessoa.CadastrarUsuarioESenha(usuariosDoSistema);
            return new Pessoa(nomeCompleto, dataNascimento, carro, telefone, nivel, usuarioSenha[0], usuarioSenha[1]);
        }
        private double Salario()
        {
            Console.WriteLine();
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            return salario;
        }
        public static void RemoverMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            ExcluirMorador(moradores, usuariosSistema);
        }
        static private void ExcluirMorador(List<Pessoa> moradores, List<Pessoa> usuariosSistema)
        {
            Console.WriteLine("Escolha o morador que deseja excluir: \n");

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
        public static void VisualizarListaDeMoradores(List<Pessoa> usuariosSistema)
        {
            Console.WriteLine("Lista de moradores: \n");
            Console.WriteLine("Nome completo,  Data de nascimento,  Modelo,  Placa,    Telefone,  Usuário,  Senha");
            List<Pessoa> moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
            foreach (var item in moradores)
            {
                Console.WriteLine(item + "\n");
            }
        }

    }
}
