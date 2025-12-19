# ?? Documentation du Projet : Système de Gestion des Employés

## Architecture 3-Tiers avec .NET Remoting

---

## ?? Vue d'ensemble du projet

Ce projet est une **application de gestion des employés** développée selon l'architecture **3-Tiers** (Présentation, Logique Métier, Accès aux Données). Il utilise la technologie **.NET Remoting** pour permettre la communication distante entre le client et le serveur via le protocole **TCP**.

L'application permet de gérer :
- Les **employés** (ajout, modification, suppression, recherche, calcul de salaire)
- Les **départements** (avec un chef assigné)
- Les **projets** (avec budget)
- Les **affectations** d'employés aux projets

---

## ??? Structure des 4 Projets

```
???????????????????????????????????????????????????????????????????????????????
?                              SOLUTION                                       ?
???????????????????????????????????????????????????????????????????????????????
?     CLIENT      ?     SERVER      ?      COMMON      ?   WEBAPPLICATION1    ?
?  (Présentation) ? (Logique Métier)? (Modèles Partagés)?   (API Web .NET 10) ?
? Windows Forms   ? (Accès Données) ?                  ?      (Futur)         ?
? .NET Framework  ? .NET Framework  ?  .NET Framework  ?     .NET 10          ?
?      4.8        ?      4.8        ?       4.8        ?                      ?
???????????????????????????????????????????????????????????????????????????????
```

---

## ?? Projet 1 : `Common` (Bibliothèque de classes partagée)

### ?? Emplacement : `Common\`

Le projet **Common** contient tous les éléments partagés entre le client et le serveur. C'est le **contrat** entre les deux parties. Sans ce projet, le client et le serveur ne pourraient pas communiquer car ils ne "parleraient pas le même langage".

### Pourquoi ce projet est essentiel ?

Dans une architecture distribuée avec .NET Remoting, les objets doivent être **sérialisés** (convertis en flux binaire) pour transiter sur le réseau. Le client et le serveur doivent donc connaître exactement la même structure de classes. Ce projet définit :

1. **Les modèles de données** : Les objets qui transitent sur le réseau
2. **L'interface du service** : Le contrat définissant les opérations disponibles

### ?? Fichiers du projet Common

| Fichier | Description |
|---------|-------------|
| `Employe.cs` | Classe modèle représentant un employé |
| `Departement.cs` | Classe modèle représentant un département |
| `Projet.cs` | Classe modèle représentant un projet |
| `Affectation.cs` | Classe modèle pour lier employés et projets |
| `IRPC.cs` | Interface définissant toutes les opérations du service |

---

### ?? Classe `Employe`

```csharp
[Serializable]  // OBLIGATOIRE pour .NET Remoting
public class Employe
{
    public string Cin { get; set; }      // Identifiant unique (Carte d'Identité Nationale)
    public string Nom { get; set; }       // Nom complet de l'employé
    public double Taux { get; set; }      // Taux horaire (ex: 50.00 DH/h)
    public int NbrHeure { get; set; }     // Nombre d'heures travaillées
}
```

**Rôle :** Cette classe représente un employé dans le système. Elle contient les informations de base nécessaires pour identifier un employé et calculer son salaire.

**Attribut `[Serializable]` :** Cet attribut est **obligatoire** car les objets `Employe` doivent être convertis en flux binaire pour transiter sur le réseau TCP entre le client et le serveur.

**Propriétés :**
- `Cin` : Identifiant unique de l'employé (clé primaire logique)
- `Nom` : Nom complet pour l'affichage
- `Taux` : Taux horaire utilisé pour le calcul du salaire
- `NbrHeure` : Heures travaillées, utilisées avec le taux pour calculer le salaire

---

### ?? Classe `Departement`

```csharp
[Serializable]
public class Departement
{
    public int Id { get; set; }           // Identifiant auto-incrémenté
    public string Nom { get; set; }       // Nom du département
    public string ChefCin { get; set; }   // CIN du chef (clé étrangère vers Employe)
}
```

