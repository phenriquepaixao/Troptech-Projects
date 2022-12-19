using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoZe.ClassLib;
using MercadoZe.ClassLib.DAO;

namespace MercadoZe.ConsoleApp
{
    public static class AcoesProduto
    {
        static ProdutoDAO _produtoDao = new ProdutoDAO();
        static List<Produto> _listaProdutos = new List<Produto>();
        static Produto _produtoEncontrado = new Produto();

        public static void CadastraProduto()
        {
            Console.WriteLine("############# Cadastrar produto #############");

            Produto novoProduto = new Produto();

            Console.Write("Nome: ");
            novoProduto.Nome = Console.ReadLine();

            Console.Write("Descrição: ");
            novoProduto.Descricao = Console.ReadLine();

            Console.Write("Data de vencimento: ");
            novoProduto.DataVencimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Preço: ");
            novoProduto.PrecoUn = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unidade: ");
            novoProduto.Unidade = Console.ReadLine();

            Console.Write("Quantidade: ");
            novoProduto.Quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoDao.CreateProduto(novoProduto);

            Console.Clear();
            Console.WriteLine($"\nProduto cadastrado com sucesso, clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuProdutos();
        }
        public static void BuscarTodosProdutos()
        {
            _listaProdutos = _produtoDao.ReadTodosProdutos();
            Console.WriteLine("############# Produtos cadastrados #############\n");

            foreach (var produto in _listaProdutos)
            {
                Console.WriteLine(produto);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine($"Clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuProdutos();
        }
        public static void SelecionaDescricaoProduto()
        {

            Console.WriteLine("############# Buscar produto cadastrado #############\n");

            Console.WriteLine("Digite a descrição do produto que deseja buscar");
            Console.Write("-> ");

            var descricao = Console.ReadLine();

            _listaProdutos = _produtoDao.ReadDescricaoProduto(descricao);

            Console.WriteLine("----------------------------------------------");
            foreach (var produto in _listaProdutos)
            {
                Console.WriteLine(produto);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine($"Clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuProdutos();
        }
        public static void SelecionaCodigoProduto()
        {

            Console.WriteLine("############# Buscar produto cadastrado #############\n");

            Console.WriteLine("Digite o codigo do produto que deseja buscar");
            Console.Write("-> ");

            var codigo = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigo);

            if (_produtoEncontrado.Codigo != 0)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(_produtoEncontrado);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }
        }
        public static void EditaProduto()
        {
            Console.WriteLine("############# Editar produto #############\n");

            Console.WriteLine("Digite o código do produto que deseja editar");
            Console.Write("-> ");
            var codigo = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigo);

            if (_produtoEncontrado.Codigo == 0)
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_produtoEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("\n############ Digite os novos valores para o produto ############");
            Console.Write("Nome: ");
            _produtoEncontrado.Nome = Console.ReadLine();

            Console.Write("Descrição: ");
            _produtoEncontrado.Descricao = Console.ReadLine();

            Console.Write("Data de vencimento: ");
            _produtoEncontrado.DataVencimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Preço: ");
            _produtoEncontrado.PrecoUn = Convert.ToDouble(Console.ReadLine());

            Console.Write("Unidade: ");
            _produtoEncontrado.Unidade = Console.ReadLine();

            Console.Write("Quantidade: ");
            _produtoEncontrado.Quantidade = Convert.ToInt32(Console.ReadLine());

            _produtoDao.UpdateProduto(_produtoEncontrado);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Produto atualizado com sucesso, clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuProdutos();
        }
        public static void DeletaProduto()
        {
            Console.WriteLine("############# Deletar produto #############\n");

            Console.WriteLine("Digite o código do produto que deseja deletar");
            Console.Write("-> ");
            var codigo = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigo);

            if (_produtoEncontrado.Codigo == 0)
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_produtoEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Deseja deletar o produto? S/N");
            Console.Write("-> ");
            var deletarProduto = Console.ReadLine();

            if (deletarProduto.ToUpper() == "S")
            {
                try
                {
                    _produtoDao.DeleteProduto(_produtoEncontrado);

                    Console.Clear();
                    Console.WriteLine($"\nProduto deletado com sucesso, clique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();

                }
                catch (SqlException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }
        }
        public static void CadastraProdutoEstoque()
        {
            Console.WriteLine("############# Cadastrar produto no estoque #############\n");
            Console.WriteLine("Digite o código do produto que deseja inserir no estoque");
            Console.Write("-> ");
            var codigo = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigo);

            if (_produtoEncontrado.Codigo == 0)
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_produtoEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Deseja inserir o produto? S/N");
            Console.Write("-> ");
            var deletarProduto = Console.ReadLine();

            if (deletarProduto.ToUpper() == "S")
            {
                try
                {
                    _produtoDao.AddProdutoEstoque(_produtoEncontrado);

                    Console.Clear();
                    Console.WriteLine($"\nProduto inserido no estoque com sucesso, clique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();

                }
                catch (SqlException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }


        }
        public static void RemoveProdutoEstoque()
        {
            Console.WriteLine("############# Remover produto do estoque #############\n");

            Console.WriteLine("Digite o código do produto que deseja remover do estoque");
            Console.Write("-> ");
            var codigo = int.Parse(Console.ReadLine());

            _produtoEncontrado = _produtoDao.ReadCodigoProduto(codigo);

            if (_produtoEncontrado.Codigo == 0)
            {
                Console.Clear();
                Console.WriteLine($"O produto não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_produtoEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Deseja remover o produto? S/N");
            Console.Write("-> ");
            var deletarProduto = Console.ReadLine();

            if (deletarProduto.ToUpper() == "S")
            {
                try
                {
                    _produtoDao.RemoveProdutoEstoque(_produtoEncontrado);

                    Console.Clear();
                    Console.WriteLine($"\nProduto removido do estoque com sucesso, clique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();

                }
                catch (SqlException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuProdutos();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuProdutos();
            }
        }
    }
}