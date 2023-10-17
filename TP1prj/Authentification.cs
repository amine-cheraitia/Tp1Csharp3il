// Contenu de Authentification.cs
public class Authentification
{
    private string MotDePasse { get; set; }

    public Authentification(string motDePasse)
    {
        MotDePasse = motDePasse;
        MotDePasse = "random";
    }

    public bool Authentifier(string motDePasseSaisi)
    {
        return MotDePasse == motDePasseSaisi;
    }
}
