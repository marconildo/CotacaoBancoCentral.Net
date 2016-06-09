using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotacaoBcB.Net;

namespace CotacaoBcb.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // 188 - IGP-M
            new CotacaoBcB.Net.CotacaoBcb().ConsultarCodigoCotacao("inpc");
            //System.Console.WriteLine(teste);
            System.Console.ReadLine();
        }
    }
}
