using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public class Classe
    {
        // Propriétés correspondant à Program.cs
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nom)
        {
            this.nomClasse = nom;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        // Méthodes correspondant aux appels dans Program.cs
      public void ajouterEleve(string prenom, string nom)
{
    if (eleves.Count >= 30)
    {
        Console.WriteLine("La classe est pleine.");
        return;
    }
    eleves.Add(new Eleve(prenom, nom));
}

        public void ajouterMatiere(string matiere)
{
    if (matieres.Count >= 10)
    {
        Console.WriteLine("Le nombre maximum de matières est atteint.");
        return;
    }
    matieres.Add(matiere);
}

        public double moyenneMatiere(int idMatiere)
{
    var moyennesEleves = eleves
        .Where(e => e.notes.Any(n => n.matiere == idMatiere))
        .Select(e => e.moyenneMatiere(idMatiere))
        .ToList();

    if (moyennesEleves.Count == 0) return 0;

    double moyenne = moyennesEleves.Average(); 
    return Math.Truncate(moyenne * 100) / 100;
}
       public double moyenneGeneral()
{
    if (matieres.Count == 0) return 0;

    double sommeMoyennes = matieres
        .Select((m, index) => moyenneMatiere(index))
        .Sum();

    // Il faut calculer la moyenne générale avant de l'utiliser
    double moyenne = sommeMoyennes / matieres.Count;
    return Math.Truncate(moyenne * 100) / 100;
}
    }
}
