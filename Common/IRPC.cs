using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Interface du service RPC partagée entre le client et le serveur.
    /// </summary>
    public interface IRPC
    {
        // --- Employes ---
        bool AjouterEmploye(Employe employe);
        Employe RechercherEmploye(string cin);
        bool ModifierEmploye(Employe employe);
        bool SupprimerEmploye(string cin);
        double CalculerSalaire(string cin);
        List<Employe> ListerTousEmployes();

        // --- Departements ---
        bool AjouterDepartement(Departement departement);
        bool ModifierDepartement(Departement departement);
        bool SupprimerDepartement(int id);
        List<Departement> ListerDepartements();

        // --- Projets ---
        bool AjouterProjet(Projet projet);
        bool ModifierProjet(Projet projet);
        bool SupprimerProjet(int id);
        List<Projet> ListerProjets();

        // --- Affectations ---
        bool AjouterAffectation(Affectation affectation);
        bool ModifierAffectation(Affectation affectation);
        bool SupprimerAffectation(int id);
        List<Affectation> ListerAffectations();
    }
}