**Rôle :** Cette classe représente un département de l'entreprise. Chaque département peut avoir un chef qui est lui-même un employé.

**Relation avec Employe :** La propriété `ChefCin` est une **clé étrangère** qui référence le `Cin` d'un employé. Cela crée une relation entre les départements et les employés.

---

### ?? Classe `Projet`

```csharp
[Serializable]
public class Projet
{
    public int Id { get; set; }           // Identifiant auto-incrémenté
    public string Nom { get; set; }       // Nom du projet
    public double Budget { get; set; }    // Budget alloué au projet
}
```

**Rôle :** Cette classe représente un projet sur lequel les employés peuvent travailler. Chaque projet a un budget défini.

---

### ?? Classe `Affectation`

```csharp
[Serializable]
public class Affectation
{
    public int Id { get; set; }           // Identifiant auto-incrémenté
    public string EmployeCin { get; set; } // CIN de l'employé affecté
    public int ProjetId { get; set; }     // ID du projet
    public int Heures { get; set; }       // Heures travaillées sur ce projet
}
```

**Rôle :** Cette classe est une **table de liaison** (ou table d'association) qui permet de créer une relation **Many-to-Many** (plusieurs-à-plusieurs) entre les employés et les projets.

**Relations :**
- `EmployeCin` ? référence `Employe.Cin`
- `ProjetId` ? référence `Projet.Id`

Un employé peut travailler sur plusieurs projets, et un projet peut avoir plusieurs employés.

---

### ?? Interface `IRPC`

```csharp
public interface IRPC
{
    // --- Opérations sur les Employés ---
    bool AjouterEmploye(Employe employe);
    Employe RechercherEmploye(string cin);
    bool ModifierEmploye(Employe employe);
    bool SupprimerEmploye(string cin);
    double CalculerSalaire(string cin);
    List<Employe> ListerTousEmployes();

    // --- Opérations sur les Départements ---
    bool AjouterDepartement(Departement departement);
    bool ModifierDepartement(Departement departement);
    bool SupprimerDepartement(int id);
    List<Departement> ListerDepartements();

    // --- Opérations sur les Projets ---
    bool AjouterProjet(Projet projet);
    bool ModifierProjet(Projet projet);
    bool SupprimerProjet(int id);
    List<Projet> ListerProjets();

    // --- Opérations sur les Affectations ---
    bool AjouterAffectation(Affectation affectation);
    bool ModifierAffectation(Affectation affectation);
    bool SupprimerAffectation(int id);
    List<Affectation> ListerAffectations();
}
```

**Rôle :** Cette interface est le **contrat** entre le client et le serveur. Elle définit toutes les méthodes que le client peut appeler à distance sur le serveur.

**Pourquoi une interface ?**
- Elle permet le **découplage** : le client ne connaît que l'interface, pas l'implémentation
- Elle facilite les **tests** : on peut créer des implémentations mock pour les tests
- Elle définit un **contrat clair** : toute classe qui implémente cette interface doit fournir ces méthodes

**Pattern CRUD :** Chaque entité (Employe, Departement, Projet, Affectation) dispose des opérations :
- **C**reate : `Ajouter...`
- **R**ead : `Rechercher...`, `Lister...`
- **U**pdate : `Modifier...`
- **D**elete : `Supprimer...`

---

## ?? Projet 2 : `Server` (Application Console)

### ?? Emplacement : `Server\`

Le projet **Server** est le cœur de l'application. Il implémente la **logique métier** et l'**accès aux données**. Il expose le service via .NET Remoting sur le port TCP **1234**.

### ?? Fichiers du projet Server

| Fichier | Rôle | Couche |
|---------|------|--------|
| `Program.cs` | Point d'entrée, configure le canal TCP et enregistre le service | Configuration |
| `EmployeService.cs` | Implémente `IRPC`, contient la logique métier | Logique Métier |
| `DbDataStore.cs` | Accès à la base de données SQL Server | Accès aux Données |
| `JsonDataStore.cs` | Alternative : stockage en fichier JSON | Accès aux Données |

---

### ?? Classe `Program` (Point d'entrée du serveur)

```csharp
class Program
{
    static void Main(string[] args)
    {
        // 1. Création du canal TCP sur le port 1234
        TcpChannel channel = new TcpChannel(1234);
        ChannelServices.RegisterChannel(channel, false);

        // 2. Enregistrement du service en mode Singleton
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(EmployeService),       // Type de la classe du service
            "EmployeService",             // Nom URI pour accéder au service
            WellKnownObjectMode.Singleton // Mode d'activation
        );

        // 3. Le serveur reste en attente
        Console.WriteLine("Serveur en attente de connexions...");
        Console.ReadLine();
    }
}
```

**Rôle :** Cette classe est le point d'entrée de l'application serveur. Elle configure l'infrastructure .NET Remoting.

**Étapes de configuration :**

1. **Création du canal TCP :** Un canal de communication est créé sur le port 1234. Ce canal permet au serveur d'écouter les requêtes entrantes.

2. **Enregistrement du service :** Le service `EmployeService` est enregistré avec un URI (`EmployeService`). Les clients pourront y accéder via `tcp://localhost:1234/EmployeService`.

3. **Mode Singleton vs SingleCall :**
   - **Singleton** (utilisé ici) : Une seule instance du service est créée et partagée entre tous les clients
   - **SingleCall** : Une nouvelle instance est créée pour chaque appel de méthode

---

### ?? Classe `EmployeService` (Logique Métier)

```csharp
public class EmployeService : MarshalByRefObject, IRPC
{
    private readonly DbDataStore _dataStore;

    public EmployeService()
    {
        string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementDB;...";
        _dataStore = new DbDataStore(conn);
    }

    // Implémentation des méthodes de l'interface IRPC...
}
```

**Rôle :** Cette classe est le service principal. Elle hérite de `MarshalByRefObject` (obligatoire pour .NET Remoting) et implémente l'interface `IRPC`.

**Héritage de `MarshalByRefObject` :** Cette classe de base permet à l'objet d'être accessible à distance. Sans cet héritage, .NET Remoting ne pourrait pas créer un proxy pour accéder à l'objet depuis le client.

**Méthodes importantes :**

#### Méthode `CalculerSalaire` (avec règle métier)

```csharp
public double CalculerSalaire(string cin)
{
    Employe employe = RechercherEmploye(cin);
    
    if (employe == null)
        return -1;

    double salaire;

    // RÈGLE MÉTIER : Heures supplémentaires
    if (employe.NbrHeure > 50)
    {
        int heuresNormales = 50;
        int heuresSupplementaires = employe.NbrHeure - 50;

        // Heures normales au taux normal + Heures sup à 140%
        salaire = (heuresNormales * employe.Taux) + 
                  (heuresSupplementaires * employe.Taux * 1.4);
    }
    else
    {
        salaire = employe.NbrHeure * employe.Taux;
    }

    return salaire;
}
```

**Règle métier importante :**
> Si un employé travaille plus de **50 heures**, les heures supplémentaires (au-delà de 50h) sont payées à **140%** du taux normal.

**Exemple de calcul :**
- Employé avec `Taux = 100 DH/h` et `NbrHeure = 60`
- Heures normales : 50h × 100 = 5000 DH
- Heures sup : 10h × 100 × 1.4 = 1400 DH
- **Salaire total : 6400 DH**

#### Méthode `InitializeLifetimeService`

```csharp
public override object InitializeLifetimeService()
{
    return null;  // Durée de vie infinie
}
```

**Rôle :** Par défaut, .NET Remoting détruit les objets après un certain temps d'inactivité. En retournant `null`, l'objet reste actif indéfiniment tant que le serveur tourne.

---

### ?? Classe `DbDataStore` (Accès aux Données)

```csharp
public class DbDataStore
{
    private readonly string _connectionString;

    public DbDataStore(string connectionString)
    {
        _connectionString = connectionString;
        EnsureDatabaseExists();  // Crée la DB si elle n'existe pas
        EnsureTableExists();     // Crée les tables si elles n'existent pas
    }

    // Méthodes CRUD pour chaque entité...
}
```

**Rôle :** Cette classe gère toutes les opérations avec la base de données SQL Server LocalDB.

**Fonctionnalités automatiques :**
- Création automatique de la base de données `EmployeeManagementDB` si elle n'existe pas
- Création automatique des tables (`Employees`, `Departements`, `Projets`, `Affectations`)

**Structure des tables créées :**

```sql
-- Table Employees
CREATE TABLE dbo.Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cin NVARCHAR(50) NOT NULL UNIQUE,
    Nom NVARCHAR(200) NOT NULL,
    Taux FLOAT NOT NULL,
    NbrHeure INT NOT NULL
);

-- Table Departements
CREATE TABLE dbo.Departements (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(200) NOT NULL,
    ChefCin NVARCHAR(50) NULL
);

-- Table Projets
CREATE TABLE dbo.Projets (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(200) NOT NULL,
    Budget FLOAT NOT NULL
);

-- Table Affectations
CREATE TABLE dbo.Affectations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeCin NVARCHAR(50) NOT NULL,
    ProjetId INT NOT NULL,
    Heures INT NOT NULL
);
```

**Exemple de méthode CRUD :**

```csharp
public bool Ajouter(Employe employe)
{
    const string sql = @"INSERT INTO Employees (Cin, Nom, Taux, NbrHeure) 
                         VALUES (@Cin, @Nom, @Taux, @NbrHeure)";

    using (var conn = new SqlConnection(_connectionString))
    using (var cmd = new SqlCommand(sql, conn))
    {
        // Paramètres pour éviter les injections SQL
        cmd.Parameters.AddWithValue("@Cin", employe.Cin);
        cmd.Parameters.AddWithValue("@Nom", employe.Nom);
        cmd.Parameters.AddWithValue("@Taux", employe.Taux);
        cmd.Parameters.AddWithValue("@NbrHeure", employe.NbrHeure);

        conn.Open();
        cmd.ExecuteNonQuery();
        return true;
    }
}
```

**Sécurité :** L'utilisation de paramètres (`@Cin`, `@Nom`, etc.) protège contre les **injections SQL**.

---

### ?? Classe `JsonDataStore` (Alternative JSON)

```csharp
public class JsonDataStore
{
    private readonly string _filePath;
    private readonly JavaScriptSerializer _serializer;
    private readonly object _lock = new object();

    public JsonDataStore(string filePath = "employes.json")
    {
        _filePath = filePath;
        _serializer = new JavaScriptSerializer();
        
        if (!File.Exists(_filePath))
        {
            InitialiserDonneesTest();
        }
    }
}
```

**Rôle :** Cette classe est une **alternative** à `DbDataStore`. Elle stocke les données dans un fichier JSON au lieu d'une base de données SQL Server.

**Avantages :**
- Pas besoin d'installer SQL Server
- Fichier portable et facile à lire
- Idéal pour les tests et le développement

**Thread Safety :** Le `lock` assure que plusieurs threads ne modifient pas le fichier en même temps.

---

## ?? Projet 3 : `Client` (Application Windows Forms)

### ?? Emplacement : `Client\`

Le projet **Client** est l'interface utilisateur graphique (GUI). Il communique avec le serveur via un **proxy** obtenu par .NET Remoting.

### ?? Fichiers du projet Client

| Fichier | Description |
|---------|-------------|
| `Program.cs` | Point d'entrée, lance le formulaire principal |
| `MainForm.cs` | Logique de l'interface utilisateur |
| `MainForm.Designer.cs` | Définition visuelle des contrôles (généré par le designer) |

---

### ?? Classe `Program` (Point d'entrée du client)

```csharp
static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
```

**Rôle :** Point d'entrée standard d'une application Windows Forms.

**Attribut `[STAThread]` :** Obligatoire pour Windows Forms, définit le modèle de threading.

---

### ?? Classe `MainForm` (Interface utilisateur)

```csharp
public partial class MainForm : Form
{
    private IRPC serviceProxy;  // Proxy vers le service distant

    private int _selectedDeptId = -1;
    private int _selectedProjetId = -1;
    private int _selectedAffId = -1;

    public MainForm()
    {
        InitializeComponent();
    }
}
```

**Rôle :** Cette classe gère toute l'interface utilisateur et la communication avec le serveur.

**Variables de sélection :** Les variables `_selectedDeptId`, `_selectedProjetId`, `_selectedAffId` stockent l'ID de l'élément sélectionné dans les grilles pour les opérations de modification/suppression.

#### Connexion au serveur

```csharp
private void MainForm_Load(object sender, EventArgs e)
{
    try
    {
        // 1. Création du canal TCP côté client
        TcpChannel channel = new TcpChannel();
        ChannelServices.RegisterChannel(channel, false);

        // 2. Obtention du proxy vers le service distant
        serviceProxy = (IRPC)Activator.GetObject(
            typeof(IRPC),
            "tcp://localhost:1234/EmployeService"
        );

        lblStatus.Text = "Statut: Connecté au serveur";
        lblStatus.ForeColor = System.Drawing.Color.Green;

        // 3. Chargement initial des données
        ChargerListeEmployes();
        ChargerDepartements();
        ChargerProjets();
        ChargerAffectations();
    }
    catch (Exception ex)
    {
        lblStatus.Text = "Statut: Erreur de connexion";
        MessageBox.Show($"Erreur : {ex.Message}");
    }
}
```

**Le proxy :** La variable `serviceProxy` est un **proxy** qui ressemble à l'objet réel mais qui transmet les appels au serveur distant. Du point de vue du code, appeler `serviceProxy.AjouterEmploye(emp)` semble être un appel local, mais en réalité :

1. L'objet `emp` est **sérialisé** en binaire
2. Il est **envoyé** via TCP au serveur (port 1234)
3. Le serveur **désérialise** l'objet et **exécute** la méthode
4. Le résultat est **sérialisé** et **renvoyé** au client
5. Le client **désérialise** le résultat

#### Interface à onglets

L'interface utilise un `TabControl` avec 4 onglets :

| Onglet | Entité gérée | Contrôles principaux |
|--------|--------------|---------------------|
| Employés | `Employe` | txtCin, txtNom, txtTaux, txtHeures, dgvEmployes |
| Départements | `Departement` | txtDeptNom, txtDeptChefCin, dgvDepartements |
| Projets | `Projet` | txtProjetNom, txtProjetBudget, dgvProjets |
| Affectations | `Affectation` | txtAffEmpCin, txtAffProjetId, txtAffHeures, dgvAffectations |

#### Exemple d'opération CRUD (Ajouter un employé)

```csharp
private void BtnAjouter_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrWhiteSpace(txtCin.Text)) return;

        // 1. Création de l'objet Employe
        Employe emp = new Employe
        {
            Cin = txtCin.Text.Trim(),
            Nom = txtNom.Text.Trim(),
            Taux = double.Parse(txtTaux.Text),
            NbrHeure = int.Parse(txtHeures.Text)
        };

        // 2. Appel distant (transparent grâce au proxy)
        if (serviceProxy.AjouterEmploye(emp))
        {
            MessageBox.Show("Employé ajouté!");
            ViderChampsEmploye();
            ChargerListeEmployes();  // Rafraîchir la grille
        }
        else
        {
            MessageBox.Show("Erreur: CIN déjà existant");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

#### Sélection dans la grille

```csharp
private void DgvEmployes_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        DataGridViewRow row = dgvEmployes.Rows[e.RowIndex];
        
        // Remplir les champs de saisie avec les données sélectionnées
        txtCin.Text = row.Cells["Cin"].Value?.ToString() ?? "";
        txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
        txtTaux.Text = row.Cells["Taux"].Value?.ToString() ?? "";
        txtHeures.Text = row.Cells["NbrHeure"].Value?.ToString() ?? "";
    }
}
```

**Rôle :** Quand l'utilisateur clique sur une ligne de la grille, les données sont automatiquement copiées dans les champs de saisie pour permettre la modification.

---

## ?? Projet 4 : `WebApplication1` (API Web - .NET 10)

### ?? Emplacement : `WebApplication1\`

Ce projet est une **application web minimale** créée avec .NET 10. C'est actuellement un squelette de base qui pourrait être développé pour remplacer .NET Remoting par une API REST moderne.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

**État actuel :** Projet de base non développé.

**Potentiel futur :** Pourrait être transformé en API REST pour moderniser l'architecture et permettre l'accès depuis des clients web/mobile.

---

## ?? Diagramme de communication

```
????????????????????         TCP Port 1234         ????????????????????
?                  ?  ??????????????????????????   ?                  ?
?      CLIENT      ?     Appel de méthode          ?      SERVER      ?
?    (MainForm)    ?     (objet sérialisé)         ?  (EmployeService)?
?   Windows Forms  ?                               ?                  ?
?                  ?  ??????????????????????????   ?                  ?
?                  ?     Résultat sérialisé        ?                  ?
????????????????????                               ????????????????????
         ?                                                  ?
         ? Utilise l'interface                              ? Utilise
         ?                                                  ?
         ?                                                  ?
