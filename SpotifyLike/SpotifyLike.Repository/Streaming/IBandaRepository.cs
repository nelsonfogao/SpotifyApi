using SpotifyLike.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Streaming
{
    public interface IBandaRepository
    {
        Musica GetMusica(Guid idMusica);
    }
}
