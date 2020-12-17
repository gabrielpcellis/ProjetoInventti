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

            //Faça enquanto houver usuário existente
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
                //Se não houver um usuário conectado, informará na tela
                if (usuarioConectado == null)
                {
                    Console.WriteLine("Usuário não encontrado");
                }
                //se houver, dará boas vindas mostrando apenas o nome do objeto 
                else
                {
                    Console.WriteLine("Olá usuário {0}, bem-vindo!", usuarioConectado.NomeCompleto);
                }
                //Verifica o tipo de acesso do objeto atual para liberar o acesso ideal
                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case Enums.TipoNivelAcesso.Administrador:
                        // menu
                        // Chamar método estático responsável pelas funções do administrador
                        Menu.Administrador();

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
            } while (!usuarioExistente);

            Console.ReadLine();
        }
    }
}
