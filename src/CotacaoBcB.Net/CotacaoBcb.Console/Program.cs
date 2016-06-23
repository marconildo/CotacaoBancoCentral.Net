using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotacaoBcB.Net;
using CotacaoBcB.Net.Exceptions;

namespace CotacaoBcb.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // 188 - IGP-M
            var service = new CotacaoBcB.Net.CotacaoBcb();

            try
            {
                var teste = service.ConsultarValorEspecifico(188, new DateTime(2016, 8, 1));
            }
            catch (Exception e)
            {
                if (e is InvalidCodeException)
                {
                    
                }
            }

            //System.Console.WriteLine(teste);
            System.Console.ReadLine();
        }
    }
}
