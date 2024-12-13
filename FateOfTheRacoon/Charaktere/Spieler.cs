using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Spieler : Charakter
    {
        public int Level { get; set; }
        public int Erfahrungspunkte { get; set; }
        public Spieler()
        {
            Name = "Coonie";
            Leben = MaxLeben;
            Staerke = 20;
            Level = 1;
            Erfahrungspunkte = 0;
        }

        public int erforderlicheExp = 100;

        public void ErhoeheExp(int exp)
        {
            Erfahrungspunkte += exp;
            Console.WriteLine($"Du hast {exp} Erfahrungspunkte erhalten.");
            PruefeLvlUp();
        }
        
        public void PruefeLvlUp()
        {
            if (Erfahrungspunkte >= erforderlicheExp) LvlUp();
        }

        private void LvlUp()
        {
            Level++;
            Erfahrungspunkte -= 100;
            MaxLeben += 20;
            Staerke += 10;
            Console.WriteLine($"Du bist ein Level aufgestiegen!");
        }

        
    }
}
