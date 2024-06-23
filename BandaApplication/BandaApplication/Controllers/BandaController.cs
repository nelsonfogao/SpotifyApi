using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace BandaApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private readonly IBandaService service;

        public BandaController(IBandaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Criar(BandaRequest request)
        {
            if (ModelState.IsValid == false) return BadRequest();
            var banda = new Banda()
            {
                Id = new Guid(),
                Nome = request.Nome,
                Descricao = request.Descricao,
                Albums = request.Albums,
            };


            var bandaCriada = this.service.CriarBanda(banda);
            BandaResponse response = BandaParaResponse(bandaCriada);

            return Created($"/banda/{response.Id}", response);

        }

        [HttpGet("{id}")]
        public IActionResult ObterBanda(Guid id)
        {
            var banda = this.service.ObterBanda(id);

            if (banda == null)
                return NotFound();

            var response = BandaParaResponse(banda);

            return Ok(response);

        }

        [HttpGet()]
        public IActionResult ObterBandas()
        {
            var bandas = this.service.ObterBandas();

            if (bandas == null)
                return NotFound();

            var response = bandas;

            return Ok(response);

        }

        private BandaResponse BandaParaResponse(Banda bandaCriada)
        {
            var response = new BandaResponse()
            {
                Id = bandaCriada.Id,
                Nome = bandaCriada.Nome,
                Descricao = bandaCriada.Descricao,
                Albums = bandaCriada.Albums,
            };

            return response;
        }

    }
}
