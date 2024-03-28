using Domain;

namespace BandaApplication
{
    public class BandaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public List<Album> Albums { get; set; }
    }
}
