using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienEntra.Models
{
    public class Musique
    {
        public int Idmusique { get; set; }

        public string Titre { get; set; }

        public string Genre { get; set; }
        public Chanteur Chanteur { get; set; }


    }
}
