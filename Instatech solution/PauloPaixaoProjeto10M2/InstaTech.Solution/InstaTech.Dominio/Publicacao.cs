using System;

namespace InstaTech.Dominio
{
    public class Publicacao
    {
        public int IdPublicacao { get; }
        public string TituloPublicacao { get; }
        public DateTime DataPublicacao { get; set;}
        public string UsuarioPublicacao { get; }
        public long QuantidadeCurtidasPublicacao { get; set;}
        public Publicacao(int idPublicacao, string tituloPublicacao, DateTime dataPublicacao, string usuarioPublicacao, long quantidadeCurtidasPublicacao)
        {
            IdPublicacao = idPublicacao;
            TituloPublicacao = tituloPublicacao;
            DataPublicacao = dataPublicacao;
            UsuarioPublicacao = usuarioPublicacao;
            QuantidadeCurtidasPublicacao = quantidadeCurtidasPublicacao;
        }

    }
}