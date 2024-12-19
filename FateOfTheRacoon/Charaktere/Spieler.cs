using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FateOfTheRacoon.Charaktere
{
    public class Spieler
    {
        public int Level = 1;
        public int Erfahrungspunkte = 0;
        public string Name = "Coonie";
        public int  Leben = 100;
        public int MaxLeben = 100;
        public int Staerke = 20;
            

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
            Leben = MaxLeben;
            Console.WriteLine($"Du bist ein Level aufgestiegen!");
        }
    }
}