????????????????????                               ????????????????????
?      COMMON      ?                               ?    DbDataStore   ?
?  ??????????????  ?                               ?                  ?
?  ?   IRPC     ?  ?                               ?  SQL Server      ?
?  ? (interface)?  ?                               ?  LocalDB         ?
?  ??????????????  ?                               ?                  ?
?  ??????????????  ?                               ????????????????????
?  ?  Employe   ?  ?
?  ? Departement?  ?
?  ?  Projet    ?  ?
?  ? Affectation?  ?
?  ??????????????  ?
????????????????????
```

---

## ?? Schéma de la Base de Données

```
???????????????????????           ???????????????????????
?     Employees       ?           ?    Departements     ?
???????????????????????           ???????????????????????
? Id (PK, auto)       ?           ? Id (PK, auto)       ?
? Cin (UNIQUE)        ????????????? ChefCin (FK)        ?
? Nom                 ?           ? Nom                 ?
? Taux                ?           ???????????????????????
? NbrHeure            ?
???????????????????????
         ?
         ? EmployeCin (FK)
         ?
???????????????????????           ???????????????????????
?    Affectations     ?           ?      Projets        ?
???????????????????????           ???????????????????????
? Id (PK, auto)       ?           ? Id (PK, auto)       ?
? EmployeCin (FK)     ?           ? Nom                 ?
? ProjetId (FK)       ????????????? Budget              ?
? Heures              ?           ???????????????????????
???????????????????????

