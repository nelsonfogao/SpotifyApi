using Domain;

namespace BandaApplication
{
    public class BandaRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Album> Albums { get; set; }
    }
}
