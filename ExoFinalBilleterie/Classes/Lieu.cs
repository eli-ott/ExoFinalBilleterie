using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{
    internal class Lieu : Adresse
    {
        public int Capacite { get; set; }

        public Lieu(string rue, string ville) : base(rue, ville) { }
        public Lieu(int capacite, string rue, string ville) : this(rue, ville)
        {
            this.Capacite = capacite;
        }

        public override string ToString()
        {
            return Ville;
        }
    }
}
