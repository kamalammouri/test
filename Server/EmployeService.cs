using System;
using System.Collections.Generic;
using Common;

namespace Server
{
    /// <summary>
    /// Implementation du service RPC pour la gestion des employes.
    /// Herite de MarshalByRefObject pour permettre l'acces a distance via .NET Remoting.
    /// Utilise une base de donnees SQL Server (EmployeeManagementDB) pour le stockage.
    /// </summary>
    public class EmployeService : MarshalByRefObject, IRPC
    {
        // Gestionnaire de stockage SQL
        private readonly DbDataStore _dataStore;

        /// <summary>
        /// Constructeur - Initialise le stockage SQL
        /// </summary>
        public EmployeService()
        {
            // Simpler LocalDB connection string (no encryption flags)
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementDB;Integrated Security=True;Connect Timeout=30;";
            _dataStore = new DbDataStore(conn);
            Console.WriteLine("[SERVER] Service initialise avec stockage SQL (EmployeeManagementDB)");
        }

        /// <summary>
        /// Ajoute un nouvel employe dans la base de donnees.
        /// </summary>
        /// <param name="employe">L'employe a ajouter</param>
        /// <returns>True si l'ajout a reussi, False sinon</returns>
        public bool AjouterEmploye(Employe employe)
        {
            try
            {
                bool resultat = _dataStore.Ajouter(employe);

                if (resultat)
                {
                    Console.WriteLine($"[SERVER] Employe ajoute : {employe.Nom} (CIN: {employe.Cin})");
                }
                else
                {
                    Console.WriteLine($"[SERVER] CIN deja existant : {employe.Cin}");
                }

                return resultat;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de l'ajout : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Recherche un employe par son CIN.
        /// </summary>
        /// <param name="cin">Le CIN de l'employe a rechercher</param>
        /// <returns>L'employe trouve ou null si non trouve</returns>
        public Employe RechercherEmploye(string cin)
        {
            try
            {
                Employe employe = _dataStore.Rechercher(cin);

                if (employe != null)
                {
                    Console.WriteLine($"[SERVER] Employe trouve : {employe.Nom}");
                }
                else
                {
                    Console.WriteLine($"[SERVER] Aucun employe trouve avec CIN: {cin}");
                }

                return employe;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de la recherche : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Calcule le salaire d'un employe selon la regle metier.
        /// Regle : Si NbrHeure > 50, les heures supplementaires sont payees a 140%.
        /// </summary>
        /// <param name="cin">Le CIN de l'employe</param>
        /// <returns>Le salaire calcule, ou -1 si l'employe n'est pas trouve</returns>
        public double CalculerSalaire(string cin)
        {
            try
            {
                Employe employe = RechercherEmploye(cin);

                if (employe == null)
                {
                    Console.WriteLine("[SERVER] Impossible de calculer le salaire : employe non trouve");
                    return -1;
                }

                double salaire;

                // Application de la regle metier
                if (employe.NbrHeure > 50)
                {
                    // Heures normales (50h) + Heures supplementaires a 140%
                    int heuresNormales = 50;
                    int heuresSupplementaires = employe.NbrHeure - 50;

                    salaire = (heuresNormales * employe.Taux) + 
                              (heuresSupplementaires * employe.Taux * 1.4);

                    Console.WriteLine($"[SERVER] Calcul salaire avec heures sup : {heuresSupplementaires}h a 140%");
                }
                else
                {
                    // Calcul normal sans heures supplementaires
                    salaire = employe.NbrHeure * employe.Taux;
                }

                Console.WriteLine($"[SERVER] Salaire calcule pour {employe.Nom} : {salaire:F2}");
                return salaire;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors du calcul du salaire : {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Supprime un employe par son CIN.
        /// </summary>
        /// <param name="cin">Le CIN de l'employe a supprimer</param>
        /// <returns>True si la suppression a reussi, False sinon</returns>
        public bool SupprimerEmploye(string cin)
        {
            try
            {
                bool resultat = _dataStore.Supprimer(cin);

                if (resultat)
                {
                    Console.WriteLine($"[SERVER] Employe supprime : CIN {cin}");
                }
                else
                {
                    Console.WriteLine($"[SERVER] Aucun employe trouve avec CIN: {cin}");
                }

                return resultat;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de la suppression : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Modifie un employe existant.
        /// </summary>
        /// <param name="employe">L'employe avec les nouvelles donnees</param>
        /// <returns>True si la modification a reussi, False sinon</returns>
        public bool ModifierEmploye(Employe employe)
        {
            try
            {
                bool resultat = _dataStore.Modifier(employe);

                if (resultat)
                {
                    Console.WriteLine($"[SERVER] Employe modifie : {employe.Nom} (CIN: {employe.Cin})");
                }
                else
                {
                    Console.WriteLine($"[SERVER] Aucun employe trouve avec CIN: {employe.Cin}");
                }

                return resultat;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de la modification : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Recupere la liste de tous les employes.
        /// </summary>
        /// <returns>Liste de tous les employes</returns>
        public List<Employe> ListerTousEmployes()
        {
            try
            {
                List<Employe> employes = _dataStore.ListerTous();
                Console.WriteLine($"[SERVER] Liste recuperee : {employes.Count} employe(s)");
                return employes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de la recuperation : {ex.Message}");
                return new List<Employe>();
            }
        }

        // --- Departements ---
        public bool AjouterDepartement(Departement departement)
        {
            try
            {
                return _dataStore.AjouterDepartement(departement);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de l'ajout departement : {ex.Message}");
                return false;
            }
        }

        public List<Departement> ListerDepartements()
        {
            try
            {
                return _dataStore.ListerDepartements();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors du listing departements : {ex.Message}");
                return new List<Departement>();
            }
        }

        // --- Projets ---
        public bool AjouterProjet(Projet projet)
        {
            try
            {
                return _dataStore.AjouterProjet(projet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de l'ajout projet : {ex.Message}");
                return false;
            }
        }

        public List<Projet> ListerProjets()
        {
            try
            {
                return _dataStore.ListerProjets();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors du listing projets : {ex.Message}");
                return new List<Projet>();
            }
        }

        // --- Affectations ---
        public bool AjouterAffectation(Affectation affectation)
        {
            try
            {
                return _dataStore.AjouterAffectation(affectation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors de l'ajout affectation : {ex.Message}");
                return false;
            }
        }

        public List<Affectation> ListerAffectations()
        {
            try
            {
                return _dataStore.ListerAffectations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Erreur lors du listing affectations : {ex.Message}");
                return new List<Affectation>();
            }
        }

        /// <summary>
        /// Override pour garder l'objet actif indefiniment sur le serveur.
        /// Retourne null pour une duree de vie infinie.
        /// </summary>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
