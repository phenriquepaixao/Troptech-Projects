using System;
using System.Collections.Generic;
using InstaTech.Dominio;
using InstaTech.Dominio.Repository;

namespace InstaTech.Infra.Data.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private List<Comentario> _listaComentarios { get; }
        public ComentarioRepository()
        {
            _listaComentarios = new List<Comentario>()
            {
                new Comentario(1, "Comentário 1", new DateTime(2021, 3, 18, 12, 43, 3), "usuario1", 10, 1),
                new Comentario(2, "Comentário 2", new DateTime(2022, 9, 2, 8, 30, 52), "usuario2", 20, 2),
                new Comentario(3, "Comentário 3", new DateTime(2022, 5, 14, 23, 11, 10), "usuario3", 30, 3),
                new Comentario(4, "Comentário 1", new DateTime(2021, 3, 18, 12, 43, 3), "usuario1", 10, 1),
                new Comentario(5, "Comentário 2", new DateTime(2022, 9, 2, 8, 30, 52), "usuario2", 20, 2),
                new Comentario(6, "Comentário 3", new DateTime(2022, 5, 14, 23, 11, 10), "usuario3", 30, 3)
            };
        }

        public List<Comentario> BuscaComentarios()
        {
            return _listaComentarios;
        }
        public Comentario BuscaComentarioPorId(int id)
        {
            return _listaComentarios.Find(comentario => comentario.IdComentario == id);
        }

        public List<Comentario> BuscaComentariosPorIdPublicacao(int idPublicacao)
        {
            return _listaComentarios.FindAll(comentario => comentario.IdPublicacao == idPublicacao);
        }

    }
}