Relations :
• Employees 1 ????? N Departements (Un employé peut être chef de plusieurs départements)
• Employees 1 ????? N Affectations (Un employé peut avoir plusieurs affectations)
• Projets 1 ????? N Affectations (Un projet peut avoir plusieurs affectations)
```

---

## ?? Relations entre les projets

```
                    ???????????????
                    ?   COMMON    ?
                    ?  (Partagé)  ?
                    ???????????????
                           ?
              ???????????????????????????
              ?                         ?
              ?                         ?
       ???????????????           ???????????????
       ?   CLIENT    ?           ?   SERVER    ?
       ?  Référence  ?           ?  Référence  ?
       ?   Common    ?           ?   Common    ?
       ???????????????           ???????????????
```

**Dépendances :**
- `Client` ? référence `Common`
- `Server` ? référence `Common`
- `Common` ? aucune dépendance (projet autonome)

---

## ?? Comment exécuter le projet

### Prérequis
- Visual Studio 2019 ou supérieur
- .NET Framework 4.8
- SQL Server LocalDB (inclus avec Visual Studio)

### Étapes de lancement

#### Étape 1 : Démarrer le Serveur

1. Clic droit sur le projet `Server`
2. Sélectionner "Définir comme projet de démarrage"
3. Appuyer sur F5 ou cliquer sur "Démarrer"

Le serveur affichera :
```
========================================
   SERVEUR GESTION DES EMPLOYÉS
   Architecture 3-Tiers - .NET Remoting
