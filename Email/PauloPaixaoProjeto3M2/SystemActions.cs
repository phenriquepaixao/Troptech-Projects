using System;
using System.Collections.Generic;

namespace PauloPaixaoProjeto3M2
{
    public static class SystemActions
    {
        private static LinkedList<Email> ListEmails = new LinkedList<Email>();

        public static void SendDoubt()
        {
            Console.Clear();

            DoubtEmail email = new DoubtEmail();

            Console.Write("Descreva sua dúvida: ");
            email.Content = Console.ReadLine();

            try
            {
                email.ValidateDoubt();
                ListEmails.AddFirst(email);

                Console.WriteLine("\nDúvida enviada com sucesso, pressione qualquer tecla para continuar");
                Console.ReadKey();

            }
            catch (EmailException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }

        public static void SendAnswer()
        {
            Console.Clear();

            if (ListIsNull())
            {
                Console.WriteLine("Nenhuma dúvida para responder :)");
            }
            else
            {
                Console.Write("Informe o ID do Email que gostaria de responder: ");
                int idDoubt = int.Parse(Console.ReadLine());

                

                if (ExistsEmail(idDoubt) && !EmailAlreadyAnswered(idDoubt))
                {
                    Console.Write("Descreva sua resposta: ");
                    string contentAnswer = Console.ReadLine();

                    string contentDoubt = null;

                    foreach (Email doubt in ListEmails)
                    {
                        if (doubt is DoubtEmail && doubt.IdNumber == idDoubt)
                        {
                            DoubtEmail doubtEmail = (DoubtEmail)doubt;

                            doubtEmail.WasAnswered = true;
                            contentDoubt = doubtEmail.Content;
                        }
                    }

                    AnswerEmail email = new AnswerEmail(contentAnswer, idDoubt, contentDoubt);
                    ListEmails.AddFirst(email);

                    Console.Clear();
                    Console.WriteLine("Duvida respondida com sucesso.");

                }
                else
                {
                    Console.WriteLine("Este email não existe ou já foi respondido.");
                }
            }

        }

        public static void DisplayEmails(string userType)
        {
            Console.Clear();

            if (userType == "1")
            {
                if (ListIsNull())
                    Console.WriteLine("Você não tem nenhuma dúvida registrada :)");
                else
                    foreach (Email email in ListEmails)
                        Console.WriteLine(email.Display());

            }
            else if (userType == "2")
            {
                if (ListIsNull())
                {
                    Console.WriteLine("Nenhuma dúvida para responder :)");
                }
                else
                {
                    int doubtsCounter = 0;

                    foreach (Email doubtsToAnswer in ListEmails)
                    {
                        if (doubtsToAnswer is DoubtEmail)
                        {
                            //Cast to DoubtEmail to access WasAnswered Prop
                            DoubtEmail doubtWasAnswered = (DoubtEmail)doubtsToAnswer;

                            if (doubtWasAnswered.WasAnswered != true)
                            {
                                Console.WriteLine(doubtsToAnswer.Display());
                                doubtsCounter++;
                            }
                        }
                    }

                    if (doubtsCounter <= 0)
                        Console.WriteLine("Nenhuma dúvida para responder :)");
                }

            }
        }

        private static bool ListIsNull()
        {
            if (ListEmails.Count <= 0)
                return true;
            else
                return false;
        }
        private static bool ExistsEmail(int idEmail)
        {
            foreach (var email in ListEmails)
                if (email.IdNumber == idEmail)
                    return true;

            return false;
        }
        private static bool EmailAlreadyAnswered(int idEmail)
        {
            foreach (Email email in ListEmails)
            {
                if (email is DoubtEmail && email.IdNumber == idEmail)
                {
                    DoubtEmail emailAlreadyAnswered = (DoubtEmail)email;

                    if (emailAlreadyAnswered.WasAnswered == true)
                        return true;
                }
            }

            return false;
        }

    }
}