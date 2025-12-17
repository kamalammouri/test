using System;

namespace Common
{
    [Serializable]
    public class Projet
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Budget { get; set; }

        public override string ToString()
        {
            return $"{Nom} (Budget: {Budget:C})";
        }
    }
}