========================================

[INFO] Canal TCP enregistré sur le port 1234
[INFO] Service 'EmployeService' enregistré en mode Singleton
[INFO] URI du service : tcp://localhost:1234/EmployeService

[SERVEUR] En attente de connexions clients...
```

#### Étape 2 : Démarrer le Client

1. Clic droit sur le projet `Client`
2. Sélectionner "Déboguer" ? "Démarrer une nouvelle instance"

L'interface graphique s'ouvrira avec 4 onglets.

#### Étape 3 : Utiliser l'application

| Onglet | Actions disponibles |
|--------|---------------------|
| **Employés** | Ajouter, modifier, supprimer des employés |
| **Départements** | Gérer les départements et assigner des chefs |
| **Projets** | Créer et gérer les projets avec leurs budgets |
| **Affectations** | Assigner des employés aux projets avec des heures |

---

## ?? Résumé des technologies utilisées

| Technologie | Utilisation |
|-------------|-------------|
| **.NET Framework 4.8** | Framework de développement principal |
| **.NET 10** | Projet WebApplication1 (futur) |
| **.NET Remoting** | Communication client-serveur distante |
| **TCP Channel** | Protocole de transport (port 1234) |
| **Windows Forms** | Interface utilisateur graphique |
| **SQL Server LocalDB** | Base de données relationnelle |
| **ADO.NET** | Accès aux données (SqlConnection, SqlCommand) |
| **Serialization** | Conversion des objets pour le transport réseau |

---

## ? Points clés à retenir pour la présentation

### 1. Architecture 3-Tiers
Séparation claire entre :
- **Présentation** (Client - Windows Forms)
- **Logique Métier** (Server - EmployeService)
- **Accès aux Données** (Server - DbDataStore)

### 2. Attribut `[Serializable]`
Obligatoire sur toutes les classes qui transitent sur le réseau (Employe, Departement, Projet, Affectation).

### 3. `MarshalByRefObject`
Classe de base obligatoire pour les objets accessibles à distance via .NET Remoting.

### 4. Mode Singleton
Une seule instance du service `EmployeService` est partagée entre tous les clients connectés.

### 5. Interface `IRPC`
Contrat partagé entre client et serveur qui définit toutes les opérations disponibles. Permet le découplage.

### 6. Règle métier du salaire
Les heures au-delà de 50h sont payées à **140%** du taux normal.

### 7. Proxy transparent
Le client utilise un proxy qui rend les appels distants transparents (ressemblent à des appels locaux).

### 8. Sécurité SQL
Utilisation de paramètres SQL (`@Param`) pour éviter les injections SQL.

---

## ?? Glossaire

| Terme | Définition |
|-------|------------|
| **3-Tiers** | Architecture en 3 couches (Présentation, Logique, Données) |
| **RPC** | Remote Procedure Call - Appel de procédure à distance |
| **.NET Remoting** | Technologie Microsoft pour la communication inter-processus |
| **Proxy** | Objet local qui représente un objet distant |
| **Sérialisation** | Conversion d'un objet en flux binaire |
| **Singleton** | Pattern où une seule instance existe |
| **CRUD** | Create, Read, Update, Delete |
| **TCP** | Transmission Control Protocol |
| **LocalDB** | Version légère de SQL Server pour le développement |

---

## ????? Auteur

Projet développé dans le cadre du cours de développement .NET distribué.

---

*Bonne présentation ! ??*
