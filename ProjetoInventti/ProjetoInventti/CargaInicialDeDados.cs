using ProjetoInventti.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti {
    public static class CargaInicialDeDados {

        public static List<Pessoa> GerarCarga()
        {
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Morador("Usuario 1", DateTime.Now, "1", null, string.Empty, "1", "1", null));
            lista.Add(new Morador("Usuario 2", DateTime.Now, "2", null, string.Empty, "2", "2", null));
            lista.Add(new Morador("Usuario 3", DateTime.Now, "3", null, string.Empty, "3", "3", null));
            lista.Add(new Morador("Usuario 4", DateTime.Now, "4", null, string.Empty, "4", "4", null));
            lista.Add(new Morador("Usuario 5", DateTime.Now, "5", null, string.Empty, "5", "5", null));
            lista.Add(new Morador("Usuario 6", DateTime.Now, "6", null, string.Empty, "6", "6", null));
            lista.Add(new Morador("Usuario 7", DateTime.Now, "7", null, string.Empty, "7", "7", null));
            lista.Add(new Administrador("Usuario 8", DateTime.Now, "87", null, string.Empty, "8", "8"));

            return lista;
        }
    }
}
