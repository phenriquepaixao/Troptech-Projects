using System;
using System.Collections;

namespace PauloPaixaoProjeto4
{
    class Program
    {

        const int nroLinhasMatriz = 3;//Numero de linhas da Matriz
        const int nroColunasMatriz = 3;//Numero de colunas da Matriz
        static string[,] jogoDaVelha = new string[nroLinhasMatriz, nroColunasMatriz]; //Matriz do jogo da velha
        static Queue filaJogadas = new Queue(); //Fila de jogadas
        static void Main(string[] args)
        {
            //Variáveis locais
            int contadorDiagonal, contadorDiagonalInvertida, contadorLinha, contadorColuna;

            Console.Clear();
            Console.WriteLine("###################################################");
            Console.WriteLine("################## JOGO DA VELHA ##################");
            Console.WriteLine("###################################################\n");

            //Escolha do jogador na entrada do usuário e cria uma Fila com as 9 jogadas possíveis
            criaJogadas();

            //Mostra o jogo atual para orientar o usuario
            mostraJogo(jogoDaVelha);

            //Repete ate que as jogadas acabem
            while (filaJogadas.Count > 0)
            {
                //Solicita ao usuário a posição LINHA, COLUNA
                Console.Write($"Jogador {filaJogadas.Peek()}, informe a posição da sua jogada (linha,coluna):");

                //quebrando a string de entrada pela vírgula, o resultado é inserido em um Vetor
                var jogadaEscolhida = Console.ReadLine().Split(",");

                //Cria e inicializa um vetor para adicionar as posições de entrada do usuário
                int[] posicaoMatriz = new int[jogadaEscolhida.Length];
                Console.Clear();

                //Adicionando as posições no vetor em INT para serem utilzizadas como LINHA e COLUNA na matriz
                for (int i = 0; i < jogadaEscolhida.Length; i++)
                    posicaoMatriz[i] = int.Parse(jogadaEscolhida[i]);

                //Verifica se o valor de entrada do usuário ultrapassa o tamanho das linhas e/ou colunas
                if (posicaoMatriz[0] > 2 || posicaoMatriz[1] > 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("A posição é inválida, digite novamente\n");
                    Console.BackgroundColor = ConsoleColor.Black;

                    //Mostra o jogo atual para orientar o usuário
                    mostraJogo(jogoDaVelha);

                }
                //Verifica se o valor de entrada do usuário não é uma posição preenchida
                else if (jogoDaVelha[posicaoMatriz[0], posicaoMatriz[1]] != null)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("A jogada já foi realizada, escolha outra posição!\n");
                    Console.BackgroundColor = ConsoleColor.Black;

                    //Mostra o jogo atual para orientar o usuário
                    mostraJogo(jogoDaVelha);
                }
                else
                {
                    //Adiciona a jogada atual a Matriz jogoDaVelha
                    jogoDaVelha[posicaoMatriz[0], posicaoMatriz[1]] = (string)filaJogadas.Peek();

                    /* 
                    ############################################################################ 
                    Verifica se o jogador venceu através da linha, coluna ou as diagonais
                    ############################################################################ 
                    */

                    //Verifica a
                    contadorLinha = 0;
                    for (int linha = 0; linha < nroLinhasMatriz; linha++)
                    {
                        for (int coluna = 0; coluna < nroColunasMatriz; coluna++)
                        {
                            //Linha
                            if (jogoDaVelha[linha, coluna] != null)
                                if (jogoDaVelha[linha, coluna] == (string)filaJogadas.Peek())
                                    contadorLinha++;

                            if (contadorLinha >= 3)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine($"Parabéns jogador {filaJogadas.Peek()}, você venceu!\n");
                                Console.BackgroundColor = ConsoleColor.Black;
                                return;
                            }
                        }
                        contadorLinha = 0;
                    }

                    //Verifica se a coluna
                    contadorColuna = 0;
                    for (int coluna = 0; coluna < nroLinhasMatriz; coluna++)
                    {
                        for (int linha = 0; linha < nroColunasMatriz; linha++)
                        {
                            //Coluna
                            if (jogoDaVelha[linha, coluna] != null)
                                if (jogoDaVelha[linha, coluna] == (string)filaJogadas.Peek())
                                    contadorColuna++;
                            //Coluna
                        }
                        if (contadorColuna >= 3)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine($"Parabéns jogador {filaJogadas.Peek()}, você venceu!\n");
                            Console.BackgroundColor = ConsoleColor.Black;
                            return;
                        }
                        contadorColuna = 0;
                    }

