using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoZe.ClassLib;
using MercadoZe.ClassLib.DAO;

namespace MercadoZe.ConsoleApp
{
    public static class AcoesPedido
    {
        static PedidoDAO _pedidoDao = new PedidoDAO();
        static ProdutoDAO _produtoDao = new ProdutoDAO();
        static ClienteDAO _clienteDao = new ClienteDAO();

        static List<Pedido> _listaPedidos = new List<Pedido>();

        static Pedido _pedidoEncontrado = new Pedido();
        static Produto _produtoEncontrado = new Produto();
        static Cliente _clienteEncontrado = new Cliente();

        public static void CadastraPedido()
        {
            Console.WriteLine("############# Cadastrar Pedido #############\n");
            Pedido novoPedido = new Pedido();

            Console.WriteLine("Digite o código do produto que deseja fazer o pedido");
            Console.Write("-> ");
            var codigoProduto = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigoProduto);

            if (_produtoEncontrado.Codigo == 0)
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuPedidos();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_produtoEncontrado);
            Console.WriteLine("----------------------------------------------");

            novoPedido.Produto = _produtoEncontrado;

            var quantidade = 0;
            var repetirQuantidade = "";

            do
            {
                Console.Write("Quantidade: ");
                quantidade = int.Parse(Console.ReadLine());

                if (_produtoEncontrado.Quantidade < quantidade)
                {
                    Console.Clear();
                    Console.WriteLine($"A quantidade em estoque que é {_produtoEncontrado.Quantidade}, deseja digitar novamente? S/N");
                    Console.Write($"-> ");
                    repetirQuantidade = Console.ReadLine();

                    if (repetirQuantidade.ToUpper() == "N")
                    {
                        Console.WriteLine($"Clique em qualquer tecla para continuar.");
                        Console.ReadKey();
                        Menus.MenuPedidos();
                    }
                }
                else
                {
                    repetirQuantidade = "n";
                }
            }
            while (repetirQuantidade.ToUpper() == "S");

            novoPedido.Quantidade = quantidade;

            var novaQuantidade = _produtoEncontrado.Quantidade - novoPedido.Quantidade;
            _produtoDao.UpdateQuantidade(_produtoEncontrado, novaQuantidade);


            Console.WriteLine("Digite o CPF do cliente");
            Console.Write("-> ");
            var cpf = Console.ReadLine();

            _clienteEncontrado = _clienteDao.ReadCpfCliente(cpf);

            novoPedido.Cliente = _clienteEncontrado;

            if (string.IsNullOrEmpty(_clienteEncontrado.Cpf))
            {
                Console.WriteLine($"O cliente não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();

                novoPedido.Cliente.Cpf = "0";
                novoPedido.CalculaValorTotal();

                _pedidoDao.CreatePedido(novoPedido);

                Console.Clear();
                Console.WriteLine($"Pedido cadastrado com sucesso, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuPedidos();
            }
            else
            {
                novoPedido.CalculaValorTotal();
                novoPedido.CalculaPontosFidelidade();

                _clienteDao.UpdatePontosFidelidadeCliente(_clienteEncontrado);

                _pedidoDao.CreatePedido(novoPedido);

                Console.Clear();
                Console.WriteLine($"Pedido cadastrado com sucesso, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuPedidos();
            }
        }

        public static void BuscarTodosPedidos()
        {
            _listaPedidos = _pedidoDao.ReadTodosPedidos();
            Console.WriteLine("############# Pedidos cadastrados #############\n");

            foreach (var pedido in _listaPedidos)
            {
                Console.WriteLine(pedido);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine($"Clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuPedidos();
        }


    }
}