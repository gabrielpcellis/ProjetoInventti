using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Pessoa {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public int NumeroApartamento { get; set; }
        public string PlacaCarro { get; set; }
        public double Salario { get; set; }
        public DateTime DataContratacao { get; set; }
        public Carro Carro { get; set; }
        public Predio Predio { get; set; }

        //Construtor Administrador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, int telefone, double salario, Carro carro)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            Carro = carro;
        }
        
        //Construtor Sindico
        public Pessoa(string nomeCompleto, DateTime dataNascimento, int telefone, double salario, DateTime dataContratacao, Carro carro, Predio predio)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            DataContratacao = dataContratacao;
            Carro = carro;
        }
        //Construtor Zelador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, int telefone, double salario, DateTime dataContratacao, Carro carro)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Salario = salario;
            DataContratacao = dataContratacao;
            Carro = carro;
        }
        //Construdor Morador
        public Pessoa(string nomeCompleto, DateTime dataNascimento, int telefone, Predio predio, Carro carro) 
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Predio = predio;
            Carro = carro;
        }
        //Construtor da lista ListaAdministrador
        public Pessoa(Administrador ListaAdministrador)
        {

        }
    }
}
