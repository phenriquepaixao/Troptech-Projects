using System;
using System.Collections.Generic;
using InstaTech.Dominio;
using InstaTech.Dominio.Repository;

namespace InstaTech.Infra.Data.Repository
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private List<Publicacao> _listaPublicacoes { get; }

        public PublicacaoRepository()
        {
            _listaPublicacoes = new List<Publicacao>()
            {
                new Publicacao(1, "Titulo publicacao 1", new DateTime(2021, 3, 18, 12, 43, 3), "usuario1", 300),
                new Publicacao(2, "Titulo publicacao 2", new DateTime(2022, 9, 2, 8, 30, 52), "usuario2", 400),
                new Publicacao(3, "Titulo publicacao 3", new DateTime(2022, 5, 14, 23, 11, 10), "usuario3", 500)
            };
        }

        public List<Publicacao> BuscaPublicacoes()
        {
            return _listaPublicacoes;
        }

        public Publicacao BuscaPublicacaoPorId(int id)
        {
            return _listaPublicacoes.Find(publicacao => publicacao.IdPublicacao == id);
        }
    }
}