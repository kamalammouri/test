using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    /// <summary>
    /// Programme principal du serveur.
    /// Configure le canal TCP et enregistre le service Remoting.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("========================================");
                Console.WriteLine("   SERVEUR GESTION DES EMPLOYÉS");
                Console.WriteLine("   Architecture 3-Tiers - .NET Remoting");
                Console.WriteLine("========================================\n");

                // Création et enregistrement du canal TCP sur le port 1234
                TcpChannel channel = new TcpChannel(1234);
                ChannelServices.RegisterChannel(channel, false);
                
                Console.WriteLine("[INFO] Canal TCP enregistré sur le port 1234");

                // Enregistrement du service en mode Singleton
                // Mode Singleton : Une seule instance du service pour tous les clients
                // Alternative : WellKnownObjectMode.SingleCall pour une instance par appel
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(EmployeService),           // Type du service
                    "EmployeService",                 // URI du service
                    WellKnownObjectMode.Singleton     // Mode d'activation
                );

                Console.WriteLine("[INFO] Service 'EmployeService' enregistré en mode Singleton");
                Console.WriteLine("[INFO] URI du service : tcp://localhost:1234/EmployeService");
                Console.WriteLine("\n[SERVEUR] En attente de connexions clients...");
                Console.WriteLine("Appuyez sur ENTRÉE pour arrêter le serveur.\n");

                // Le programme reste ouvert pour écouter les requêtes
                Console.ReadLine();

                // Nettoyage lors de la fermeture
                ChannelServices.UnregisterChannel(channel);
                Console.WriteLine("[INFO] Serveur arrêté.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERREUR] Une erreur est survenue : {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\nAppuyez sur ENTRÉE pour quitter...");
                Console.ReadLine();
            }
        }
    }
}
