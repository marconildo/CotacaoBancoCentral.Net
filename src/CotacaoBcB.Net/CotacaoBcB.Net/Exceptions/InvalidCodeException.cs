using System;

namespace CotacaoBcB.Net.Exceptions
{
    public class InvalidCodeException : Exception
    {
        public InvalidCodeException() : base("O código informado não corresponde a um índice válido.")
        {

        }
    }
}
