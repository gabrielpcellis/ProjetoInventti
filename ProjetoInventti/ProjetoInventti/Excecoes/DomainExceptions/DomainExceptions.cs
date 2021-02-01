using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoInventti.Excecoes.DomainExceptions
{
    class DomainExceptions : ApplicationException
    {
        public DomainExceptions(string message) : base(message)
        {
        }
    }
}
