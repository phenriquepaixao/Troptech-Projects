using System.Collections.Generic;
using InstaTech.Dominio;
using InstaTech.Dominio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstaTech.WebApi.Controllers
{
    [ApiController]
    [Route("publicacao")]
    public class PublicacaoController : ControllerBase
    {
        private IPublicacaoRepository _publicacaoRepo;

        public PublicacaoController(IPublicacaoRepository publicacaoRepository)
        {
            this._publicacaoRepo = publicacaoRepository;
        }

        [HttpPost]
        public List<Publicacao> PostAdicionarPublicacao([FromBody] Publicacao novaPublicacao)
        {
            _publicacaoRepo.BuscaPublicacoes().Add(novaPublicacao);
            return _publicacaoRepo.BuscaPublicacoes();
        }

        [HttpGet]
        [Route("{id}")]
        public Publicacao GetBuscarPublicacaoPorId(int id)
        {
            return _publicacaoRepo.BuscaPublicacaoPorId(id);
        }

        [HttpPut]
        public Publicacao PutAtualizarDataPublicacao([FromBody] Publicacao publicacaoParaAtualizar)
        {
            var publicacaoBuscada = _publicacaoRepo.BuscaPublicacaoPorId(publicacaoParaAtualizar.IdPublicacao);
            publicacaoBuscada.DataPublicacao = publicacaoParaAtualizar.DataPublicacao;
            return publicacaoBuscada;
        }

        [HttpPut]
        [Route("{id}")]
        public Publicacao PutCurtirPublicacao(int id)
        {
            var publicacaoBuscada = _publicacaoRepo.BuscaPublicacaoPorId(id);
            publicacaoBuscada.QuantidadeCurtidasPublicacao += 1;
            return publicacaoBuscada;
        }

        [HttpDelete]
        [Route("{id}")]
        public List<Publicacao> DeleteDeletarPublicacao(int id)
        {
            var publicacaoBuscada = _publicacaoRepo.BuscaPublicacaoPorId(id);
            _publicacaoRepo.BuscaPublicacoes().Remove(publicacaoBuscada);
            return _publicacaoRepo.BuscaPublicacoes();
        }

    }
}