-- ============================================
-- Script SQL pour la création de la base de données
-- Gestion des Employés - Architecture 3-Tiers
-- ============================================

-- Création de la base de données (à exécuter en premier)
-- Décommentez les lignes suivantes si la base n'existe pas encore
/*
CREATE DATABASE GestionEmployes;
GO
*/

-- Utiliser la base de données
USE GestionEmployes;
GO

-- ============================================
-- Suppression de la table si elle existe déjà
-- ============================================
IF OBJECT_ID('dbo.Employe', 'U') IS NOT NULL
    DROP TABLE dbo.Employe;
GO

-- ============================================
-- Création de la table Employe
-- ============================================
CREATE TABLE Employe
(
    -- Identifiant auto-incrémenté
    Id INT IDENTITY(1,1) PRIMARY KEY,
    
    -- Carte d'Identité Nationale (unique)
    Cin NVARCHAR(20) NOT NULL UNIQUE,
    
    -- Nom de l'employé
    Nom NVARCHAR(100) NOT NULL,
    
    -- Taux horaire
    Taux DECIMAL(10, 2) NOT NULL,
    
    -- Nombre d'heures travaillées
    NbrHeure INT NOT NULL,
    
    -- Contraintes de validation
    CONSTRAINT CK_Taux_Positive CHECK (Taux >= 0),
    CONSTRAINT CK_NbrHeure_Positive CHECK (NbrHeure >= 0)
);
GO

-- ============================================
-- Index sur le CIN pour accélérer les recherches
-- ============================================
CREATE NONCLUSTERED INDEX IX_Employe_Cin ON Employe(Cin);
GO

-- ============================================
-- Données de test (optionnel)
-- ============================================
INSERT INTO Employe (Cin, Nom, Taux, NbrHeure) VALUES ('AB123456', 'Ahmed Bennani', 50.00, 40);
INSERT INTO Employe (Cin, Nom, Taux, NbrHeure) VALUES ('CD789012', 'Fatima Alaoui', 60.00, 55);
INSERT INTO Employe (Cin, Nom, Taux, NbrHeure) VALUES ('EF345678', 'Mohamed Idrissi', 45.00, 50);
GO

-- ============================================
-- Vérification des données insérées
-- ============================================
SELECT * FROM Employe;
GO

-- ============================================
-- Exemple de calcul de salaire (pour vérification)
-- Règle : Si NbrHeure > 50, heures sup à 140%
-- ============================================
SELECT 
    Cin,
    Nom,
    Taux,
    NbrHeure,
    CASE 
        WHEN NbrHeure > 50 THEN (50 * Taux) + ((NbrHeure - 50) * Taux * 1.4)
        ELSE NbrHeure * Taux
    END AS Salaire
FROM Employe;
GO

PRINT 'Base de données créée avec succès !';
GO
