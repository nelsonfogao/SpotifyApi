using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IBandaService
    {
        Banda CriarBanda(Banda banda);

        Banda ObterBanda(Guid id);

        List<Banda> ObterBandas();
    }
}
