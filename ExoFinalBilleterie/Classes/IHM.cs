using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Classes
{
    internal class IHM
    {
        public int Etape { get; set; } = 0;
        public List<Client> Clients { get; set; } = new();
        public List<Evenement> Evenements { get; set; } = new();
        public List<Lieu> Lieux { get; set; } = new();

        public IHM()
        {
            Lieu lieu1 = new Lieu(250, "test", "test");
            Lieu lieu2 = new Lieu(150, "test2", "test2");
            Evenement event1 = new Evenement("concert 1", lieu1, new DateOnly(), new TimeOnly());
            Evenement event2 = new Evenement("concert 2", lieu2, new DateOnly(), new TimeOnly());

            Lieux.Add(lieu1);
            Lieux.Add(lieu2);
            Evenements.Add(event1);
            Evenements.Add(event2);
        }

        public void Start()
        {
            do
            {
                switch (Etape)
                {
                    case 0:
                        Intro();
                        break;
                    case 1:
                        Client client = CreerClient();
                        Clients.Add(client);

                        ReserverEvenement(client);
                        break;
                    case 2:
                        //TODO quand le client à déjà reserver
                        break;
                }
            } while (true);
        }

        public void Intro()
        {
            Console.WriteLine("Deja client ? Oui - Non");
            string choix = Console.ReadLine();

            switch (choix.ToLower())
            {
                case 'oui':
                    break;
                case "non":
                    Etape = 1;
                    break;
            }
        }
        public Client CreerClient()
        {
            Console.WriteLine("Bonjour, entrez votre prénom :");
            string nom = Console.ReadLine();
            Console.WriteLine("Votre nom :");
            string prenom = Console.ReadLine();
            Console.WriteLine("Votre adresse :");
            string adresse = Console.ReadLine();
            Console.WriteLine("Votre age :");
            int age;
            do
            {
                string reponseAge = Console.ReadLine();
                if (int.TryParse(reponseAge, out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un chiffre");
                }
            } while (true);
            Console.WriteLine("Votre numéro de téléphone");
            int tel;
            do
            {
                string reponseTel = Console.ReadLine();
                if (int.TryParse(reponseTel, out tel))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer votre numéro avec le format : XXXXXXXXXX");
                }
            } while (true);

            return new Client(nom, prenom, adresse, age, tel);
        }

        public void ReserverEvenement(Client client)
        {
            Console.WriteLine("Liste des concerts disponibles : \n");
            Console.WriteLine(GetListeEvenement());

            int eventIndex;
            Console.WriteLine("Choisissez un évenement :");
            int.TryParse(Console.ReadLine(), out eventIndex);

            Evenement evenement = Evenements[eventIndex - 1];

            Console.WriteLine(evenement.ToString());

            Console.WriteLine("Quel type de billet voulez vous ? (Standard, gold, VIP)");
            string choix = Console.ReadLine() ?? "Standard";

            evenement.ReserverBillet(client, choix);

            //TODO Faire qu'on puisse voir ses billets ou en reserver de nouveau
            //Console.WriteLine($"1 - Réserver à nouveau un billet" +
            //        $"2 - Voir mes billets");
            //const choix = Console.ReadLine();
        }

        public string GetListeEvenement()
        {
            string listeBillets = "";

            int index = 0;
            foreach (Evenement evenement in Evenements)
            {
                index++;

                listeBillets = listeBillets +
                    $"{index} - {evenement.Nom}\n";
            }
            return listeBillets;
        }
    }
}
