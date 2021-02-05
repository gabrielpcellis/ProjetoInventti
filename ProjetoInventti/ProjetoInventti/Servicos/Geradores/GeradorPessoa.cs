using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoInventti.Servicos
{
    public class GeradorPessoa
    {
        public Administrador CadastrarAdministrador(List<Pessoa> usuarios, List<Predio> predios)
        {
            Console.WriteLine("Bem vindo ao cadastro de administrador: \n");
            TipoNivelAcesso nivel = TipoNivelAcesso.Administrador;
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            Administrador novoAdm = new Administrador(GerarPessoa(nivel, usuarios), predio);
            Console.Clear();
            Console.WriteLine("Novo usuário cadastrado: \n");
            Console.WriteLine("Nome completo, data de nascimento, placa carro, modelo carro, telefone, usuário, senha: \n");
            Console.WriteLine(novoAdm);
            return novoAdm;
        }

        public Sindico CadastrarSindico(List<Predio> predios, List<Pessoa> usuarios)
        {
            Console.WriteLine("Bem vindo ao cadastro de síndico: \n");
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            TipoNivelAcesso nivel = TipoNivelAcesso.Sindico;
            Sindico novoSindico = new Sindico(GerarPessoa(nivel, usuarios), predio, Salario());
            Console.Clear();
            Console.WriteLine("Novo usuário cadastrado: \n");
            Console.WriteLine("Nome completo, data de nascimento, placa carro, modelo carro, telefone, usuário, senha: \n");
            Console.WriteLine(novoSindico);
            return novoSindico;
        }

        public Zelador CadastrarZelador(List<Predio> predios, List<Pessoa> usuarios)
        {
            Console.WriteLine("Bem vindo ao cadastro de zelador: \n");
            Predio predio = new Predio();
            predio.EscolherPredio(predio, predios);
            TipoNivelAcesso nivel = TipoNivelAcesso.Zelador;
            Zelador novoZelador = new Zelador(GerarPessoa(nivel, usuarios), predio, Salario());
            Console.Clear();
            Console.WriteLine("Novo usuário cadastrado: \n");
            Console.WriteLine("Nome completo, data de nascimento, placa carro, modelo carro, telefone, usuário, senha: \n");
            Console.WriteLine(novoZelador);
            return novoZelador;
        }

        public Morador CadastrarMorador(List<Predio> predios, List<Pessoa> usuarios, Pessoa usuarioAtual)
        {
            Console.WriteLine("Bem vindo ao cadastro de morador: \n");
            Predio predio = new Predio();
            foreach (var item in predios)
            {
                if (item.NomePredio == usuarioAtual.Predio.NomePredio)
                {
                    predio = usuarioAtual.Predio;
                }
            }
            TipoNivelAcesso nivel = TipoNivelAcesso.Morador;
            Morador novoMorador = new Morador(GerarPessoa(nivel, usuarios), predio);
            Predio.EscolherPredio(predios, usuarios,  novoMorador);
            Console.Clear();
            Console.WriteLine("Novo usuário cadastrado: \n");
            Console.WriteLine("Nome completo, data de nascimento, placa carro, modelo carro, telefone, usuário, senha: \n");
            Console.WriteLine(novoMorador);
            return novoMorador;
        }

        private Pessoa GerarPessoa(TipoNivelAcesso nivel, List<Pessoa> usuariosDoSistema)
        {
            Console.WriteLine();
            Console.WriteLine("Agora entre com os dados abaixo: ");
            Console.Write("Nome completo: ");
            string nomeCompleto = Console.ReadLine();
            Console.Write("Data de nascimento (dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.WriteLine();
            Carro carro = new Carro();
            Console.WriteLine("Possui carro (S ou N)?");
            char s = char.Parse(Console.ReadLine().ToUpper());
            if (s == 'S')
            {
                Console.WriteLine("Dados do carro");
                Console.Write("Placa do carro (ex: DWV19F): ");
                string placaCarro = (Console.ReadLine());
                Console.Write("Modelo do carro (ex: Fiat): ");
                string modeloCarro = Console.ReadLine();
                carro = new Carro(placaCarro, modeloCarro);
            }
            else
            {
                carro = new Carro("Não possui", "Não possui");
            }
            string[] usuarioSenha = Pessoa.CadastrarUsuarioESenha(usuariosDoSistema);
            int id = Pessoa.Identificador(usuariosDoSistema);
            return new Pessoa(id, nomeCompleto, dataNascimento, carro, telefone, nivel, usuarioSenha[0], usuarioSenha[1]);
        }

        private double Salario()
        {
            Console.WriteLine();
            Console.Write("Salário: ");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            return salario;
        }

        public static void RemoverMorador(List<Pessoa> usuariosSistema)
        {
            ExcluirMorador(usuariosSistema);
        }

        static private void ExcluirMorador(List<Pessoa> usuariosSistema)
        {
            Console.WriteLine("Escolha o morador que desejas excluir: \n");

            for (int i = 0; i < usuariosSistema.Count; i++)
            {
                if (usuariosSistema[i].TipoNivelAcesso == TipoNivelAcesso.Morador)
                {
                    Console.WriteLine("ID: {0} - " + usuariosSistema[i], usuariosSistema[i].Id);
                }
            }

            Console.WriteLine();
            Console.Write("Informe o ID do morador que desejas excluir: ");
            int identificador = int.Parse(Console.ReadLine());
            Console.WriteLine("Você selecionou o ID: " + identificador);

            Console.Write("Tem certeza que deseja excluir este morador (S/N)? ");
            char escolha = char.Parse(Console.ReadLine().ToUpper());

            if (escolha == 'S')
            {
                Pessoa obj = new Pessoa();
                foreach (var item in usuariosSistema)
                {
                    if (item.Id == identificador && item.TipoNivelAcesso == TipoNivelAcesso.Morador)
                    {
                        obj = item;
                        usuariosSistema.Remove(item);
                        Console.WriteLine("Impossível excluir.");
                        break;
                    }
                }

                if (obj.Id != identificador || obj.TipoNivelAcesso != TipoNivelAcesso.Morador)
                {
                    Console.WriteLine("Exclusão não permitida.");
                }
            }
            else
            {
                Console.WriteLine("Exclusão cancelada. Você voltou para o menu! \n");
            }
        }

        public static void VisualizarListaDeMoradores(List<Pessoa> usuariosSistema)
        {
            Console.Clear();
            if (usuariosSistema.Count > 0)
            {
                Console.WriteLine("Lista de moradores: \n");
                List<Pessoa> moradores = usuariosSistema.FindAll(x => x.TipoNivelAcesso == TipoNivelAcesso.Morador);
                foreach (var item in moradores)
                {
                    Console.WriteLine(item + "\n");
                }
            }
            else
            {
                Console.WriteLine("Lista vazia!");
            }
        }

    }
}
