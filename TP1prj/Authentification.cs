// Contenu de Authentification.cs
using System;
using Newtonsoft.Json;
using System.IO;
public class Authentification
{
    private GestionAbsences gestionAbsences;


    private string Utilisateur { get; set; }
    private string MotDePasse { get; set; }


    public Authentification(GestionAbsences gestionAbsence)
    {
        this.gestionAbsences = gestionAbsence;
        ChargerInformationsAuthentificationDepuisFichier("utilisateur.json");

    }
    //
    public void ChargerInformationsAuthentificationDepuisFichier(string cheminFichier)
    {
        if (File.Exists(cheminFichier))
        {
            string jsonData = File.ReadAllText(cheminFichier);
            var authData = JsonConvert.DeserializeObject<AuthData>(jsonData);

            if (authData != null)
            {
                Utilisateur = authData.utilisateur;
                MotDePasse = authData.motDePasse;
            }
        }
        else
        {
            Console.WriteLine("Le fichier JSON d'authentification n'existe pas.");
        }
    }
    //
    public bool Authentifier(string utilisateurSaisi, string motDePasseSaisi)
    {
        return Utilisateur == utilisateurSaisi && MotDePasse == motDePasseSaisi;
    }

    public void tryToAuth()
    {
        Console.WriteLine("Veuillez entrer votre nom d'utilisateur :");
        var utilisateurSaisi = Console.ReadLine();
        Console.WriteLine("Veuillez entrer votre mot de passe :");
        var motDePasseSaisi = Console.ReadLine();

        if (Authentifier(utilisateurSaisi, motDePasseSaisi))
        {
            Console.Clear();
            var menu = new Menu(gestionAbsences);
            while (true)
            {
                menu.AfficherMenu();
            }
        }
        else
        {
            Console.WriteLine("Authentification échouée. L'application se ferme.");
            Environment.Exit(0);
        }
    }

    private class AuthData
    {
        public string utilisateur { get; set; }
        public string motDePasse { get; set; }
    }
}









