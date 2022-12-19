namespace PauloPaixaoProjeto2M2
{
    public sealed class Vendas
    {
        private string _descricao;
        private decimal _valorTotal;
        private Cliente _cliente;

        public string Descricao { get => _descricao; set => _descricao = value; }
        public decimal ValorTotal { get => _valorTotal; set => _valorTotal = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
    }
}