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
    public class MusicaService
    {
        private MusicaRepository musicaRepository;

        public MusicaService(MusicaRepository musicaRepository)
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
