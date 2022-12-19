using System;
using System.Threading;

namespace ContaDeLuz.ConsoleApp
{
    public class Menu
    {

        public static void MenuPrincipal()
        {
            string[] _menuItens =
            {
                "1 - Área de contas",
                "2 - SAIR"
            };

            Console.Clear();

            Console.WriteLine("#######################################\n########## CELESC ##########\n#######################################");
            Console.WriteLine("O que deseja realizar?\n");
            foreach (var item in _menuItens)
                Console.WriteLine(item);

            Console.Write("-> ");
            var escolhaUsuario = Console.ReadLine();

            switch (escolhaUsuario)
            {
                case "1":
                    Console.Clear();
                    MenuContas();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Saindo do sistema");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida, pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    MenuPrincipal();
                    break;
            }
        }
        public static void MenuContas()
        {
            string[] _menuItens =
            {
                "1 - Cadastrar conta",
                "2 - Consultar conta",
                "3 - Voltar ao menu principal"
            };

            Console.Clear();

            Console.WriteLine("#######################################\n########## CELESC ##########\n#######################################");
            Console.WriteLine("O que deseja realizar?\n");
            foreach (var item in _menuItens)
                Console.WriteLine(item);

            Console.Write("-> ");
            var escolhaUsuario = Console.ReadLine();

            switch (escolhaUsuario)
            {
                case "1":
                    Console.Clear();
                    AcoesConta.CadastraConta();
                    break;
                case "2":
                    Console.Clear();
                    AcoesConta.BuscarConta();
                    break;
                case "3":
                    Console.Clear();
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida, pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    MenuContas();
                    break;
            }
        }

    }
}