using System;

namespace CotacaoBcB.Net.Exceptions
{
    [Serializable]
    class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}
