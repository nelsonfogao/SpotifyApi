using Domain;

namespace BandaApplication
{
    public class BandaRequest
    {
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public List<Album> Albums { get; set; }
    }
}
