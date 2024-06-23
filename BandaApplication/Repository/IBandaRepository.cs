using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBandaRepository
    {
        void Save(Banda banda);

        Banda GetBanda(Guid id);

        List<Banda> GetBandas();

        void Update(Banda banda);

        void Remove(Banda banda);
    }
}
