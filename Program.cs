using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public class Chanson
        {
            public string Titre;
            public string Artiste;
            public string Album;
            public int AnneeDeSortie;
            public int DureeEnSecondes;
            public string IdentifiantUnique;

            public Chanson(string titre, string artiste, string album, int anSortie, int dureeEnSec, string id)
            { 
                this.Titre = titre;
                this.Artiste = artiste;
                this.Album = album;
                this.AnneeDeSortie = anSortie;
                this.DureeEnSecondes = dureeEnSec;
                this.IdentifiantUnique = id;
            }
        }

        public class BibliothequeMusicale
        {
            public List<Chanson> ChansonList = new List<Chanson>();
            
            public void AjouterChanson(Chanson element)
            {
                ChansonList.Add(element);
                Console.WriteLine($"Vous avez ajouté : {element.Titre} de {element.Artiste} de l'album {element.Album} en {element.AnneeDeSortie} qui dure {element.DureeEnSecondes}sec. Son identifiant est {element.IdentifiantUnique}\n");
            }

            public void SupprimerChanson(string id)
            {
                foreach (Chanson chant in ChansonList)
                {
                    if (chant.IdentifiantUnique == id)
                    {
                        ChansonList.Remove(chant);
                        break;
                    }
                }

                Console.WriteLine("\nNouvelle liste suite à suppression :");

                foreach (Chanson element in ChansonList)
                {
                    Console.WriteLine($"{element.Titre} de {element.Artiste} de l'album {element.Album} en {element.AnneeDeSortie} qui dure {element.DureeEnSecondes}sec. Son identifiant est {element.IdentifiantUnique}");
                }

            }
            public List<Chanson> RecherhcerChanson(string titre)
            {
                bool test = true;
                
                List<Chanson> resultat = new List<Chanson>();
                foreach (Chanson element in ChansonList)
                {
                    if (element.Titre == titre)
                    {
                        if (test)
                        {
                            Console.WriteLine("\nVoici la liste que vous avez rechercher selon le titre :");
                            test = false;
                        }
                        resultat.Add(element);
                        Console.WriteLine($"{element.Titre} de {element.Artiste} de l'album {element.Album} en {element.AnneeDeSortie} qui dure {element.DureeEnSecondes}sec. Son identifiant est {element.IdentifiantUnique}");
                    }
                }
                return resultat;
            }
            public List<Chanson> RecherhcerChanson(int anSortie)
            {
                bool test = true;
                
                List<Chanson> resultat = new List<Chanson>();
                foreach (Chanson chant in ChansonList)
                {
                    if (chant.AnneeDeSortie == anSortie)
                    {
                        if (test)
                        {
                            Console.WriteLine("\nVoici la liste que vous avez rechercher selon l'année :");
                            test = false;
                        }
                        resultat.Add(chant);
                        Console.WriteLine($"{chant.Titre} de {chant.Artiste} de l'album {chant.Album} en {chant.AnneeDeSortie} qui dure {chant.DureeEnSecondes}sec. Son identifiant est {chant.IdentifiantUnique}");
                    }
                }
                return resultat;
            }
        }
        static void Main(string[] args)
        {
            BibliothequeMusicale bibliothequeChansons = new BibliothequeMusicale();

            Chanson chanson1 = new Chanson("Soleil", "Paul", "Sunshine", 2023, 300, "ID1234");
            bibliothequeChansons.AjouterChanson(chanson1);

            Chanson chanson2 = new Chanson("Lune", "Pierre", "Sunshine", 2023, 250, "ID1235");
            bibliothequeChansons.AjouterChanson(chanson2);

            Chanson chanson3 = new Chanson("Au bord de la route", "Gisèle", "Auto chant", 2020, 211, "ID1236");
            bibliothequeChansons.ChansonList.Add(chanson3);

            Chanson chanson4 = new Chanson("Sur le chemin", "Jessica", "The way", 2010, 163, "ID1237");
            bibliothequeChansons.ChansonList.Add(chanson4);

            Chanson chanson5 = new Chanson("Comme hier", "Frank", "Yesterday", 1995, 203, "ID1238");
            bibliothequeChansons.ChansonList.Add(chanson5);

            Console.WriteLine("Voici ma liste de chanson :");

            for (int i = 0; i < bibliothequeChansons.ChansonList.Count; i++)
            {
                Console.WriteLine(bibliothequeChansons.ChansonList[i].Titre);
            }

            foreach (Chanson element in bibliothequeChansons.ChansonList)
            {
                Console.WriteLine(element.Artiste);
            }

            List<Chanson> chansonsIn = bibliothequeChansons.RecherhcerChanson("Lune");
            bibliothequeChansons.RecherhcerChanson(2023);

            bibliothequeChansons.SupprimerChanson("ID1237");

        }
    }
}