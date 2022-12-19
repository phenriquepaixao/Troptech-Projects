using System.Collections.Generic;

namespace InstaTech.Dominio.Repository
{
    public interface IComentarioRepository
    {
        List<Comentario> BuscaComentarios();
        Comentario BuscaComentarioPorId(int id);
        List<Comentario> BuscaComentariosPorIdPublicacao(int id);
    }
}