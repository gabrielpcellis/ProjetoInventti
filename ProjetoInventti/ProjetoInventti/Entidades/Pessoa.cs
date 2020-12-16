using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Pessoa {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public double Salario { get; set; }
        public DateTime DataContratacao { get; set; }
        public Carro Carro { get; set; }
        public Predio Predio { get; set; }

        //Construtor Administrador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, string telefone, double salario, Carro carro)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            Carro = carro;
        }
        
        //Construtor Sindico
        public Pessoa(string nomeCompleto, DateTime dataNascimento, string telefone, double salario, DateTime dataContratacao, Carro carro, Predio predio)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            DataContratacao = dataContratacao;
            Carro = carro;
        }
        //Construtor Zelador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, string telefone, double salario, DateTime dataContratacao, Carro carro)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            DataContratacao = dataContratacao;
            Carro = carro;
        }
        //Construdor Morador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, string telefone, Predio predio, Carro carro)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Predio = predio;
            Carro = carro;
        }

    }
}
