using System;

namespace Common
{
    [Serializable]
    public class Departement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string ChefCin { get; set; } // Foreign key to Employe

        public override string ToString()
        {
            return $"{Nom} (Chef: {ChefCin})";
        }
    }
}
