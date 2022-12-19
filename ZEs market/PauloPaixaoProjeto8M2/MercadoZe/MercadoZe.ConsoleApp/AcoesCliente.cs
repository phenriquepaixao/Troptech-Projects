using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MercadoZe.ClassLib;
using MercadoZe.ClassLib.DAO;

namespace MercadoZe.ConsoleApp
{
    public static class AcoesCliente
    {
        static ClienteDAO _clienteDao = new ClienteDAO();
        static List<Cliente> _listaClientes = new List<Cliente>();
        static Cliente _clienteEncontrado = new Cliente();
        public static void CadastraCliente()
        {
            Console.WriteLine("############# Cadastrar cliente #############");

            Cliente novoCliente = new Cliente();

            Console.Write("Cpf: ");
            novoCliente.Cpf = Console.ReadLine();

            Console.Write("Nome: ");
            novoCliente.Nome = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            novoCliente.DataNascimento = DateTime.Parse(Console.ReadLine());

            //Console.Write("Pontos: ");
            //novoCliente.PontosFidelidade = Convert.ToDouble(Console.ReadLine());

            //Criando o endereço do cliente
            var novoEndereco = new Endereco();
            Console.WriteLine("\n### Endereço do cliente");

            Console.Write("Rua: ");
            novoEndereco.Rua = Console.ReadLine();

            Console.Write("Número: ");
            novoEndereco.Numero = int.Parse(Console.ReadLine());

            Console.Write("Bairro: ");
            novoEndereco.Bairro = Console.ReadLine();

            Console.Write("CEP: ");
            novoEndereco.Cep = Console.ReadLine();

            Console.Write("Complemento: ");
            novoEndereco.Complemento = Console.ReadLine();

            novoCliente.Endereco = novoEndereco;

            _clienteDao.CreateCliente(novoCliente);

            Console.Clear();
            Console.WriteLine($"Cliente cadastrado com sucesso, clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuCliente();
        }
        public static void BuscarTodosClientes()
        {
            _listaClientes = _clienteDao.ReadTodosClientes();
            Console.WriteLine("############# Clientes cadastrados #############\n");

            foreach (var cliente in _listaClientes)
            {
                Console.WriteLine(cliente);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine($"Clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuCliente();
        }
        public static void EditaCliente()
        {
            Console.WriteLine("############# Editar cliente #############\n");

            Console.WriteLine("Digite o CPF do cliente que deseja editar");
            Console.Write("-> ");
            var cpf = Console.ReadLine();

            _clienteEncontrado = _clienteDao.ReadCpfCliente(cpf);

            if (string.IsNullOrEmpty(_clienteEncontrado.Cpf))
            {
                Console.Clear();
                Console.WriteLine($"O cliente não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuCliente();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_clienteEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("\n############ Digite os novos valores para o cliente ############");
            Console.Write("Cpf: ");
            _clienteEncontrado.Cpf = Console.ReadLine();

            Console.Write("Nome: ");
            _clienteEncontrado.Nome = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            _clienteEncontrado.DataNascimento = DateTime.Parse(Console.ReadLine());

            //Console.Write("Pontos: ");
            //_clienteEncontrado.PontosFidelidade = Convert.ToDouble(Console.ReadLine());

            //Criando o endereço do cliente
            Console.WriteLine("\n### Endereço do cliente");

            var enderecoEncontrado = _clienteEncontrado.Endereco;

            Console.Write("Rua: ");
            enderecoEncontrado.Rua = Console.ReadLine();

            Console.Write("Número: ");
            enderecoEncontrado.Numero = int.Parse(Console.ReadLine());

            Console.Write("Bairro: ");
            enderecoEncontrado.Bairro = Console.ReadLine();

            Console.Write("CEP: ");
            enderecoEncontrado.Cep = Console.ReadLine();

            Console.Write("Complemento: ");
            enderecoEncontrado.Complemento = Console.ReadLine();

            _clienteEncontrado.Endereco = enderecoEncontrado;

            _clienteDao.UpdateCliente(_clienteEncontrado);

            Console.Clear();
            Console.WriteLine($"Cliente atualizado com sucesso, clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuCliente();
        }
        public static void SelecionaCpfCliente()
        {

            Console.WriteLine("############# Buscar cliente pelo CPF #############\n");

            Console.WriteLine("Digite o CPF do cliente que deseja buscar");
            Console.Write("-> ");

            var cpf = Console.ReadLine();

            _clienteEncontrado = _clienteDao.ReadCpfCliente(cpf);

            if (!string.IsNullOrEmpty(_clienteEncontrado.Cpf))
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(_clienteEncontrado);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuCliente();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"O cliente não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuCliente();
            }
        }
        public static void SelecionaNomeCliente()
        {

            Console.WriteLine("############# Buscar cliente cadastrado #############\n");

            Console.WriteLine("Digite o nome do cliente que deseja buscar");
            Console.Write("-> ");

            var nome = Console.ReadLine();

            _listaClientes = _clienteDao.ReadNomeCliente(nome);

            Console.WriteLine("----------------------------------------------");
            foreach (var cliente in _listaClientes)
            {
                Console.WriteLine(cliente);
                Console.WriteLine("----------------------------------------------");
            }

            Console.WriteLine($"Clique em qualquer tecla para continuar.");
            Console.ReadKey();
            Menus.MenuCliente();
        }
        public static void DeletaCliente()
        {
            Console.WriteLine("############# Deletar cliente #############\n");

            Console.WriteLine("Digite o CPF do cliente que deseja deletar");
            Console.Write("-> ");
            var cpf = Console.ReadLine();

            _clienteEncontrado = _clienteDao.ReadCpfCliente(cpf);

            if (string.IsNullOrEmpty(_clienteEncontrado.Cpf))
            {
                Console.Clear();
                Console.WriteLine($"O cliente não foi encontrado, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuCliente();
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(_clienteEncontrado);
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Deseja deletar o cliente? S/N");
            Console.Write("-> ");
            var deletarCliente = Console.ReadLine();

            if (deletarCliente.ToUpper() == "S")
            {
                try
                {
                    _clienteDao.DeleteCliente(_clienteEncontrado);

                    Console.Clear();
                    Console.WriteLine($"\nCliente deletado com sucesso, clique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuCliente();

                }
                catch (SqlException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                    Console.ReadKey();
                    Menus.MenuCliente();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menus.MenuCliente();
            }
        }
    }
}