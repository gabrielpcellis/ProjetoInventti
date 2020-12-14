using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Entidades {
    public class Carro {

        public string PlacaCarro { get; set; }
        public string ModeloCarro { get; set; }

        public Carro(string placaCarro, string modeloCarro)
        {
            PlacaCarro = placaCarro;
            ModeloCarro = modeloCarro;
        }
    }
}
