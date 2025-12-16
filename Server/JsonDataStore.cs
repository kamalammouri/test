using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Common;

namespace Server
{
    /// <summary>
    /// Classe pour gérer le stockage des employés dans un fichier JSON.
    /// Remplace la base de données SQL Server pour simplifier le déploiement.
    /// </summary>
    public class JsonDataStore
    {
        private readonly string _filePath;
        private readonly JavaScriptSerializer _serializer;
        private readonly object _lock = new object();

        /// <summary>
        /// Constructeur - Initialise le chemin du fichier JSON
        /// </summary>
        /// <param name="filePath">Chemin du fichier JSON (par défaut: employes.json)</param>
        public JsonDataStore(string filePath = "employes.json")
        {
            _filePath = filePath;
            _serializer = new JavaScriptSerializer();
            
            // Créer le fichier avec des données de test si il n'existe pas
            if (!File.Exists(_filePath))
            {
                InitialiserDonneesTest();
            }
        }

        /// <summary>
        /// Initialise le fichier avec des données de test
        /// </summary>
        private void InitialiserDonneesTest()
        {
            var employes = new List<Employe>
            {
                new Employe("AB123456", "Ahmed Bennani", 50.00, 40),
                new Employe("CD789012", "Fatima Alaoui", 60.00, 55),
                new Employe("EF345678", "Mohamed Idrissi", 45.00, 50)
            };
            SauvegarderTout(employes);
            Console.WriteLine($"[JSON] Fichier créé avec {employes.Count} employés de test");
        }

        /// <summary>
        /// Charge tous les employés depuis le fichier JSON
        /// </summary>
        public List<Employe> ChargerTout()
        {
            lock (_lock)
            {
                try
                {
                    if (!File.Exists(_filePath))
                    {
                        return new List<Employe>();
                    }

                    string json = File.ReadAllText(_filePath);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return new List<Employe>();
                    }

                    return _serializer.Deserialize<List<Employe>>(json) ?? new List<Employe>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[JSON] Erreur lecture : {ex.Message}");
                    return new List<Employe>();
                }
            }
        }

        /// <summary>
        /// Sauvegarde tous les employés dans le fichier JSON
        /// </summary>
        public void SauvegarderTout(List<Employe> employes)
        {
            lock (_lock)
            {
                try
                {
                    string json = _serializer.Serialize(employes);
                    File.WriteAllText(_filePath, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[JSON] Erreur écriture : {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// Ajoute un employé
        /// </summary>
        public bool Ajouter(Employe employe)
        {
            var employes = ChargerTout();
            
            // Vérifier si le CIN existe déjà
            if (employes.Exists(e => e.Cin == employe.Cin))
            {
                return false;
            }

            employes.Add(employe);
            SauvegarderTout(employes);
            return true;
        }

        /// <summary>
        /// Recherche un employé par CIN
        /// </summary>
        public Employe Rechercher(string cin)
        {
            var employes = ChargerTout();
            return employes.Find(e => e.Cin == cin);
        }

        /// <summary>
        /// Supprime un employé par CIN
        /// </summary>
        public bool Supprimer(string cin)
        {
            var employes = ChargerTout();
            int removed = employes.RemoveAll(e => e.Cin == cin);

            if (removed > 0)
            {
                SauvegarderTout(employes);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Modifie un employé existant
        /// </summary>
        public bool Modifier(Employe employe)
        {
            var employes = ChargerTout();
            int index = employes.FindIndex(e => e.Cin == employe.Cin);

            if (index >= 0)
            {
                employes[index] = employe;
                SauvegarderTout(employes);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Récupère tous les employés
        /// </summary>
        public List<Employe> ListerTous()
        {
            return ChargerTout();
        }
    }
}
