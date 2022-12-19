using System;

namespace PauloPaixaoProjeto3
{
    class Program
    {
        private static void Main(string[] args)
        {

            /* ############## CONSTANTES ############## */

            //Usuário e senha
            const string NOMEUSER           = "troptech";
            const string SENHAUSER          = "123";

            //Informações de estilização
            const string MENU               = "\n----------------- MENU -----------------";
            const string CALCULADORA        = "########################################\n############# CALCULADORA ##############\n########################################";
            const string DIVISORIA          = "----------------------------------------";

            //Mensagens
            const string MSGERROLOGIN       = "\nATENÇÃO: Seu nome de usuário está incorreto.";
            const string MSGERROSENHA       = "\nATENÇÃO: Sua senha está incorreta.";
            const string MSGERROSENHALOGIN  = "\nATENÇÃO: Seu nome de usuário e sua senha estão incorretos.";
            const string MSGTENTATIVAS      = "\nATENÇÃO: Você ultrapassou o limite de tentativas. Fechando o programa";
            const string MSGERROOPCOESMENU  = "\nATENÇÃO: Digite um valor válido.";

            //Informações de menu
            const string INFOOPCOESMENU     = "[1] + SOMA\n[2] - SUBTRAÇÃO\n[3] / DIVISÃO\n[4] * MULTIPLICAÇÃO\n[5] X SAIR";
            const string INFOOPCOESSUBMENU  = "[1] REFAZER OPERAÇÃO\n[2] VOLTAR PARA O MENU PRINCIPAL";

            //Informações de operações
            const string OPERACAOSOMA       = "\n------------ Operação SOMA -------------\n";
            const string OPERACAOSUB        = "\n---------- Operação SUBTRAÇÃO ----------\n";
            const string OPERACAODIV        = "\n----------- Operação DIVISÃO -----------\n";
            const string OPERACAOMULT       = "\n-------- Operação MULTIPLICAÇÃO --------\n";
            
            /* ############## VARIAVEIS ############## */
            string nomeUsuario, senhaUsuario, tentativasLogin;
            int nroTentativasLogin = 1, opcoesMenu=0, opcoesSubMenu=0;
            long primeiroNro, segundoNro;
            bool repetirMenu, repetirSubMenu;

            //Limpar o console quando o programa iniciar
            Console.Clear();
            
            //Do While para testar a condição de número de tentativas de login
            do
            {   
                /* ########## PAGINA LOGIN ##########*/
                //Montando a introdução da calculadora
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(CALCULADORA);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(DIVISORIA);
                Console.WriteLine("########### Faça o seu login ###########");
                Console.WriteLine();

                //Solicitando usuário e senha
                Console.Write("Usuário: ");
                nomeUsuario = Console.ReadLine();

                Console.Write("Senha:   ");
                senhaUsuario = Console.ReadLine();

                //Teste para verificar se o número de tentativas ultrapassou 3x
                tentativasLogin = (nroTentativasLogin >= 3) ? MSGTENTATIVAS : $"Tentativas restantes: {3 - nroTentativasLogin} \nPressione qualquer tecla para tentar novamente.";
                
                /*
                Verifica se usuário e senha estão incorretos e mostra a mensagem adequada
                Mostra a mensagem de acordo com o número de tentativas
                Incrementa o número de tentativas para o teste ternário
                */
                if (nomeUsuario != NOMEUSER && senhaUsuario != SENHAUSER)
                {
                    /*
                    Testamos o número de tentativas erradas para mostrar a mensagem correta e finalizar o programa
                    O for é para animar os TRES PONTOS que está finalizando o programa
                    */
                    if (nroTentativasLogin >= 3)
                    {
                        Console.Clear();
                        Console.Write(tentativasLogin);
                        
                        for (int i = 0; i < 3; i++)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Write(".");
                        }

                        return;
                    }else{
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(MSGERROSENHALOGIN + "\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(tentativasLogin);
                    }
                    nroTentativasLogin++;


                /*
                Verifica se usuário está incorreto e mostra a mensagem adequada
                Mostra a mensagem de acordo com o número de tentativas
                Incrementa o número de tentativas para o teste ternário
                */
                }else if (nomeUsuario != NOMEUSER)
                {
                    /*
                    Testamos o número de tentativas erradas para mostrar a mensagem correta e finalizar o programa
                    O for é para animar os TRES PONTOS que está finalizando o programa
                    */
                    if (nroTentativasLogin >= 3)
                    {
                        Console.Clear();
                        Console.Write(tentativasLogin);
                        
                        for (int i = 0; i < 3; i++)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Write(".");
                        }

                        return;
                    }else{
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(MSGERROLOGIN + "\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(tentativasLogin);
                    }
                    nroTentativasLogin++;

                /*
                Verifica se a senha está incorreta e mostra a mensagem adequada
                Mostra a mensagem de acordo com o número de tentativas
                Incrementa o número de tentativas para o teste ternário
                */
                }else if (senhaUsuario != SENHAUSER)
                {
                    /*
                    Testamos o número de tentativas erradas para mostrar a mensagem correta e finalizar o programa
                    O for é para animar os TRES PONTOS que está finalizando o programa
                    */
                    if (nroTentativasLogin >= 3)
                    {
                        Console.Clear();
                        Console.Write(tentativasLogin);
                        
                        for (int i = 0; i < 3; i++)
                        {
                            System.Threading.Thread.Sleep(1000);
                            Console.Write(".");
                        }

                        return;
                    }else{
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(MSGERROSENHA + "\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(tentativasLogin);
                    }
                    nroTentativasLogin++;

                /* LOGIN BEM SUCEDIDO
                Em caso de sucesso no login, vai para o menu
                */
                }else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Fazendo login");
                    for (int i = 0; i < 3; i++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.Write(".");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    /* ########## MENU PRINCIPAL ##########*/
                    Console.Clear();
                    //Montando a introdução da calculadora
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(CALCULADORA);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(DIVISORIA);
                    Console.WriteLine($"Usuário: {nomeUsuario}");
                    Console.WriteLine(DIVISORIA);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(MENU);
                    Console.WriteLine("Escolha uma das opções abaixo:");
                    Console.WriteLine(INFOOPCOESMENU);
                    Console.WriteLine(DIVISORIA);
                    Console.ForegroundColor = ConsoleColor.White;
                    opcoesMenu = Convert.ToInt32(Console.ReadLine());

                    repetirMenu = true;

                    while (repetirMenu)
                    {
                        if (opcoesMenu == 1 || opcoesMenu == 2 || opcoesMenu == 3 || opcoesMenu == 4 || opcoesMenu == 5)
                        {
                            repetirMenu = false;

                            //Switch de controle de opções do MENU
                            switch (opcoesMenu)
                            {
                                //Caso seja digitada a opção 1, entra em SOMA
                                case 1:                   
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(CALCULADORA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine($"Usuário: {nomeUsuario}");
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine(OPERACAOSOMA);
                                    Console.Write("Digite o primeiro numero: ");
                                    primeiroNro = Convert.ToInt64(Console.ReadLine());
                                    Console.Write("Digite o segundo numero: ");
                                    segundoNro = Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine($"Resultado: {primeiroNro + segundoNro}");
                                    //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine("Escolha uma das opções abaixo:");
                                    Console.WriteLine(INFOOPCOESSUBMENU);
                                    Console.WriteLine(DIVISORIA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    opcoesSubMenu = Convert.ToInt32(Console.ReadLine());

                                    repetirSubMenu = true;

                                    //Vai repetir o submenu até que o usuário digite um valor válido
                                    while (repetirSubMenu)
                                    {
                                        if (opcoesSubMenu == 1 || opcoesSubMenu == 2)
                                        {
                                            repetirSubMenu = false;

                                            //Switch de controle de opções do SUBMENU
                                            switch (opcoesSubMenu)
                                            {    
                                                case 1:
                                                    //Switch que repete as operações
                                                    switch (opcoesMenu)
                                                    {
                                                        
                                                        case 1:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSOMA);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro + segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 2:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSUB);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro - segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 3:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAODIV);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro / segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 4:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOMULT);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro * segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;
                                                    }


                                                break;

                                                //Caso seja digitada a opção 2 repete o menu principal
                                                case 2:
                                                repetirMenu = true;
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine(CALCULADORA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(DIVISORIA);
                                                Console.WriteLine($"Usuário: {nomeUsuario}");
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("----------------- MENU -----------------");
                                                Console.WriteLine("Escolha uma das opções abaixo:");
                                                Console.WriteLine(INFOOPCOESMENU);
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                opcoesMenu = Convert.ToInt32(Console.ReadLine());
                                                break;
                                            }


                                        }else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine(CALCULADORA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                            Console.WriteLine(DIVISORIA);
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine(MSGERROOPCOESMENU);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                break;

                                //Caso seja digitada a opção 2, entra em SUBTRAÇÃO
                                case 2:                   
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(CALCULADORA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine($"Usuário: {nomeUsuario}");
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine(OPERACAOSUB);
                                    Console.Write("Digite o primeiro numero: ");
                                    primeiroNro = Convert.ToInt64(Console.ReadLine());
                                    Console.Write("Digite o segundo numero: ");
                                    segundoNro = Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine($"Resultado: {primeiroNro - segundoNro}");
                                    //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine("Escolha uma das opções abaixo:");
                                    Console.WriteLine(INFOOPCOESSUBMENU);
                                    Console.WriteLine(DIVISORIA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    opcoesSubMenu = Convert.ToInt32(Console.ReadLine());

                                    repetirSubMenu = true;

                                    //Vai repetir o submenu até que o usuário digite um valor válido
                                    while (repetirSubMenu)
                                    {
                                        if (opcoesSubMenu == 1 || opcoesSubMenu == 2)
                                        {
                                            repetirSubMenu = false;

                                            //Switch de controle de opções do SUBMENU
                                            switch (opcoesSubMenu)
                                            {    
                                                case 1:
                                                    //Switch que repete as operações
                                                    switch (opcoesMenu)
                                                    {
                                                        
                                                        case 1:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSOMA);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro + segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 2:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSUB);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro - segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 3:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAODIV);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro / segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 4:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOMULT);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro * segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;
                                                    }


                                                break;

                                                //Caso seja digitada a opção 2 repete o menu principal
                                                case 2:
                                                repetirMenu = true;
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine(CALCULADORA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(DIVISORIA);
                                                Console.WriteLine($"Usuário: {nomeUsuario}");
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine(MENU);
                                                Console.WriteLine("Escolha uma das opções abaixo:");
                                                Console.WriteLine(INFOOPCOESMENU);
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                opcoesMenu = Convert.ToInt32(Console.ReadLine());
                                                break;
                                            }


                                        }else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine(CALCULADORA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                            Console.WriteLine(DIVISORIA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                break;

                                case 3:                   
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(CALCULADORA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine($"Usuário: {nomeUsuario}");
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine(OPERACAODIV);
                                    Console.Write("Digite o primeiro numero: ");
                                    primeiroNro = Convert.ToInt64(Console.ReadLine());
                                    Console.Write("Digite o segundo numero: ");
                                    segundoNro = Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine($"Resultado: {primeiroNro / segundoNro}");
                                    Console.WriteLine(DIVISORIA);

                                    //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                    Console.WriteLine("Escolha uma das opções abaixo:");
                                    Console.WriteLine(INFOOPCOESSUBMENU);
                                    Console.WriteLine(DIVISORIA);
                                    opcoesSubMenu = Convert.ToInt32(Console.ReadLine());

                                    repetirSubMenu = true;

                                    //Vai repetir o submenu até que o usuário digite um valor válido
                                    while (repetirSubMenu)
                                    {
                                        if (opcoesSubMenu == 1 || opcoesSubMenu == 2)
                                        {
                                            repetirSubMenu = false;

                                            //Switch de controle de opções do SUBMENU
                                            switch (opcoesSubMenu)
                                            {    
                                                case 1:
                                                    //Switch que repete as operações
                                                    switch (opcoesMenu)
                                                    {
                                                        
                                                        case 1:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSOMA);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro + segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 2:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSUB);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro - segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 3:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAODIV);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro / segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 4:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOMULT);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro * segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;
                                                    }


                                                break;

                                                //Caso seja digitada a opção 2 repete o menu principal
                                                case 2:
                                                repetirMenu = true;
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine(CALCULADORA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(DIVISORIA);
                                                Console.WriteLine($"Usuário: {nomeUsuario}");
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine(MENU);
                                                Console.WriteLine("Escolha uma das opções abaixo:");
                                                Console.WriteLine(INFOOPCOESMENU);
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                opcoesMenu = Convert.ToInt32(Console.ReadLine());
                                                break;
                                            }


                                        }else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine(CALCULADORA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                            Console.WriteLine(DIVISORIA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                break;

                                case 4:                   
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine(CALCULADORA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine($"Usuário: {nomeUsuario}");
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine(OPERACAOMULT);
                                    Console.Write("Digite o primeiro numero: ");
                                    primeiroNro = Convert.ToInt64(Console.ReadLine());
                                    Console.Write("Digite o segundo numero: ");
                                    segundoNro = Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine($"Resultado: {primeiroNro * segundoNro}");
                                    //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(DIVISORIA);
                                    Console.WriteLine("Escolha uma das opções abaixo:");
                                    Console.WriteLine(INFOOPCOESSUBMENU);
                                    Console.WriteLine(DIVISORIA);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    opcoesSubMenu = Convert.ToInt32(Console.ReadLine());

                                    repetirSubMenu = true;

                                    //Vai repetir o submenu até que o usuário digite um valor válido
                                    while (repetirSubMenu)
                                    {
                                        if (opcoesSubMenu == 1 || opcoesSubMenu == 2)
                                        {
                                            repetirSubMenu = false;

                                            //Switch de controle de opções do SUBMENU
                                            switch (opcoesSubMenu)
                                            {    
                                                case 1:
                                                    //Switch que repete as operações
                                                    switch (opcoesMenu)
                                                    {
                                                        
                                                        case 1:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSOMA);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro + segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 2:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOSUB);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro - segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 3:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAODIV);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro / segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;

                                                        case 4:
                                                            repetirSubMenu = true;
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                            Console.WriteLine(CALCULADORA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine(OPERACAOMULT);
                                                            Console.Write("Digite o primeiro numero: ");
                                                            primeiroNro = Convert.ToInt64(Console.ReadLine());
                                                            Console.Write("Digite o segundo numero: ");
                                                            segundoNro = Convert.ToInt64(Console.ReadLine());

                                                            Console.WriteLine($"Resultado: {primeiroNro * segundoNro}");
                                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                                            Console.WriteLine(DIVISORIA);
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            opcoesSubMenu = Convert.ToInt32(Console.ReadLine());
                                                        break;
                                                    }


                                                break;

                                                //Caso seja digitada a opção 2 repete o menu principal
                                                case 2:
                                                repetirMenu = true;
                                                Console.Clear();

                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine(CALCULADORA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine(DIVISORIA);
                                                Console.WriteLine($"Usuário: {nomeUsuario}");
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("----------------- MENU -----------------");
                                                Console.WriteLine("Escolha uma das opções abaixo:");
                                                Console.WriteLine(INFOOPCOESMENU);
                                                Console.WriteLine(DIVISORIA);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                opcoesMenu = Convert.ToInt32(Console.ReadLine());
                                                break;
                                            }


                                        }else
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine(CALCULADORA);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine($"Usuário: {nomeUsuario}");
                                            //Mostra um submenu para o usuário escolher entre repetir a opeção ou ir para o menu principal
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine(DIVISORIA);
                                            Console.WriteLine("Escolha uma das opções abaixo:");
                                            Console.WriteLine(INFOOPCOESSUBMENU);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine(MSGERROOPCOESMENU);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            opcoesMenu = Convert.ToInt32(Console.ReadLine());

                                        }
                                    }
                                break;
                                case 5:

                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.Write("Saindo do sistema");
                                    for (int i = 0; i < 3; i++)
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                        Console.Write(".");
                                    }
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                break;

                            }


                        }else
                        {
                            repetirMenu = true;                            
                            /* ########## MENU PRINCIPAL ##########*/
                            Console.Clear();
                            //Montando a introdução da calculadora
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(CALCULADORA);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(DIVISORIA);
                            Console.WriteLine($"Usuário: {nomeUsuario}");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("----------------- MENU -----------------");
                            Console.WriteLine("Escolha uma das opções abaixo:");
                            Console.WriteLine(INFOOPCOESMENU);
                            Console.WriteLine(DIVISORIA);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(MSGERROOPCOESMENU);
                            Console.BackgroundColor = ConsoleColor.Black;
                            opcoesMenu = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    return;

                }
                /*
                O ReadKey serve para o programa aguardar e mostrar a mensagem ao usuário
                O Clear é para que cada tentativa seja limpa da tela
                */
                Console.ReadKey();
                Console.Clear();
            } while (nroTentativasLogin <= 3);

        }

        
    }
}