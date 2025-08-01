using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public class Eleve
    {
        // Propriétés correspondant à Program.cs
        public string prenom { get; private set; }
        public string nom { get; private set; }
        internal List<Note> notes { get; private set; }

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

public void ajouterNote(Note n)
{
    if (notes.Count >= 200)
    {
        return; // Limite atteinte, on n'ajoute plus de note
    }
    notes.Add(n);
}
        public double moyenneMatiere(int idMatiere)
        {
            var notesMatiere = notes.Where(n => n.matiere == idMatiere).ToList();
            if (notesMatiere.Count == 0) return 0;
            double moyenne = notesMatiere.Average(n => n.note);
            return Math.Truncate(moyenne * 100) / 100;
        }

        public double moyenneGeneral()
{
    var idsMatieres = notes.Select(n => n.matiere).Distinct().ToList();
    if (idsMatieres.Count == 0) return 0;

    double sommeMoyennes = idsMatieres.Sum(id => moyenneMatiere(id));

    // Il faut calculer la moyenne avant de l'utiliser
    double moyenne = sommeMoyennes / idsMatieres.Count;
    return Math.Truncate(moyenne * 100) / 100;
}
    }
}
