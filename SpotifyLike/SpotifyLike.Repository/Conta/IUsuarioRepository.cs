using SpotifyLike.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Conta
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuario(Guid id);
        void Remove(Usuario usuario);
        void Save(Usuario usuario);
        void Update(Usuario usuario);
    }
}
