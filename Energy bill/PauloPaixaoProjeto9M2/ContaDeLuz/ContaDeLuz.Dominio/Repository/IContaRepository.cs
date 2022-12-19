using System;

namespace ContaDeLuz.Dominio.Repository
{
    public interface IContaRepository
    {
        void CadastraConta(int numeroLeitura, DateTime dataLeitura, long kw, double valorPagamento, DateTime dataPagamento, double mediaConsumo);
        Conta BuscarMesAnoConta(int mesLeitura, int anoLeitura);
    }
}