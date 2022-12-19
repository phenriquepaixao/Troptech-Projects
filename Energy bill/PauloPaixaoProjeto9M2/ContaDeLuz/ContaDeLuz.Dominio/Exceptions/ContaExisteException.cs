using System;

namespace ContaDeLuz.Dominio.Exceptions
{
    public class ContaExisteException : Exception
    {
        public ContaExisteException() : base("Conta já está cadastrada")
        {
        }
    }
}