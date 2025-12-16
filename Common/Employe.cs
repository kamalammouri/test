using System;

namespace Common
{
    /// <summary>
    /// Classe modèle représentant un employé.
    /// Marquée [Serializable] pour permettre le transfert réseau via .NET Remoting.
    /// </summary>
    [Serializable]
    public class Employe
    {
        /// <summary>
        /// Carte d'Identité Nationale de l'employé (identifiant unique)
        /// </summary>
        public string Cin { get; set; }

        /// <summary>
        /// Nom de l'employé
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Taux horaire de l'employé
        /// </summary>
        public double Taux { get; set; }

        /// <summary>
        /// Nombre d'heures travaillées
        /// </summary>
        public int NbrHeure { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Employe()
        {
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="cin">CIN de l'employé</param>
        /// <param name="nom">Nom de l'employé</param>
        /// <param name="taux">Taux horaire</param>
        /// <param name="nbrHeure">Nombre d'heures travaillées</param>
        public Employe(string cin, string nom, double taux, int nbrHeure)
        {
            Cin = cin;
            Nom = nom;
            Taux = taux;
            NbrHeure = nbrHeure;
        }

        /// <summary>
        /// Représentation textuelle de l'employé
        /// </summary>
        public override string ToString()
        {
            return $"CIN: {Cin}, Nom: {Nom}, Taux: {Taux}, Heures: {NbrHeure}";
        }
    }
}
