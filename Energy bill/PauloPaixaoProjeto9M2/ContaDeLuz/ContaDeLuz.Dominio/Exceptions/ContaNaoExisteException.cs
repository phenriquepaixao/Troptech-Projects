using System;

namespace ContaDeLuz.Dominio.Exceptions
{
    public class ContaNaoExisteException : Exception
    {
        public ContaNaoExisteException() : base("A Conta não está cadastrada")
        {
        }
    }
}