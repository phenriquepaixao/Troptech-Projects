using System.Collections.Generic;

namespace InstaTech.Dominio.Repository
{
    public interface IPublicacaoRepository
    {
        List<Publicacao> BuscaPublicacoes();
        Publicacao BuscaPublicacaoPorId(int id);
    }
}