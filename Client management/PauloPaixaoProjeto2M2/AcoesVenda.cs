using System;
using System.Collections.Generic;

namespace PauloPaixaoProjeto2M2
{
    public sealed class AcoesVenda
    {
        private static LinkedList<Vendas> _listaDeVendas = new LinkedList<Vendas>();
        public static LinkedList<Vendas> ListaDeVendas { get => _listaDeVendas;}

        public static void AdicionarVenda(Vendas venda)
        {
            _listaDeVendas.AddLast(venda);
        }

        public static void MostrarTodasVendas()
        {
            Console.WriteLine("\n### Vendas cadastradas ###\n");
            foreach (Vendas vendas in ListaDeVendas)
            {
                Console.WriteLine($"Descrição: {vendas.Descricao}");
                Console.WriteLine($"Valor....: R$ {vendas.ValorTotal}");
                Console.WriteLine($"Nome.....: {vendas.Cliente.NomeCliente}");
                Console.WriteLine($"Telefone.: {vendas.Cliente.TelefoneCliente}");
                Console.WriteLine($"-------------------------------------------------");
            }
        }

    }

}