using System;
using System.Threading;

namespace PauloPaixaoProjeto2M2
{
    class Program
    {

        //Opções menu principal
        private static string[] opcoesMenu = new string[]
        {
            "[1] Cadatrar cliente",
            "[2] Exibir todos os clientes",
            "[3] Pesquisar cliente",
            "[4] Remover cliente",
            "[5] Cadastrar venda",
            "[6] Exibir todas as vendas",
            "[0] Sair"
        };

        //Opções menu tipo de pessoa PF ou PJ
        private static string[] _opcoesMenuCliente = new string[] { "[1] Pessoa Física", "[2] Pessoa Jurídica" };

        private static Endereco _enderecoCliente;

        public const string TEXTOSISTEMA = "###################################\n####### TROPTECH MODAS LTDA #######\n###################################\n";

        static void Main(string[] args)
        {
            string escolhaUsuario;

            do
            {
                Console.Clear();
                Console.WriteLine(TEXTOSISTEMA);

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Qual ação você deseja realizar?\n ");

                foreach (var opcao in opcoesMenu)
                    Console.WriteLine(opcao);

                Console.Write("-> ");

                escolhaUsuario = Console.ReadLine();

                Console.Clear();


                switch (escolhaUsuario)
                {
                    //Cadastrar nono cliente PF ou PJ
                    case "1":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        Console.WriteLine("----------------------------");
                        foreach (var tipo in _opcoesMenuCliente)
                            Console.WriteLine(tipo);
                        Console.WriteLine("----------------------------");

                        Console.Write("-> ");

                        var tipoCliente = Console.ReadLine();

                        //PF ou PJ
                        if (tipoCliente == "1")
                        {
                            Console.Clear();
                            Console.WriteLine(TEXTOSISTEMA);

                            PessoaFisica novaPessoaFisica = new PessoaFisica();

                            Console.WriteLine("### Novo cliente Pessoa física ###\n----------------------------------");
                            Console.WriteLine("### Dados do cliente\n");

                            Console.Write("Digite o nome do cliente: ");
                            novaPessoaFisica.NomeCliente = Console.ReadLine();

                            Console.Write("Digite o telefone do cliente: ");
                            novaPessoaFisica.TelefoneCliente = Console.ReadLine();

                            //Criando o endereço do cliente
                            Console.WriteLine("\n### Endereço do cliente");
                            Console.Write("Rua: ");
                            var RuaEnd = Console.ReadLine();

                            Console.Write("Numero: ");
                            var NumeroEnd = int.Parse(Console.ReadLine());

                            Console.Write("Cidade: ");
                            var CidadeEnd = Console.ReadLine();

                            Console.Write("Estado: ");
                            var EstadoEnd = Console.ReadLine();

                            Console.Write("País: ");
                            var PaisEnd = Console.ReadLine();

                            _enderecoCliente = new Endereco(RuaEnd, NumeroEnd, CidadeEnd, EstadoEnd, PaisEnd);
                            novaPessoaFisica.EnderecoCliente = _enderecoCliente;

                            Console.Write("Digite o CPF do cliente: ");
                            novaPessoaFisica.Cpf = Console.ReadLine();

                            AcoesCliente.AdicionarPessoaFisica(novaPessoaFisica);
                        }
                        else if (tipoCliente == "2")
                        {
                            Console.Clear();
                            Console.WriteLine(TEXTOSISTEMA);

                            PessoaJuridica novaPessoaJuridica = new PessoaJuridica();

                            Console.WriteLine("### Novo cliente Pessoa jurídica ###\n----------------------------------");
                            Console.WriteLine("### Dados do cliente\n");

                            Console.Write("Digite o nome do cliente: ");
                            novaPessoaJuridica.NomeCliente = Console.ReadLine();

                            Console.Write("Digite o telefone do cliente: ");
                            novaPessoaJuridica.TelefoneCliente = Console.ReadLine();

                            //Criando o endereço do cliente
                            Console.WriteLine("\n### Endereço do cliente");
                            Console.Write("Rua: ");
                            var RuaEnd = Console.ReadLine();

                            Console.Write("Numero: ");
                            var NumeroEnd = int.Parse(Console.ReadLine());

                            Console.Write("Cidade: ");
                            var CidadeEnd = Console.ReadLine();

                            Console.Write("Estado: ");
                            var EstadoEnd = Console.ReadLine();

                            Console.Write("País: ");
                            var PaisEnd = Console.ReadLine();

                            _enderecoCliente = new Endereco(RuaEnd, NumeroEnd, CidadeEnd, EstadoEnd, PaisEnd);
                            novaPessoaJuridica.EnderecoCliente = _enderecoCliente;

                            Console.Write("Digite o CNPJ do cliente: ");
                            novaPessoaJuridica.Cnpj = Console.ReadLine();


                            AcoesCliente.AdicionarPessoaJuridica(novaPessoaJuridica);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção inválida.\n\nPressione qualquer tecla para voltar ao menu principal...");
                            Console.ReadKey();
                        }
                        break;

                    //Mostra todos os clientes
                    case "2":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        AcoesCliente.MostrarTodosClientes();
                        Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                        Console.ReadKey();
                        break;

                    //Pesquisa cliente pelo nome
                    case "3":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        Console.Write("Digite o nome do Cliente que deseja pesquisar: ");
                        var nomePesquisa = Console.ReadLine();

                        if (AcoesCliente.PesquisarPessoaFisica(nomePesquisa) == true || AcoesCliente.PesquisarPessoaJuridica(nomePesquisa) == true)
                        {
                            foreach (var pf in AcoesCliente.ListaPessoaFisica)
                            {
                                if (pf.NomeCliente == nomePesquisa)
                                {
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.WriteLine($"Nome....: {pf.NomeCliente}\nCPF.....: {pf.Cpf}\nTelefone: {pf.TelefoneCliente}\nEndereço: {pf.EnderecoCliente.EndCompleto}");
                                    Console.WriteLine("------------------------------------------------------");
                                }
                            }
                            foreach (var pj in AcoesCliente.ListaPessoaJuridica)
                            {
                                if (pj.NomeCliente == nomePesquisa)
                                {
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.WriteLine($"Nome....: {pj.NomeCliente}\nCNPJ.....: {pj.Cnpj}\nTelefone: {pj.TelefoneCliente}\nEndereço: {pj.EnderecoCliente.EndCompleto}");
                                    Console.WriteLine("------------------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nO Cliente {nomePesquisa} não existe!");
                        }

                        Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                        Console.ReadKey();

                        break;

                    //Exclui cliente pelo CPF ou CNPJ
                    case "4":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        Console.WriteLine("----------------------------");
                        foreach (var tipo in _opcoesMenuCliente)
                            Console.WriteLine(tipo);
                        Console.WriteLine("----------------------------");

                        Console.Write("-> ");

                        tipoCliente = Console.ReadLine();

                        //PF ou PJ
                        if (tipoCliente == "1")
                        {
                            Console.Write("\nDigite o CPF do cliente que deseja excluir: ");

                            var cpfDeleta = Console.ReadLine();

                            if (AcoesCliente.RemoverPessoaFisica(cpfDeleta) == true)
                            {
                                Console.WriteLine($"\nO cliente foi excluido com sucesso.");
                                Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                                Console.ReadKey();
                            }
                            else
                            {

                                Console.WriteLine($"\nO cliente não existe!");
                                Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                                Console.ReadKey();
                            }

                        }
                        else if (tipoCliente == "2")
                        {
                            Console.Write("\nDigite o CNPJ do cliente que deseja excluir: ");

                            var cnpjDeleta = Console.ReadLine();

                            if (AcoesCliente.RemoverPessoaFisica(cnpjDeleta) == true)
                            {
                                Console.WriteLine($"\nO cliente foi excluido com sucesso.");
                                Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"\nO cliente não existe!");
                                Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção inválida.\n\nPressione qualquer tecla para voltar ao menu principal...");
                            Console.ReadKey();
                        }

                        break;

                    //Cadastra nova venda
                    case "5":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        Console.WriteLine("----------------------------");
                        foreach (var tipo in _opcoesMenuCliente)
                            Console.WriteLine(tipo);
                        Console.WriteLine("----------------------------");

                        Console.Write("-> ");

                        tipoCliente = Console.ReadLine();

                        //PF ou PJ
                        if (tipoCliente == "1")
                        {
                            Console.Clear();
                            Console.WriteLine(TEXTOSISTEMA);
                            Vendas novaVendaPF = new Vendas();

                            Console.WriteLine("### Nova venda Pessoa física ###\n--------------------------------");

                            Console.Write("Nome do cliente: ");
                            var nomeClienteVenda = Console.ReadLine();

                            if (AcoesCliente.PesquisarPessoaFisica(nomeClienteVenda) == true)
                            {
                                foreach (var pf in AcoesCliente.ListaPessoaFisica)
                                {
                                    if (pf.NomeCliente == nomeClienteVenda)
                                    {
                                        novaVendaPF.Cliente = pf;

                                        Console.Write("Descrição da venda: ");
                                        novaVendaPF.Descricao = Console.ReadLine();

                                        Console.Write("Valor da venda: ");
                                        novaVendaPF.ValorTotal = decimal.Parse(Console.ReadLine());

                                        AcoesVenda.AdicionarVenda(novaVendaPF);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\nO Cliente {nomeClienteVenda} não existe!");
                            }
                        }
                        else if (tipoCliente == "2")
                        {
                            Console.Clear();
                            Console.WriteLine(TEXTOSISTEMA);

                            Vendas novaVendaPJ = new Vendas();

                            Console.WriteLine("### Nova venda Pessoa jurídica ###\n--------------------------------");

                            Console.Write("Nome do cliente: ");
                            var nomeClienteVenda = Console.ReadLine();

                            if (AcoesCliente.PesquisarPessoaJuridica(nomeClienteVenda) == true)
                            {
                                foreach (var pj in AcoesCliente.ListaPessoaJuridica)
                                {
                                    if (pj.NomeCliente == nomeClienteVenda)
                                    {
                                        novaVendaPJ.Cliente = pj;

                                        Console.Write("Descrição da venda: ");
                                        novaVendaPJ.Descricao = Console.ReadLine();

                                        Console.Write("Valor da venda: ");
                                        novaVendaPJ.ValorTotal = decimal.Parse(Console.ReadLine());

                                        AcoesVenda.AdicionarVenda(novaVendaPJ);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\nO Cliente {nomeClienteVenda} não existe!");
                            }

                        }
                        Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                        Console.ReadKey();

                        break;

                    //Mostra todas as vendas
                    case "6":
                        Console.Clear();
                        Console.WriteLine(TEXTOSISTEMA);

                        AcoesVenda.MostrarTodasVendas();
                        Console.WriteLine("\nPressione qualquer tecla para para voltar ao menu principal...");
                        Console.ReadKey();
                        break;

                    //Sai do sistema
                    case "0":
                        Console.Clear();
                        Console.Write("Saindo do sistema");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            Thread.Sleep(1000);
                        }
                        Console.Clear();
                        break;
                }

            } while (escolhaUsuario != "0");
        }
    }
}