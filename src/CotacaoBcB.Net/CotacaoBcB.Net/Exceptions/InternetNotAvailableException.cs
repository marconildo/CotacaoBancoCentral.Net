using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoBcB.Net.Exceptions
{
    public class InternetNotAvailableException : Exception
    {
        public InternetNotAvailableException() : base("Acesso a internet não disponível. Contate o administrador do sistema.")
        {

        }
    }
}
