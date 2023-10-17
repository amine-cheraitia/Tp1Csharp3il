
public class Menu
{
    public void AfficherMenu()
    {
        Console.WriteLine("Menu de l'application :");
        Console.WriteLine("1. Saisir la présence");
        Console.WriteLine("2. Afficher la liste des absents");
        Console.WriteLine("3. Enregistrer les données");
        Console.WriteLine("4. Quitter");

        var choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                // Appel de la méthode SaisirPresence de la classe Appel
                var apl = new Appel();
                apl.SaisirPresence();
                break;
            case "2":
                // Appel de la méthode AfficherAbsents de la classe Appel
                break;
            case "3":
                // Appel de la méthode EnregistrerDonneesEnJson de la classe Appel
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }
}
