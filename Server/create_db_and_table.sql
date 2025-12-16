-- Run this script in SSMS or Visual Studio SQL Server Object Explorer to create the database and table
-- It is safe to run multiple times.

IF DB_ID('EmployeeManagementDB') IS NULL
BEGIN
    CREATE DATABASE EmployeeManagementDB;
END
GO

USE EmployeeManagementDB;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Employees (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Cin NVARCHAR(50) NOT NULL CONSTRAINT UQ_Employees_Cin UNIQUE,
        Nom NVARCHAR(200) NOT NULL,
        Taux FLOAT NOT NULL,
        NbrHeure INT NOT NULL
    );
END
GO
