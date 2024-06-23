using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BandaRepository : IBandaRepository
    {
        private static List<Banda> Bandas { get; set; } = new List<Banda>();

        public BandaRepository()
        {

        }

        public void Save(Banda banda)
        {
            banda.Id = Guid.NewGuid();
            Bandas.Add(banda);
        }

        public Banda GetBanda(Guid id)
        {
            return Bandas.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Banda> GetBandas()
        {
            return Bandas;
        }

        public void Update(Banda banda)
        {
            Bandas.Remove(banda);
            Bandas.Add(banda);
        }

        public void Remove(Banda banda)
        {
            Bandas.Remove(banda);
        }
    }
}
