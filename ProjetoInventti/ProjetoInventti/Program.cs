using ProjetoInventti.Entidades;
using ProjetoInventti.Enums;
using ProjetoInventti.Menus;
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
            List<Predio> predios = CargaInicialDeDados.GerarPredio();
            List<Contas> contas = CargaInicialDeDados.GerarContasAPagar();
            List<Solicitacoes> solicitacoesSindico = CargaInicialDeDados.GerarSolicitacoes();
            List<Solicitacoes> solicitacoesZelador = CargaInicialDeDados.GerarSolicitacoes();
            List<Solicitacoes> solicitacoesMorador = new List<Solicitacoes>();
            List<Solicitacoes> historico = solicitacoesSindico;
            List<Solicitacoes> solicitacoesEmAnalise = new List<Solicitacoes>();

            bool usuarioExistente = false;
            bool sair = false;

            while (sair == false)
            {
                if (usuarioConectado == null)
                {
                    Menu.ValidarUsuario(ref usuarioConectado, usuariosSistema, usuarioExistente);
                }
                Console.WriteLine("Você está logado como: '{0}', seja bem vindo! \n", usuarioConectado.NomeCompleto);
                Menu menu = new Menu();

                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case TipoNivelAcesso.Administrador:
                        menu.MenuAdministrador(usuariosSistema, contas, predios, ref sair, ref usuarioConectado);
                        break;
                    case TipoNivelAcesso.Sindico:
                        menu.MenuSindico(usuariosSistema, usuarioConectado, ref solicitacoesSindico, predios, solicitacoesZelador, ref sair,
                            ref usuarioConectado, historico, solicitacoesEmAnalise);
                        break;
                    case TipoNivelAcesso.Zelador:
                        menu.MenuZelador(ref usuarioConectado, solicitacoesZelador, ref sair);
                        break;
                    case TipoNivelAcesso.Morador:
                        menu.MenuMorador(solicitacoesMorador, ref usuarioConectado, solicitacoesSindico, ref sair);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
