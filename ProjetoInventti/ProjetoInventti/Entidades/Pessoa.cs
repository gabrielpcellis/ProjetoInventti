using ProjetoInventti.Enums;
using System;

namespace ProjetoInventti.Entidades {
    public class Pessoa {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroApartamento { get; set; }
        public Carro Carro { get; set; }
        public string Telefone { get; set; }
        public TipoNivelAcesso TipoNivelAcesso { get; set; }
        public string UsuarioAcesso { get; set; }
        public string SenhaAcesso { get; set; }

        public Pessoa(string nomeCompleto, DateTime dataNascimento, string numeroApartamento, Carro carro, string telefone, TipoNivelAcesso tipoNivelAcesso, string user, string senha)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            NumeroApartamento = numeroApartamento;
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
