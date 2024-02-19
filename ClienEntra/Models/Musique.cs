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

        public override bool Equals(object obj)
        {
            return obj is Musique musique &&
                   Idmusique == musique.Idmusique &&
                   Titre == musique.Titre &&
                   Genre == musique.Genre &&
                   EqualityComparer<Chanteur>.Default.Equals(Chanteur, musique.Chanteur);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Idmusique, Titre, Genre, Chanteur);
        }
    }
}
