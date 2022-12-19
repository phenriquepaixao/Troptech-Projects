namespace PauloPaixaoProjeto2M2
{
    public struct Endereco
    {
        private string _rua;
        private int _numero;
        private string _cidade;
        private string _estado;
        private string _pais;

        public string Rua { get => _rua; set => _rua = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public string Cidade { get => _cidade; set => _cidade = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Pais { get => _pais; set => _pais = value; }
        public string EndCompleto { get => $"Rua {Rua}, {Numero}, {Cidade}/{Estado} - {Pais}"; }

        public Endereco(string rua, int numero, string cidade, string estado, string pais)
        {
            _rua = rua;
            _numero = numero;
            _cidade = cidade;
            _estado = estado;
            _pais = pais;
        }
    }
}