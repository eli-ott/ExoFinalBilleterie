using ExoFinalBilleterie.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{
    internal class Evenement
    {
        public string Nom { get; set; }
        public Lieu Lieu { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Heure { get; set; }
        public int NbPlaces { get; set; }
        public List<Billet> Billets { get; set; } = new List<Billet>();

        public Evenement(string nom, Lieu lieu, DateOnly date, TimeOnly heure)
        {
            Nom = nom;
            Lieu = lieu;
            Date = date;
            Heure = heure;
        }

        public void ReserverBillet(Client client, string typePlace)
        {
            if (Lieu.Capacite > NbPlaces)
            {
                Billet billet = new Billet(NbPlaces + 1, client, this, typePlace);
                Billets.Add(billet);

                client.AjouterBillet(billet);
                NbPlaces++;

                Console.WriteLine($"Votre billet à été reservé - Place n°{billet.Place}");
                Console.WriteLine($"Il reste {Lieu.Capacite - NbPlaces} places pour cet évenement");
            }
            else
            {
                Console.WriteLine("Il ne reste plus de places pour cet évenement");
            }
        }

        public string GetListeBillets()
        {
            string listeBillets = "";

            foreach (Billet billet in Billets)
            {
                listeBillets += $"{billet.Place}, ";
            }

            return listeBillets;
        }

        public string GetListeBilletsDispo()
        {
            string listeBillets = "";
            int billetsRestant = Lieu.Capacite - NbPlaces;

            for (int i = NbPlaces; i <= Lieu.Capacite; i++)
            {
                listeBillets += $"{i},";
            }

            return listeBillets;
        }

        public override string ToString()
        {
            return @$"{Nom} le {Date.ToString()} à {Heure.ToString()} à {Lieu.ToString()}
Billets disponibles :
{GetListeBilletsDispo()}";
        }
    }
}

