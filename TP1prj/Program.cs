class Program
{
    static void Main()

    {
        GestionAbsences gestionAbsences = new GestionAbsences();
        gestionAbsences.ChargerListeEtudiantsDepuisFichier("listeEtudiants.json");
        gestionAbsences.ChargerListeAbsentsDepuisFichier("absents.json");
        gestionAbsences.LireStatDepuisFichier("stat.json");
        Authentification authentification = new Authentification(gestionAbsences);
        authentification.tryToAuth();
        var menu = new Menu(gestionAbsences);
        gestionAbsences.VerifierPresences();
        gestionAbsences.AfficherEtudiantsAbsents();

        Console.ReadLine();
    }
}
