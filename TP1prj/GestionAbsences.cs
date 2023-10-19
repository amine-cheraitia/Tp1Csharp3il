using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GestionAbsences
{
    public List<Etudiant> ListeEtudiants { get; set; }
    public List<Etudiant> ListeAlternant { get; set; }
    public List<Etudiant> ListeEtudiantsAbsents { get; set; }

    public GestionAbsences()
    {
        ListeAlternant = new List<Etudiant>();
        ListeEtudiants = new List<Etudiant>();
        ListeEtudiantsAbsents = new List<Etudiant>();
    }
    //charger la liste des étudiants
    public void ChargerListeEtudiantsDepuisFichier(string cheminFichier)
    {
        if (File.Exists(cheminFichier))
        {
            string jsonData = File.ReadAllText(cheminFichier);
            ListeEtudiants = JsonConvert.DeserializeObject<List<Etudiant>>(jsonData);
        }
        else
        {
            Console.WriteLine("Le fichier JSON n'existe pas.");
        }
    }
    //charger ma mosye des absents
    public void ChargerListeAbsentsDepuisFichier(string cheminFichier)
    {
        if (File.Exists(cheminFichier))
        {
            string jsonData = File.ReadAllText(cheminFichier);
            ListeEtudiantsAbsents = JsonConvert.DeserializeObject<List<Etudiant>>(jsonData);
        }
        else
        {
            Console.WriteLine("Le fichier JSON des absents n'existe pas.");
        }
    }
    //sauvegarder les absents dans un fichier json
    public void SauvegarderListeAbsentsDansFichier(string cheminFichier)
    {
        string jsonData = JsonConvert.SerializeObject(ListeEtudiantsAbsents, Formatting.Indented);
        File.WriteAllText(cheminFichier, jsonData);
        Console.WriteLine("Liste des absents sauvegardée dans un fichier JSON.");
    }
    public void VerifierPresences()
    {
        //vider le fichier absence 
        File.WriteAllText("absents.json", string.Empty);
        ListeEtudiantsAbsents = new List<Etudiant>();
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
                if (etudiant.mode == "FA")
                {
                    ListeAlternant.Add(etudiant);
                }
                etudiant.EstPresent = true;
            }


            /*  Console.WriteLine("la taille de ma liste est de " + ListeEtudiantsAbsents.Count()); */

        }
        if (ListeAlternant.Count > 0)
        {
            Console.WriteLine("il est nécessaire que les étudiants FA suivants signent :");
            int longueurMaxNom = ListeAlternant.Max(e => e.nom.Length) + 2; // Trouve la longueur maximale du nom
            foreach (var etudiantAlternant in ListeAlternant)
            {

                string nomAjuste = etudiantAlternant.nom.PadRight(longueurMaxNom);
                Console.WriteLine($"\t- {nomAjuste} - {etudiantAlternant.mode}");

            }
            Console.ReadKey();
            Console.Clear();

        }
        SauvegarderListeAbsentsDansFichier("absents.json");

    }

    public void AfficherEtudiantsAbsents()
    {
        Console.Clear();
        if (ListeEtudiantsAbsents.Count > 0)
        {

            Console.WriteLine("Les étudiants absents sont :\n");
            int longueurMaxNom = ListeEtudiantsAbsents.Max(e => e.nom.Length) + 2; // Trouve la longueur maximale du nom
            foreach (var etudiantAbsent in ListeEtudiantsAbsents)
            {

                string nomAjuste = etudiantAbsent.nom.PadRight(longueurMaxNom);
                Console.WriteLine($"\t- {nomAjuste} - {etudiantAbsent.mode}");

            }
        }
        else
        {
            Console.WriteLine("La liste des absences est actuellement vide. Avez-vous pensé à vérifier qui est absent en classe ");
        }
    }
}
