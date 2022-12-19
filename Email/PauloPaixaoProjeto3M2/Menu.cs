using System;
using System.Threading;

namespace PauloPaixaoProjeto3M2
{
    public static class Menu
    {

        public static void ShowPrincipalMenu()
        {
            string[] _menuItens =
            {
                "1 - ACESSAR COMO ALUNO",
                "2 - ACESSAR COMO PROFESSOR",
                "3 - SAIR"
            };

            Console.Clear();

            Console.WriteLine("##################################################################\n########## Bem vindo ao sistema de e-mail do Trop Tech! ##########\n##################################################################");
            Console.WriteLine("O que deseja realizar?\n");
            foreach (var item in _menuItens)
                Console.WriteLine(item);

            Console.Write("-> ");
            var choicePrincipalMenu = Console.ReadLine();

            switch (choicePrincipalMenu)
            {
                case "1":
                    ShowStudentMenu(choicePrincipalMenu);
                    break;
                case "2":
                    ShowProfessorlMenu(choicePrincipalMenu);
                    break;
                case "3":
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
                    ShowPrincipalMenu();
                    break;
            }
        }

        public static void ShowStudentMenu(string choicePrincipalMenu)
        {
            string[] _menuItens =
            {
                "1 - ENVIAR DÚVIDA",
                "2 - VISUALIZAR E-MAILS",
                "3 - VOLTAR AO MENU PRINCIPAL"
            };

            Console.Clear();

            Console.WriteLine("=======================================================\n==================== Área do Aluno ====================\n=======================================================");
            Console.WriteLine("O que deseja realizar?\n");
            foreach (var item in _menuItens)
                Console.WriteLine(item);

            Console.Write("-> ");
            var choiceStudentMenu = Console.ReadLine();

            switch (choiceStudentMenu)
            {
                case "1":
                    SystemActions.SendDoubt();

                    ShowStudentMenu(choicePrincipalMenu);
                    break;
                case "2":
                    SystemActions.DisplayEmails(choicePrincipalMenu);

                    Console.WriteLine("\n---------------------------------------\nPressione qualquer tecla para continuar");
                    Console.ReadKey();

                    ShowStudentMenu(choicePrincipalMenu);
                    break;
                case "3":
                    ShowPrincipalMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida, pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    ShowStudentMenu(choicePrincipalMenu);
                    break;
            }
        }

        public static void ShowProfessorlMenu(string choicePrincipalMenu)
        {
            string[] _menuItens =
            {
                "1 - VISUALIZAR DÚVIDA",
                "2 - ENVIAR RESPOSTA",
                "3 - VOLTAR AO MENU PRINCIPAL"
            };

            Console.Clear();

            Console.WriteLine("===========================================================\n==================== Área do Professor ====================\n===========================================================");
            Console.WriteLine("O que deseja realizar?\n");
            foreach (var item in _menuItens)
                Console.WriteLine(item);

            Console.Write("-> ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SystemActions.DisplayEmails(choicePrincipalMenu);

                    Console.WriteLine("\n---------------------------------------\nPressione qualquer tecla para continuar");
                    Console.ReadKey();

                    ShowProfessorlMenu(choicePrincipalMenu);
                    break;
                case "2":
                    SystemActions.SendAnswer();

                    Console.WriteLine("\n---------------------------------------\nPressione qualquer tecla para continuar");
                    Console.ReadKey();

                    ShowProfessorlMenu(choicePrincipalMenu);
                    break;
                case "3":
                    ShowPrincipalMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida, pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    ShowProfessorlMenu(choicePrincipalMenu);
                    break;
            }
        }


    }
}