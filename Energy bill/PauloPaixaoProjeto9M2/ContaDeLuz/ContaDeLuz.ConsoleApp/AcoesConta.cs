using System;
using ContaDeLuz.Dominio.Exceptions;
using ContaDeLuz.Infra.Data.Repository;

namespace ContaDeLuz.ConsoleApp
{
    public class AcoesConta
    {
        private static ContaRepository _contaRepository = new ContaRepository();
        public static void CadastraConta()
        {
            Console.WriteLine("############# Cadastrar conta #############\n");

            Console.Write("Digite o número da leitura -> ");
            var numeroLeitura = int.Parse(Console.ReadLine());

            DateTime dataLeitura;

            try
            {
                Console.Write("Digite a data da leitura -> ");
                dataLeitura = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Você deve digitar uma data válida. Clique em qualquer tecla para continuar");
                Console.ReadKey();
                Menu.MenuContas();
                return;
            }

            Console.Write("Digite a quantidade de KW gastos -> ");
            var kw = long.Parse(Console.ReadLine());

            Console.Write("Digite o valor do pagamento -> ");
            var valorPagamento = double.Parse(Console.ReadLine());

            DateTime dataPagamento;

            try
            {
                Console.Write("Digite a data do pagamento -> ");
                dataPagamento = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Você deve digitar uma data válida. Clique em qualquer tecla para continuar");
                Console.ReadKey();
                Menu.MenuContas();
                return;
            }

            Console.Write("Digite a média de consumo -> ");
            var mediaConsumo = double.Parse(Console.ReadLine());

            try
            {
                _contaRepository.CadastraConta(numeroLeitura, dataLeitura, kw, valorPagamento, dataPagamento, mediaConsumo);

                Console.Clear();
                Console.WriteLine($"\nConta cadastrada com sucesso, clique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menu.MenuContas();
            }
            catch (ContaExisteException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menu.MenuContas();
            }
        }

        public static void BuscarConta()
        {
            Console.WriteLine("############# Buscar conta #############\n");

            int mesLeitura;
            int anoLeitura;

            try
            {
                Console.Write("Digite o mês da leitura -> ");
                mesLeitura = int.Parse(Console.ReadLine());

                Console.Write("Digite o ano da leitura -> ");
                anoLeitura = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("O valor é inválido. Clique em qualquer tecla para continuar");
                Console.ReadKey();
                Menu.MenuContas();
                return;
            }
            
            try
            {
                var contaBuscada = _contaRepository.BuscarMesAnoConta(mesLeitura, anoLeitura);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(contaBuscada);
                Console.WriteLine("-------------------------------------------");
            }
            catch (ContaNaoExisteException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"\nClique em qualquer tecla para continuar.");
                Console.ReadKey();
                Menu.MenuContas();
            }
        }
    }
}