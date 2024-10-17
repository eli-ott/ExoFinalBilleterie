using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{
    internal class Billet
    {
        public int Place { get; set; }
        public Client Client { get; set; }
        public Evenement Evenement { get; set; }
        public string TypePlace { get; set; }

        public Billet(int place, Client client, Evenement evenement, string typePlace)
        {
            Place = place;
            Client = client;
            Evenement = evenement;
            TypePlace = typePlace;
        }
    }
}
