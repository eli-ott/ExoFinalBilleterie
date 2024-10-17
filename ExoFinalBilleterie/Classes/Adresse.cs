using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{

    internal class Adresse
    {
        public string Rue { get; set; }
        public string Ville { get; set; }

        public Adresse(string rue, string ville) {
            Rue = rue;
            Ville = ville;
        }
    }
}
