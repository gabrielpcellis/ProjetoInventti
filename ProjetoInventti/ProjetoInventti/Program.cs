using ProjetoInventti.Entidades;
using ProjetoInventti.Menus;
using System;
using System.Collections.Generic;
using ProjetoInventti.Enums;

namespace ProjetoInventti
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pessoa usuarioConectado = null;
            List<Pessoa> usuariosSistema = CargaInicialDeDados.GerarCarga();
            List<Predio> predios = CargaInicialDeDados.GerarPredio();
            List<Contas> contas = CargaInicialDeDados.GerarContasAPagar();
            List<Solicitacoes> solicitacoesSindico = CargaInicialDeDados.GerarSolicitacoes();
            List<Solicitacoes> solicitacoesZelador = CargaInicialDeDados.GerarSolicitacoes();
            List<Solicitacoes> solicitacoesMorador = new List<Solicitacoes>();
            List<Historico> historicoDeAcoes = new List<Historico>();

            bool usuarioExistente = false;
            bool sair = false;

            while (sair == false)
            {
                if (usuarioConectado == null)
                {
                    ValidarUsuario(ref usuarioConectado, usuariosSistema, usuarioExistente);
                }
                Console.WriteLine("Olá '{0}', seja bem vindo! \n", usuarioConectado.NomeCompleto);
                var menu = new Menu();

                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case TipoNivelAcesso.Administrador:
                        menu.MenuAdministrador(usuariosSistema, contas, predios, ref sair, ref usuarioConectado);
                        break;
                    case TipoNivelAcesso.Sindico:
                        menu.MenuSindico(usuariosSistema, usuarioConectado, ref solicitacoesSindico, predios, solicitacoesZelador, historicoDeAcoes, ref sair, ref usuarioConectado);
                        break;
                    case TipoNivelAcesso.Zelador:
                        menu.MenuZelador(usuarioConectado, solicitacoesZelador, ref sair, ref usuarioConectado);
                        break;
                    case TipoNivelAcesso.Morador:
                        menu.MenuMorador(solicitacoesMorador,ref usuarioConectado, solicitacoesSindico, ref sair);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ValidarUsuario(ref Pessoa usuarioConectado, List<Pessoa> usuariosSistema, bool usuarioExistente)
        {
            do
            {
                Console.WriteLine("                                      BEM VINDO, MEU COMPATRIÓTAAAAAAAAAAAAAAA!!!!!!!!!!!                           \n");
                Console.WriteLine("Para fazer login, informe os dados abaixo, por gentileza: \n");
                Console.Write("Informe seu usuário: ");
                var usuario = Console.ReadLine();
                Console.Write("Informe sua senha: ");
                var senha = Console.ReadLine();

                for (int i = 0; i < usuariosSistema.Count; i++)
                {
                    if (usuariosSistema[i].VerificarDadosDeAcesso(usuario, senha))
                    {
                        usuarioConectado = usuariosSistema[i];
                        usuarioExistente = true;
                        break;
                    }
                }
                if (usuarioConectado == null)
                {
                    Console.WriteLine("Usuário não encontrado \n");
                }

            } while (!usuarioExistente);
        }

    }
}
