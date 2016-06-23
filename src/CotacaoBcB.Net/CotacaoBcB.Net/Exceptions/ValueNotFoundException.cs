using System;

namespace CotacaoBcB.Net.Exceptions
{
    public class ValueNotFoundException : Exception
    {
        public ValueNotFoundException() : base("Nenhum valor foi encontrado para a data informada.")
        {
            
        }
    }
}
