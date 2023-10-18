using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

public class Appel
{
    public List<Etudiant> ListeEtudiants { get; set; }
    public List<Etudiant> ListeEtudiantsAbsents { get; set; }
    public DateTime DateAppel { get; set; }
    public string PeriodeStatistiques { get; set; }

    public void SaisirPresence()
    {
        /* Console.WriteLine($"Appel du {DateAppel}"); */
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
            etudiant.EstPresent = (reponse == "o");
        }
    }

    public void AfficherAbsents()
    {
        Console.WriteLine("Les étudiants absents sont :\n");
        foreach (var etudiantAbsent in ListeEtudiants.Where(e => !e.EstPresent))
        {
            Console.WriteLine($"\t- {etudiantAbsent.nom}");
        }
    }

    public void EnregistrerDonneesEnJson()
    {
        var jsonData = JsonConvert.SerializeObject(this);
        File.WriteAllText("appel.json", jsonData);
    }
}
