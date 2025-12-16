using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Interface IRPC définissant le contrat du middleware.
    /// Cette interface définit les méthodes accessibles à distance via .NET Remoting.
    /// </summary>
    public interface IRPC
    {
        /// <summary>
        /// Ajoute un nouvel employé dans la base de données.
        /// </summary>
        /// <param name="employe">L'employé à ajouter</param>
        /// <returns>True si l'ajout a réussi, False sinon</returns>
        bool AjouterEmploye(Employe employe);

        /// <summary>
        /// Recherche un employé par son CIN.
        /// </summary>
        /// <param name="cin">Le CIN de l'employé à rechercher</param>
        /// <returns>L'employé trouvé ou null si non trouvé</returns>
        Employe RechercherEmploye(string cin);

        /// <summary>
        /// Calcule le salaire d'un employé.
        /// Règle métier : Si NbrHeure > 50, les heures supplémentaires 
        /// (au-delà de 50h) sont payées à un taux de 140% (taux * 1.4).
        /// </summary>
        /// <param name="cin">Le CIN de l'employé</param>
        /// <returns>Le salaire calculé</returns>
        double CalculerSalaire(string cin);

        /// <summary>
        /// Supprime un employé de la base de données.
        /// </summary>
        /// <param name="cin">Le CIN de l'employé à supprimer</param>
        /// <returns>True si la suppression a réussi, False sinon</returns>
        bool SupprimerEmploye(string cin);

        /// <summary>
        /// Modifie un employé existant.
        /// </summary>
        /// <param name="employe">L'employé avec les nouvelles données</param>
        /// <returns>True si la modification a réussi, False sinon</returns>
        bool ModifierEmploye(Employe employe);

        /// <summary>
        /// Récupère la liste de tous les employés.
        /// </summary>
        /// <returns>Liste de tous les employés</returns>
        List<Employe> ListerTousEmployes();
    }
}
