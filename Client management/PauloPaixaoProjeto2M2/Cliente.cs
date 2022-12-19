using System.Collections.Generic;

namespace PauloPaixaoProjeto2M2
{
    public abstract class Cliente
    {
        private string _nomeCliente;
        private string _telefoneCliente;
        private Endereco _enderecoCliente;

        public string NomeCliente { get => _nomeCliente; set => _nomeCliente = value; }
        public string TelefoneCliente { get => _telefoneCliente; set => _telefoneCliente = value; }
        public Endereco EnderecoCliente { get => _enderecoCliente; set => _enderecoCliente = value; }
    }
}