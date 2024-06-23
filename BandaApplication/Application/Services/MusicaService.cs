using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository musicaRepository;

        public MusicaService(IMusicaRepository musicaRepository)
        {
            this.musicaRepository = musicaRepository;
        }

        public Musica ObterMusica(Guid id)
        {
            var musica = this.musicaRepository.GetMusica(id);
            return musica;
        }
    }
}
