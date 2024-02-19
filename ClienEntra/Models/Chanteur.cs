using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienEntra.Models
{
    public class Chanteur
    {
        public int Idchanteur { get; set; }
        public string Nomchanteur { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Chanteur chanteur &&
                   Idchanteur == chanteur.Idchanteur &&
                   Nomchanteur == chanteur.Nomchanteur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Idchanteur, Nomchanteur);
        }
    }
}
