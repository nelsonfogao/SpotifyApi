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
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;

        public BandaService(IBandaRepository bandaRepository)
        {
            this.bandaRepository = bandaRepository;
        }

        public Banda CriarBanda(Banda banda)
        {
            this.bandaRepository.Save(banda);

            return banda;

        }

        public Banda ObterBanda(Guid id)
        {
            var banda = this.bandaRepository.GetBanda(id);
            return banda;
        }
        public List<Banda> ObterBandas()
        {
            var bandas = this.bandaRepository.GetBandas();
            return bandas;
        }
    }
}
