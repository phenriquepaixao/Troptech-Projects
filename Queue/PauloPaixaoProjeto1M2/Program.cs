using System;

namespace PauloPaixaoProjeto1M2
{
    class Program
    {
        static void Main(string[] args)
        {
            string escolhaUsuario;

            Console.Clear();
            do
            {
                //Mostra as opções do Menu
                AcoesDoSistema.OpcoesMenu();

                //Solicita ao usuário a opção do Menu
                escolhaUsuario = Console.ReadLine();

                //Chama o método de acordo com a função escolhida
                AcoesDoSistema.EscolhaUsuario(escolhaUsuario);

            } while (escolhaUsuario != "6");
        }
    }
}
