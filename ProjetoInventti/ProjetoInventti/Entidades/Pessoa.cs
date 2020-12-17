using ProjetoInventti.Enums;
using ProjetoInventti.Serviços;
using System;

namespace ProjetoInventti.Entidades {
    public class Pessoa {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public Carro Carro { get; set; }
        public string Telefone { get; set; }
        public TipoNivelAcesso TipoNivelAcesso { get; set; }
        public string UsuarioAcesso { get; set; }
        public string SenhaAcesso { get; set; }

        public Pessoa(string nomeCompleto, DateTime dataNascimento, Carro carro, string telefone, TipoNivelAcesso tipoNivelAcesso, string user, string senha)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Carro = carro;
            Telefone = telefone;
            TipoNivelAcesso = tipoNivelAcesso;
            UsuarioAcesso = user;
            SenhaAcesso = senha;
        }

        public bool VerificarDadosDeAcesso(string usuario, string senha)
        {
            //bool informacoesConferem = false;
            //if (usuario == UsuarioAcesso && senha == SenhaAcesso)
            //    informacoesConferem = true;
            //return informacoesConferem;

            return usuario == UsuarioAcesso && senha == SenhaAcesso;
        }
    }
}
