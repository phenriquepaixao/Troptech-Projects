using System;

namespace PauloPaixaoProjeto1M2
{
    public class Queue
    {
        //FIFO - First in First out
        private int[] _fila;
        private int _qtdItensFila;
        private int _tamanhoFila;

        public int Quantidade { get { return _fila.Length; } }
        public int Primeiro { get { return _fila[0]; } }

        public Queue()
        {
            _fila = new int[0];
        }

        public void Enfileirar(int itemEnfileirar)
        {
            _qtdItensFila = Quantidade;
            _qtdItensFila++;

            var tempFila = new int[_qtdItensFila];

            for (int i = 0; i < Quantidade; i++)
                tempFila[i] = _fila[i];

            _fila = tempFila;

            tempFila[_qtdItensFila - 1] = itemEnfileirar;
        }
        public int Desenfileirar()
        {
            _tamanhoFila = Quantidade - 1;

            var tempFila = new int[_tamanhoFila];

            var itemDesenfileirar = _fila[0];

            for (int i = 0; i < _tamanhoFila; i++)
                tempFila[i] = _fila[i + 1];

            _fila = tempFila;

            return itemDesenfileirar;
        }

        public void Limpar()
        {
            _fila = new int[0];
        }

        public bool ConsultaItem(int itemConsulta)
        {
            foreach (var itemNaFila in _fila)
            {
                if (itemNaFila == itemConsulta)
                    return true;
            }
            return false;
        }

        public bool VerificaFilaVazia()
        {

            if (Quantidade == 0)
                return true;
            else
                return false;

        }


    }
}