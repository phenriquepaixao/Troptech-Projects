using System;
using System.Collections.Generic;

namespace PauloPaixaoProjeto2M2
{
    public sealed class PessoaFisica : Cliente
    {      
        private string _cpf;
        public string Cpf { get => _cpf; set => _cpf = value; }
    }
}