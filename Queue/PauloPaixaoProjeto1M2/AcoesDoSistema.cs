using System;

namespace PauloPaixaoProjeto1M2
{
    public static class AcoesDoSistema
    {
        private static Queue _fila = new Queue();

        private static string[] _opcoesMenu;


        public static void Enfileirar()
        {
            Console.Write("Insira o valor que deseja enfileirar: ");
            var itemEnfileirar = int.Parse(Console.ReadLine());

            _fila.Enfileirar(itemEnfileirar);

            ImprimeQtdItens();
        }

        public static void Desenfileirar()
        {

            var filaVazia = _fila.VerificaFilaVazia();

            if (filaVazia)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"A fila está vazia.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                var itemDesenfileirar = _fila.Desenfileirar();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"O item {itemDesenfileirar} foi desenfileirado\n");
                Console.ForegroundColor = ConsoleColor.White;
                ImprimeQtdItens();
            }
        }

        public static void VerPrimeiroItem()
        {
            var filaVazia = _fila.VerificaFilaVazia();

            if (filaVazia)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"A fila está vazia.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"O item no topo é: {_fila.Primeiro}\n");
            }
        }

        public static void ConsultaItem()
        {
            Console.Write("Qual item gostaria de verificar: ");
            var itemConsulta = int.Parse(Console.ReadLine());

            var existeItem = _fila.ConsultaItem(itemConsulta);

            if (existeItem)
                Console.WriteLine($"O item {itemConsulta} existe na fila.\n");
            else
                Console.WriteLine($"O item {itemConsulta} não exite na fila.\n");
        }

        public static void Limpar()
        {

            var filaVazia = _fila.VerificaFilaVazia();

            if (filaVazia)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"A fila está vazia.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                _fila.Limpar();

                ImprimeQtdItens();
            }
        }

        public static void OpcoesMenu()
        {
            _opcoesMenu = new string[] { "########################", "[1] Entrar na fila", "[2] Remover da fila", "[3] Ver quem está na vez", "[4] Consultar item", "[5] Limpar", "[6] Sair", "########################" };

            Console.WriteLine("Qual ação você deseja realizar?\n ");

            foreach (var opcao in _opcoesMenu)
                Console.WriteLine(opcao);

            Console.Write("-> ");

        }

        public static void EscolhaUsuario(string escolhaUsuario)
        {
            Console.Clear();

            switch (escolhaUsuario)
            {
                case "1":
                    Enfileirar();
                    break;
                case "2":
                    Desenfileirar();
                    break;
                case "3":
                    VerPrimeiroItem();
                    break;
                case "4":
                    ConsultaItem();
                    break;
                case "5":
                    Limpar();
                    break;
                default:
                    break;
            }
        }

        private static void ImprimeQtdItens()
        {
            Console.WriteLine($"A quandidade de itens presente na fila é: {_fila.Quantidade}\n");
        }
    }
}