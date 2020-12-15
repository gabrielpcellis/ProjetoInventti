using ProjetoInventti.Entidades;
using ProjetoInventti.Serviços;
using System;
using System.Collections.Generic;

namespace ProjetoInventti {
    public class Program {
        static void Main(string[] args)
        {
            //Criar um switch case para definir que tipo de pessoa cadastrar
            //Criar um for para definir a quantidade de pessoas a serem cadastradas
            //Criar e instanciar uma lista para cada tipo de pessoa a ser cadastrada

            List<Administrador> administradores = new List<Administrador>();

            administradores.Add(Cadastro.CadastrarAdministrador());
        }
    }
}
