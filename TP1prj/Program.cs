class Program
{
    static void Main()

    {
        GestionAbsences gestionAbsences = new GestionAbsences();
        Authentification authentification = new Authentification(gestionAbsences);

        authentification.tryToAuth();



        var menu = new Menu(gestionAbsences);


        gestionAbsences.VerifierPresences();
        gestionAbsences.AfficherEtudiantsAbsents();

        Console.ReadLine();
    }
}
