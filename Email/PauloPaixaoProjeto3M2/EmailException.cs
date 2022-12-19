using System;

namespace PauloPaixaoProjeto3M2
{
    public class EmailException : SystemException
    {
        public EmailException(string message) : base(message)
        {
        }
    }
}