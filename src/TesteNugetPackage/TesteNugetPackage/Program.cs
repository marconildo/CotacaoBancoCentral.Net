using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotacaoBcB.Net;

namespace TesteNugetPackage
{
    class Program
    {
        static void Main(string[] args)
        {
            CotacaoBcb ws = new CotacaoBcb();

            var teste = ws.ConsultarUltimoValor(188);
        }
    }
}
