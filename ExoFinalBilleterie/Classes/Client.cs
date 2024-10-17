using ExoFinalBilleterie.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{
    internal class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Addresse { get; set; }
        public int Age { get; set; }
        public int Tel { get; set; }
        public List<Billet> Billets { get; set; } = new List<Billet>();

        public Client(string nom, string prenom, string addresse, int age, int tel)
        {
            Nom = nom;
            Prenom = prenom;
            Addresse = addresse;
            Age = age;
            Tel = tel;
        }

        public void AjouterBillet(Billet billet)
        {
            Billets.Add(billet);
        }
    }
}