                    //Verifica as diagonais / e \
                    contadorDiagonal = 0;
                    contadorDiagonalInvertida = 0;
                    contadorLinha = 0;
                    for (int linha = 0; linha < nroLinhasMatriz; linha++)
                    {
                        for (int coluna = 0; coluna < nroColunasMatriz; coluna++)
                        {
                            //Diagonal
                            if (linha == coluna)
                                if (jogoDaVelha[linha, coluna] != null)
                                    if (jogoDaVelha[linha, coluna] == (string)filaJogadas.Peek())
                                        contadorDiagonal++;
                            //Diagonal

                            //Diagonal invertida
                            if (linha + coluna == nroLinhasMatriz - 1)
                                if (jogoDaVelha[linha, coluna] != null)
                                    if (jogoDaVelha[linha, coluna] == (string)filaJogadas.Peek())
                                        contadorDiagonalInvertida++;
                            //Diagonal invertida
                        }

                    }
                    if (contadorDiagonal >= 3 || contadorDiagonalInvertida >= 3)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"Parabéns jogador {filaJogadas.Peek()}, você venceu!\n");
                        Console.BackgroundColor = ConsoleColor.Black;
                        return;
                    }

                    /*
                    ############################################################################ 
                    Verifica se o jogador venceu através da linha, coluna ou as diagonais
                    ############################################################################
                    */

                    mostraJogo(jogoDaVelha);

                    //Mostra a hora da jogada
                    var dataAtual = DateTime.Now;
                    Console.WriteLine($"Horário da jogada {dataAtual.Hour}:{dataAtual.Minute}:{dataAtual.Second}");

                    //Remove a jogada realizada da fila
                    filaJogadas.Dequeue();
                }//IF

            }//Repete ate que as jogadas acabem

        }//MAIN

        /* Método para crição das jogadas*/
        static void criaJogadas()
        {

            string jogadorEscolhido;
            var jogadorInvalido = true;

            //Repete até o que o usuário escolha o jogador
            do
            {
                Console.Write("Escolha um jogador X ou O: ");
                jogadorEscolhido = Console.ReadLine().ToUpper();
                Console.Clear();

                //Verifica se o jogador digitado é X ou O
                if (jogadorEscolhido != "X" && jogadorEscolhido != "O")
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("O jogador é inválido, digite novamente\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    jogadorInvalido = false;
                }
            } while (jogadorInvalido);

            //Cria as jogadas com o tamanho da Matriz jogoDaVelha
            for (int nroJogadas = 0; nroJogadas < jogoDaVelha.Length; nroJogadas++)
            {
                //Adiciona o jogador escolhido nas posições
                if (nroJogadas % 2 == 0)
                {
                    filaJogadas.Enqueue(jogadorEscolhido);
                }
                else
                {
                    //Condição ternária para inserção do jogador na fila (evita que repita o jogador. Ex: [1,0]X e [1,1]X)
                    filaJogadas.Enqueue(jogadorEscolhido == "X" ? "0" : "X");
                }
            }
        }

        /* Método para mostrar o jogo a cada jogada*/
        static void mostraJogo(string[,] jogoDaVelha)
        {
            for (int linha = 0; linha < nroLinhasMatriz; linha++)
            {
                //Percorrendo as colunas da matriz
                for (int coluna = 0; coluna < nroColunasMatriz; coluna++)
                {
                    //Se linha é menor que dois ele desenha os caracteres "___" senao deixa em branco
                    if (linha < 2)
                        //Condição ternária para mostrar o valor caso não seja nullo
                        Console.Write("{0}", jogoDaVelha[linha, coluna] == null ? "___" : "_" + jogoDaVelha[linha, coluna] + "_");
                    else
                        Console.Write("{0}", jogoDaVelha[linha, coluna] == null ? "   " : " " + jogoDaVelha[linha, coluna] + " ");

                    //Se coluna é menor que dois ele desenha o caractere "|"
                    if (coluna < 2)
                        Console.Write("|");
                }
                //Quebra de linha para separar as informações
                Console.Write("\n");
            }
            //Mostra um quadro de ajuda com as posições do jogo
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(
                "-----------\n" +
                "-  AJUDA  -\n" +
                "-----------\n" +
                "0,0|0,1|0,2\n" +
                "1,0|1,1|1,2\n" +
                "2,0|2,1|2,2\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }//class
}//namespace
