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
        CalculerMoyenneAbsencesEnPourcentage();
        SauvegarderMoyenneAbsencesDansFichier("stat.json");


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
    public void AfficherLalisteEtudiants()
    {
        Console.Clear();
        if (ListeEtudiants.Count > 0)
        {

            Console.WriteLine("Les étudiants sont :\n");
            int longueurMaxNom = ListeEtudiants.Max(e => e.nom.Length) + 2; // Trouve la longueur maximale du nom
            foreach (var etudiant in ListeEtudiants)
            {

                string nomAjuste = etudiant.nom.PadRight(longueurMaxNom);
                Console.WriteLine($"\t- {nomAjuste} - {etudiant.mode}");

            }
        }
        else
        {
            Console.WriteLine("La liste des étudiants est actuellement vide. ");
        }
    }
    //stat
    public double CalculerMoyenneAbsencesEnPourcentage()
    {
        if (ListeEtudiants.Count > 0)
        {
            int nombreAbsents = ListeEtudiantsAbsents.Count;
            int nombreTotal = ListeEtudiants.Count;
            double moyenneAbsences = (double)nombreAbsents / nombreTotal;
            double moyenneAbsencesEnPourcentage = moyenneAbsences * 100.0;
            return Math.Round(moyenneAbsencesEnPourcentage, 2); // Arrondir à 2 chiffres après la virgule
        }
        else
        {
            Console.WriteLine("La liste des étudiants est vide. Impossible de calculer la moyenne des absences.");
            return 0.0;
        }
    }


    //sauvegarde les stat 
    public void SauvegarderMoyenneAbsencesDansFichier(string cheminFichier)
    {
        double moyenneAbsencesPourcentage = CalculerMoyenneAbsencesEnPourcentage();
        int moyenneAbsences = (int)moyenneAbsencesPourcentage; // Convertir en entier
        string jsonData = JsonConvert.SerializeObject(new { MoyenneAbs = moyenneAbsences }, Formatting.Indented);
        File.WriteAllText(cheminFichier, jsonData);

    }


    //lire la stat
    public void LireStatDepuisFichier(string cheminFichier)
    {
        if (File.Exists(cheminFichier))
        {
            try
            {
                string jsonData = File.ReadAllText(cheminFichier);
                dynamic statObject = JsonConvert.DeserializeObject(jsonData);

                double statValue = statObject["MoyenneAbs"].Value; // Assurez-vous d'ajuster la clé en fonction de votre structure JSON

                Console.WriteLine("La moyenne des absences sur le total est de  : " + statValue + "%");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la lecture du fichier stat.json : " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Le fichier stat.json n'existe pas.");
        }
    }



}
