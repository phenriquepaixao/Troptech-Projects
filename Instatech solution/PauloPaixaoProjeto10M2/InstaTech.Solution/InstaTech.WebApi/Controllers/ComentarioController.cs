using System.Collections.Generic;
using InstaTech.Dominio;
using InstaTech.Dominio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstaTech.WebApi.Controllers
{
    [ApiController]
    [Route("comentario")]
    public class ComentarioController : ControllerBase
    {
        private IComentarioRepository _comentarioRepo { get; }

        public ComentarioController(IComentarioRepository comentarioRepo)
        {
            this._comentarioRepo = comentarioRepo;
        }

        [HttpPost]
        public List<Comentario> PostAdicionarComentario([FromBody] Comentario novoComentario)
        {
            _comentarioRepo.BuscaComentarios().Add(novoComentario);
            return _comentarioRepo.BuscaComentarios();
        }

        [HttpGet]
        [Route("{id}")]
        public Comentario GetComentarioPorId(int id)
        {
            return _comentarioRepo.BuscaComentarioPorId(id);
        }

        [HttpGet]
        [Route("publicacao/{idPublicacao}")]
        public List<Comentario> GetComentarioPorIdPublicacao(int idPublicacao)
        {
            return _comentarioRepo.BuscaComentariosPorIdPublicacao(idPublicacao);
        }

        [HttpPut]
        [Route("{id}")]
        public Comentario PutCurtirComentario(int id)
        {
            var comentarioBuscado = _comentarioRepo.BuscaComentarioPorId(id);
            comentarioBuscado.QuantidadeCurtidasComentario += 1;
            return comentarioBuscado;
        }

        [HttpDelete]
        [Route("{id}")]
        public List<Comentario> DeleteDeletarComentario(int id)
        {
            var comentarioBuscado = _comentarioRepo.BuscaComentarioPorId(id);
            _comentarioRepo.BuscaComentarios().Remove(comentarioBuscado);
            
            return _comentarioRepo.BuscaComentarios();
        }

    }
}