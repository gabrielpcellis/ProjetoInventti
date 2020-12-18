using ProjetoInventti.Entidades;
using ProjetoInventti.Servicos;
using System;
using System.Collections.Generic;

namespace ProjetoInventti
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pessoa usuarioConectado = null;
            List<Pessoa> usuariosSistema = CargaInicialDeDados.GerarCarga();
            bool usuarioExistente = false;
            bool sair;

            do
            {

                //Faça enquanto houver usuário inexistente
                if (usuarioConectado == null)
                    ValidarUsuario(ref usuarioConectado, usuariosSistema, usuarioExistente);

                //se houver, dará boas vindas mostrando apenas o nome do objeto 
                Console.WriteLine("Usuário {0}", usuarioConectado.NomeCompleto);
                //Verifica o tipo de acesso do objeto atual para liberar o acesso ideal
                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case Enums.TipoNivelAcesso.Administrador:
                        // menu
                        // Chamar método estático responsável pelas funções do administrador
                        var menu = new Menu();
                        menu.Administrador(usuariosSistema);

                        break;
                    case Enums.TipoNivelAcesso.Sindico:
                        // menu
                        // Chamar método estático responsável pelas funções do sindico
                        break;
                    case Enums.TipoNivelAcesso.Zelador:
                        // menu
                        // Chamar método estático responsável pelas funções do zelador
                        break;
                    case Enums.TipoNivelAcesso.Morador:
                        // menu
                        // Chamar método estático responsável pelas funções do morador
                        break;
                    default:

                        break;
                }
                //Repetir enquanto o usuário não for encontrado

                Console.WriteLine("Deseja sair do Programa ? 1 - Sim 2 - Não");
                sair = Console.ReadLine() == "1" ? true : false;

            } while (!sair);
        }

        private static void ValidarUsuario(ref Pessoa usuarioConectado, List<Pessoa> usuariosSistema, bool usuarioExistente)
        {
            do
            {
                //Entrada de dados
                Console.Write("Informe seu usuário: ");
                var usuario = Console.ReadLine();
                Console.Write("Informe sua senha: ");
                var senha = Console.ReadLine();

                //Percorre a lista até o final à procura dos dados obtidos
                for (int i = 0; i < usuariosSistema.Count; i++)
                {
                    //verifica se o objeto atual da posição "i" tem usuário e senha 
                    //Caso tenha, adicionará o objeto da posição atual à variável "usuarioConectado" e retornará "true" para "usuarioExistente"
                    //depois encerrará a condicional
                    if (usuariosSistema[i].VerificarDadosDeAcesso(usuario, senha))
                    {
                        usuarioConectado = usuariosSistema[i];
                        usuarioExistente = true;
                        break;
                    }
                }

                if (usuarioConectado == null)
                    Console.WriteLine("Usuário não encontrado");
                Console.WriteLine();

            } while (!usuarioExistente);
        }
    }
}
