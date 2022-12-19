namespace PauloPaixaoProjeto2M2
{
    public sealed class PessoaJuridica : Cliente
    {
        private string _cnpj;
        public string Cnpj { get => _cnpj; set => _cnpj = value; }
    }
}