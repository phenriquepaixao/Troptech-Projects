using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoZe.ClassLib
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public double PrecoUn { get; set; }
        public string Unidade { get; set; }
        public int Quantidade { get; set; }

        public override string ToString()
        {
            return $"Código: {Codigo}\nNome: {Nome}\nDescrição: {Descricao}\nData de vencimento: {DataVencimento}\nPreço Un: {PrecoUn}\nUnidade: {Unidade}\nQuantidade: {Quantidade}";
        }
    }
}