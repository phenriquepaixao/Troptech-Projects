using System;

namespace InstaTech.Dominio
{
    public class Comentario
    {

        public int IdComentario { get; }
        public string DescricaoComentario { get; }
        public DateTime DataPublicacaoComentario { get; }
        public string UsuarioComentario { get; }
        public long QuantidadeCurtidasComentario { get; set;}
        public int IdPublicacao { get; }
        public Comentario(int idComentario, string descricaoComentario, DateTime dataPublicacaoComentario, string usuarioComentario, long quantidadeCurtidasComentario, int idPublicacao)
        {
            this.IdComentario = idComentario;
            this.DescricaoComentario = descricaoComentario;
            this.DataPublicacaoComentario = dataPublicacaoComentario;
            this.UsuarioComentario = usuarioComentario;
            this.QuantidadeCurtidasComentario = quantidadeCurtidasComentario;
            this.IdPublicacao = idPublicacao;
        }

    }
}