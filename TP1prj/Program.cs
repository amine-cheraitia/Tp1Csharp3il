using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var listeEtudiants = new List<Etudiant>
        {
            new Etudiant { Nom = "Brice", Statut = "FE" },
            new Etudiant { Nom = "Amine", Statut = "FA" },
            // Ajoutez d'autres étudiants ici
        };

        var appel = new Appel
        {
            ListeEtudiants = listeEtudiants,
            DateAppel = DateTime.Now,
            PeriodeStatistiques = "Période actuelle",
        };

        var authentification = new Authentification("votre_mot_de_passe");

        Console.WriteLine("Veuillez entrer votre mot de passe :");
        var motDePasseSaisi = Console.ReadLine();

        if (authentification.Authentifier(motDePasseSaisi))
        {
            var menu = new Menu();

            while (true)
            {
                menu.AfficherMenu();
            }
        }
        else
        {
            Console.WriteLine("Mot de passe incorrect. L'application se ferme.");
        }
    }
}
