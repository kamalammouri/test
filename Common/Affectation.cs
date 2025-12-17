using System;

namespace Common
{
    [Serializable]
    public class Affectation
    {
        public int Id { get; set; }
        public string EmployeCin { get; set; }
        public int ProjetId { get; set; }
        public int Heures { get; set; }

        public override string ToString()
        {
            return $"Emp: {EmployeCin}, Proj: {ProjetId}, Hrs: {Heures}";
        }
    }
}
