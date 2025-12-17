using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace Server
{
    public class DbDataStore
    {
        private readonly string _connectionString;

        public DbDataStore(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            EnsureDatabaseExists();
            EnsureTableExists();
        }

        private void EnsureDatabaseExists()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(_connectionString);
                var dbName = builder.InitialCatalog;
                if (string.IsNullOrWhiteSpace(dbName)) return;

                // Connect to master to create database if missing
                builder.InitialCatalog = "master";
                using (var conn = new SqlConnection(builder.ToString()))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"IF DB_ID(@db) IS NULL
BEGIN
    DECLARE @sql NVARCHAR(MAX) = N'CREATE DATABASE [' + @db + N']';
    EXEC(@sql);
END";
                    cmd.Parameters.AddWithValue("@db", dbName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVER] Failed to ensure database exists: {ex.Message}");
            }
        }

        private void EnsureTableExists()
        {
            var schemas = new List<string>
            {
                @"IF OBJECT_ID('dbo.Employees','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Employees (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Cin NVARCHAR(50) NOT NULL CONSTRAINT UQ_Employees_Cin UNIQUE,
                        Nom NVARCHAR(200) NOT NULL,
                        Taux FLOAT NOT NULL,
                        NbrHeure INT NOT NULL
                    );
                END",
                @"IF OBJECT_ID('dbo.Departements','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Departements (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Nom NVARCHAR(200) NOT NULL,
                        ChefCin NVARCHAR(50) NULL
                    );
                END",
                @"IF OBJECT_ID('dbo.Projets','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Projets (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Nom NVARCHAR(200) NOT NULL,
                        Budget FLOAT NOT NULL
                    );
                END",
                @"IF OBJECT_ID('dbo.Affectations','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Affectations (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        EmployeCin NVARCHAR(50) NOT NULL,
                        ProjetId INT NOT NULL,
                        Heures INT NOT NULL
                    );
                END"
            };

            foreach (var sql in schemas)
            {
                try
                {
                    using (var conn = new SqlConnection(_connectionString))
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SERVER] Failed to ensure table exists: {ex.Message}");
                }
            }
        }

        public bool Ajouter(Employe employe)
        {
            if (employe == null) throw new ArgumentNullException(nameof(employe));

            // Normalize CIN to avoid duplicates due to extra spaces
            string cin = (employe.Cin ?? string.Empty).Trim();

            const string sql = @"INSERT INTO Employees (Cin, Nom, Taux, NbrHeure) VALUES (@Cin, @Nom, @Taux, @NbrHeure);";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Cin", cin);
                cmd.Parameters.AddWithValue("@Nom", (employe.Nom ?? string.Empty).Trim());
                cmd.Parameters.AddWithValue("@Taux", employe.Taux);
                cmd.Parameters.AddWithValue("@NbrHeure", employe.NbrHeure);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Unique constraint violation (duplicate Cin)
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SERVER] Error inserting employee: {ex.Message}");
                    return false;
                }
            }
        }

        public Employe Rechercher(string cin)
        {
            const string sql = @"SELECT Cin, Nom, Taux, NbrHeure FROM Employees WHERE Cin = @Cin";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Cin", (cin ?? string.Empty).Trim());
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new Employe
                    {
                        Cin = r.GetString(r.GetOrdinal("Cin")),
                        Nom = r.GetString(r.GetOrdinal("Nom")),
                        Taux = r.GetDouble(r.GetOrdinal("Taux")),
                        NbrHeure = r.GetInt32(r.GetOrdinal("NbrHeure"))
                    };
                }
            }
        }

        public bool Modifier(Employe employe)
        {
            const string sql = @"UPDATE Employees SET Nom = @Nom, Taux = @Taux, NbrHeure = @NbrHeure WHERE Cin = @Cin";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Cin", (employe.Cin ?? string.Empty).Trim());
                cmd.Parameters.AddWithValue("@Nom", (employe.Nom ?? string.Empty).Trim());
                cmd.Parameters.AddWithValue("@Taux", employe.Taux);
                cmd.Parameters.AddWithValue("@NbrHeure", employe.NbrHeure);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool Supprimer(string cin)
        {
            const string sql = @"DELETE FROM Employees WHERE Cin = @Cin";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Cin", (cin ?? string.Empty).Trim());
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public List<Employe> ListerTous()
        {
            const string sql = @"SELECT Cin, Nom, Taux, NbrHeure FROM Employees ORDER BY Nom";
            var list = new List<Employe>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Employe
                        {
                            Cin = r.GetString(r.GetOrdinal("Cin")),
                            Nom = r.GetString(r.GetOrdinal("Nom")),
                            Taux = r.GetDouble(r.GetOrdinal("Taux")),
                            NbrHeure = r.GetInt32(r.GetOrdinal("NbrHeure"))
                        });
                    }
                }
            }

            return list;
        }
        public bool AjouterDepartement(Departement dept)
        {
            const string sql = @"INSERT INTO Departements (Nom, ChefCin) VALUES (@Nom, @ChefCin)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", dept.Nom ?? "");
                cmd.Parameters.AddWithValue("@ChefCin", (object)dept.ChefCin ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Departement> ListerDepartements()
        {
            const string sql = @"SELECT Id, Nom, ChefCin FROM Departements";
            var list = new List<Departement>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Departement
                        {
                            Id = r.GetInt32(0),
                            Nom = r.GetString(1),
                            ChefCin = r.IsDBNull(2) ? null : r.GetString(2)
                        });
                    }
                }
            }
            return list;
        }

        public bool AjouterProjet(Projet proj)
        {
            const string sql = @"INSERT INTO Projets (Nom, Budget) VALUES (@Nom, @Budget)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nom", proj.Nom ?? "");
                cmd.Parameters.AddWithValue("@Budget", proj.Budget);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Projet> ListerProjets()
        {
            const string sql = @"SELECT Id, Nom, Budget FROM Projets";
            var list = new List<Projet>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Projet
                        {
                            Id = r.GetInt32(0),
                            Nom = r.GetString(1),
                            Budget = r.GetDouble(2)
                        });
                    }
                }
            }
            return list;
        }

        public bool AjouterAffectation(Affectation aff)
        {
            const string sql = @"INSERT INTO Affectations (EmployeCin, ProjetId, Heures) VALUES (@EmployeCin, @ProjetId, @Heures)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeCin", aff.EmployeCin ?? "");
                cmd.Parameters.AddWithValue("@ProjetId", aff.ProjetId);
                cmd.Parameters.AddWithValue("@Heures", aff.Heures);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Affectation> ListerAffectations()
        {
            const string sql = @"SELECT Id, EmployeCin, ProjetId, Heures FROM Affectations";
            var list = new List<Affectation>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Affectation
                        {
                            Id = r.GetInt32(0),
                            EmployeCin = r.GetString(1),
                            ProjetId = r.GetInt32(2),
                            Heures = r.GetInt32(3)
                        });
                    }
                }
            }
            return list;
        }
    }
}
