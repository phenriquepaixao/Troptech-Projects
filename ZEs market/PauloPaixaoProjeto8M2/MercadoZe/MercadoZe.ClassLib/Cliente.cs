using System;

namespace MercadoZe.ClassLib
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double PontosFidelidade { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"CPF: {Cpf}\nNome: {Nome}\nData de nascimento: {DataNascimento}\nPontos de fidelidade: {PontosFidelidade}\nEndereco\nRua: {Endereco.Rua} - Número: {Endereco.Numero} - Bairro: {Endereco.Bairro} - Cep: {Endereco.Cep} - Complemento: {Endereco.Complemento}";
        }
    }
}