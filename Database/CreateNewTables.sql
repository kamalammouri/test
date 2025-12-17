USE EmployeeManagementDB;
GO

-- Table Departements
IF OBJECT_ID('dbo.Departements', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Departements (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nom NVARCHAR(200) NOT NULL,
        ChefCin NVARCHAR(50) NULL
    );
    PRINT 'Table Departements created.';
END
ELSE
BEGIN
    PRINT 'Table Departements already exists.';
END
GO

-- Table Projets
IF OBJECT_ID('dbo.Projets', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Projets (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nom NVARCHAR(200) NOT NULL,
        Budget FLOAT NOT NULL
    );
    PRINT 'Table Projets created.';
END
ELSE
BEGIN
    PRINT 'Table Projets already exists.';
END
GO

-- Table Affectations
IF OBJECT_ID('dbo.Affectations', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Affectations (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        EmployeCin NVARCHAR(50) NOT NULL,
        ProjetId INT NOT NULL,
        Heures INT NOT NULL
    );
    PRINT 'Table Affectations created.';
END
ELSE
BEGIN
    PRINT 'Table Affectations already exists.';
END
GO
