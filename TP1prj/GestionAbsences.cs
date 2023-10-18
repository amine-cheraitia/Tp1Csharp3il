using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GestionAbsences
{
    public List<Etudiant> ListeEtudiants { get; set; }
    public List<Etudiant> ListeEtudiantsAbsents { get; set; }

    public GestionAbsences()
    {
        ListeEtudiants = new List<Etudiant>
        {
            new Etudiant { nom = "Brice", mode="FA" },
            new Etudiant { nom = "Amine", mode="FE" },
            new Etudiant { nom = "Oussama", mode="FA" },
            new Etudiant { nom = "Khalil", mode="FA" },
            new Etudiant { nom = "Emnna", mode="FE" },
            new Etudiant { nom = "Mouadhafer", mode="FA" },
            new Etudiant { nom = "Claudia", mode="FE" }
        };

        ListeEtudiantsAbsents = new List<Etudiant>();
    }

    public void VerifierPresences()
    {
        Console.Clear();
        foreach (var etudiant in ListeEtudiants)
        {
            Console.WriteLine($"Est-ce que {etudiant.nom} est présent(e) ? O/N");
            var reponse = Console.ReadLine().ToLower();
            Console.Clear();
            while (reponse != "n" && reponse != "o")
            {
                Console.WriteLine("La réponse est incorrecte, veuillez choisir O ou N comme réponse.");
                Console.WriteLine($"Est-ce que {etudiant.nom} est présent(e) ? O/N");
                reponse = Console.ReadLine().ToLower();
                Console.Clear();
            }

            if (reponse == "n")
            {
                etudiant.EstPresent = false;
                ListeEtudiantsAbsents.Add(etudiant);
            }
            else
            {
                etudiant.EstPresent = true;
            }
            Console.WriteLine("la taille de ma liste est de " + ListeEtudiantsAbsents.Count());
        }
    }

    public void AfficherEtudiantsAbsents()
    {
        Console.WriteLine("la taille de ma liste est de " + ListeEtudiantsAbsents.Count());
        Console.WriteLine("Les étudiants absents sont :\n");
        int longueurMaxNom = ListeEtudiantsAbsents.Max(e => e.nom.Length) + 2; // Trouve la longueur maximale du nom
        foreach (var etudiantAbsent in ListeEtudiantsAbsents)
        {

            string nomAjuste = etudiantAbsent.nom.PadRight(longueurMaxNom);
            Console.WriteLine($"\t- {nomAjuste} - {etudiantAbsent.mode}");

        }
    }
}
