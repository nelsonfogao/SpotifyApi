

using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MusicaRepository : IMusicaRepository
    {
        private static List<Musica> Musicas { get; set; } = new List<Musica>();
        private static List<Banda> Bandas { get; set; } = new List<Banda>();
        private readonly IBandaRepository bandaRepository;

        public MusicaRepository(IBandaRepository bandaRepository)
        {
            this.bandaRepository = bandaRepository;
        }


        public Musica GetMusica(Guid id)
        {
            Bandas = bandaRepository.GetBandas();
            Musicas = Bandas.SelectMany(banda => banda.Albums.SelectMany(album => album.Musicas)).ToList();
            return Musicas.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
