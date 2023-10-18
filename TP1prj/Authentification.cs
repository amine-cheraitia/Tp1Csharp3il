// Contenu de Authentification.cs
public class Authentification
{
    private GestionAbsences gestionAbsences;


    private string MotDePasse { get; set; }

    public Authentification(GestionAbsences gestionAbsence)
    {
        this.gestionAbsences = gestionAbsence;
        Console.WriteLine("Veuillez entrer votre mot de passe :");
        MotDePasse = "random";
    }

    public bool Authentifier(string motDePasseSaisi)
    {

        return MotDePasse == motDePasseSaisi;
    }

    public void tryToAuth()
    {
        var motDePasseSaisi = Console.ReadLine();
        if (Authentifier(motDePasseSaisi))
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
            Console.WriteLine("Mot de passe incorrect. L'application se ferme.");
            Environment.Exit(0);
        }

    }






}
