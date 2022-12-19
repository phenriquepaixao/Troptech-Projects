using System;
using System.Globalization;

namespace MercadoZe.ClassLib
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public DateTime DataPedido { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
        public double CalculaValorTotal()
        {
            return this.ValorTotal = Produto.PrecoUn * this.Quantidade;
        }

        public double CalculaPontosFidelidade()
        {
            return this.Cliente.PontosFidelidade = this.ValorTotal * 2;
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo}\nDataPedido: {DataPedido}\nCódigo do produto: {Produto.Codigo}\nNome do Produto: {Produto.Nome}\nQuantidade: {Quantidade}\nValor Total: {ValorTotal}\nCPF do Cliente: {Cliente.Cpf}\nNome do Cliente: {Cliente.Nome}";
        }
    }
}
