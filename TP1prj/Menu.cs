
public class Menu
{
    private GestionAbsences gestionAbsences;

    public Menu(GestionAbsences gestionAbsences)
    {
        this.gestionAbsences = gestionAbsences;
    }
    public void AfficherMenu()
    {
        Console.WriteLine("Menu de l'application :");
        Console.WriteLine("1. Saisir la présence");
        Console.WriteLine("2. Afficher la liste des absents");
        Console.WriteLine("3. Enregistrer les données");
        Console.WriteLine("4. Quitter");

        var choix = Console.ReadLine();

        /* Console.Clear(); */

        switch (choix)
        {
            case "1":
                // Appel de la méthode SaisirPresence de la classe Appel

                gestionAbsences.VerifierPresences();
                break;
            case "2":
                // Appel de la méthode AfficherAbsents de la classe Appel
                gestionAbsences.AfficherEtudiantsAbsents();
                Console.ReadKey();
                Console.Clear();
                break;
            case "3":
                // Appel de la méthode EnregistrerDonneesEnJson de la classe Appel
                break;
            case "4":
                Console.Clear();
                Console.WriteLine("Au revoir !");
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Choix invalide.");
                break;
        }
    }
}
