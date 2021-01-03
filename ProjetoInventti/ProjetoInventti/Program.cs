﻿using ProjetoInventti.Entidades;
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
            List<Contas> contasAPagar = CargaInicialDeDados.GerarContasAPagar();
            List<Contas> contasAReceber = CargaInicialDeDados.GerarContasAReceber();
            List<Solicitacoes> solicitacoesSindico = CargaInicialDeDados.GerarSolicitacoes();
            List<Solicitacoes> solicitacoesZelador = new List<Solicitacoes>();
            List<Solicitacoes> solicitacoesMorador = new List<Solicitacoes>();

            bool usuarioExistente = false;
            bool sair;

            do
            {
                //Faça enquanto houver usuário inexistente
                if (usuarioConectado == null)
                {
                    ValidarUsuario(ref usuarioConectado, usuariosSistema, usuarioExistente);
                }
                //se houver, dará boas vindas mostrando apenas o nome do objeto 
                Console.WriteLine("Olá '{0}', seja bem vindo!", usuarioConectado.NomeCompleto);
                Console.WriteLine();
                var menu = new Menu();

                //Verifica o tipo de acesso do objeto atual para liberar o acesso ideal
                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case Enums.TipoNivelAcesso.Administrador:
                        // Chamar método responsável pelas funções do administrador
                        menu.MenuAdministrador(usuariosSistema, contasAPagar, contasAReceber);
                        break;
                    case Enums.TipoNivelAcesso.Sindico:
                        // Chamar método responsável pelas funções do sindico
                        menu.MenuSindico(usuariosSistema, usuarioConectado, solicitacoesSindico, solicitacoesZelador);
                        break;
                    case Enums.TipoNivelAcesso.Zelador:
                        // Chamar método responsável pelas funções do zelador
                        menu.MenuZelador(usuarioConectado, solicitacoesZelador);
                        break;
                    case Enums.TipoNivelAcesso.Morador:
                        // Chamar método responsável pelas funções do morador
                        menu.MenuMorador(solicitacoesMorador, usuarioConectado, solicitacoesSindico);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Deseja sair do Programa ? 1 - Sim, 2 - Não");
                sair = Console.ReadLine() == "1" ? true : false;

                //Trocar usuário ao desconectar
                if (sair != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Trocar de usuário: 1- Sim, 2- Não");
                    int trocar = int.Parse(Console.ReadLine());
                    if (trocar == 1)
                    {
                        usuarioConectado = null;
                    }
                }

            } while (!sair);
        }

        //Método estático para entrar e validar se o usuário está conectado ou não
        private static void ValidarUsuario(ref Pessoa usuarioConectado, List<Pessoa> usuariosSistema, bool usuarioExistente)
        {
            do
            {
                Console.WriteLine("                                         BEM VINDO, MEU COMPATRIÓTA!!!!!!!!!!!                           ");
                Console.WriteLine();
                Console.WriteLine("Para fazer login, informe os dados abaixo, por gentileza: ");
                Console.WriteLine();
                //Entrada de dados
                Console.Write("Informe seu usuário: ");
                var usuario = Console.ReadLine();
                Console.Write("Informe sua senha: ");
                var senha = Console.ReadLine();

                //Percorre a lista até o final à procura dos dados obtidos
                //verifica se o objeto atual da posição "i" tem usuário e senha 
                for (int i = 0; i < usuariosSistema.Count; i++)
                {
                    //Caso tenha, adicionará o objeto da posição atual à variável "usuarioConectado" e retornará "true" para "usuarioExistente"
                    //depois encerrará a condicional
                    if (usuariosSistema[i].VerificarDadosDeAcesso(usuario, senha))
                    {
                        usuarioConectado = usuariosSistema[i];
                        usuarioExistente = true;
                        break;
                    }
                }
                //Se usuarioConectado for nulo, mostrará a mensagem
                if (usuarioConectado == null)
                {
                    Console.WriteLine("Usuário não encontrado");
                }
                Console.WriteLine();

            } while (!usuarioExistente);
        }

    }
}
