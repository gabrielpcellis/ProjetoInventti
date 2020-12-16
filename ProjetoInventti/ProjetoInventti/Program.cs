using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;

namespace ProjetoInventti {
    public class Program {
        static void Main(string[] args)
        {
            Pessoa usuarioConectado = null;
            List<Pessoa> usuariosSistema = CargaInicialDeDados.GerarCarga();
            bool usuarioExistente = false;

            do
            {

            

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
                Console.WriteLine("Usuário não encontrado");
            }
            else
            {
                Console.WriteLine(string.Format("Olá morador '{0}', bem-vindo!",usuarioConectado.NomeCompleto));
            }

                switch (usuarioConectado.TipoNivelAcesso)
                {
                    case Enums.TipoNivelAcesso.Administrador:
                        break;
                    case Enums.TipoNivelAcesso.Sindico:
                        break;
                    case Enums.TipoNivelAcesso.Zelador:
                        break;
                    case Enums.TipoNivelAcesso.Morador:
                        break;
                    default:
                        break;
                }


            } while (!usuarioExistente);

            Console.ReadLine();
        }
    }
}
