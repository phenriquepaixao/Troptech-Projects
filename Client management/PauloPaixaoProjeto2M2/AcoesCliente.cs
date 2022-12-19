using System;
using System.Collections.Generic;

namespace PauloPaixaoProjeto2M2
{
    public sealed class AcoesCliente
    {
        private static LinkedList<PessoaFisica> _listaPessoaFisica = new LinkedList<PessoaFisica>();
        private static LinkedList<PessoaJuridica> _listaPessoaJuridica = new LinkedList<PessoaJuridica>();
        public static LinkedList<PessoaFisica> ListaPessoaFisica { get => _listaPessoaFisica; set => _listaPessoaFisica = value; }
        public static LinkedList<PessoaJuridica> ListaPessoaJuridica { get => _listaPessoaJuridica; set => _listaPessoaJuridica = value; }

        public static void AdicionarPessoaFisica(PessoaFisica pessoaFisica)
        {
            ListaPessoaFisica.AddLast(pessoaFisica);
        }

        public static void AdicionarPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            ListaPessoaJuridica.AddLast(pessoaJuridica);
        }

        public static bool PesquisarPessoaFisica(string nomeCliente)
        {
            foreach (PessoaFisica pf in ListaPessoaFisica)
            {
                if (pf.NomeCliente == nomeCliente)
                    return true;
            }
            return false;
        }

        public static bool PesquisarPessoaJuridica(string nomeCliente)
        {
            foreach (PessoaJuridica pj in ListaPessoaJuridica)
            {
                if (pj.NomeCliente == nomeCliente)
                    return true;
            }
            return false;
        }

        public static bool RemoverPessoaFisica(string cpfCliente)
        {
            foreach (PessoaFisica pf in ListaPessoaFisica)
            {
                if (pf.Cpf == cpfCliente)
                {
                    ListaPessoaFisica.Remove(pf);
                    return true;
                }
            }
            return false;
        }

        public static bool RemoverPessoaJuridica(string cnpjCliente)
        {
            foreach (PessoaJuridica pj in ListaPessoaJuridica)
            {
                if (pj.Cnpj == cnpjCliente)
                {
                    ListaPessoaJuridica.Remove(pj);
                    return true;
                }
            }
            return false;
        }

        public static void MostrarTodosClientes()
        {
            Console.WriteLine("\n### Clientes pessoa física cadastrados ###");
            Console.WriteLine($"-------------------------------------------");
            foreach (PessoaFisica pf in ListaPessoaFisica)
            {
                Console.WriteLine($"Nome....: {pf.NomeCliente}");
                Console.WriteLine($"Telefone: {pf.TelefoneCliente}");
                Console.WriteLine($"Endereço: {pf.EnderecoCliente.EndCompleto}");
                Console.WriteLine($"CPF.....: {pf.Cpf}");
                Console.WriteLine($"-------------------------------------------------");
            }

            Console.WriteLine("\n### Clientes pessoa jurídica cadastrados ###");
            Console.WriteLine($"---------------------------------------------");
            foreach (PessoaJuridica pj in ListaPessoaJuridica)
            {
                Console.WriteLine($"Nome....: {pj.NomeCliente}");
                Console.WriteLine($"Telefone: {pj.TelefoneCliente}");
                Console.WriteLine($"Endereço: {pj.EnderecoCliente.EndCompleto}");
                Console.WriteLine($"CNPJ....: {pj.Cnpj}");
                Console.WriteLine($"-------------------------------------------------");
            }
        }

    }
}