using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace BandaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaService service;

        public MusicaController(IMusicaService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult ObterMusica(Guid id)
        {
            var musica = this.service.ObterMusica(id);

            if (musica == null)
                return NotFound();

            var response = MusicaParaResponse(musica);

            return Ok(response);

        }

        private MusicaResponse MusicaParaResponse(Musica musicaCriada)
        {
            var response = new MusicaResponse()
            {
                Id = musicaCriada.Id,
                Nome = musicaCriada.Nome,
                Duracao = musicaCriada.Duracao
            };

            return response;
        }
    }
}
