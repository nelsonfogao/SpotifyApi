using SpotifyLike.Domain.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Transacao
{
    public interface IPlanoRepository
    {
        Plano GetPlanoById(Guid planoId);
    }
}
