using System;

namespace ContaDeLuz.Dominio
{
    public class Conta
    {
        public int NumeroLeitura { get; set; }
        public DateTime DataLeitura { get; set; }
        public long Kw { get; set; }
        public double ValorPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double MediaConsumo { get; set; }

        public Conta(int numeroLeitura, DateTime dataLeitura, long kw, double valorPagamento, DateTime dataPagamento, double mediaConsumo)
        {
            this.NumeroLeitura = numeroLeitura;
            this.DataLeitura = dataLeitura;
            this.Kw = kw;
            this.ValorPagamento = valorPagamento;
            this.DataPagamento = dataPagamento;
            this.MediaConsumo = mediaConsumo;
        }

        public override string ToString()
        {
            return $"Número da leitura: {NumeroLeitura}\nData da Leitura: {DataLeitura}\nKW: {Kw}\nValor do pagamento: {ValorPagamento}\nData do pagamento: {DataPagamento}\nMedia de consumo: {MediaConsumo}";
        }
    }
}