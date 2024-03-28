using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain
{

    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Decimal Duracao { get; set; }

    }
}
