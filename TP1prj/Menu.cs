
public class Menu
{
    private GestionAbsences gestionAbsences;

    public Menu(GestionAbsences gestionAbsences)
    {
        this.gestionAbsences = gestionAbsences;
    }
    public void AfficherMenu()
    {
        Console.WriteLine(@"
  _____       __                           _____ _               _      __  __  _____ ___  _____  
 |  __ \     /_/                          / ____| |             | |    |  \/  |/ ____|__ \|  __ \ 
 | |__) | __ ___  ___  ___ _ __   ___ ___| |    | |__   ___  ___| | __ | \  / | (___    ) | |  | |
 |  ___/ '__/ _ \/ __|/ _ \ '_ \ / __/ _ \ |    | '_ \ / _ \/ __| |/ / | |\/| |\___ \  / /| |  | |
 | |   | | |  __/\__ \  __/ | | | (_|  __/ |____| | | |  __/ (__|   <  | |  | |____) |/ /_| |__| |
 |_|   |_|  \___||___/\___|_| |_|\___\___|\_____|_| |_|\___|\___|_|\_\ |_|  |_|_____/|____|_____/ 
                                                                                                  
");
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine("Menu de l'application :");
        Console.WriteLine("1. Saisir la présence");
        Console.WriteLine("2. Afficher la liste des absents");
        Console.WriteLine("3. Afficher les statistiques");
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
